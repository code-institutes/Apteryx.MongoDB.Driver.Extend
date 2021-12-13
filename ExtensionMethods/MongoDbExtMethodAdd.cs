using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
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
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">插入操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        public static void Add<T>(this IMongoCollection<T> collection,
            T document,
            InsertOneOptions options = null,
            CancellationToken cancellationToken = default)
        {
            collection.InsertOne(document, options, cancellationToken);
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">插入操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        public static void Add<T>(this IMongoCollection<T> collection,
            IClientSessionHandle session,
            T document,
            InsertOneOptions options = null,
            CancellationToken cancellationToken = default)
        {
            collection.InsertOne(session, document, options, cancellationToken);
        }

        /// <summary>
        /// 插入多条
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="documents">文档对象</param>
        /// <param name="options">插入操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        public static void AddMany<T>(this IMongoCollection<T> collection,
            IEnumerable<T> documents,
            InsertManyOptions options = null,
            CancellationToken cancellationToken = default)
        {
            collection.InsertMany(documents, options, cancellationToken);
        }

        /// <summary>
        /// 插入多条
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="options">插入操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        public static void AddMany<T>(this IMongoCollection<T> collection,
            IClientSessionHandle session,
            IEnumerable<T> documents,
            InsertManyOptions options = null,
            CancellationToken cancellationToken = default)
        {
            collection.InsertMany(session, documents, options, cancellationToken);
        }

        #endregion
    }
}
