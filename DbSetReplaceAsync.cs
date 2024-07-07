using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Apteryx.MongoDB.Driver.Extend
{
    public partial class DbSet<T>
    {
        #region 替换(异步)

        /// <summary>
        /// 替换单条(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="id">文档默认ID</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<ReplaceOneResult> WhereReplaceOneAsnyc(
            string id,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)            
        {
            return Task.Run(() => WhereReplaceOne(id, document, options, cancellationToken));
        }

        /// <summary>
        /// 替换单条(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">文档默认ID</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<ReplaceOneResult> WhereReplaceOneAsnyc(
            IClientSessionHandle session,
            string id,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)            
        {
            return Task.Run(() => WhereReplaceOne(session, id, document, options, cancellationToken));
        }

        /// <summary>
        /// 替换单条(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="filter">过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<ReplaceOneResult> WhereReplaceOneAsnyc(
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)            
        {
            return Task.Run(() => WhereReplaceOne(filter, document, options, cancellationToken));
        }

        /// <summary>
        /// 替换单条(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<ReplaceOneResult> WhereReplaceOneAsnyc(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)            
        {
            return Task.Run(() => WhereReplaceOne(session, filter, document, options, cancellationToken));
        }

        /// <summary>
        /// 替换单条(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<ReplaceOneResult> WhereReplaceOneAsnyc(
            Expression<Func<T, bool>> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)            
        {
            return Task.Run(() => WhereReplaceOne(filter, document, options, cancellationToken));
        }

        /// <summary>
        /// 替换单条(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<ReplaceOneResult> WhereReplaceOneAsnyc(
            IClientSessionHandle session,
            Expression<Func<T, bool>> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)            
        {
            return Task.Run(() => WhereReplaceOne(session, filter, document, options, cancellationToken));
        }

        /// <summary>
        /// 动态表替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<ReplaceOneResult> DynamicCollectionWhereReplaceOneAsnyc<TForeign>(
            TForeign foreignDocument,
            string id,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity            
        {
            return Task.Run(() => DynamicCollectionWhereReplaceOne(foreignDocument, id, document, options, cancellationToken));
        }

        /// <summary>
        /// 动态表替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<ReplaceOneResult> DynamicCollectionWhereReplaceOneAsnyc<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            string id,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity            
        {
            return Task.Run(() => DynamicCollectionWhereReplaceOne(session, foreignDocument, id, document, options, cancellationToken));
        }

        /// <summary>
        /// 动态表替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<ReplaceOneResult> DynamicCollectionWhereReplaceOneAsnyc<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity            
        {
            return Task.Run(() => DynamicCollectionWhereReplaceOne(foreignDocument, filter, document, options, cancellationToken));
        }

        /// <summary>
        /// 动态表替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<ReplaceOneResult> DynamicCollectionWhereReplaceOneAsnyc<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity            
        {
            return Task.Run(() => DynamicCollectionWhereReplaceOne(session, foreignDocument, filter, document, options, cancellationToken));
        }

        /// <summary>
        /// 动态表替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<ReplaceOneResult> DynamicCollectionWhereReplaceOneAsnyc<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity            
        {
            return Task.Run(() => DynamicCollectionWhereReplaceOne(foreignDocument, filter, document, options, cancellationToken));

        }

        /// <summary>
        /// 动态表替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<ReplaceOneResult> DynamicCollectionWhereReplaceOneAsnyc<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity            
        {
            return Task.Run(() => DynamicCollectionWhereReplaceOne(session, foreignDocument, filter, document, options, cancellationToken));
        }

        /// <summary>
        /// 查询替换单条(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="id">文档默认ID</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<T> FindOneAndReplaceOneAsync(
            string id,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)            
        {
            return Task.Run(() => FindOneAndReplaceOne(id, document, options, cancellationToken));
        }

        /// <summary>
        /// 查询替换单条(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<T> FindOneAndReplaceOneAsync(
            IClientSessionHandle session,
            string id,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)            
        {
            return Task.Run(() => FindOneAndReplaceOne(session, id, document, options, cancellationToken));
        }

        /// <summary>
        /// 查询替换单条(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="filter">过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<T> FindOneAndReplaceOneAsync(
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)            
        {
            return Task.Run(() => FindOneAndReplaceOne(filter, document, options, cancellationToken));
        }

        /// <summary>
        /// 查询替换单条(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<T> FindOneAndReplaceOneAsync(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)            
        {
            return Task.Run(() => FindOneAndReplaceOne(session, filter, document, options, cancellationToken));
        }

        /// <summary>
        /// 查询替换单条(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<T> FindOneAndReplaceOneAsync(
            Expression<Func<T, bool>> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)            
        {
            return Task.Run(() => FindOneAndReplaceOne(filter, document, options, cancellationToken));
        }

        /// <summary>
        /// 查询替换单条(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<T> FindOneAndReplaceOneAsync(
            IClientSessionHandle session,
            Expression<Func<T, bool>> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)            
        {
            return Task.Run(() => FindOneAndReplaceOne(session, filter, document, options, cancellationToken));
        }

        /// <summary>
        /// 动态表查询替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<T> DynamicCollectionFindOneAndReplaceOneAsync<TForeign>(
            TForeign foreignDocument,
            string id,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity            
        {
            return Task.Run(() => DynamicCollectionFindOneAndReplaceOne(foreignDocument, id, document, options, cancellationToken));
        }

        /// <summary>
        /// 动态表查询替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<T> DynamicCollectionFindOneAndReplaceOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            string id,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity            
        {
            return Task.Run(() => DynamicCollectionFindOneAndReplaceOne(session, foreignDocument, id, document, options, cancellationToken));
        }

        /// <summary>
        /// 动态表查询替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<T> DynamicCollectionFindOneAndReplaceOneAsync<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity            
        {
            return Task.Run(() => DynamicCollectionFindOneAndReplaceOne(foreignDocument, filter, document, options, cancellationToken));
        }

        /// <summary>
        /// 动态表查询替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<T> DynamicCollectionFindOneAndReplaceOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity            
        {
            return Task.Run(() => DynamicCollectionFindOneAndReplaceOne(session, foreignDocument, filter, document, options, cancellationToken));
        }

        /// <summary>
        /// 动态表查询替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<T> DynamicCollectionFindOneAndReplaceOneAsync<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity            
        {
            return Task.Run(() => DynamicCollectionFindOneAndReplaceOne(foreignDocument, filter, document, options, cancellationToken));
        }

        /// <summary>
        /// 动态表查询替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<T> DynamicCollectionFindOneAndReplaceOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity            
        {
            return Task.Run(() => DynamicCollectionFindOneAndReplaceOne(session,foreignDocument, filter, document, options, cancellationToken));
        }

        #endregion
    }
}
