using MongoDB.Driver;
using System;
using System.Linq.Expressions;
using System.Threading;

namespace Apteryx.MongoDB.Driver.Extend
{
    public partial class DbSet<T>
    {
        #region 计数（同步）

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter">过滤器</param>
        /// <param name="options">设置</param>
        /// <param name="cancellationToken">标记</param>
        /// <returns></returns>
        public long CountDocuments(FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default)
        {
            return _collection.CountDocuments(filter, options, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>
        /// <param name="options">设置</param>
        /// <param name="cancellationToken">标记</param>
        /// <returns></returns>
        public long CountDocuments(IClientSessionHandle session, FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default)
        {
            return _collection.CountDocuments(session, filter, options, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <param name="filter">过滤器</param>
        /// <param name="options">设置</param>
        /// <param name="cancellationToken">标记</param>
        /// <returns></returns>
        public long CountDocuments(string collectionName, FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default)
        {
            return _collection.CountDocuments(filter, options, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>
        /// <param name="options">设置</param>
        /// <param name="cancellationToken">标记</param>
        /// <returns></returns>
        public long CountDocuments(string collectionName, IClientSessionHandle session, FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default)
        {
            return _collection.CountDocuments(session, filter, options, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <param name="filter">过滤器</param>
        /// <param name="options">设置</param>
        /// <param name="cancellationToken">标记</param>
        /// <returns></returns>
        public long CountDocuments(string collectionName, Expression<Func<T, bool>> filter, CountOptions options = null, CancellationToken cancellationToken = default)
        {
            return _collection.CountDocuments(filter, options, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>
        /// <param name="options">设置</param>
        /// <param name="cancellationToken">标记</param>
        /// <returns></returns>
        public long CountDocuments(string collectionName, IClientSessionHandle session, Expression<Func<T, bool>> filter, CountOptions options = null, CancellationToken cancellationToken = default)
        {
            return _collection.CountDocuments(session, filter, options, cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <param name="options">设置</param>
        /// <param name="cancellationToken">标记</param>
        /// <returns></returns>
        public long DynamicCollectionCountDocuments<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            CountOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}").CountDocuments(filter, options, cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <param name="options">设置</param>
        /// <param name="cancellationToken">标记</param>
        /// <returns></returns>
        public long DynamicCollectionCountDocuments<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            CountOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}").CountDocuments(session, filter, options, cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <param name="options">设置</param>
        /// <param name="cancellationToken">标记</param>
        /// <returns></returns>
        public long DynamicCollectionCountDocuments<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            CountOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}").CountDocuments(filter, options, cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="session">客户端会话句柄</param>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <param name="options">设置</param>
        /// <param name="cancellationToken">标记</param>
        /// <returns></returns>
        public long DynamicCollectionCountDocuments<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            CountOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}").CountDocuments(session, filter, options, cancellationToken);
        }

        #endregion
    }
}
