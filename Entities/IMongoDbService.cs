using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Apteryx.MongoDB.Driver.Extend.Entities;
using MongoDB.Driver;

namespace Apteryx.MongoDB.Driver.Extend.Entities
{
    public interface IMongoDbService
    {
        void Add<T>(T obj) where T : BaseMongoEntity;
        void Add<T>(string tableName, T obj) where T : BaseMongoEntity;
        void DynamicTableAdd<T>(T obj) where T : BaseMongoEntity;
        Task AddAsync<T>(T obj) where T : BaseMongoEntity;
        Task AddAsync<T>(string tableName, T obj) where T : BaseMongoEntity;
        Task DynamicTableAddAsync<T>(T obj) where T : BaseMongoEntity;

        IEnumerable<T> FindAll<T>() where T : BaseMongoEntity;
        IEnumerable<T> FindAll<T>(string tableName) where T : BaseMongoEntity;
        IEnumerable<T> Where<T>(Expression<Func<T, bool>> filter) where T : BaseMongoEntity;
        T FindOne<T>(Expression<Func<T, bool>> filter) where T : BaseMongoEntity;
        T FindOne<T>(string tableName, Expression<Func<T, bool>> filter) where T : BaseMongoEntity;
        Task<IAsyncCursor<T>> FindAllAsync<T>() where T : BaseMongoEntity;
        Task<IAsyncCursor<T>> FindAsync<T>(string tableName) where T : BaseMongoEntity;
        Task<IAsyncCursor<T>> WhereAsync<T>(Expression<Func<T, bool>> filter) where T : BaseMongoEntity;
        Task<T> FindOneAsync<T>(Expression<Func<T, bool>> filter) where T : BaseMongoEntity;
        Task<T> FindOneAsync<T>(string tableName, Expression<Func<T, bool>> filter) where T : BaseMongoEntity;

        ReplaceOneResult Update<T>(FilterDefinition<T> filter, T obj) where T : BaseMongoEntity;
        Task<ReplaceOneResult> UpdateAsnyc<T>(FilterDefinition<T> filter, T obj) where T : BaseMongoEntity;
    }
}
