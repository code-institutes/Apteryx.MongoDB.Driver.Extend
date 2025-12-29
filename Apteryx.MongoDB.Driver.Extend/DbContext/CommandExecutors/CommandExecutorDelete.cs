using System;
using MongoDB.Driver;
using System.Threading;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Apteryx.MongoDB.Driver.Extend;

public partial class CommandExecutor<T>
{
    #region 删除（同步）

    /// <summary>
    /// 删除（单个）
    /// </summary>
    /// <param name="id">文档对象ID</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    public DeleteResult DeleteOne(string id, DeleteOptions options = null, CancellationToken cancellationToken = default)
    {
        return _collection.DeleteOne(d => d.Id == id, options, cancellationToken);
    }

    /// <summary>
    /// 删除（单个）
    /// </summary>
    /// <param name="session">会话句柄(作用于事务)</param>
    /// <param name="id">文档对象ID</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    public DeleteResult DeleteOne(IClientSessionHandle session, string id, DeleteOptions options = null, CancellationToken cancellationToken = default)
    {
        return _collection.DeleteOne(session, d => d.Id == id, options, cancellationToken);
    }

    /// <summary>
    /// 删除（单个）
    /// </summary>
    /// <param name="document">文档对象</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    public DeleteResult DeleteOne(T document, DeleteOptions options = null, CancellationToken cancellationToken = default)
    {
        return _collection.DeleteOne(d => d.Id == document.Id, options, cancellationToken);
    }

    /// <summary>
    /// 删除（单个）
    /// </summary>
    /// <param name="session">会话句柄(作用于事务)</param>
    /// <param name="document">文档对象</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    public DeleteResult DeleteOne(IClientSessionHandle session, T document, DeleteOptions options = null, CancellationToken cancellationToken = default)
    {
        return _collection.DeleteOne(session, d => d.Id == document.Id, options, cancellationToken);
    }

    /// <summary>
    /// 删除（单个）
    /// </summary>
    /// <param name="filter">过滤器</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    public DeleteResult DeleteOne(FilterDefinition<T> filter, DeleteOptions options = null, CancellationToken cancellationToken = default)
    {
        return _collection.DeleteOne(filter, options, cancellationToken);
    }

    /// <summary>
    /// 删除（单个）
    /// </summary>
    /// <param name="session">会话句柄(作用于事务)</param>
    /// <param name="filter">过滤器</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    public DeleteResult DeleteOne(IClientSessionHandle session, FilterDefinition<T> filter, DeleteOptions options = null, CancellationToken cancellationToken = default)
    {
        return _collection.DeleteOne(session, filter, options, cancellationToken);
    }

    /// <summary>
    /// 删除（单个）
    /// </summary>
    /// <param name="expression">Lambda过滤器</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    public DeleteResult DeleteOne(Expression<Func<T, bool>> expression, DeleteOptions options = null, CancellationToken cancellationToken = default)
    {
        return _collection.DeleteOne(expression, options, cancellationToken);
    }

    /// <summary>
    /// 删除（单个）
    /// </summary>
    /// <param name="session">会话句柄(作用于事务)</param>
    /// <param name="expression">Lambda过滤器</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    public DeleteResult DeleteOne(IClientSessionHandle session, Expression<Func<T, bool>> expression, DeleteOptions options = null, CancellationToken cancellationToken = default)
    {
        return _collection.DeleteOne(session, expression, options, cancellationToken);
    }

    /// <summary>
    /// 查询并删除（单个）
    /// </summary>
    /// <param name="id">文档对象ID</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public T FindOneAndDelete(string id, FindOneAndDeleteOptions<T> options = null, CancellationToken cancellationToken = default)
    {
        return _collection.FindOneAndDelete<T>(f => f.Id == id, options, cancellationToken);
    }

    /// <summary>
    /// 查询并删除（单个）
    /// </summary>
    /// <param name="session">会话句柄(作用于事务)</param>
    /// <param name="id">文档对象ID</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public T FindOneAndDelete(IClientSessionHandle session, string id, FindOneAndDeleteOptions<T> options = null, CancellationToken cancellationToken = default)
    {
        return _collection.FindOneAndDelete<T>(session, f => f.Id == id, options, cancellationToken);
    }

    /// <summary>
    /// 查询并删除（单个）
    /// </summary>
    /// <param name="filter">过滤器</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public T FindOneAndDelete(FilterDefinition<T> filter, FindOneAndDeleteOptions<T> options = null, CancellationToken cancellationToken = default)
    {
        return _collection.FindOneAndDelete(filter, options, cancellationToken);
    }

    /// <summary>
    /// 查询并删除（单个）
    /// </summary>
    /// <param name="session">会话句柄(作用于事务)</param>
    /// <param name="filter">过滤器</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public T FindOneAndDelete(IClientSessionHandle session, FilterDefinition<T> filter, FindOneAndDeleteOptions<T> options = null, CancellationToken cancellationToken = default)
    {
        return _collection.FindOneAndDelete(session, filter, options, cancellationToken);
    }

    /// <summary>
    /// 查询并删除（单个）
    /// </summary>
    /// <param name="expression">Lambda过滤器</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public T FindOneAndDelete(Expression<Func<T, bool>> expression, FindOneAndDeleteOptions<T> options = null, CancellationToken cancellationToken = default)
    {
        return _collection.FindOneAndDelete(expression, options, cancellationToken);
    }

    /// <summary>
    /// 查询并删除（单个）
    /// </summary>
    /// <param name="session">会话句柄(作用于事务)</param>
    /// <param name="expression">Lambda过滤器</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public T FindOneAndDelete(IClientSessionHandle session, Expression<Func<T, bool>> expression, FindOneAndDeleteOptions<T> options = null, CancellationToken cancellationToken = default)
    {
        return _collection.FindOneAndDelete(session, expression, options, cancellationToken);
    }

    /// <summary>
    /// 动态查询并删除（单个）
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="foreignDocument">上级文档</param>
    /// <param name="id">文档对象ID</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public T DynamicCollectionFindOneAndDelete<TForeign>(
        TForeign foreignDocument,
        string id,
        MongoCollectionSettings settings = null,
        FindOneAndDeleteOptions<T> options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindOneAndDelete<T>(d => d.Id == id, options, cancellationToken);
    }

    /// <summary>
    /// 动态查询并删除（单个）
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="session">会话句柄(作用于事务)</param>
    /// <param name="foreignDocument">上级文档</param>
    /// <param name="id">文档对象ID</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public T DynamicCollectionFindOneAndDelete<TForeign>(
        IClientSessionHandle session,
        TForeign foreignDocument,
        string id,
        MongoCollectionSettings settings = null,
        FindOneAndDeleteOptions<T> options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindOneAndDelete<T>(session, d => d.Id == id, options, cancellationToken);
    }

    /// <summary>
    /// 动态查询并删除（单个）
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="foreignDocument">上级文档</param>
    /// <param name="filter">过滤器</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public T DynamicCollectionFindOneAndDelete<TForeign>(
        TForeign foreignDocument,
        FilterDefinition<T> filter,
        MongoCollectionSettings settings = null,
        FindOneAndDeleteOptions<T> options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindOneAndDelete<T>(filter, options, cancellationToken);
    }

    /// <summary>
    /// 动态查询并删除（单个）
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="session">会话句柄(作用于事务)</param>
    /// <param name="foreignDocument">上级文档</param>
    /// <param name="filter">过滤器</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public T DynamicCollectionFindOneAndDelete<TForeign>(
        IClientSessionHandle session,
        TForeign foreignDocument,
        FilterDefinition<T> filter,
        MongoCollectionSettings settings = null,
        FindOneAndDeleteOptions<T> options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindOneAndDelete<T>(session, filter, options, cancellationToken);
    }

    /// <summary>
    /// 动态查询并删除（单个）
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="foreignDocument">上级文档</param>
    /// <param name="expression">Lambda表达式</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public T DynamicCollectionFindOneAndDelete<TForeign>(
        TForeign foreignDocument,
        Expression<Func<T, bool>> expression,
        MongoCollectionSettings settings = null,
        FindOneAndDeleteOptions<T> options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindOneAndDelete<T>(expression, options, cancellationToken);
    }

    /// <summary>
    /// 动态查询并删除（单个）
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="session">会话句柄(作用于事务)</param>
    /// <param name="foreignDocument">上级文档</param>
    /// <param name="expression">Lambda表达式</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public T DynamicCollectionFindOneAndDelete<TForeign>(
        IClientSessionHandle session,
        TForeign foreignDocument,
        Expression<Func<T, bool>> expression,
        MongoCollectionSettings settings = null,
        FindOneAndDeleteOptions<T> options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindOneAndDelete<T>(session, expression, options, cancellationToken);
    }

    /// <summary>
    /// 删除（批量）
    /// </summary>
    /// <param name="documents">文档对象</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    public List<DeleteResult> DeleteMany(IEnumerable<T> documents, DeleteOptions options = null, CancellationToken cancellationToken = default)
    {
        var results = new List<DeleteResult>();
        foreach (var document in documents)
        {
            var result = _collection.DeleteOne(d => d.Id == document.Id, options, cancellationToken);
            results.Add(result);
        }
        return results;
    }

    /// <summary>
    /// 删除（批量）
    /// </summary>
    /// <param name="session">会话句柄(作用于事务)</param>
    /// <param name="documents">文档对象</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    public List<DeleteResult> DeleteMany(IClientSessionHandle session, IEnumerable<T> documents, DeleteOptions options = null, CancellationToken cancellationToken = default)
    {
        var results = new List<DeleteResult>();
        foreach (var document in documents)
        {
            var result = _collection.DeleteOne(session, d => d.Id == document.Id, options, cancellationToken);
            results.Add(result);
        }
        return results;
    }

    /// <summary>
    /// 删除（批量）
    /// </summary>
    /// <param name="filter">过滤器</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    public DeleteResult DeleteMany(FilterDefinition<T> filter, DeleteOptions options = null, CancellationToken cancellationToken = default)
    {
        return _collection.DeleteMany(filter, options, cancellationToken);
    }

    /// <summary>
    /// 删除（批量）
    /// </summary>
    /// <param name="session">会话句柄(作用于事务)</param>
    /// <param name="filter">过滤器</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    public DeleteResult DeleteMany(IClientSessionHandle session, FilterDefinition<T> filter, DeleteOptions options = null, CancellationToken cancellationToken = default)
    {
        return _collection.DeleteMany(session, filter, options, cancellationToken);
    }

    /// <summary>
    /// 删除（批量）
    /// </summary>
    /// <param name="expression">Lambda过滤器</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    public DeleteResult DeleteMany(Expression<Func<T, bool>> expression, DeleteOptions options = null, CancellationToken cancellationToken = default)
    {
        return _collection.DeleteMany(expression, options, cancellationToken);
    }

    /// <summary>
    /// 删除（批量）
    /// </summary>
    /// <param name="session">会话句柄(作用于事务)</param>
    /// <param name="expression">Lambda过滤器</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    public DeleteResult DeleteMany(IClientSessionHandle session, Expression<Func<T, bool>> expression, DeleteOptions options = null, CancellationToken cancellationToken = default)
    {
        return _collection.DeleteMany(session, expression, options, cancellationToken);
    }

    /// <summary>
    /// 根据主文档的默认id动态的删除附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="foreignDocument">上级文档</param>
    /// <param name="id">文档对象ID</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    public DeleteResult DynamicCollectionDeleteOne<TForeign>(
        TForeign foreignDocument,
        string id,
        MongoCollectionSettings settings = null,
        DeleteOptions options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).DeleteOne(d => d.Id == id, options, cancellationToken);
    }

    /// <summary>
    /// 根据主文档的默认id动态的删除附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="session">会话句柄(作用于事务)</param>
    /// <param name="foreignDocument">上级文档</param>
    /// <param name="id">文档对象ID</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    public DeleteResult DynamicCollectionDeleteOne<TForeign>(
        IClientSessionHandle session,
        TForeign foreignDocument,
        string id,
        MongoCollectionSettings settings = null,
        DeleteOptions options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).DeleteOne(session, d => d.Id == id, options, cancellationToken);
    }

    /// <summary>
    /// 根据主文档的默认id动态的删除附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="foreignDocument">上级文档</param>
    /// <param name="document">文档对象</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    public DeleteResult DynamicCollectionDeleteOne<TForeign>(
        TForeign foreignDocument,
        T document,
        MongoCollectionSettings settings = null,
        DeleteOptions options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).DeleteOne(d => d.Id == document.Id, options, cancellationToken);
    }

    /// <summary>
    /// 根据主文档的默认id动态的删除附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="session">会话句柄(作用于事务)</param>
    /// <param name="foreignDocument">上级文档</param>
    /// <param name="document">文档对象</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    public DeleteResult DynamicCollectionDeleteOne<TForeign>(
        IClientSessionHandle session,
        TForeign foreignDocument,
        T document,
        MongoCollectionSettings settings = null,
        DeleteOptions options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).DeleteOne(session, d => d.Id == document.Id, options, cancellationToken);
    }

    /// <summary>
    /// 根据主文档的默认id动态的删除附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="foreignDocument">上级文档</param>
    /// <param name="filter">过滤器</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    public DeleteResult DynamicCollectionDeleteOne<TForeign>(
        TForeign foreignDocument,
        FilterDefinition<T> filter,
        MongoCollectionSettings settings = null,
        DeleteOptions options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).DeleteOne(filter, options, cancellationToken);
    }

    /// <summary>
    /// 根据主文档的默认id动态的删除附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="session">会话句柄(作用于事务)</param>
    /// <param name="foreignDocument">上级文档</param>
    /// <param name="filter">过滤器</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    public DeleteResult DynamicCollectionDeleteOne<TForeign>(
        IClientSessionHandle session,
        TForeign foreignDocument,
        FilterDefinition<T> filter,
        MongoCollectionSettings settings = null,
        DeleteOptions options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).DeleteOne(session, filter, options, cancellationToken);
    }

    /// <summary>
    /// 根据主文档的默认id动态的删除附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="foreignDocument">上级文档</param>
    /// <param name="expression">Lambda过滤器</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    public DeleteResult DynamicCollectionDeleteOne<TForeign>(
        TForeign foreignDocument,
        Expression<Func<T, bool>> expression,
        MongoCollectionSettings settings = null,
        DeleteOptions options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).DeleteOne(expression, options, cancellationToken);
    }

    /// <summary>
    /// 根据主文档的默认id动态的删除附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="session">会话句柄(作用于事务)</param>
    /// <param name="foreignDocument">上级文档</param>
    /// <param name="expression">Lambda过滤器</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    public DeleteResult DynamicCollectionDeleteOne<TForeign>(
        IClientSessionHandle session,
        TForeign foreignDocument,
        Expression<Func<T, bool>> expression,
        MongoCollectionSettings settings = null,
        DeleteOptions options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).DeleteOne(session, expression, options, cancellationToken);
    }

    /// <summary>
    /// 根据主文档的默认id动态的删除附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="foreignDocument">上级文档</param>
    /// <param name="documents">文档对象</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    public List<DeleteResult> DynamicCollectionDeleteMany<TForeign>(
        TForeign foreignDocument,
        IEnumerable<T> documents,
        MongoCollectionSettings settings = null,
        DeleteOptions options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        var results = new List<DeleteResult>();
        foreach (var document in documents)
        {
            var result = _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).DeleteOne(d => d.Id == document.Id, options, cancellationToken);
            results.Add(result);
        }

        return results;
    }

    /// <summary>
    /// 根据主文档的默认id动态的删除附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="session">会话句柄(作用于事务)</param>
    /// <param name="foreignDocument">上级文档</param>
    /// <param name="documents">文档对象</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    public List<DeleteResult> DynamicCollectionDeleteMany<TForeign>(
        IClientSessionHandle session,
        TForeign foreignDocument,
        IEnumerable<T> documents,
        MongoCollectionSettings settings = null,
        DeleteOptions options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        var results = new List<DeleteResult>();
        foreach (var document in documents)
        {
            var result = _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).DeleteOne(session, d => d.Id == document.Id, options, cancellationToken);
            results.Add(result);
        }
        return results;
    }

    /// <summary>
    /// 根据主文档的默认id动态的删除附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="foreignDocument">上级文档</param>
    /// <param name="filter">过滤器</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    public DeleteResult DynamicCollectionDeleteMany<TForeign>(
        TForeign foreignDocument,
        FilterDefinition<T> filter,
        MongoCollectionSettings settings = null,
        DeleteOptions options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).DeleteMany(filter, options, cancellationToken);

    }

    /// <summary>
    /// 根据主文档的默认id动态的删除附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="session">会话句柄(作用于事务)</param>
    /// <param name="foreignDocument">上级文档</param>
    /// <param name="filter">过滤器</param>
    /// <param name="settings"></param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    public DeleteResult DynamicCollectionDeleteMany<TForeign>(
        IClientSessionHandle session,
        TForeign foreignDocument,
        FilterDefinition<T> filter,
        MongoCollectionSettings settings = null,
        DeleteOptions options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).DeleteMany(session, filter, options, cancellationToken);
    }

    /// <summary>
    /// 根据主文档的默认id动态的删除附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="foreignDocument">上级文档</param>
    /// <param name="expression">Lambda过滤器</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    public DeleteResult DynamicCollectionDeleteMany<TForeign>(
        TForeign foreignDocument,
        Expression<Func<T, bool>> expression,
        MongoCollectionSettings settings = null,
        DeleteOptions options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).DeleteMany(expression, options, cancellationToken);

    }

    /// <summary>
    /// 根据主文档的默认id动态的删除附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="session">会话句柄(作用于事务)</param>
    /// <param name="foreignDocument">上级文档</param>
    /// <param name="expression">Lambda过滤器</param>
    /// <param name="settings"></param>
    /// <param name="options">删除操作选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    public DeleteResult DynamicCollectionDeleteMany<TForeign>(
        IClientSessionHandle session,
        TForeign foreignDocument,
        Expression<Func<T, bool>> expression,
        MongoCollectionSettings settings = null,
        DeleteOptions options = null,
        CancellationToken cancellationToken = default)
        where TForeign : BaseMongoEntity
    {
        return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).DeleteMany(session, expression, options, cancellationToken);
    }

    #endregion
}
