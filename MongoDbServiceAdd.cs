using System.Collections.Generic;
using Apteryx.MongoDB.Driver.Extend.Entities;

namespace Apteryx.MongoDB.Driver.Extend
{
    public abstract partial class MongoDbService
    {
        #region 同步方法

        /// <summary>
        /// 插入单条
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="document"></param>
        public void Add<T>(T document) where T : BaseMongoEntity
        {
            database.GetCollection<T>(typeof(T).Name).InsertOne(document);
        }

        /// <summary>
        /// 插入多条
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="documents"></param>
        public void AddMany<T>(IEnumerable<T> documents) where T : BaseMongoEntity
        {
            database.GetCollection<T>(typeof(T).Name).InsertMany(documents);
        }

        /// <summary>
        /// 根据关联对象动态的创建与关联对象相关的数据表
        /// </summary>
        /// <typeparam name="TForeign"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="foreignDocument">上级对象</param>
        /// <param name="document"></param>
        public void DynamicCollectionAdd<TForeign, T>(TForeign foreignDocument, T document)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").InsertOne(document);
        }

        /// <summary>
        /// 根据关联对象动态的创建与关联对象相关的数据表
        /// </summary>
        /// <typeparam name="TForeign"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="foreignDocument">上级对象</param>
        /// <param name="documents"></param>
        public void DynamicCollectionAddMany<TForeign, T>(TForeign foreignDocument, IEnumerable<T> documents)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").InsertMany(documents);
        }

        #endregion
    }
}
