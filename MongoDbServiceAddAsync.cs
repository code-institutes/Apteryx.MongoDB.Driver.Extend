using System.Collections.Generic;
using System.Threading.Tasks;
using Apteryx.MongoDB.Driver.Extend.Entities;

namespace Apteryx.MongoDB.Driver.Extend
{
    public abstract partial class MongoDbService
    {
        #region 异步方法

        /// <summary>
        /// 插入单条
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="document"></param>
        /// <returns></returns>
        public Task AddAsync<T>(T document) where T : BaseMongoEntity
        {
            return database.GetCollection<T>(typeof(T).Name).InsertOneAsync(document);
        }

        /// <summary>
        /// 插入单条
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tableName">数据库表明</param>
        /// <param name="document"></param>
        /// <returns></returns>
        public Task AddAsync<T>(string tableName, T document) where T : BaseMongoEntity
        {
            return database.GetCollection<T>(tableName).InsertOneAsync(document);
        }

        /// <summary>
        /// 插入多条
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="documents"></param>
        public void AddManyAsync<T>(IEnumerable<T> documents) where T : BaseMongoEntity
        {
            database.GetCollection<T>(typeof(T).Name).InsertManyAsync(documents);
        }

        public void AddManyAsync<T>(string tableName, IEnumerable<T> documents) where T : BaseMongoEntity
        {
            database.GetCollection<T>(tableName).InsertManyAsync(documents);
        }

        /// <summary>
        /// 根据关联对象动态的创建与关联对象相关的数据表
        /// </summary>
        /// <typeparam name="TForeign"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="foreignDocument">上级对象</param>
        /// <param name="document"></param>
        /// <returns></returns>
        public Task DynamicTableAddAsync<TForeign, T>(T foreignDocument, T document)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").InsertOneAsync(document);
        }

        /// <summary>
        /// 根据关联对象动态的创建与关联对象相关的数据表
        /// </summary>
        /// <typeparam name="TForeign"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="foreignDocument">上级对象</param>
        /// <param name="documents"></param>
        /// <returns></returns>
        public Task DynamicTableAddManyAsync<TForeign, T>(T foreignDocument, IEnumerable<T> documents)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").InsertManyAsync(documents);
        }

        #endregion
    }
}
