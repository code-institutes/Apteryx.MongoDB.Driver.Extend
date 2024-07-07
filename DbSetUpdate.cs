using MongoDB.Driver;
using System;
using System.Linq.Expressions;
using System.Threading;

namespace Apteryx.MongoDB.Driver.Extend
{
    public partial class DbSet<T>
    {
        #region 更新(同步)

        /// <summary>
        /// 更新单条(自动更新UpdateTime字段)
        /// </summary>        
        /// <param name="id">文档默认ID</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult WhereUpdateOne(
            string id,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.UpdateOne(u => u.Id == id, update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult WhereUpdateOne(
            IClientSessionHandle session,
            string id,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.UpdateOne(session, u => u.Id == id, update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult WhereUpdateOne(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.UpdateOne(filter, update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult WhereUpdateOne(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.UpdateOne(session, filter, update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult WhereUpdateOne(
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.UpdateOne(filter, update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult WhereUpdateOne(
            IClientSessionHandle session,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)

        {
            return _collection.UpdateOne(session, filter, update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 动态表更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="id">默认文档ID</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult DynamicCollectionWhereUpdateOne<TForeign>(
            TForeign foreignDocument,
            string id,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity

        {
            return _database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").UpdateOne(u => u.Id == id,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 动态表更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult DynamicCollectionWhereUpdateOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            string id,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").UpdateOne(session, u => u.Id == id,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 动态表更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult DynamicCollectionWhereUpdateOne<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").UpdateOne(filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 动态表更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult DynamicCollectionWhereUpdateOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").UpdateOne(session, filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 动态表更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult DynamicCollectionWhereUpdateOne<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").UpdateOne(filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 动态表更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult DynamicCollectionWhereUpdateOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").UpdateOne(session, filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 查询更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <param name="id">文档默认ID</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public T FindOneAndUpdateOne(
            string id,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.FindOneAndUpdate<T>(u => u.Id == id,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 查询更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public T FindOneAndUpdateOne(
            IClientSessionHandle session,
            string id,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.FindOneAndUpdate<T>(session, u => u.Id == id,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 查询更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public T FindOneAndUpdateOne(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.FindOneAndUpdate(filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 查询更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public T FindOneAndUpdateOne(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.FindOneAndUpdate(session, filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 查询更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public T FindOneAndUpdateOne(
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.FindOneAndUpdate(filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 查询更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public T FindOneAndUpdateOne(
            IClientSessionHandle session,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.FindOneAndUpdate(filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 动态表查询更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public T DynamicCollectionFindOneAndUpdateOne<TForeign>(
            TForeign foreignDocument,
            string id,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").FindOneAndUpdate<T>(u => u.Id == id,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 动态表查询更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public T DynamicCollectionFindOneAndUpdateOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            string id,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").FindOneAndUpdate<T>(session, u => u.Id == id,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 动态表查询更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public T DynamicCollectionFindOneAndUpdateOne<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").FindOneAndUpdate(filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 动态表查询更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public T DynamicCollectionFindOneAndUpdateOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").FindOneAndUpdate(session, filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 动态表查询更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public T DynamicCollectionFindOneAndUpdateOne<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").FindOneAndUpdate(filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 动态表查询更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public T DynamicCollectionFindOneAndUpdateOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").FindOneAndUpdate(filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 更新多条(自动更新UpdateTime字段)
        /// </summary>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult WhereUpdateMany(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.UpdateMany(filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 更新多条(自动更新UpdateTime字段)
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult WhereUpdateMany(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.UpdateMany(session, filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 更新多条(自动更新UpdateTime字段)
        /// </summary>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult WhereUpdateMany(
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.UpdateMany(filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 更新多条(自动更新UpdateTime字段)
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult WhereUpdateMany(
            IClientSessionHandle session,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
        {
            return _collection.UpdateMany(session, filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 动态表更新多条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult DynamicCollectionWhereUpdateMany<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").UpdateMany(filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 动态表更新多条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult DynamicCollectionWhereUpdateMany<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").UpdateMany(session, filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 动态表更新多条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult DynamicCollectionWhereUpdateMany<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").UpdateMany(filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 动态表更新多条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult DynamicCollectionWhereUpdateMany<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").UpdateMany(session, filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        #endregion

    }
}
