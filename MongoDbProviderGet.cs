using Apteryx.MongoDB.Driver.Extend.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Apteryx.MongoDB.Driver.Extend.ExtensionMethods;
using System.Threading.Tasks;

namespace Apteryx.MongoDB.Driver.Extend
{
    public abstract partial class MongoDbProvider
    {
        #region 同步方法
        public IEnumerable<T> Get<T>() where T : BaseMongoEntity
        {
            return _database.GetCollection<T>(typeof(T).Name).Find(_ => true).ToList();
        }
        public IEnumerable<T> Get<T>(string tableName) where T : BaseMongoEntity
        {
            return _database.GetCollection<T>(tableName).Find(_ => true).ToList();
        }
        public IEnumerable<T> Get<T>(Expression<Func<T, bool>> filter) where T : BaseMongoEntity
        {
            return _database.GetCollection<T>(typeof(T).Name).Find(filter).ToList();
        }
        public T GetOne<T>(Expression<Func<T, bool>> filter) where T : BaseMongoEntity
        {
            return _database.GetCollection<T>(typeof(T).Name).FindOne(filter);
        }
        public T GetOne<T>(string tableName, Expression<Func<T, bool>> filter) where T : BaseMongoEntity
        {
            return _database.GetCollection<T>(tableName).FindOne(filter);
        }
        #endregion

        #region 异步方法
        public Task<List<T>> GetAsync<T>() where T : BaseMongoEntity
        {
            return Task.Run(async () => { return await (await _database.GetCollection<T>(typeof(T).Name).FindAsync(_ => true)).ToListAsync(); });
        }
        public Task<List<T>> GetAsync<T>(string tableName) where T : BaseMongoEntity
        {
            return Task.Run(async () =>
            {
                return await (await _database.GetCollection<T>(tableName).FindAsync(_ => true)).ToListAsync();
            });
        }
        public Task<List<T>> GetAsync<T>(Expression<Func<T, bool>> filter) where T : BaseMongoEntity
        {
            return Task.Run(async () => { return await (await _database.GetCollection<T>(typeof(T).Name).FindAsync(filter)).ToListAsync(); });
        }
        public Task<T> GetOneAsync<T>(Expression<Func<T, bool>> filter) where T : BaseMongoEntity
        {
            return Task.Run(() =>
            {
                return _database.GetCollection<T>(typeof(T).Name).FindOneAsync(filter);
            });
        }
        public Task<T> GetOneAsync<T>(string tableName, Expression<Func<T, bool>> filter) where T : BaseMongoEntity
        {
            return Task.Run(() =>
            {
                return _database.GetCollection<T>(tableName).FindOneAsync(filter);
            });
        }
        #endregion
    }
}
