using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Apteryx.MongoDB.Driver.Extend.Entities;
using MongoDB.Driver;

namespace apteryx.mongodb.driver.extend.ExtensionMethods
{
    /// <summary>
    /// MongoDb扩展方法:查询(异步)
    /// </summary>
    public static partial class MongoDbExtensionMethod
    {
        #region 查询(异步)

        /// <summary>
        /// 查询单条
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static Task<T> FindOneAsync<T>(this IMongoCollection<T> collection, Expression<Func<T, bool>> filter)
        {
            return (collection.Find(filter)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static Task<IEnumerable<T>> FindAllAsync<T>(this IMongoCollection<T> collection)
        {
            return Task.Run(() => FindAll(collection));
        }

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static Task<IEnumerable<T>> WhereAsync<T>(this IMongoCollection<T> collection,
            Expression<Func<T, bool>> filter)
        {
            return Task.Run(() => Where(collection, filter));
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
        public static Task<T> DynamicTableFindOneAsync<TForeign, T>(this IMongoCollection<T> collection, TForeign foreignDocument, Expression<Func<T, bool>> filter)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return collection.Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").FindAsync(filter).Result.FirstOrDefaultAsync();
        }

        /// <summary>
        /// 动态表查询全部
        /// </summary>
        /// <typeparam name="TForeign"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="foreignDocument"></param>
        /// <returns></returns>
        public static Task<IEnumerable<T>> DynamicTableFindAllAsync<TForeign, T>(this IMongoCollection<T> collection, TForeign foreignDocument)
        where TForeign : BaseMongoEntity
        where T : BaseMongoEntity
        {
            return Task.Run(() => DynamicTableFindAll(collection, foreignDocument));
        }

        /// <summary>
        /// 动态表条件查询
        /// </summary>
        /// <typeparam name="TForeign"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="foreignDocument"></param>
        /// <returns></returns>
        public static Task<IEnumerable<T>> DynamicTableWhereAsync<TForeign, T>(this IMongoCollection<T> collection, TForeign foreignDocument, Expression<Func<T, bool>> filter)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return Task.Run(() => DynamicTableWhere(collection, foreignDocument, filter));
        }

        #endregion
    }
}
