using MongoDB.Driver;
using System;
using System.Linq.Expressions;
using System.Threading;
using Apteryx.MongoDB.Driver.Extend.Entities;

namespace Apteryx.MongoDB.Driver.Extend
{
    public abstract partial class MongoDbService
    {
        #region 更新(同步)

        /// <summary>
        /// 更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="id">文档默认ID</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult WhereUpdateOne<T>(
            string id,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>(typeof(T).Name).UpdateOne(u => u.Id == id,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }
        /// <summary>
        /// 更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult WhereUpdateOne<T>(
            IClientSessionHandle session,
            string id,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>(typeof(T).Name).UpdateOne(session, u => u.Id == id,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }
        /// <summary>
        /// 更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult WhereUpdateOne<T>(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>(typeof(T).Name).UpdateOne(filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }
        /// <summary>
        /// 更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult WhereUpdateOne<T>(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>(typeof(T).Name).UpdateOne(session, filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }
        /// <summary>
        /// 更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult WhereUpdateOne<T>(
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>(typeof(T).Name).UpdateOne(filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }
        /// <summary>
        /// 更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult WhereUpdateOne<T>(
            IClientSessionHandle session,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>(typeof(T).Name).UpdateOne(session, filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }
        /// <summary>
        /// 动态表更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="id">默认文档ID</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult DynamicCollectionWhereUpdateOne<TForeign, T>(
            TForeign foreignDocument,
            string id,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").UpdateOne(u => u.Id == id,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }
        /// <summary>
        /// 动态表更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult DynamicCollectionWhereUpdateOne<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            string id,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").UpdateOne(session, u => u.Id == id,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }
        /// <summary>
        /// 动态表更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult DynamicCollectionWhereUpdateOne<TForeign, T>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").UpdateOne(filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }
        /// <summary>
        /// 动态表更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult DynamicCollectionWhereUpdateOne<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").UpdateOne(session, filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }
        /// <summary>
        /// 动态表更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult DynamicCollectionWhereUpdateOne<TForeign, T>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").UpdateOne(filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }
        /// <summary>
        /// 动态表更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult DynamicCollectionWhereUpdateOne<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").UpdateOne(session, filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }
        /// <summary>
        /// 查询更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="id">文档默认ID</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public T FindOneAndUpdateOne<T>(
            string id,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>(typeof(T).Name).FindOneAndUpdate<T>(u => u.Id == id,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }
        /// <summary>
        /// 查询更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public T FindOneAndUpdateOne<T>(
            IClientSessionHandle session,
            string id,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>(typeof(T).Name).FindOneAndUpdate<T>(session, u => u.Id == id,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }
        /// <summary>
        /// 查询更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public T FindOneAndUpdateOne<T>(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>(typeof(T).Name).FindOneAndUpdate(filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }
        /// <summary>
        /// 查询更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public T FindOneAndUpdateOne<T>(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>(typeof(T).Name).FindOneAndUpdate(session, filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }
        /// <summary>
        /// 查询更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public T FindOneAndUpdateOne<T>(
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>(typeof(T).Name).FindOneAndUpdate(filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }
        /// <summary>
        /// 查询更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public T FindOneAndUpdateOne<T>(
            IClientSessionHandle session,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>(typeof(T).Name).FindOneAndUpdate(filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }
        /// <summary>
        /// 动态表查询更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public T DynamicCollectionFindOneAndUpdateOne<TForeign, T>(
            TForeign foreignDocument,
            string id,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").FindOneAndUpdate<T>(u => u.Id == id,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }
        /// <summary>
        /// 动态表查询更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public T DynamicCollectionFindOneAndUpdateOne<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            string id,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").FindOneAndUpdate<T>(session, u => u.Id == id,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }
        /// <summary>
        /// 动态表查询更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public T DynamicCollectionFindOneAndUpdateOne<TForeign, T>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").FindOneAndUpdate(filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }
        /// <summary>
        /// 动态表查询更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public T DynamicCollectionFindOneAndUpdateOne<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").FindOneAndUpdate(session, filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }
        /// <summary>
        /// 动态表查询更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public T DynamicCollectionFindOneAndUpdateOne<TForeign, T>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").FindOneAndUpdate(filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }
        /// <summary>
        /// 动态表查询更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public T DynamicCollectionFindOneAndUpdateOne<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").FindOneAndUpdate(filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }
        /// <summary>
        /// 更新多条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult WhereUpdateMany<T>(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>(typeof(T).Name).UpdateMany(filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }
        /// <summary>
        /// 更新多条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult WhereUpdateMany<T>(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>(typeof(T).Name).UpdateMany(session, filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }
        /// <summary>
        /// 更新多条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult WhereUpdateMany<T>(
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>(typeof(T).Name).UpdateMany(filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }
        /// <summary>
        /// 更新多条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult WhereUpdateMany<T>(
            IClientSessionHandle session,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>(typeof(T).Name).UpdateMany(session, filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }
        /// <summary>
        /// 动态表更新多条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult DynamicCollectionWhereUpdateMany<TForeign, T>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").UpdateMany(filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }
        /// <summary>
        /// 动态表更新多条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult DynamicCollectionWhereUpdateMany<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").UpdateMany(session, filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }
        /// <summary>
        /// 动态表更新多条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult DynamicCollectionWhereUpdateMany<TForeign, T>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").UpdateMany(filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }
        /// <summary>
        /// 动态表更新多条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="update">更新定义</param>
        /// <param name="options">更新操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public UpdateResult DynamicCollectionWhereUpdateMany<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").UpdateMany(session, filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        #endregion

    }
}
