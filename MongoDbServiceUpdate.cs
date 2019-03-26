using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Apteryx.MongoDB.Driver.Extend.Entities;

namespace Apteryx.MongoDB.Driver.Extend
{
    public abstract partial class MongoDbService
    {
        #region 同步方法
        public ReplaceOneResult Update<T>(FilterDefinition<T> filter,T obj) where T:BaseMongoEntity
        {
            return _database.GetCollection<T>(typeof(T).Name).ReplaceOne(filter,obj);
        }
        #endregion

        #region 同步方法
        public Task<ReplaceOneResult> UpdateAsnyc<T>(FilterDefinition<T> filter, T obj) where T:BaseMongoEntity
        {
            return _database.GetCollection<T>(typeof(T).Name).ReplaceOneAsync(filter, obj);
        }
        #endregion
    }
}
