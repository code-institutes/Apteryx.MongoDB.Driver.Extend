using System.Collections.Generic;
using Apteryx.MongoDB.Driver.Extend.Entities;
using System.Threading.Tasks;

namespace Apteryx.MongoDB.Driver.Extend
{
    public abstract partial class MongoDbService
    {

        

        public void AddManyAsync<T>(IEnumerable<T> documents) where T : BaseMongoEntity
        {
            throw new System.NotImplementedException();
        }

        public void AddManyAsync<T>(string tableName, IEnumerable<T> documents) where T : BaseMongoEntity
        {
            throw new System.NotImplementedException();
        }
        #region 同步方法

        /// <summary>
        /// 插入单条
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="document"></param>
        public void Add<T>(T document) where T : BaseMongoEntity
        {
            _database.GetCollection<T>(typeof(T).Name).InsertOne(document);
        }

        /// <summary>
        /// 插入单条
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tableName">数据库表明</param>
        /// <param name="document"></param>
        public void Add<T>(string tableName, T document) where T : BaseMongoEntity
        {
            _database.GetCollection<T>(tableName).InsertOne(document);
        }

        /// <summary>
        /// 插入多条
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="documents"></param>
        public void AddMany<T>(IEnumerable<T> documents) where T : BaseMongoEntity
        {
            _database.GetCollection<T>(typeof(T).Name).InsertMany(documents);
        }

        /// <summary>
        /// 插入多条
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tableName">数据库表名</param>
        /// <param name="documents"></param>
        public void AddMany<T>(string tableName, IEnumerable<T> documents) where T : BaseMongoEntity
        {
            _database.GetCollection<T>(tableName).InsertMany(documents);
        }

        /// <summary>
        /// 根据关联对象动态的创建与关联对象相关的数据表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="foreignObj">上级对象</param>
        /// <param name="document"></param>
        public void DynamicTableAdd<T>(T foreignObj, T document) where T : BaseMongoEntity
        {
            _database.GetCollection<T>($"{typeof(T).Name}_{foreignObj.Id}").InsertOne(document);
        }

        #endregion


        #region 异步方法

        /// <summary>
        /// 插入单条
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="document"></param>
        /// <returns></returns>
        public Task AddAsync<T>(T document) where T : BaseMongoEntity
        {
            return _database.GetCollection<T>(typeof(T).Name).InsertOneAsync(document);
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
            return _database.GetCollection<T>(tableName).InsertOneAsync(document);
        }

        /// <summary>
        /// 根据关联对象动态的创建与关联对象相关的数据表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="foreignObj">上级对象</param>
        /// <param name="document"></param>
        /// <returns></returns>
        public Task DynamicTableAddAsync<T>(T foreignObj, T document) where T : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{typeof(T).Name}_{foreignObj.Id}").InsertOneAsync(document);
        }

        #endregion
    }
}
