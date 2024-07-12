using System;
using System.Linq.Expressions;
using System.Threading;
using MongoDB.Driver;

namespace Apteryx.MongoDB.Driver.Extend
{
    public partial class DbSet<T>
    {
        #region 替换(同步)

        /// <summary>
        /// 替换（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="id">文档默认ID</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public ReplaceOneResult ReplaceOne(
            string id,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
        {
            document.UpdateTime = DateTime.Now;
            return _collection.ReplaceOne(r => r.Id == id, document, options, cancellationToken);
        }

        /// <summary>
        /// 替换（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public ReplaceOneResult ReplaceOne(
            IClientSessionHandle session,
            string id,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
        {
            document.UpdateTime = DateTime.Now;
            return _collection.ReplaceOne(session, r => r.Id == id, document, options, cancellationToken);
        }

        /// <summary>
        /// 替换（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="filter">过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public ReplaceOneResult ReplaceOne(
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
        {
            document.UpdateTime = DateTime.Now;
            return _collection.ReplaceOne(filter, document, options, cancellationToken);
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
        public ReplaceOneResult ReplaceOne(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
        {
            document.UpdateTime = DateTime.Now;
            return _collection.ReplaceOne(session, filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 替换（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public ReplaceOneResult ReplaceOne(
            Expression<Func<T, bool>> expression,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
        {
            document.UpdateTime = DateTime.Now;
            return _collection.ReplaceOne(expression, document, options, cancellationToken);
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
        public ReplaceOneResult ReplaceOne(
            IClientSessionHandle session,
            Expression<Func<T, bool>> expression,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
        {
            document.UpdateTime = DateTime.Now;
            return _collection.ReplaceOne(session, expression, document, options, cancellationToken);
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
        public ReplaceOneResult DynamicCollectionReplaceOne<TForeign>(
            TForeign foreignDocument,
            string id,
            T document,
            MongoCollectionSettings settings = null,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).ReplaceOne(r => r.Id == id, document, options, cancellationToken);
        }

        /// <summary>
        /// 动态表替换（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public ReplaceOneResult DynamicCollectionReplaceOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            string id,
            T document,
            MongoCollectionSettings settings = null,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).ReplaceOne(session, r => r.Id == id, document, options, cancellationToken);
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
        public ReplaceOneResult DynamicCollectionReplaceOne<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            MongoCollectionSettings settings = null,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).ReplaceOne(filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 动态表替换（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public ReplaceOneResult DynamicCollectionReplaceOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            MongoCollectionSettings settings = null,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).ReplaceOne(session, filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 动态表替换（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public ReplaceOneResult DynamicCollectionReplaceOne<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            T document,
            MongoCollectionSettings settings = null,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).ReplaceOne(expression, document, options, cancellationToken);
        }

        /// <summary>
        /// 动态表替换（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public ReplaceOneResult DynamicCollectionReplaceOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            T document,
            MongoCollectionSettings settings = null,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).ReplaceOne(session, expression, document, options, cancellationToken);
        }

        /// <summary>
        /// 查询替换（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="id">文档默认ID</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public T FindOneAndReplaceOne(
            string id,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
        {
            document.UpdateTime = DateTime.Now;
            return _collection.FindOneAndReplace<T>(r => r.Id == id, document, options, cancellationToken);
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
        public T FindOneAndReplaceOne(
            IClientSessionHandle session,
            string id,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
        {
            document.UpdateTime = DateTime.Now;
            return _collection.FindOneAndReplace<T>(session, r => r.Id == id, document, options, cancellationToken);
        }

        /// <summary>
        /// 查询替换（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="filter">过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public T FindOneAndReplaceOne(
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
        {
            document.UpdateTime = DateTime.Now;
            return _collection.FindOneAndReplace(filter, document, options, cancellationToken);
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
        public T FindOneAndReplaceOne(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
        {
            document.UpdateTime = DateTime.Now;
            return _collection.FindOneAndReplace(session, filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 查询替换（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public T FindOneAndReplaceOne(
            Expression<Func<T, bool>> expression,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
        {
            document.UpdateTime = DateTime.Now;
            return _collection.FindOneAndReplace(expression, document, options, cancellationToken);
        }

        /// <summary>
        /// 查询替换（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public T FindOneAndReplaceOne(
            IClientSessionHandle session,
            Expression<Func<T, bool>> expression,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
        {
            document.UpdateTime = DateTime.Now;
            return _collection.FindOneAndReplace(session, expression, document, options, cancellationToken);
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
        public T DynamicCollectionFindOneAndReplaceOne<TForeign>(
            TForeign foreignDocument,
            string id,
            T document,
            MongoCollectionSettings settings = null,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindOneAndReplace<T>(r => r.Id == id, document, options, cancellationToken);
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
        public T DynamicCollectionFindOneAndReplaceOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            string id,
            T document,
            MongoCollectionSettings settings = null,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindOneAndReplace<T>(session, r => r.Id == id, document, options, cancellationToken);
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
        public T DynamicCollectionFindOneAndReplaceOne<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            MongoCollectionSettings settings = null,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindOneAndReplace(filter, document, options, cancellationToken);
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
        public T DynamicCollectionFindOneAndReplaceOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            MongoCollectionSettings settings = null,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindOneAndReplace(session, filter, document, options, cancellationToken);
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
        public T DynamicCollectionFindOneAndReplaceOne<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            T document,
            MongoCollectionSettings settings = null,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindOneAndReplace(expression, document, options, cancellationToken);
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
        public T DynamicCollectionFindOneAndReplaceOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            T document,
            MongoCollectionSettings settings = null,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindOneAndReplace(session, expression, document, options, cancellationToken);
        }

        #endregion
    }
}
