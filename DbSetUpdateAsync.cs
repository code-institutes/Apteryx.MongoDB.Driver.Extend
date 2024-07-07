using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;

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
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<UpdateResult> WhereUpdateOneAsync(
            string id,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)            
        {
            return Task.Run(() => WhereUpdateOne(id, update, options, cancellationToken));
        }

        /// <summary>
        /// 更新（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<UpdateResult> WhereUpdateOneAsync(
            IClientSessionHandle session,
            string id,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)            
        {
            return Task.Run(() => WhereUpdateOne(session, id, update, options, cancellationToken));
        }

        /// <summary>
        /// 更新（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<UpdateResult> WhereUpdateOneAsync(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)            
        {
            return Task.Run(() => WhereUpdateOne(filter, update, options, cancellationToken));
        }

        /// <summary>
        /// 更新（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<UpdateResult> WhereUpdateOneAsync(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)            
        {
            return Task.Run(() => WhereUpdateOne(session, filter, update, options, cancellationToken));
        }

        /// <summary>
        /// 更新（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<UpdateResult> WhereUpdateOneAsync(
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)            
        {
            return Task.Run(() => WhereUpdateOne(filter, update, options, cancellationToken));
        }

        /// <summary>
        /// 更新（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<UpdateResult> WhereUpdateOneAsync(
            IClientSessionHandle session,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)            
        {
            return Task.Run(() => WhereUpdateOne(session, filter, update, options, cancellationToken));
        }

        /// <summary>
        /// 动态表更新（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="id">默认文档ID</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<UpdateResult> DynamicCollectionWhereUpdateOneAsync<TForeign>(
            TForeign foreignDocument,
            string id,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity            
        {
            return Task.Run(() => DynamicCollectionWhereUpdateOne(foreignDocument, u => u.Id == id, update, options, cancellationToken));
        }

        /// <summary>
        /// 动态表更新（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<UpdateResult> DynamicCollectionWhereUpdateOneAsync<TForeign>(
            IClientSessionHandle seesion,
            TForeign foreignDocument,
            string id,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity            
        {
            return Task.Run(() => DynamicCollectionWhereUpdateOne(seesion, foreignDocument, u => u.Id == id, update, options, cancellationToken));
        }

        /// <summary>
        /// 动态表更新（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<UpdateResult> DynamicCollectionWhereUpdateOneAsync<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity            
        {
            return Task.Run(() => DynamicCollectionWhereUpdateOne(foreignDocument, filter, update, options, cancellationToken));
        }

        /// <summary>
        /// 动态表更新（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<UpdateResult> DynamicCollectionWhereUpdateOneAsync<TForeign>(
            IClientSessionHandle seesion,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity            
        {
            return Task.Run(() => DynamicCollectionWhereUpdateOne(seesion, foreignDocument, filter, update, options, cancellationToken));
        }

        /// <summary>
        /// 动态表更新（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">Lmabda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<UpdateResult> DynamicCollectionWhereUpdateOneAsync<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity            
        {
            return Task.Run(() => DynamicCollectionWhereUpdateOne(foreignDocument, filter, update, options, cancellationToken));
        }

        /// <summary>
        /// 动态表更新（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">Lmabda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<UpdateResult> DynamicCollectionWhereUpdateOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity            
        {
            return Task.Run(() => DynamicCollectionWhereUpdateOne(session, foreignDocument, filter, update, options, cancellationToken));
        }

        /// <summary>
        /// 查询更新（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="id">文档默认ID</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<T> FindOneAndUpdateOneAsync(
            string id,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)            
        {
            return Task.Run(() => FindOneAndUpdateOne(id, update, options, cancellationToken));
        }

        /// <summary>
        /// 查询更新（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<T> FindOneAndUpdateOneAsync(
            IClientSessionHandle session,
            string id,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)            
        {
            return Task.Run(() => FindOneAndUpdateOne(session, id, update, options, cancellationToken));
        }

        /// <summary>
        /// 查询更新（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<T> FindOneAndUpdateOneAsync(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)            
        {
            return Task.Run(() => FindOneAndUpdateOne(filter, update, options, cancellationToken));
        }

        /// <summary>
        /// 查询更新（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<T> FindOneAndUpdateOneAsync(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)            
        {
            return Task.Run(() => FindOneAndUpdateOne(session, filter, update, options, cancellationToken));
        }

        /// <summary>
        /// 查询更新（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<T> FindOneAndUpdateOneAsync(
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)            
        {
            return Task.Run(() => FindOneAndUpdateOne(filter, update, options, cancellationToken));
        }

        /// <summary>
        /// 查询更新（单个）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<T> FindOneAndUpdateOneAsync(
            IClientSessionHandle session,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)            
        {
            return Task.Run(() => FindOneAndUpdateOne(session, filter, update, options, cancellationToken));
        }

        /// <summary>
        /// 动态表查询更新（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<T> DynamicCollectionFindOneAndUpdateOneAsync<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity            
        {
            return Task.Run(() => DynamicCollectionFindOneAndUpdateOne(foreignDocument, filter, update, options, cancellationToken));
        }

        /// <summary>
        /// 动态表查询更新（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<T> DynamicCollectionFindOneAndUpdateOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity            
        {
            return Task.Run(() => DynamicCollectionFindOneAndUpdateOne(session, foreignDocument, filter, update, options, cancellationToken));
        }

        /// <summary>
        /// 动态表查询更新（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<T> DynamicCollectionFindOneAndUpdateOneAsync<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity            
        {
            return Task.Run(() => DynamicCollectionFindOneAndUpdateOne(foreignDocument, filter, update, options, cancellationToken));
        }

        /// <summary>
        /// 动态表查询更新（单个）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<T> DynamicCollectionFindOneAndUpdateOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity            
        {
            return Task.Run(() => DynamicCollectionFindOneAndUpdateOne(session, foreignDocument, filter, update, options, cancellationToken));
        }

        /// <summary>
        /// 更新（批量）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<UpdateResult> WhereUpdateManyAsync(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)            
        {
            return Task.Run(() => WhereUpdateMany(filter, update, options, cancellationToken));
        }

        /// <summary>
        /// 更新（批量）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<UpdateResult> WhereUpdateManyAsync(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)            
        {
            return Task.Run(() => WhereUpdateMany(session, filter, update, options, cancellationToken));
        }

        /// <summary>
        /// 更新（批量）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<UpdateResult> WhereUpdateManyAsync(
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)            
        {
            return Task.Run(() => WhereUpdateMany(filter, update, options, cancellationToken));
        }

        /// <summary>
        /// 更新（批量）(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<UpdateResult> WhereUpdateManyAsync(
            IClientSessionHandle session,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)            
        {
            return Task.Run(() => WhereUpdateMany(session,filter, update, options, cancellationToken));
        }

        /// <summary>
        /// 动态表更新（批量）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<UpdateResult> DynamicCollectionWhereUpdateManyAsync<TForeign>(
            TForeign foreignDocument, 
            FilterDefinition<T> filter, 
            UpdateDefinition<T> update, 
            UpdateOptions options = null, 
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity            
        {
            return Task.Run(() => DynamicCollectionWhereUpdateMany(foreignDocument, filter, update, options, cancellationToken));
        }

        /// <summary>
        /// 动态表更新（批量）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<UpdateResult> DynamicCollectionWhereUpdateManyAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity            
        {
            return Task.Run(() => DynamicCollectionWhereUpdateMany(session,foreignDocument, filter, update, options, cancellationToken));
        }

        /// <summary>
        /// 动态表更新（批量）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<UpdateResult> DynamicCollectionWhereUpdateManyAsync<TForeign>(
            TForeign foreignDocument, 
            Expression<Func<T, bool>> filter, 
            UpdateDefinition<T> update, 
            UpdateOptions options = null, 
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity            
        {
            return Task.Run(() => DynamicCollectionWhereUpdateMany(foreignDocument, filter, update, options, cancellationToken));
        }

        /// <summary>
        /// 动态表更新（批量）(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public Task<UpdateResult> DynamicCollectionWhereUpdateManyAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity            
        {
            return Task.Run(() => DynamicCollectionWhereUpdateMany(session,foreignDocument, filter, update, options, cancellationToken));
        }

        #endregion
    }
}
