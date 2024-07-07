using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Apteryx.MongoDB.Driver.Extend
{
    public partial class DbSet<T>
    {
        #region 查询(异步)

        /// <summary>
        /// 查询返回（单个）
        /// </summary>
        /// <param name="id">文档默认ID</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<T> FindOneAsync(string id, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return Task.Run(() => FindOne(id, settings, options));
        }

        /// <summary>
        /// 查询返回（单个）
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<T> FindOneAsync(IClientSessionHandle session, string id, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return Task.Run(() => FindOne(session, id, settings, options));
        }

        /// <summary>
        /// 查询返回（单个）
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<T> FindOneAsync(string collectionName, string id, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return Task.Run(() => FindOne(collectionName, id, settings, options));
        }

        /// <summary>
        /// 查询返回（单个）
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<T> FindOneAsync(string collectionName, IClientSessionHandle session, string id, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return Task.Run(() => FindOne(collectionName, session, id, settings, options));
        }

        /// <summary>
        /// 查询返回（单个）
        /// </summary>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<T> FindOneAsync(FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return Task.Run(() => FindOne(filter, settings, options));
        }

        /// <summary>
        /// 查询返回（单个）
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<T> FindOneAsync(IClientSessionHandle session, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return Task.Run(() => FindOne(session, filter, settings, options));
        }

        /// <summary>
        /// 查询返回（单个）
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<T> FindOneAsync(string collectionName, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return Task.Run(() => FindOne(collectionName, filter, settings, options));
        }

        /// <summary>
        /// 查询返回（单个）
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<T> FindOneAsync(string collectionName, IClientSessionHandle session, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return Task.Run(() => FindOne(collectionName, session, filter, settings, options));
        }

        /// <summary>
        /// 查询返回（单个）
        /// </summary>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<T> FindOneAsync(Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return Task.Run(() => FindOne(filter, settings, options));
        }

        /// <summary>
        /// 查询返回（单个）
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<T> FindOneAsync(IClientSessionHandle session, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return Task.Run(() => FindOne(session, filter, settings, options));
        }

        /// <summary>
        /// 查询返回（单个）
        /// </summary>

        /// <param name="collectionName">集合名称</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<T> FindOneAsync(string collectionName, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return Task.Run(() => FindOne(collectionName, filter, settings, options));
        }

        /// <summary>
        /// 查询返回（单个）
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<T> FindOneAsync(string collectionName, IClientSessionHandle session, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return Task.Run(() => FindOne(collectionName, filter, settings, options));
        }

        /// <summary>
        /// 查询返回（单个）
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<T> DynamicCollectionFindOneAsync<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            MongoCollectionSettings settings = null,
            FindOptions options = null)
            where TForeign : BaseMongoEntity
        {
            return Task.Run(() => DynamicCollectionFindOne(foreignDocument, filter, settings, options));
        }

        /// <summary>
        /// 查询返回（单个）
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<T> DynamicCollectionFindOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            MongoCollectionSettings settings = null,
            FindOptions options = null)
            where TForeign : BaseMongoEntity
        {
            return Task.Run(() => DynamicCollectionFindOne(session, foreignDocument, filter, settings, options));
        }

        /// <summary>
        /// 查询返回（单个）
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<T> DynamicCollectionFindOneAsync<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            MongoCollectionSettings settings = null,
            FindOptions options = null)
            where TForeign : BaseMongoEntity
        {
            return Task.Run(() => DynamicCollectionFindOne(foreignDocument, filter, settings, options));
        }

        /// <summary>
        /// 查询返回（单个）
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<T> DynamicCollectionFindOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            MongoCollectionSettings settings = null,
            FindOptions options = null)
            where TForeign : BaseMongoEntity
        {
            return Task.Run(() => DynamicCollectionFindOne(session, foreignDocument, filter, settings, options));
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<IEnumerable<T>> FindAllAsync(MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return Task.Run(() => FindAll(settings, options));
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<IEnumerable<T>> FindAllAsync(IClientSessionHandle session, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return Task.Run(() => FindAll(settings, options));
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<IEnumerable<T>> FindAllAsync(string collectionName, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return Task.Run(() => FindAll(collectionName, settings, options));
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<IEnumerable<T>> FindAllAsync(string collectionName, IClientSessionHandle session, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return Task.Run(() => FindAll(collectionName, session, settings, options));
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<IEnumerable<T>> DynamicCollectionFindAllAsync<TForeign>(TForeign foreignDocument, MongoCollectionSettings settings = null, FindOptions options = null)
            where TForeign : BaseMongoEntity

        {
            return Task.Run(() => DynamicCollectionFindAll(foreignDocument, settings, options));
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<IEnumerable<T>> DynamicCollectionFindAllAsync<TForeign>(IClientSessionHandle session, TForeign foreignDocument, MongoCollectionSettings settings = null, FindOptions options = null)
            where TForeign : BaseMongoEntity

        {
            return Task.Run(() => DynamicCollectionFindAll(session, foreignDocument, settings, options));
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<IEnumerable<T>> WhereAsync(FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return Task.Run(() => Where(filter, settings, options));
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<IEnumerable<T>> WhereAsync(IClientSessionHandle session, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return Task.Run(() => Where(session, filter, settings, options));
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<IEnumerable<T>> WhereAsync(string collectionName, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return Task.Run(() => Where(collectionName, filter, settings, options));
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<IEnumerable<T>> WhereAsync(string collectionName, IClientSessionHandle session, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return Task.Run(() => Where(collectionName, session, filter, settings, options));
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return Task.Run(() => Where(filter, settings, options));
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<IEnumerable<T>> WhereAsync(IClientSessionHandle session, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return Task.Run(() => Where(session, filter, settings, options));
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<IEnumerable<T>> WhereAsync(string collectionName, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return Task.Run(() => Where(collectionName, filter, settings, options));
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<IEnumerable<T>> WhereAsync(string collectionName, IClientSessionHandle session, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return Task.Run(() => Where(collectionName, session, filter, settings, options));
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<IEnumerable<T>> DynamicCollectionWhereAsync<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            MongoCollectionSettings settings = null,
            FindOptions options = null)
            where TForeign : BaseMongoEntity
        {
            return Task.Run(() => DynamicCollectionWhere(foreignDocument, filter, settings, options));
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<IEnumerable<T>> DynamicCollectionWhereAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            MongoCollectionSettings settings = null,
            FindOptions options = null)
            where TForeign : BaseMongoEntity
        {
            return Task.Run(() => DynamicCollectionWhere(session, foreignDocument, filter, settings, options));
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<IEnumerable<T>> DynamicCollectionWhereAsync<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            MongoCollectionSettings settings = null,
            FindOptions options = null)
            where TForeign : BaseMongoEntity
        {
            return Task.Run(() => DynamicCollectionWhere(foreignDocument, filter, settings, options));
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<IEnumerable<T>> DynamicCollectionWhereAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            MongoCollectionSettings settings = null,
            FindOptions options = null)
            where TForeign : BaseMongoEntity
        {
            return Task.Run(() => DynamicCollectionWhere(session, foreignDocument, filter, settings, options));
        }

        #endregion
    }
}
