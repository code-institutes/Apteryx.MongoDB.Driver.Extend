using MongoDB.Driver;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Apteryx.MongoDB.Driver.Extend
{
    public abstract partial class MongoDbProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="filter">过滤器</param>
        /// <param name="options">设置</param>
        /// <param name="cancellationToken">标记</param>
        /// <returns></returns>
        public Task<long> CountDocumentsAsync<T>(FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity
        {
            return Task.Run(()=> CountDocuments(filter,options,cancellationToken));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">客户端会话句柄</param>
        /// <param name="filter">过滤器</param>
        /// <param name="options">设置</param>
        /// <param name="cancellationToken">标记</param>
        /// <returns></returns>
        public Task<long> CountDocumentsAsync<T>(IClientSessionHandle session, FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity
        {
            return Task.Run(() => CountDocuments(session, filter, options, cancellationToken));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collectionName">集合名称</param>
        /// <param name="filter">过滤器</param>
        /// <param name="options">设置</param>
        /// <param name="cancellationToken">标记</param>
        /// <returns></returns>
        public Task<long> CountDocumentsAsync<T>(string collectionName, FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity
        {
            return Task.Run(() => CountDocuments(collectionName, filter, options, cancellationToken));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collectionName">集合名称</param>
        /// <param name="session">客户端会话句柄</param>
        /// <param name="filter">过滤器</param>
        /// <param name="options">设置</param>
        /// <param name="cancellationToken">标记</param>
        /// <returns></returns>
        public Task<long> CountDocumentsAsync<T>(string collectionName, IClientSessionHandle session, FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity
        {
            return Task.Run(() => CountDocuments(collectionName,session, filter, options, cancellationToken));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collectionName">集合名称</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="options">设置</param>
        /// <param name="cancellationToken">标记</param>
        /// <returns></returns>
        public Task<long> CountDocumentsAsync<T>(string collectionName, Expression<Func<T, bool>> filter, CountOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity
        {
            return Task.Run(() => CountDocuments(collectionName, filter, options, cancellationToken));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collectionName">集合名称</param>
        /// <param name="session">客户端会话句柄</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="options">设置</param>
        /// <param name="cancellationToken">标记</param>
        /// <returns></returns>
        public Task<long> CountDocumentsAsync<T>(string collectionName, IClientSessionHandle session, Expression<Func<T, bool>> filter, CountOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity
        {
            return Task.Run(() => CountDocuments(collectionName, session, filter, options, cancellationToken));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <param name="options">设置</param>
        /// <param name="cancellationToken">标记</param>
        /// <returns></returns>
        public Task<long> DynamicCollectionCountDocumentsAsync<TForeign, T>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            CountOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return Task.Run(() => DynamicCollectionCountDocuments(foreignDocument, filter, options, cancellationToken));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="session">客户端会话句柄</param>
        /// <param name="filter">过滤器</param>
        /// <param name="options">设置</param>
        /// <param name="cancellationToken">标记</param>
        /// <returns></returns>
        public Task<long> DynamicCollectionCountDocumentsAsync<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            CountOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return Task.Run(() => DynamicCollectionCountDocuments(session, foreignDocument, filter, options, cancellationToken));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="options">设置</param>
        /// <param name="cancellationToken">标记</param>
        /// <returns></returns>
        public Task<long> DynamicCollectionCountDocumentsAsync<TForeign, T>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            CountOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return Task.Run(() => DynamicCollectionCountDocuments(foreignDocument, filter, options, cancellationToken));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="session">客户端会话句柄</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="options">设置</param>
        /// <param name="cancellationToken">标记</param>
        /// <returns></returns>
        public Task<long> DynamicCollectionCountDocumentsAsync<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            CountOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return Task.Run(() => DynamicCollectionCountDocuments(session, foreignDocument, filter, options, cancellationToken));
        }
    }
}
