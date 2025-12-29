using System;
using System.Linq;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Apteryx.MongoDB.Driver.Extend;

public partial class CommandExecutor<T>
{
    #region 查询(异步)

    /// <summary>
    /// 查询返回（单个）
    /// </summary>
    /// <param name="id">文档默认ID</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">查找操作设置</param>
    /// <returns></returns>
    public async Task<T> FindOneAsync(string id, FindOptions<T> options = null)
    {
        var cursor = await _collection.FindAsync(f => f.Id == id, options);
        await cursor.MoveNextAsync();
        return cursor.Current.FirstOrDefault();
    }

    /// <summary>
    /// 查询返回（单个）
    /// </summary>
    /// <param name="session">会话句柄(作用于事务)</param>
    /// <param name="id">文档默认ID</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">查找操作设置</param>
    /// <returns></returns>
    public async Task<T> FindOneAsync(IClientSessionHandle session, string id, FindOptions<T> options = null)
    {
        var cursor = await _collection.FindAsync(session, f => f.Id == id, options);
        await cursor.MoveNextAsync();
        return cursor.Current.FirstOrDefault();
    }

    /// <summary>
    /// 查询返回（单个）
    /// </summary>
    /// <param name="filter">过滤器</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">查找操作设置</param>
    /// <returns></returns>
    public async Task<T> FindOneAsync(FilterDefinition<T> filter, FindOptions<T> options = null)
    {
        var cursor = await _collection.FindAsync(filter, options);
        await cursor.MoveNextAsync();
        return cursor.Current.FirstOrDefault();
    }

    /// <summary>
    /// 查询返回（单个）
    /// </summary>
    /// <param name="session">会话句柄(作用于事务)</param>
    /// <param name="filter">过滤器</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">查找操作设置</param>
    /// <returns></returns>
    public async Task<T> FindOneAsync(IClientSessionHandle session, FilterDefinition<T> filter, FindOptions<T> options = null)
    {
        var cursor = await _collection.FindAsync(session, filter, options);
        await cursor.MoveNextAsync();
        return cursor.Current.FirstOrDefault();
    }

    /// <summary>
    /// 查询返回（单个）
    /// </summary>
    /// <param name="expression">Lambda过滤器</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">查找操作设置</param>
    /// <returns></returns>
    public async Task<T> FindOneAsync(Expression<Func<T, bool>> expression, FindOptions<T> options = null)
    {
        var cursor = await _collection.FindAsync(expression, options);
        await cursor.MoveNextAsync();
        return cursor.Current.FirstOrDefault();
    }

    /// <summary>
    /// 查询返回（单个）
    /// </summary>
    /// <param name="session">会话句柄(作用于事务)</param>
    /// <param name="expression">Lambda过滤器</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">查找操作设置</param>
    /// <returns></returns>
    public async Task<T> FindOneAsync(IClientSessionHandle session, Expression<Func<T, bool>> expression, FindOptions<T> options = null)
    {
        var cursor = await _collection.FindAsync(session, expression, options);
        await cursor.MoveNextAsync();
        return cursor.Current.FirstOrDefault();
    }

    /// <summary>
    /// 查询返回（单个）
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="foreignDocument">文档对象</param>
    /// <param name="id">文档默认ID</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">查找操作设置</param>
    /// <returns></returns>
    public async Task<T> DynamicCollectionFindOneAsync<TForeign>(
        TForeign foreignDocument,
        string id,
        MongoCollectionSettings settings = null,
        FindOptions<T> options = null)
        where TForeign : BaseMongoEntity
    {
        var cursor = await _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindAsync(f => f.Id == id, options);
        await cursor.MoveNextAsync();
        return cursor.Current.FirstOrDefault();
    }

    /// <summary>
    /// 查询返回（单个）
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="foreignDocument">文档对象</param>
    /// <param name="id">文档默认ID</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">查找操作设置</param>
    /// <returns></returns>
    public async Task<T> DynamicCollectionFindOneAsync<TForeign>(
        IClientSessionHandle session,
        TForeign foreignDocument,
        string id,
        MongoCollectionSettings settings = null,
        FindOptions<T> options = null)
        where TForeign : BaseMongoEntity
    {
        var cursor = await _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindAsync(session, f => f.Id == id, options);
        await cursor.MoveNextAsync();
        return cursor.Current.FirstOrDefault();
    }

    /// <summary>
    /// 查询返回（单个）
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="foreignDocument">文档对象</param>
    /// <param name="filter">过滤器</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">查找操作设置</param>
    /// <returns></returns>
    public async Task<T> DynamicCollectionFindOneAsync<TForeign>(
        TForeign foreignDocument,
        FilterDefinition<T> filter,
        MongoCollectionSettings settings = null,
        FindOptions<T> options = null)
        where TForeign : BaseMongoEntity
    {
        var cursor = await _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindAsync(filter, options);
        await cursor.MoveNextAsync();
        return cursor.Current.FirstOrDefault();
    }

    /// <summary>
    /// 查询返回（单个）
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="foreignDocument">文档对象</param>
    /// <param name="filter">过滤器</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">查找操作设置</param>
    /// <returns></returns>
    public async Task<T> DynamicCollectionFindOneAsync<TForeign>(
        IClientSessionHandle session,
        TForeign foreignDocument,
        FilterDefinition<T> filter,
        MongoCollectionSettings settings = null,
        FindOptions<T> options = null)
        where TForeign : BaseMongoEntity
    {
        var cursor = await _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindAsync(session, filter, options);
        await cursor.MoveNextAsync();
        return cursor.Current.FirstOrDefault();
    }

    /// <summary>
    /// 查询返回（单个）
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="foreignDocument">文档对象</param>
    /// <param name="expression">Lambda过滤器</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">查找操作设置</param>
    /// <returns></returns>
    public async Task<T> DynamicCollectionFindOneAsync<TForeign>(
        TForeign foreignDocument,
        Expression<Func<T, bool>> expression,
        MongoCollectionSettings settings = null,
        FindOptions<T> options = null)
        where TForeign : BaseMongoEntity
    {
        var cursor = await _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindAsync(expression, options);
        await cursor.MoveNextAsync();
        return cursor.Current.FirstOrDefault();
    }

    /// <summary>
    /// 查询返回（单个）
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="foreignDocument">文档对象</param>
    /// <param name="expression">Lambda过滤器</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">查找操作设置</param>
    /// <returns></returns>
    public async Task<T> DynamicCollectionFindOneAsync<TForeign>(
        IClientSessionHandle session,
        TForeign foreignDocument,
        Expression<Func<T, bool>> expression,
        MongoCollectionSettings settings = null,
        FindOptions<T> options = null)
        where TForeign : BaseMongoEntity
    {
        var cursor = await _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindAsync(session, expression, options);
        await cursor.MoveNextAsync();
        return cursor.Current.FirstOrDefault();
    }

    /// <summary>
    /// 查询全部
    /// </summary>
    /// <param name="settings">集合设置</param>
    /// <param name="options">查找操作设置</param>
    /// <returns></returns>
    public async IAsyncEnumerable<T> FindAllAsync(FindOptions<T> options = null)
    {
        using (var cursor = await _collection.FindAsync(_ => true, options))
        {
            while (await cursor.MoveNextAsync())
            {
                foreach (var user in cursor.Current)
                {
                    yield return user;
                }
            }
        }
    }

    /// <summary>
    /// 查询全部
    /// </summary>
    /// <param name="session">会话句柄(作用于事务)</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">查找操作设置</param>
    /// <returns></returns>
    public async IAsyncEnumerable<T> FindAllAsync(IClientSessionHandle session, FindOptions<T> options = null)
    {
        using (var cursor = await _collection.FindAsync(session, _ => true, options))
        {
            while (await cursor.MoveNextAsync())
            {
                foreach (var user in cursor.Current)
                {
                    yield return user;
                }
            }
        }
    }

    /// <summary>
    /// 查询全部
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="foreignDocument">文档对象</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">查找操作设置</param>
    /// <returns></returns>
    public async IAsyncEnumerable<T> DynamicCollectionFindAllAsync<TForeign>(TForeign foreignDocument, MongoCollectionSettings settings = null, FindOptions<T> options = null)
        where TForeign : BaseMongoEntity
    {
        using (var cusor = await _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindAsync(_ => true, options))
        {
            while (await cusor.MoveNextAsync())
            {
                foreach (var user in cusor.Current)
                {
                    yield return user;
                }
            }
        }
    }

    /// <summary>
    /// 查询全部
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="session">会话句柄(作用于事务)</param>
    /// <param name="foreignDocument">文档对象</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">查找操作设置</param>
    /// <returns></returns>
    public async IAsyncEnumerable<T> DynamicCollectionFindAllAsync<TForeign>(IClientSessionHandle session, TForeign foreignDocument, MongoCollectionSettings settings = null, FindOptions<T> options = null)
        where TForeign : BaseMongoEntity

    {
        using (var cusor = await _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindAsync(session, _ => true, options))
        {
            while (await cusor.MoveNextAsync())
            {
                foreach (var user in cusor.Current)
                {
                    yield return user;
                }
            }
        }
    }

    /// <summary>
    /// 查询返回集合
    /// </summary>
    /// <param name="filter">过滤器</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">查找操作设置</param>
    /// <returns></returns>
    public async IAsyncEnumerable<T> FindAsync(FilterDefinition<T> filter, FindOptions<T> options = null)
    {
        using (var cursor = await _collection.FindAsync(filter, options))
        {
            while (await cursor.MoveNextAsync())
            {
                foreach (var user in cursor.Current)
                {
                    yield return user;
                }
            }
        }
    }

    /// <summary>
    /// 查询返回集合
    /// </summary>
    /// <param name="session">会话句柄(作用于事务)</param>
    /// <param name="filter">过滤器</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">查找操作设置</param>
    /// <returns></returns>
    public async IAsyncEnumerable<T> FindAsync(IClientSessionHandle session, FilterDefinition<T> filter, FindOptions<T> options = null)
    {
        using (var cursor = await _collection.FindAsync(session, filter, options))
        {
            while (await cursor.MoveNextAsync())
            {
                foreach (var user in cursor.Current)
                {
                    yield return user;
                }
            }
        }
    }

    /// <summary>
    /// 查询返回集合
    /// </summary>
    /// <param name="expression">Lambda过滤器</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">查找操作设置</param>
    /// <returns></returns>
    public async IAsyncEnumerable<T> FindAsync(Expression<Func<T, bool>> expression, FindOptions<T> options = null)
    {
        using (var cursor = await _collection.FindAsync(expression, options))
        {
            while (await cursor.MoveNextAsync())
            {
                foreach (var user in cursor.Current)
                {
                    yield return user;
                }
            }
        }
    }

    /// <summary>
    /// 查询返回集合
    /// </summary>
    /// <param name="session">会话句柄(作用于事务)</param>
    /// <param name="expression">Lambda过滤器</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">查找操作设置</param>
    /// <returns></returns>
    public async IAsyncEnumerable<T> FindAsync(IClientSessionHandle session, Expression<Func<T, bool>> expression, FindOptions<T> options = null)
    {
        using (var cursor = await _collection.FindAsync(session, expression, options))
        {
            while (await cursor.MoveNextAsync())
            {
                foreach (var user in cursor.Current)
                {
                    yield return user;
                }
            }
        }
    }

    /// <summary>
    /// 查询返回集合
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="foreignDocument">文档对象</param>
    /// <param name="filter">过滤器</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">查找操作设置</param>
    /// <returns></returns>
    public async IAsyncEnumerable<T> DynamicCollectionFindAsync<TForeign>(
        TForeign foreignDocument,
        FilterDefinition<T> filter,
        MongoCollectionSettings settings = null,
        FindOptions<T> options = null)
        where TForeign : BaseMongoEntity
    {
        using (var cusor = await _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindAsync(filter, options))
        {
            while (await cusor.MoveNextAsync())
            {
                foreach (var user in cusor.Current)
                {
                    yield return user;
                }
            }
        }
    }

    /// <summary>
    /// 查询返回集合
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="session">会话句柄(作用于事务)</param>
    /// <param name="foreignDocument">文档对象</param>
    /// <param name="filter">过滤器</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">查找操作设置</param>
    /// <returns></returns>
    public async IAsyncEnumerable<T> DynamicCollectionFindAsync<TForeign>(
        IClientSessionHandle session,
        TForeign foreignDocument,
        FilterDefinition<T> filter,
        MongoCollectionSettings settings = null,
        FindOptions<T> options = null)
        where TForeign : BaseMongoEntity
    {
        using (var cusor = await _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindAsync(session, filter, options))
        {
            while (await cusor.MoveNextAsync())
            {
                foreach (var user in cusor.Current)
                {
                    yield return user;
                }
            }
        }
    }

    /// <summary>
    /// 查询返回集合
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="foreignDocument">文档对象</param>
    /// <param name="expression">Lambda过滤器</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">查找操作设置</param>
    /// <returns></returns>
    public async IAsyncEnumerable<T> DynamicCollectionFindAsync<TForeign>(
        TForeign foreignDocument,
        Expression<Func<T, bool>> expression,
        MongoCollectionSettings settings = null,
        FindOptions<T> options = null)
        where TForeign : BaseMongoEntity
    {
        using (var cusor = await _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindAsync(expression, options))
        {
            while (await cusor.MoveNextAsync())
            {
                foreach (var user in cusor.Current)
                {
                    yield return user;
                }
            }
        }
    }

    /// <summary>
    /// 查询返回集合
    /// </summary>
    /// <typeparam name="TForeign">文档类型</typeparam>
    /// <param name="session">会话句柄(作用于事务)</param>
    /// <param name="foreignDocument">文档对象</param>
    /// <param name="expression">Lambda过滤器</param>
    /// <param name="settings">集合设置</param>
    /// <param name="options">查找操作设置</param>
    /// <returns></returns>
    public async IAsyncEnumerable<T> DynamicCollectionFindAsync<TForeign>(
        IClientSessionHandle session,
        TForeign foreignDocument,
        Expression<Func<T, bool>> expression,
        MongoCollectionSettings settings = null,
        FindOptions<T> options = null)
        where TForeign : BaseMongoEntity
    {
        using (var cusor = await _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindAsync(session, expression, options))
        {
            while (await cusor.MoveNextAsync())
            {
                foreach (var user in cusor.Current)
                {
                    yield return user;
                }
            }
        }
    }

    #endregion
}
