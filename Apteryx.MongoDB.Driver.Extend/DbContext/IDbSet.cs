using Apteryx.Mongodb.Driver.Extend;
using Apteryx.MongoDB.Driver.Extend;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Apteryx.MongoDB.Driver.Extend;

public interface IDbSet
{
    bool HasChanges { get; }
    int SaveChanges(IClientSessionHandle session, CancellationToken ct);
    Task<int> SaveChangesAsync(IClientSessionHandle session, CancellationToken ct);


    public IMongoDatabase DataBase { get; }
}

public interface IDbSet<T> : IDbSet, IQueryable<T> where T : BaseMongoEntity
{
    /// <summary>
    /// 获取用于在当前线程上立即调度任务执行的执行器。
    /// </summary>
    public ImmediateExecutor<T> Immediate { get; }
    /// <summary>
    /// 获取底层MongoDB集合，以便直接访问原生驱动操作。
    /// </summary>
    IMongoCollection<T> AsMongoCollection { get; }
    /// <summary>
    ///  获取底层MongoDB集合，以便直接访问原生驱动操作。
    /// </summary>
    public IMongoCollection<T> Native { get; }

    #region ChangeTracker相关
    void Add(T entity);

    void Update(T entity);

    void Remove(T entity);
    #endregion
}