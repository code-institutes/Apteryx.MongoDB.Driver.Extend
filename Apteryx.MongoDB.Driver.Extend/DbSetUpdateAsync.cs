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

        #region 更新(异步)

        /// <summary>
        /// 更新（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="id">文档默认ID</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<UpdateResult> UpdateOneAsync(
            string id,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.UpdateOneAsync(u => u.Id == id, update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 更新（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<UpdateResult> UpdateOneAsync(
            IClientSessionHandle session,
            string id,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.UpdateOneAsync(session, u => u.Id == id, update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 更新（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<UpdateResult> UpdateOneAsync(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.UpdateOneAsync(filter, update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 更新（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<UpdateResult> UpdateOneAsync(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.UpdateOneAsync(session, filter, update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 更新（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<UpdateResult> UpdateOneAsync(
            Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.UpdateOneAsync(expression, update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 更新（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<UpdateResult> UpdateOneAsync(
            IClientSessionHandle session,
            Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.UpdateOneAsync(session, expression, update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 动态表更新（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="id">默认文档ID</param>
        /// <param name="update">更新定义</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<UpdateResult> DynamicCollectionUpdateOneAsync<TForeign>(
            TForeign foreignDocument,
            string id,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).UpdateOneAsync(u => u.Id == id, update, options, cancellationToken);
        }

        /// <summary>
        /// 动态表更新（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="update">更新定义</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<UpdateResult> DynamicCollectionUpdateOneAsync<TForeign>(
            IClientSessionHandle seesion,
            TForeign foreignDocument,
            string id,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).UpdateOneAsync(seesion, u => u.Id == id, update, options, cancellationToken);
        }

        /// <summary>
        /// 动态表更新（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<UpdateResult> DynamicCollectionUpdateOneAsync<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).UpdateOneAsync(filter, update, options, cancellationToken);
        }

        /// <summary>
        /// 动态表更新（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<UpdateResult> DynamicCollectionUpdateOneAsync<TForeign>(
            IClientSessionHandle seesion,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).UpdateOneAsync(seesion, filter, update, options, cancellationToken);
        }

        /// <summary>
        /// 动态表更新（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">Lmabda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<UpdateResult> DynamicCollectionUpdateOneAsync<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).UpdateOneAsync(expression, update, options, cancellationToken);
        }

        /// <summary>
        /// 动态表更新（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">Lmabda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<UpdateResult> DynamicCollectionUpdateOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).UpdateOneAsync(session, expression, update, options, cancellationToken);
        }

        /// <summary>
        /// 查询更新（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="id">文档默认ID</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<T> FindOneAndUpdateOneAsync(
            string id,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.FindOneAndUpdateAsync<T>(u => u.Id == id, update, options, cancellationToken);
        }

        /// <summary>
        /// 查询更新（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<T> FindOneAndUpdateOneAsync(
            IClientSessionHandle session,
            string id,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.FindOneAndUpdateAsync<T>(session, u => u.Id == id, update, options, cancellationToken);
        }

        /// <summary>
        /// 查询更新（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<T> FindOneAndUpdateOneAsync(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.FindOneAndUpdateAsync<T>(filter, update, options, cancellationToken);
        }

        /// <summary>
        /// 查询更新（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<T> FindOneAndUpdateOneAsync(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.FindOneAndUpdateAsync<T>(session, filter, update, options, cancellationToken);
        }

        /// <summary>
        /// 查询更新（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<T> FindOneAndUpdateOneAsync(
            Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.FindOneAndUpdateAsync<T>(expression, update, options, cancellationToken);
        }

        /// <summary>
        /// 查询更新（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<T> FindOneAndUpdateOneAsync(
            IClientSessionHandle session,
            Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.FindOneAndUpdateAsync<T>(session, expression, update, options, cancellationToken);
        }

        /// <summary>
        /// 动态表查询更新（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<T> DynamicCollectionFindOneAndUpdateOneAsync<TForeign>(
            TForeign foreignDocument,
            string id,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindOneAndUpdateAsync<T>(u => u.Id == id, update, options, cancellationToken);
        }

        /// <summary>
        /// 动态表查询更新（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<T> DynamicCollectionFindOneAndUpdateOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            string id,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindOneAndUpdateAsync<T>(session, u => u.Id == id, update, options, cancellationToken);
        }

        /// <summary>
        /// 动态表查询更新（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<T> DynamicCollectionFindOneAndUpdateOneAsync<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindOneAndUpdateAsync(filter, update, options, cancellationToken);
        }

        /// <summary>
        /// 动态表查询更新（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<T> DynamicCollectionFindOneAndUpdateOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindOneAndUpdateAsync(session, filter, update, options, cancellationToken);
        }

        /// <summary>
        /// 动态表查询更新（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<T> DynamicCollectionFindOneAndUpdateOneAsync<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindOneAndUpdateAsync(expression, update, options, cancellationToken);
        }

        /// <summary>
        /// 动态表查询更新（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<T> DynamicCollectionFindOneAndUpdateOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindOneAndUpdateAsync(session, expression, update, options, cancellationToken);
        }

        /// <summary>
        /// 更新（批量）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<UpdateResult> UpdateManyAsync(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.UpdateManyAsync(filter, update, options, cancellationToken);
        }

        /// <summary>
        /// 更新（批量）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<UpdateResult> UpdateManyAsync(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.UpdateManyAsync(session, filter, update, options, cancellationToken);
        }

        /// <summary>
        /// 更新（批量）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<UpdateResult> UpdateManyAsync(
            Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.UpdateManyAsync(expression, update, options, cancellationToken);
        }

        /// <summary>
        /// 更新（批量）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<UpdateResult> UpdateManyAsync(
            IClientSessionHandle session,
            Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.UpdateManyAsync(session, expression, update, options, cancellationToken);
        }

        /// <summary>
        /// 动态表更新（批量）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<UpdateResult> DynamicCollectionUpdateManyAsync<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).UpdateManyAsync(filter, update, options, cancellationToken);
        }

        /// <summary>
        /// 动态表更新（批量）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<UpdateResult> DynamicCollectionUpdateManyAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).UpdateManyAsync(session, filter, update, options, cancellationToken);
        }

        /// <summary>
        /// 动态表更新（批量）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<UpdateResult> DynamicCollectionUpdateManyAsync<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).UpdateManyAsync(expression, update, options, cancellationToken);
        }

        /// <summary>
        /// 动态表更新（批量）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task<UpdateResult> DynamicCollectionUpdateManyAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).UpdateManyAsync(session, expression, update, options, cancellationToken);
        }

        #endregion
    }
}
