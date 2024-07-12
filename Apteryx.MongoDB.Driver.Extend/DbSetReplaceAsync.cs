using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;
using static System.Collections.Specialized.BitVector32;

namespace Apteryx.MongoDB.Driver.Extend
{
    public partial class DbSet<T>
    {
        #region 替换(异步)

        /// <summary>
        /// 替换（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="id">文档默认ID</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<ReplaceOneResult> ReplaceOneAsync(
            string id,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.ReplaceOneAsync(d => d.Id == id, document, options, cancellationToken);
        }

        /// <summary>
        /// 替换（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">文档默认ID</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<ReplaceOneResult> ReplaceOneAsync(
            IClientSessionHandle session,
            string id,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.ReplaceOneAsync(session, d => d.Id == id, document, options, cancellationToken);
        }

        /// <summary>
        /// 替换（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="filter">过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<ReplaceOneResult> ReplaceOneAsync(
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.ReplaceOneAsync(filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 替换（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<ReplaceOneResult> ReplaceOneAsync(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.ReplaceOneAsync(session, filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 替换（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<ReplaceOneResult> ReplaceOneAsync(
            Expression<Func<T, bool>> expression,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.ReplaceOneAsync(expression, document, options, cancellationToken);
        }

        /// <summary>
        /// 替换（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<ReplaceOneResult> ReplaceOneAsync(
            IClientSessionHandle session,
            Expression<Func<T, bool>> expression,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.ReplaceOneAsync(session, expression, document, options, cancellationToken);
        }

        /// <summary>
        /// 动态表替换（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="document">文档对象</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<ReplaceOneResult> DynamicCollectionReplaceOneAsync<TForeign>(
            TForeign foreignDocument,
            string id,
            T document,
            MongoCollectionSettings settings = null,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).ReplaceOneAsync(r => r.Id == id, document, options, cancellationToken);
        }

        /// <summary>
        /// 动态表替换（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="document">文档对象</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<ReplaceOneResult> DynamicCollectionReplaceOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            string id,
            T document,
            MongoCollectionSettings settings = null,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).ReplaceOneAsync(session, r => r.Id == id, document, options, cancellationToken);
        }

        /// <summary>
        /// 动态表替换（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<ReplaceOneResult> DynamicCollectionReplaceOneAsync<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            MongoCollectionSettings settings = null,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).ReplaceOneAsync(filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 动态表替换（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<ReplaceOneResult> DynamicCollectionReplaceOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            MongoCollectionSettings settings = null,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).ReplaceOneAsync(session, filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 动态表替换（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<ReplaceOneResult> DynamicCollectionReplaceOneAsync<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            T document,
            MongoCollectionSettings settings = null,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).ReplaceOneAsync(expression, document, options, cancellationToken);

        }

        /// <summary>
        /// 动态表替换（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<ReplaceOneResult> DynamicCollectionReplaceOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            T document,
            MongoCollectionSettings settings = null,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).ReplaceOneAsync(session, expression, document, options, cancellationToken);
        }

        /// <summary>
        /// 查询替换（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="id">文档默认ID</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<T> FindOneAndReplaceOneAsync(
            string id,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.FindOneAndReplaceAsync<T>(r => r.Id == id, document, options, cancellationToken);
        }

        /// <summary>
        /// 查询替换（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<T> FindOneAndReplaceOneAsync(
            IClientSessionHandle session,
            string id,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.FindOneAndReplaceAsync(session, r => r.Id == id, document, options, cancellationToken);
        }

        /// <summary>
        /// 查询替换（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="filter">过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<T> FindOneAndReplaceOneAsync(
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.FindOneAndReplaceAsync(filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 查询替换（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<T> FindOneAndReplaceOneAsync(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.FindOneAndReplaceAsync(session, filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 查询替换（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<T> FindOneAndReplaceOneAsync(
            Expression<Func<T, bool>> expression,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.FindOneAndReplaceAsync(expression, document, options, cancellationToken);
        }

        /// <summary>
        /// 查询替换（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<T> FindOneAndReplaceOneAsync(
            IClientSessionHandle session,
            Expression<Func<T, bool>> expression,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.FindOneAndReplaceAsync(expression, session, document, options, cancellationToken);
        }

        /// <summary>
        /// 动态表查询替换（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="document">文档对象</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<T> DynamicCollectionFindOneAndReplaceOneAsync<TForeign>(
            TForeign foreignDocument,
            string id,
            T document,
            MongoCollectionSettings settings = null,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindOneAndReplaceAsync<T>(r => r.Id == id, document, options, cancellationToken);
        }

        /// <summary>
        /// 动态表查询替换（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="document">文档对象</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<T> DynamicCollectionFindOneAndReplaceOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            string id,
            T document,
            MongoCollectionSettings settings = null,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindOneAndReplaceAsync<T>(r => r.Id == id, session, document, options, cancellationToken);
        }

        /// <summary>
        /// 动态表查询替换（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<T> DynamicCollectionFindOneAndReplaceOneAsync<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            MongoCollectionSettings settings = null,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindOneAndReplaceAsync<T>(filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 动态表查询替换（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<T> DynamicCollectionFindOneAndReplaceOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            MongoCollectionSettings settings = null,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindOneAndReplaceAsync<T>(session, filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 动态表查询替换（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<T> DynamicCollectionFindOneAndReplaceOneAsync<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            T document,
            MongoCollectionSettings settings = null,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindOneAndReplaceAsync<T>(expression, document, options, cancellationToken);
        }

        /// <summary>
        /// 动态表查询替换（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<T> DynamicCollectionFindOneAndReplaceOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            T document,
            MongoCollectionSettings settings = null,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindOneAndReplaceAsync<T>(expression, session, document, options, cancellationToken);
        }

        #endregion
    }
}
