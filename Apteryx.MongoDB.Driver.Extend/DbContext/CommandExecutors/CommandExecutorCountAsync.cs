using System;
using MongoDB.Driver;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Apteryx.MongoDB.Driver.Extend;
public partial class CommandExecutor<T>
{
    #region 计数（异步）

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">文档类型</typeparam>
    /// <param name="filter">过滤器</param>
    /// <param name="options">计数选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public Task<long> CountDocumentsAsync(FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default)
    {
        return _collection.CountDocumentsAsync(filter, options, cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">文档类型</typeparam>
    /// <param name="session">客户端会话句柄</param>
    /// <param name="filter">过滤器</param>
    /// <param name="options">计数选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public Task<long> CountDocumentsAsync(IClientSessionHandle session, FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default)
    {
        return _collection.CountDocumentsAsync(session, filter, options, cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="filter">过滤器</param>
    /// <param name="options">计数选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public Task<long> CountDocumentsAsync(Expression<Func<T, bool>> expression, CountOptions options = null, CancellationToken cancellationToken = default)
    {
        return _collection.CountDocumentsAsync(expression, options, cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="session">会话句柄(作用于事务)</param>
    /// <param name="filter">过滤器</param>
    /// <param name="options">计数选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public Task<long> CountDocumentsAsync(IClientSessionHandle session, Expression<Func<T, bool>> expression, CountOptions options = null, CancellationToken cancellationToken = default)
    {
        return _collection.CountDocumentsAsync(session, expression, options, cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="foreignDocument">文档对象</param>
    /// <param name="filter">过滤器</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">计数选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public Task<long> DynamicCollectionCountDocumentsAsync<TForeign>(
        TForeign foreignDocument,
        FilterDefinition<T> filter,
        MongoCollectionSettings settings = null,
        CountOptions options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).CountDocumentsAsync(filter, options, cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="foreignDocument">文档对象</param>
    /// <param name="session">客户端会话句柄</param>
    /// <param name="filter">过滤器</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">计数选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public Task<long> DynamicCollectionCountDocumentsAsync<TForeign>(
        IClientSessionHandle session,
        TForeign foreignDocument,
        FilterDefinition<T> filter,
        MongoCollectionSettings settings = null,
        CountOptions options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).CountDocumentsAsync(session, filter, options, cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="foreignDocument">文档对象</param>
    /// <param name="expression">过滤器</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">计数选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public Task<long> DynamicCollectionCountDocumentsAsync<TForeign>(
        TForeign foreignDocument,
        Expression<Func<T, bool>> expression,
        MongoCollectionSettings settings = null,
        CountOptions options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).CountDocumentsAsync(expression, options, cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="foreignDocument">文档对象</param>
    /// <param name="session">客户端会话句柄</param>
    /// <param name="expression">过滤器</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">计数选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public Task<long> DynamicCollectionCountDocumentsAsync<TForeign>(
        IClientSessionHandle session,
        TForeign foreignDocument,
        Expression<Func<T, bool>> expression,
        MongoCollectionSettings settings = null,
        CountOptions options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).CountDocumentsAsync(session, expression, options, cancellationToken);
    }

    #endregion
}
