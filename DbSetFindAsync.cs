using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<T> FindOneAsync(string id, FindOptions<T, T> options = null)
        {
            return (await _collection.FindAsync(f => f.Id == id, options)).Current.FirstOrDefault();
        }

        /// <summary>
        /// 查询返回（单个）
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public async Task<T> FindOneAsync(IClientSessionHandle session, string id, FindOptions<T, T> options = null)
        {
            return (await _collection.FindAsync(session, f => f.Id == id, options)).Current.FirstOrDefault();
        }

        /// <summary>
        /// 查询返回（单个）
        /// </summary>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public async Task<T> FindOneAsync(FilterDefinition<T> filter, FindOptions<T, T> options = null)
        {
            return (await _collection.FindAsync(filter, options)).Current.FirstOrDefault();
        }

        /// <summary>
        /// 查询返回（单个）
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public async Task<T> FindOneAsync(IClientSessionHandle session, FilterDefinition<T> filter, FindOptions<T, T> options = null)
        {
            return (await _collection.FindAsync(session, filter, options)).Current.FirstOrDefault();
        }

        /// <summary>
        /// 查询返回（单个）
        /// </summary>
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public async Task<T> FindOneAsync(Expression<Func<T, bool>> expression, FindOptions<T, T> options = null)
        {
            return (await _collection.FindAsync(expression, options)).Current.FirstOrDefault();
        }

        /// <summary>
        /// 查询返回（单个）
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public async Task<T> FindOneAsync(IClientSessionHandle session, Expression<Func<T, bool>> expression, FindOptions<T, T> options = null)
        {
            return (await _collection.FindAsync(session, expression, options)).Current.FirstOrDefault();
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
        public async Task<T> DynamicCollectionFindOneAsync<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            MongoCollectionSettings settings = null,
            FindOptions<T, T> options = null)
            where TForeign : BaseMongoEntity
        {
            return (await _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindAsync(filter, options)).Current.FirstOrDefault();
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
        public async Task<T> DynamicCollectionFindOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            MongoCollectionSettings settings = null,
            FindOptions<T, T> options = null)
            where TForeign : BaseMongoEntity
        {
            return (await _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindAsync(session, filter, options)).Current.FirstOrDefault();
        }

        /// <summary>
        /// 查询返回（单个）
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public async Task<T> DynamicCollectionFindOneAsync<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            MongoCollectionSettings settings = null,
            FindOptions<T, T> options = null)
            where TForeign : BaseMongoEntity
        {
            return (await _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindAsync(expression, options)).Current.FirstOrDefault();
        }

        /// <summary>
        /// 查询返回（单个）
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public async Task<T> DynamicCollectionFindOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            MongoCollectionSettings settings = null,
            FindOptions<T, T> options = null)
            where TForeign : BaseMongoEntity
        {
            return (await _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindAsync(session, expression, options)).Current.FirstOrDefault();
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> FindAllAsync(FindOptions<T, T> options = null)
        {
            return (await _collection.FindAsync(_ => true, options)).Current;
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> FindAllAsync(IClientSessionHandle session,  FindOptions<T, T> options = null)
        {
            return (await _collection.FindAsync(session, _ => true, options)).Current;
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> DynamicCollectionFindAllAsync<TForeign>(TForeign foreignDocument, MongoCollectionSettings settings = null, FindOptions<T, T> options = null)
            where TForeign : BaseMongoEntity

        {
            return (await _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindAsync(_ => true, options)).Current;
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
        public async Task<IEnumerable<T>> DynamicCollectionFindAllAsync<TForeign>(IClientSessionHandle session, TForeign foreignDocument, MongoCollectionSettings settings = null, FindOptions<T, T> options = null)
            where TForeign : BaseMongoEntity

        {
            return (await _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindAsync(session, _ => true, options)).Current;
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> WhereAsync(FilterDefinition<T> filter, FindOptions<T, T> options = null)
        {
            return (await _collection.FindAsync(filter, options)).Current;
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> WhereAsync(IClientSessionHandle session, FilterDefinition<T> filter, FindOptions<T, T> options = null)
        {
            return (await _collection.FindAsync(session, filter, options)).Current;
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> expression, FindOptions<T, T> options = null)
        {
            return (await _collection.FindAsync(expression, options)).Current;
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> WhereAsync(IClientSessionHandle session, Expression<Func<T, bool>> expression, FindOptions<T, T> options = null)
        {
            return (await _collection.FindAsync(session, expression, options)).Current;
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
        public async Task<IEnumerable<T>> DynamicCollectionWhereAsync<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            MongoCollectionSettings settings = null,
            FindOptions<T, T> options = null)
            where TForeign : BaseMongoEntity
        {
            return (await _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindAsync(filter, options)).Current;
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
        public async Task<IEnumerable<T>> DynamicCollectionWhereAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            MongoCollectionSettings settings = null,
            FindOptions<T, T> options = null)
            where TForeign : BaseMongoEntity
        {
            return (await _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindAsync(session, filter, options)).Current;
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> DynamicCollectionWhereAsync<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            MongoCollectionSettings settings = null,
            FindOptions<T, T> options = null)
            where TForeign : BaseMongoEntity
        {
            return (await _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindAsync(expression, options)).Current;
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> DynamicCollectionWhereAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            MongoCollectionSettings settings = null,
            FindOptions<T, T> options = null)
            where TForeign : BaseMongoEntity
        {
            return (await _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).FindAsync(session, expression, options)).Current;
        }

        #endregion
    }
}
