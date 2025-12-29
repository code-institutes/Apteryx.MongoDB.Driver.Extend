using System;
using MongoDB.Driver;
using System.Threading;
using System.Linq.Expressions;

namespace Apteryx.MongoDB.Driver.Extend;

public partial class CommandExecutor<T>
{
    #region 更新(同步)

    /// <summary>
    /// 更新（单个）(自动更新UpdateTime字段)
    /// </summary>        
    /// <param name="id">文档默认ID</param>
    /// <param name="update">更新定义</param>
    /// <param name="options">更新操作设置</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public UpdateResult UpdateOne(
        string id,
        UpdateDefinition<T> update,
        UpdateOptions options = null,
        CancellationToken cancellationToken = default)
    {
        return _collection.UpdateOne(u => u.Id == id, update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
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
    public UpdateResult UpdateOne(
        IClientSessionHandle session,
        string id,
        UpdateDefinition<T> update,
        UpdateOptions options = null,
        CancellationToken cancellationToken = default)
    {
        return _collection.UpdateOne(session, u => u.Id == id, update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
    }

    /// <summary>
    /// 更新（单个）(自动更新UpdateTime字段)
    /// </summary>
    /// <param name="filter">过滤器</param>
    /// <param name="update">更新定义</param>
    /// <param name="options">更新操作设置</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public UpdateResult UpdateOne(
        FilterDefinition<T> filter,
        UpdateDefinition<T> update,
        UpdateOptions options = null,
        CancellationToken cancellationToken = default)
    {
        return _collection.UpdateOne(filter, update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
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
    public UpdateResult UpdateOne(
        IClientSessionHandle session,
        FilterDefinition<T> filter,
        UpdateDefinition<T> update,
        UpdateOptions options = null,
        CancellationToken cancellationToken = default)
    {
        return _collection.UpdateOne(session, filter, update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
    }

    /// <summary>
    /// 更新（单个）(自动更新UpdateTime字段)
    /// </summary>
    /// <param name="expression">Lambda过滤器</param>
    /// <param name="update">更新定义</param>
    /// <param name="options">更新操作设置</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public UpdateResult UpdateOne(
        Expression<Func<T, bool>> expression,
        UpdateDefinition<T> update,
        UpdateOptions options = null,
        CancellationToken cancellationToken = default)
    {
        return _collection.UpdateOne(expression, update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
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
    public UpdateResult UpdateOne(
        IClientSessionHandle session,
        Expression<Func<T, bool>> expression,
        UpdateDefinition<T> update,
        UpdateOptions options = null,
        CancellationToken cancellationToken = default)

    {
        return _collection.UpdateOne(session, expression, update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
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
    public UpdateResult DynamicCollectionUpdateOne<TForeign>(
        TForeign foreignDocument,
        string id,
        UpdateDefinition<T> update,
        MongoCollectionSettings settings = null,
        UpdateOptions options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity

    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).UpdateOne(u => u.Id == id,
            update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
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
    public UpdateResult DynamicCollectionUpdateOne<TForeign>(
        IClientSessionHandle session,
        TForeign foreignDocument,
        string id,
        UpdateDefinition<T> update,
        MongoCollectionSettings settings = null,
        UpdateOptions options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).UpdateOne(session, u => u.Id == id,
            update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
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
    public UpdateResult DynamicCollectionUpdateOne<TForeign>(
        TForeign foreignDocument,
        FilterDefinition<T> filter,
        UpdateDefinition<T> update,
        MongoCollectionSettings settings = null,
        UpdateOptions options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).UpdateOne(filter,
            update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
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
    public UpdateResult DynamicCollectionUpdateOne<TForeign>(
        IClientSessionHandle session,
        TForeign foreignDocument,
        FilterDefinition<T> filter,
        UpdateDefinition<T> update,
        MongoCollectionSettings settings = null,
        UpdateOptions options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).UpdateOne(session, filter,
            update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
    }

    /// <summary>
    /// 动态表更新（单个）(自动更新UpdateTime字段)
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="foreignDocument">上级文档</param>
    /// <param name="expression">Lambda过滤器</param>
    /// <param name="update">更新定义</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">更新操作设置</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public UpdateResult DynamicCollectionUpdateOne<TForeign>(
        TForeign foreignDocument,
        Expression<Func<T, bool>> expression,
        UpdateDefinition<T> update,
        MongoCollectionSettings settings = null,
        UpdateOptions options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).UpdateOne(expression,
            update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
    }

    /// <summary>
    /// 动态表更新（单个）(自动更新UpdateTime字段)
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="foreignDocument">上级文档</param>
    /// <param name="expression">Lambda过滤器</param>
    /// <param name="update">更新定义</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">更新操作设置</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public UpdateResult DynamicCollectionUpdateOne<TForeign>(
        IClientSessionHandle session,
        TForeign foreignDocument,
        Expression<Func<T, bool>> expression,
        UpdateDefinition<T> update,
        MongoCollectionSettings settings = null,
        UpdateOptions options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).UpdateOne(session, expression,
            update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
    }

    /// <summary>
    /// 查询更新（单个）(自动更新UpdateTime字段)
    /// </summary>
    /// <param name="id">文档默认ID</param>
    /// <param name="update">更新定义</param>
    /// <param name="options">更新操作设置</param>
    /// <param name="cancellationToken">取消令牌</param>
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
    /// 查询更新（单个）(自动更新UpdateTime字段)
    /// </summary>
    /// <param name="session">会话句柄(作用于事务)</param>
    /// <param name="id">文档默认ID</param>
    /// <param name="update">更新定义</param>
    /// <param name="options">更新操作设置</param>
    /// <param name="cancellationToken">取消令牌</param>
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
    /// 查询更新（单个）(自动更新UpdateTime字段)
    /// </summary>
    /// <param name="filter">过滤器</param>
    /// <param name="update">更新定义</param>
    /// <param name="options">更新操作设置</param>
    /// <param name="cancellationToken">取消令牌</param>
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
    /// 查询更新（单个）(自动更新UpdateTime字段)
    /// </summary>
    /// <param name="session">会话句柄(作用于事务)</param>
    /// <param name="filter">过滤器</param>
    /// <param name="update">更新定义</param>
    /// <param name="options">更新操作设置</param>
    /// <param name="cancellationToken">取消令牌</param>
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
    /// 查询更新（单个）(自动更新UpdateTime字段)
    /// </summary>
    /// <param name="expression">Lambda过滤器</param>
    /// <param name="update">更新定义</param>
    /// <param name="options">更新操作设置</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public T FindOneAndUpdateOne(
        Expression<Func<T, bool>> expression,
        UpdateDefinition<T> update,
        FindOneAndUpdateOptions<T> options = null,
        CancellationToken cancellationToken = default)
    {
        return _collection.FindOneAndUpdate(expression,
            update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
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
    public T FindOneAndUpdateOne(
        IClientSessionHandle session,
        Expression<Func<T, bool>> expression,
        UpdateDefinition<T> update,
        FindOneAndUpdateOptions<T> options = null,
        CancellationToken cancellationToken = default)
    {
        return _collection.FindOneAndUpdate(session, expression,
            update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
    }

    /// <summary>
    /// 动态表查询更新（单个）(自动更新UpdateTime字段)
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="foreignDocument">上级文档</param>
    /// <param name="id">文档默认ID</param>
    /// <param name="update">更新定义</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">更新操作设置</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public T DynamicCollectionFindOneAndUpdateOne<TForeign>(
        TForeign foreignDocument,
        string id,
        UpdateDefinition<T> update,
        MongoCollectionSettings settings = null,
        FindOneAndUpdateOptions<T> options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindOneAndUpdate<T>(u => u.Id == id,
            update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
    }

    /// <summary>
    /// 动态表查询更新（单个）(自动更新UpdateTime字段)
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="foreignDocument">上级文档</param>
    /// <param name="id">文档默认ID</param>
    /// <param name="update">更新定义</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">更新操作设置</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public T DynamicCollectionFindOneAndUpdateOne<TForeign>(
        IClientSessionHandle session,
        TForeign foreignDocument,
        string id,
        UpdateDefinition<T> update,
        MongoCollectionSettings settings = null,
        FindOneAndUpdateOptions<T> options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindOneAndUpdate<T>(session, u => u.Id == id,
            update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
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
    public T DynamicCollectionFindOneAndUpdateOne<TForeign>(
        TForeign foreignDocument,
        FilterDefinition<T> filter,
        UpdateDefinition<T> update,
        MongoCollectionSettings settings = null,
        FindOneAndUpdateOptions<T> options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindOneAndUpdate(filter,
            update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
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
    public T DynamicCollectionFindOneAndUpdateOne<TForeign>(
        IClientSessionHandle session,
        TForeign foreignDocument,
        FilterDefinition<T> filter,
        UpdateDefinition<T> update,
        MongoCollectionSettings settings = null,
        FindOneAndUpdateOptions<T> options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindOneAndUpdate(session, filter,
            update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
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
    public T DynamicCollectionFindOneAndUpdateOne<TForeign>(
        TForeign foreignDocument,
        Expression<Func<T, bool>> expression,
        UpdateDefinition<T> update,
        MongoCollectionSettings settings = null,
        FindOneAndUpdateOptions<T> options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindOneAndUpdate(expression,
            update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
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
    public T DynamicCollectionFindOneAndUpdateOne<TForeign>(
        IClientSessionHandle session,
        TForeign foreignDocument,
        Expression<Func<T, bool>> expression,
        UpdateDefinition<T> update,
        MongoCollectionSettings settings = null,
        FindOneAndUpdateOptions<T> options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindOneAndUpdate(session, expression,
            update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
    }

    /// <summary>
    /// 更新（批量）(自动更新UpdateTime字段)
    /// </summary>
    /// <param name="filter">过滤器</param>
    /// <param name="update">更新定义</param>
    /// <param name="options">更新操作设置</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public UpdateResult UpdateMany(
        FilterDefinition<T> filter,
        UpdateDefinition<T> update,
        UpdateOptions options = null,
        CancellationToken cancellationToken = default)
    {
        return _collection.UpdateMany(filter,
            update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
    }

    /// <summary>
    /// 更新（批量）(自动更新UpdateTime字段)
    /// </summary>
    /// <param name="session">会话句柄(作用于事务)</param>
    /// <param name="filter">过滤器</param>
    /// <param name="update">更新定义</param>
    /// <param name="options">更新操作设置</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public UpdateResult UpdateMany(
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
    /// 更新（批量）(自动更新UpdateTime字段)
    /// </summary>
    /// <param name="expression">Lambda过滤器</param>
    /// <param name="update">更新定义</param>
    /// <param name="options">更新操作设置</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public UpdateResult UpdateMany(
        Expression<Func<T, bool>> expression,
        UpdateDefinition<T> update,
        UpdateOptions options = null,
        CancellationToken cancellationToken = default)
    {
        return _collection.UpdateMany(expression,
            update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
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
    public UpdateResult UpdateMany(
        IClientSessionHandle session,
        Expression<Func<T, bool>> expression,
        UpdateDefinition<T> update,
        UpdateOptions options = null,
        CancellationToken cancellationToken = default)
    {
        return _collection.UpdateMany(session, expression,
            update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
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
    public UpdateResult DynamicCollectionUpdateMany<TForeign>(
        TForeign foreignDocument,
        FilterDefinition<T> filter,
        UpdateDefinition<T> update,
        MongoCollectionSettings settings = null,
        UpdateOptions options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).UpdateMany(filter,
            update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
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
    public UpdateResult DynamicCollectionUpdateMany<TForeign>(
        IClientSessionHandle session,
        TForeign foreignDocument,
        FilterDefinition<T> filter,
        UpdateDefinition<T> update,
        MongoCollectionSettings settings = null,
        UpdateOptions options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).UpdateMany(session, filter,
            update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
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
    public UpdateResult DynamicCollectionUpdateMany<TForeign>(
        TForeign foreignDocument,
        Expression<Func<T, bool>> expression,
        UpdateDefinition<T> update,
        MongoCollectionSettings settings = null,
        UpdateOptions options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).UpdateMany(expression,
            update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
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
    public UpdateResult DynamicCollectionUpdateMany<TForeign>(
        IClientSessionHandle session,
        TForeign foreignDocument,
        Expression<Func<T, bool>> expression,
        UpdateDefinition<T> update,
        MongoCollectionSettings settings = null,
        UpdateOptions options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).UpdateMany(session, expression,
            update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
    }

    #endregion

}

