using System;
using System.Collections.Generic;
using System.Text;
using Apteryx.MongoDB.Driver.Extend.Entities;
using MongoDB.Driver;

namespace Apteryx.MongoDB.Driver.Extend.ExtensionMethods
{
    /// <summary>
    /// MongoDb扩展方法:插入(同步)
    /// </summary>
    public static partial class MongoDbExtensionMethod
    {
        #region 插入(同步)

        /// <summary>
        /// 插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="document"></param>
        public static void Add<T>(this IMongoCollection<T> collection, T document)
        {
            collection.InsertOne(document);
        }

        /// <summary>
        /// 插入多条
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="documents"></param>
        public static void AddMany<T>(this IMongoCollection<T> collection, IEnumerable<T> documents)
        {
            collection.InsertMany(documents);
        }

        /// <summary>
        /// 动态表插入单条
        /// </summary>
        /// <typeparam name="TForeign"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="foreignDocument">上级对象</param>
        /// <param name="document"></param>
        public static void DynamicTableAdd<TForeign, T>(this IMongoCollection<T> collection, TForeign foreignDocument,
            T document)
            where T : BaseMongoEntity
            where TForeign : BaseMongoEntity
        {
            collection.Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").InsertOne(document);
        }

        /// <summary>
        /// 动态表插入多条
        /// </summary>
        /// <typeparam name="TForeign"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="foreignDocument">上级对象</param>
        /// <param name="documents"></param>
        public static void DynamicTableAddMany<TForeign, T>(this IMongoCollection<T> collection, TForeign foreignDocument,
            IEnumerable<T> documents)
            where T : BaseMongoEntity
            where TForeign : BaseMongoEntity
        {
            collection.Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").InsertMany(documents);
        }

        #endregion
    }
}
