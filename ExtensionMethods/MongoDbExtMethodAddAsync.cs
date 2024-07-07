using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Apteryx.MongoDB.Driver.Extend
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
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">插入操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        public static Task AddAsync<T>(
            this IMongoCollection<T> collection,
            T document,
            InsertOneOptions options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            return Task.Run(() => Add(collection, document, options, cancellationToken));
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
        public static Task AddAsync<T>(
            this IMongoCollection<T> collection,
            IClientSessionHandle session,
            T document,
            InsertOneOptions options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            return Task.Run(() => Add(collection, session, document, options, cancellationToken));
        }

        /// <summary>
        /// 插入（批量）
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="documents">文档对象</param>
        /// <param name="options">插入操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        public static Task AddManyAsync<T>(
            this IMongoCollection<T> collection,
            IEnumerable<T> documents,
            InsertManyOptions options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            return Task.Run(() => AddMany(collection, documents, options, cancellationToken));
        }

        /// <summary>
        /// 插入（批量）
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="options">插入操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        public static Task AddManyAsync<T>(
            this IMongoCollection<T> collection,
            IEnumerable<T> documents,
            IClientSessionHandle session,
            InsertManyOptions options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            return Task.Run(() => AddMany(collection, session, documents, options, cancellationToken));
        }

        #endregion
    }
}
