using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Apteryx.MongoDB.Driver.Extend.Entities;
using MongoDB.Driver;

namespace apteryx.mongodb.driver.extend.ExtensionMethods
{
    /// <summary>
    /// MongoDb扩展方法:查询(同步)
    /// </summary>
    public static partial class MongoDbExtensionMethod
    {
        #region 查询(同步)

        /// <summary>
        /// 查询单条
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static T FindOne<T>(this IMongoCollection<T> collection, FilterDefinition<T> filter)
            where T : BaseMongoEntity
        {
            return collection.Find(filter).FirstOrDefault();
        }

        /// <summary>
        /// 查询单条
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static T FindOne<T>(this IMongoCollection<T> collection, Expression<Func<T, bool>> filter)
            where T : BaseMongoEntity
        {
            return collection.Find(filter).FirstOrDefault();
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static IEnumerable<T> FindAll<T>(this IMongoCollection<T> collection)
        {
            return collection.Find(_ => true).ToEnumerable();
        }

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="filte"></param>
        /// <returns></returns>
        public static IEnumerable<T> Where<T>(this IMongoCollection<T> collection, FilterDefinition<T> filte)
        {
            return collection.Find(filte).ToEnumerable();
        }

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="filte"></param>
        /// <returns></returns>
        public static IEnumerable<T> Where<T>(this IMongoCollection<T> collection, Expression<Func<T, bool>> filte)
        {
            return collection.Find(filte).ToEnumerable();
        }

        /// <summary>
        /// 动态表查询单条
        /// </summary>
        /// <typeparam name="TForeign"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="foreignDocument"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static T DynamicTableFindOne<TForeign, T>(this IMongoCollection<T> collection, TForeign foreignDocument, FilterDefinition<T> filter)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return collection.Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").Find(filter).FirstOrDefault();
        }

        /// <summary>
        /// 动态表查询单条
        /// </summary>
        /// <typeparam name="TForeign"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="foreignDocument"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static T DynamicTableFindOne<TForeign, T>(this IMongoCollection<T> collection, TForeign foreignDocument, Expression<Func<T, bool>> filter)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return collection.Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").Find(filter).FirstOrDefault();
        }

        /// <summary>
        /// 动态表查询全部
        /// </summary>
        /// <typeparam name="TForeign"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="foreignDocument"></param>
        /// <returns></returns>
        public static IEnumerable<T> DynamicTableFindAll<TForeign, T>(this IMongoCollection<T> collection, TForeign foreignDocument)
        where TForeign : BaseMongoEntity
        where T : BaseMongoEntity
        {
            return collection.Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").Find(_ => true).ToEnumerable();
        }

        /// <summary>
        /// 动态表条件查询
        /// </summary>
        /// <typeparam name="TForeign"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="foreignDocument"></param>
        /// <returns></returns>
        public static IEnumerable<T> DynamicTableWhere<TForeign, T>(this IMongoCollection<T> collection, TForeign foreignDocument, FilterDefinition<T> filter)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return collection.Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").Find(filter).ToEnumerable();
        }

        /// <summary>
        /// 动态表条件查询
        /// </summary>
        /// <typeparam name="TForeign"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="foreignDocument"></param>
        /// <returns></returns>
        public static IEnumerable<T> DynamicTableWhere<TForeign, T>(this IMongoCollection<T> collection, TForeign foreignDocument, Expression<Func<T, bool>> filter)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return collection.Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").Find(filter).ToEnumerable();
        }

        #endregion
    }
}
