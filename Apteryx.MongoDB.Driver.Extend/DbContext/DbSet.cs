using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Apteryx.MongoDB.Driver.Extend;

public partial class DbSet<T> : IQueryable<T>, IDbSetProvider<T> where T : BaseMongoEntity
{
    private readonly IMongoCollection<T> _collection;
    private readonly IMongoDatabase _database;
    private readonly string _collectionName;
    public DbSet(IMongoDatabase database, string collectionName)
    {
        _database = database;
        _collectionName = collectionName;
        _collection = database.GetCollection<T>(collectionName);
    }

    public IMongoCollection<T> AsMongoCollection => _collection;

    public IMongoDatabase DataBase { get { return _database; } }

    public Type ElementType => typeof(T);

    public Expression Expression => _collection.AsQueryable().Expression;

    public IQueryProvider Provider => _collection.AsQueryable().Provider;

    public IEnumerator<T> GetEnumerator() => _collection.AsQueryable().GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
