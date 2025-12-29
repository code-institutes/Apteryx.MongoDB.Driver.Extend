using Apteryx.Mongodb.Driver.Extend;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Apteryx.MongoDB.Driver.Extend;

public partial class DbSet<T> : IDbSet<T> where T : BaseMongoEntity
{
    private readonly IMongoCollection<T> _collection;
    private readonly IMongoDatabase _database;
    private readonly string _collectionName;
    bool IDbSet.HasChanges => HasChanges;

    /// <summary>
    /// ChangeTracker：使用字典，Key 为实体引用
    /// </summary>
    private readonly Dictionary<T, TrackedEntity<T>> _changeTracker = new();
    /// <summary>
    /// 获取底层MongoDB集合，以便直接访问原生驱动操作。
    /// </summary>
    public IMongoCollection<T> AsMongoCollection => _collection;
    /// <summary>
    ///  获取底层MongoDB集合，以便直接访问原生驱动操作。
    /// </summary>
    public IMongoCollection<T> Native => _collection;
    /// <summary>
    /// 获取用于在当前线程上立即调度任务执行的执行器。
    /// </summary>
    public ImmediateExecutor<T> Immediate { get; }
    public DbSet(IMongoDatabase database, string collectionName)
    {
        _database = database;
        _collectionName = collectionName;
        _collection = database.GetCollection<T>(collectionName);
        Immediate = new ImmediateExecutor<T>(database, _collection);
    }


    public IMongoDatabase DataBase { get { return _database; } }

    #region IQueryable<T> 成员
    public Type ElementType => typeof(T);
    public Expression Expression => _collection.AsQueryable().Expression;
    public IQueryProvider Provider => _collection.AsQueryable().Provider;
    public IEnumerator<T> GetEnumerator() => _collection.AsQueryable().GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    #endregion

    int IDbSet.CommitCommands(IClientSessionHandle session, CancellationToken ct) => CommitCommands(session, ct);
    Task<int> IDbSet.CommitCommandsAsync(IClientSessionHandle session, CancellationToken ct) => CommitCommandsAsync(session, ct);

    #region ChangeTracker相关
    public void Add(T entity)
    {
        Track(entity, EntityState.Added);
    }

    public void Update(T entity)
    {
        Track(entity, EntityState.Modified);
    }

    public void Remove(T entity)
    {
        Track(entity, EntityState.Deleted);
    }

    private void Track(T entity, EntityState incoming)
    {
        if (_changeTracker.TryGetValue(entity, out var tracked))
        {
            tracked.State = Resolve(tracked.State, incoming);
        }
        else
        {
            _changeTracker[entity] = new TrackedEntity<T>(entity, incoming);
        }
    }

    private EntityState Resolve(EntityState current, EntityState incoming)
    {
        switch (current)
        {
            case EntityState.Detached:
                // 对游离实体，直接采用调用方的意图
                return incoming;

            case EntityState.Unchanged:
                return incoming switch
                {
                    EntityState.Added => EntityState.Added,
                    EntityState.Modified => EntityState.Modified,
                    EntityState.Deleted => EntityState.Deleted,
                    _ => current
                };

            case EntityState.Added:
                return incoming switch
                {
                    EntityState.Deleted => EntityState.Detached, // EF Core：Add + Remove → Detached
                    EntityState.Modified => EntityState.Added,    // 仍视为新实体
                    EntityState.Added => EntityState.Added,
                    _ => current
                };

            case EntityState.Modified:
                return incoming switch
                {
                    EntityState.Deleted => EntityState.Deleted,
                    EntityState.Added => EntityState.Modified, // Add 被忽略
                    EntityState.Modified => EntityState.Modified,
                    _ => current
                };

            case EntityState.Deleted:
                return incoming switch
                {
                    EntityState.Added => EntityState.Added,    // 相当于“重新加入”
                    EntityState.Modified => EntityState.Modified, // 认为你要重新修改
                    EntityState.Deleted => EntityState.Deleted,
                    _ => current
                };

            default:
                return current;
        }
    }


    internal bool HasChanges => _changeTracker.Count > 0;

    #endregion

    #region SaveChanges（同步）
    internal int CommitCommands(IClientSessionHandle session, CancellationToken cancellationToken = default)
    {
        int count = 0;

        foreach (var kvp in _changeTracker)
        {
            var tracked = kvp.Value;
            var entity = tracked.Entity;

            switch (tracked.State)
            {
                case EntityState.Added:
                    InsertInternal(session, entity, cancellationToken);
                    count++;
                    break;

                case EntityState.Modified:
                    ReplaceInternal(session, entity, cancellationToken);
                    count++;
                    break;

                case EntityState.Deleted:
                    DeleteInternal(session, entity, cancellationToken);
                    count++;
                    break;

                case EntityState.Detached:
                    // EF Core 行为：Detached 不执行任何数据库操作
                    break;

                case EntityState.Unchanged:
                    // 不执行任何操作
                    break;
            }
        }

        _changeTracker.Clear();
        return count;
    }

    #endregion

    #region SaveChanges（异步）
    internal async Task<int> CommitCommandsAsync(IClientSessionHandle session, CancellationToken cancellationToken = default)
    {
        int count = 0;

        foreach (var kvp in _changeTracker)
        {
            var tracked = kvp.Value;
            var entity = tracked.Entity;

            switch (tracked.State)
            {
                case EntityState.Added:
                    await InsertInternalAsync(session, entity, cancellationToken);
                    count++;
                    break;

                case EntityState.Modified:
                    await ReplaceInternalAsync(session, entity, cancellationToken);
                    count++;
                    break;

                case EntityState.Deleted:
                    await DeleteInternalAsync(session, entity, cancellationToken);
                    count++;
                    break;

                case EntityState.Detached:
                    // EF Core 行为：Detached 不执行任何数据库操作
                    break;

                case EntityState.Unchanged:
                    // 不执行任何操作
                    break;
            }
        }

        _changeTracker.Clear();
        return count;
    }

    #endregion

    #region Mongo 操作（同步/异步 + 可选 session）
    private void InsertInternal(IClientSessionHandle session, T entity, CancellationToken ct)
    {
        if (session == null)
            _collection.InsertOne(entity, cancellationToken: ct);
        else
            _collection.InsertOne(session, entity, cancellationToken: ct);
    }

    private async Task InsertInternalAsync(IClientSessionHandle session, T entity, CancellationToken ct)
    {
        if (session == null)
            await _collection.InsertOneAsync(entity, cancellationToken: ct);
        else
            await _collection.InsertOneAsync(session, entity, cancellationToken: ct);
    }

    private void ReplaceInternal(IClientSessionHandle session, T entity, CancellationToken ct)
    {
        Expression<Func<T, bool>> filter = (e) => e.Id == entity.Id;

        if (session == null)
            _collection.ReplaceOne(filter, entity, cancellationToken: ct);
        else
            _collection.ReplaceOne(session, filter, entity, cancellationToken: ct);
    }

    private async Task ReplaceInternalAsync(IClientSessionHandle session, T entity, CancellationToken ct)
    {
        Expression<Func<T, bool>> filter = (e) => e.Id == entity.Id;

        if (session == null)
            await _collection.ReplaceOneAsync(filter, entity, cancellationToken: ct);
        else
            await _collection.ReplaceOneAsync(session, filter, entity, cancellationToken: ct);
    }

    private void DeleteInternal(IClientSessionHandle session, T entity, CancellationToken ct)
    {
        Expression<Func<T, bool>> filter = (e) => e.Id == entity.Id;

        if (session == null)
            _collection.DeleteOne(filter, ct);
        else
            _collection.DeleteOne(session, filter, cancellationToken: ct);
    }

    private async Task DeleteInternalAsync(IClientSessionHandle session, T entity, CancellationToken ct)
    {
        Expression<Func<T, bool>> filter = (e) => e.Id == entity.Id;

        if (session == null)
            await _collection.DeleteOneAsync(filter, ct);
        else
            await _collection.DeleteOneAsync(session, filter, cancellationToken: ct);
    }
    #endregion
}
