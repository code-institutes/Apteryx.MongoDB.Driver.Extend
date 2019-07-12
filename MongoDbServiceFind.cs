using Apteryx.MongoDB.Driver.Extend.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Apteryx.MongoDB.Driver.Extend
{
    public abstract partial class MongoDbService
    {
        #region 同步方法
        public IEnumerable<T> FindAll<T>() where T : BaseMongoEntity
        {
            return _database.GetCollection<T>(typeof(T).Name).Find(_ => true).ToEnumerable();
        }
        public IEnumerable<T> FindAll<T>(string tableName) where T : BaseMongoEntity
        {
            return _database.GetCollection<T>(tableName).Find(_ => true).ToEnumerable();
        }
        public IEnumerable<T> Where<T>(Expression<Func<T, bool>> filter) where T : BaseMongoEntity
        {
            return _database.GetCollection<T>(typeof(T).Name).Find(filter).ToEnumerable();
        }
        public T FindOne<T>(Expression<Func<T, bool>> filter) where T : BaseMongoEntity
        {
            return _database.GetCollection<T>(typeof(T).Name).Find(filter).FirstOrDefault();
        }
        public T FindOne<T>(string tableName, Expression<Func<T, bool>> filter) where T : BaseMongoEntity
        {
            return _database.GetCollection<T>(tableName).Find(filter).FirstOrDefault();
        }
        #endregion

        #region 异步方法
        public Task<IAsyncCursor<T>> FindAllAsync<T>() where T : BaseMongoEntity
        {
            return _database.GetCollection<T>(typeof(T).Name).FindAsync(_ => true);
        }
        public Task<IAsyncCursor<T>> FindAsync<T>(string tableName) where T : BaseMongoEntity
        {
            return _database.GetCollection<T>(tableName).FindAsync(_ => true);
        }
        public Task<IAsyncCursor<T>> WhereAsync<T>(Expression<Func<T, bool>> filter) where T : BaseMongoEntity
        {
            return _database.GetCollection<T>(typeof(T).Name).FindAsync(filter);
        }
        public Task<T> FindOneAsync<T>(Expression<Func<T, bool>> filter) where T : BaseMongoEntity
        {
            return _database.GetCollection<T>(typeof(T).Name).Find(filter).FirstOrDefaultAsync();
        }
        public Task<T> FindOneAsync<T>(string tableName, Expression<Func<T, bool>> filter) where T : BaseMongoEntity
        {
            return _database.GetCollection<T>(tableName).Find(filter).FirstOrDefaultAsync();
        }
        #endregion
    }
}
