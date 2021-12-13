using Apteryx.MongoDB.Driver.Extend.Entities;
using MongoDB.Driver;
using System;
using System.Linq.Expressions;
using System.Threading;

namespace Apteryx.MongoDB.Driver.Extend
{
    public abstract partial class MongoDbService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="filter">过滤器</param>
        /// <param name="options">设置</param>
        /// <param name="cancellationToken">标记</param>
        /// <returns></returns>
        public long CountDocuments<T>(FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity
        {
            return database.GetCollection<T>(typeof(T).Name).CountDocuments(filter, options, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>
        /// <param name="options">设置</param>
        /// <param name="cancellationToken">标记</param>
        /// <returns></returns>
        public long CountDocuments<T>(IClientSessionHandle session, FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity
        {
            return database.GetCollection<T>(typeof(T).Name).CountDocuments(session, filter, options, cancellationToken);
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
        public long CountDocuments<T>(string collectionName, FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity
        {
            return database.GetCollection<T>(collectionName).CountDocuments(filter, options, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collectionName">集合名称</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>
        /// <param name="options">设置</param>
        /// <param name="cancellationToken">标记</param>
        /// <returns></returns>
        public long CountDocuments<T>(string collectionName, IClientSessionHandle session, FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity
        {
            return database.GetCollection<T>(collectionName).CountDocuments(session, filter, options, cancellationToken);
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
        public long CountDocuments<T>(string collectionName, Expression<Func<T, bool>> filter, CountOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity
        {
            return database.GetCollection<T>(collectionName).CountDocuments(filter, options, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collectionName">集合名称</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>
        /// <param name="options">设置</param>
        /// <param name="cancellationToken">标记</param>
        /// <returns></returns>
        public long CountDocuments<T>(string collectionName, IClientSessionHandle session, Expression<Func<T, bool>> filter, CountOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity
        {
            return database.GetCollection<T>(collectionName).CountDocuments(session, filter, options, cancellationToken);
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
        public long DynamicCollectionCountDocuments<TForeign, T>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            CountOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").CountDocuments(filter, options, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <param name="options">设置</param>
        /// <param name="cancellationToken">标记</param>
        /// <returns></returns>
        public long DynamicCollectionCountDocuments<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            CountOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").CountDocuments(session, filter, options, cancellationToken);
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
        public long DynamicCollectionCountDocuments<TForeign, T>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            CountOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").CountDocuments(filter, options, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">客户端会话句柄</param>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <param name="options">设置</param>
        /// <param name="cancellationToken">标记</param>
        /// <returns></returns>
        public long DynamicCollectionCountDocuments<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            CountOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").CountDocuments(session,filter, options, cancellationToken);
        }
    }
}
