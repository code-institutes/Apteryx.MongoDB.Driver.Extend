using Apteryx.MongoDB.Driver.Extend.Entities;
using System.Threading.Tasks;

namespace Apteryx.MongoDB.Driver.Extend
{
    public abstract partial class MongoDbProvider
    {
        #region 同步方法
        public void Add<T>(T obj) where T : BaseMongoEntity
        {
            _database.GetCollection<T>(typeof(T).Name).InsertOne(obj);
        }
        public void Add<T>(string tableName, T obj) where T : BaseMongoEntity
        {
            _database.GetCollection<T>(tableName).InsertOne(obj);
        }
        /// <summary>
        /// 根据当前对象动态的创建该对象的数据表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        public void DynamicTableAdd<T>(T obj) where T : BaseMongoEntity
        {
            _database.GetCollection<T>(string.Format("{0}_{1}", typeof(T).Name,obj.Id)).InsertOne(obj);
        }
        #endregion

            #region 异步方法
        public Task AddAsync<T>(T obj) where T : BaseMongoEntity
        {
            return Task.Run(() => { _database.GetCollection<T>(typeof(T).Name).InsertOneAsync(obj); });
        }
        public Task AddAsync<T>(string tableName, T obj) where T : BaseMongoEntity
        {
            return Task.Run(() => { _database.GetCollection<T>(tableName).InsertOneAsync(obj); });
        }
        /// <summary>
        /// 根据当前对象动态的创建该对象的数据表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param> 
        /// <returns></returns>
        public Task DynamicTableAddAsync<T>(T obj) where T : BaseMongoEntity
        {
            return Task.Run(() => { _database.GetCollection<T>(string.Format("{0}_{1}", typeof(T).Name, obj.Id)).InsertOne(obj); });
        }
        #endregion
    }
}
