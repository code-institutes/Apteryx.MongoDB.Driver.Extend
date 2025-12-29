using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Apteryx.MongoDB.Driver.Extend;

public partial class DbSet<T> : IQueryable<T> where T : BaseMongoEntity
{
    private readonly IMongoCollection<T> _collection;
    private readonly IMongoDatabase _database;
    private readonly string _collectionName;

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

    public Type ElementType => typeof(T);

    public Expression Expression => _collection.AsQueryable().Expression;

    public IQueryProvider Provider => _collection.AsQueryable().Provider;

    public IEnumerator<T> GetEnumerator() => _collection.AsQueryable().GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
