using System;
using MongoDB.Driver;
using System.Threading;
using System.Linq.Expressions;

namespace Apteryx.MongoDB.Driver.Extend;
public partial class ImmediateExecutor<T>
{
    #region 计数（同步）

    /// <summary>
    /// 计数
    /// </summary>
    /// <param name="filter">过滤器</param>
    /// <param name="options">计数选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public long CountDocuments(FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default)
    {
        return _collection.CountDocuments(filter, options, cancellationToken);
    }

    /// <summary>
    /// 计数
    /// </summary>
    /// <param name="session">会话句柄(作用于事务)</param>
    /// <param name="filter">过滤器</param>
    /// <param name="options">计数选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public long CountDocuments(IClientSessionHandle session, FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default)
    {
        return _collection.CountDocuments(session, filter, options, cancellationToken);
    }

    /// <summary>
    /// 计数
    /// </summary>
    /// <param name="expression">Lambda过滤器</param>
    /// <param name="options">计数选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public long CountDocuments(Expression<Func<T, bool>> expression, CountOptions options = null, CancellationToken cancellationToken = default)
    {
        return _collection.CountDocuments(expression, options, cancellationToken);
    }

    /// <summary>
    /// 计数
    /// </summary>
    /// <param name="session">会话句柄(作用于事务)</param>
    /// <param name="expression">Lambda过滤器</param>
    /// <param name="options">计数选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public long CountDocuments(IClientSessionHandle session, Expression<Func<T, bool>> expression, CountOptions options = null, CancellationToken cancellationToken = default)
    {
        return _collection.CountDocuments(session, expression, options, cancellationToken);
    }

    /// <summary>
    /// 计数
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="foreignDocument">文档对象</param>
    /// <param name="filter">过滤器</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">计数选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public long DynamicCollectionCountDocuments<TForeign>(
        TForeign foreignDocument,
        FilterDefinition<T> filter,
        MongoCollectionSettings settings = null,
        CountOptions options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).CountDocuments(filter, options, cancellationToken);
    }

    /// <summary>
    /// 计数
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="session">会话句柄(作用于事务)</param>
    /// <param name="foreignDocument">文档对象</param>
    /// <param name="filter">过滤器</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">计数选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public long DynamicCollectionCountDocuments<TForeign>(
        IClientSessionHandle session,
        TForeign foreignDocument,
        FilterDefinition<T> filter,
        MongoCollectionSettings settings = null,
        CountOptions options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).CountDocuments(session, filter, options, cancellationToken);
    }

    /// <summary>
    /// 计数
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="foreignDocument">文档对象</param>
    /// <param name="expression">Lambda过滤器</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">计数选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public long DynamicCollectionCountDocuments<TForeign>(
        TForeign foreignDocument,
        Expression<Func<T, bool>> expression,
        MongoCollectionSettings settings = null,
        CountOptions options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).CountDocuments(expression, options, cancellationToken);
    }

    /// <summary>
    /// 计数
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="session">会话句柄(作用于事务)</param>
    /// <param name="foreignDocument">文档对象</param>
    /// <param name="expression">Lambda过滤器</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">计数选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public long DynamicCollectionCountDocuments<TForeign>(
        IClientSessionHandle session,
        TForeign foreignDocument,
        Expression<Func<T, bool>> expression,
        MongoCollectionSettings settings = null,
        CountOptions options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).CountDocuments(session, expression, options, cancellationToken);
    }

    #endregion
}