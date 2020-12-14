using System.Collections.Generic;
using System.Threading.Tasks;
using Apteryx.MongoDB.Driver.Extend.Entities;
using MongoDB.Driver;

namespace Apteryx.MongoDB.Driver.Extend.ExtensionMethods
{
    /// <summary>
    /// MongoDb扩展方法:插入(异步)
    /// </summary>
    public static partial class MongoDbExtensionMethod
    {
        #region 插入(异步)

        /// <summary>
        /// 插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="document"></param>
        /// <returns></returns>
        public static Task AddAsync<T>(this IMongoCollection<T> collection, T document)
        where T:BaseMongoEntity
        {
            return Task.Run(() => Add(collection,document));
        }

        /// <summary>
        /// 插入多条
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="documents"></param>
        public static Task AddManyAsync<T>(this IMongoCollection<T> collection, IEnumerable<T> documents)
            where T : BaseMongoEntity
        {
            return Task.Run(() => AddMany(collection, documents));
        }

        /// <summary>
        /// 动态表插入单条
        /// </summary>
        /// <typeparam name="TForeign"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="foreignDocument">上级对象</param>
        /// <param name="document"></param>
        public static Task DynamicTableAddAsync<TForeign, T>(this IMongoCollection<T> collection,
            TForeign foreignDocument, T document)
            where T : BaseMongoEntity
            where TForeign : BaseMongoEntity
        {
            return Task.Run(() => DynamicTableAdd(collection,foreignDocument, document));
        }

        /// <summary>
        /// 动态表插入多条
        /// </summary>
        /// <typeparam name="TForeign"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="foreignDocument">上级对象</param>
        /// <param name="documents"></param>
        public static Task DynamicTableAddManyAsync<TForeign, T>(this IMongoCollection<T> collection,
            TForeign foreignDocument, IEnumerable<T> documents)
            where T : BaseMongoEntity
            where TForeign : BaseMongoEntity
        {
            return Task.Run(() => DynamicTableAddMany(collection, foreignDocument, documents));
        }

        #endregion
    }
}
