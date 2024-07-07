using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Apteryx.MongoDB.Driver.Extend
{
    public partial class DbSet<T>
    {
        #region 查询(同步)
        /// <summary>
        /// 查询返回单条
        /// </summary>        
        /// <param name="id">文档默认ID</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public T FindOne(string id, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return _collection.Find(f => f.Id == id, options).FirstOrDefault();
        }
        /// <summary>
        /// 查询返回单条
        /// </summary>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public T FindOne(IClientSessionHandle session, string id, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return _collection.Find(session, f => f.Id == id, options).FirstOrDefault();
        }
        /// <summary>
        /// 查询返回单条
        /// </summary>        
        /// <param name="collectionName">集合名称</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public T FindOne(string collectionName, string id, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return _collection.Find(f => f.Id == id, options).FirstOrDefault();
        }
        /// <summary>
        /// 查询返回单条
        /// </summary>        
        /// <param name="collectionName">集合名称</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public T FindOne(string collectionName, IClientSessionHandle session, string id, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return _collection.Find(session, f => f.Id == id, options).FirstOrDefault();
        }
        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public T FindOne(FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return _collection.Find(filter, options).FirstOrDefault();
        }
        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public T FindOne(IClientSessionHandle session, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return _collection.Find(session, filter, options).FirstOrDefault();
        }
        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public T FindOne(string collectionName, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return _collection.Find(filter, options).FirstOrDefault();
        }
        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public T FindOne(string collectionName, IClientSessionHandle session, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return _collection.Find(session, filter, options).FirstOrDefault();
        }
        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public T FindOne(Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return _collection.Find(filter, options).FirstOrDefault();
        }
        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public T FindOne(IClientSessionHandle session, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return _collection.Find(session, filter, options).FirstOrDefault();
        }
        /// <summary>
        /// 查询返回单条
        /// </summary>        
        /// <param name="collectionName">集合名称</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public T FindOne(string collectionName, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return _collection.Find(filter, options).FirstOrDefault();
        }
        /// <summary>
        /// 查询返回单条
        /// </summary>        
        /// <param name="collectionName">集合名称</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public T FindOne(string collectionName, IClientSessionHandle session, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return _collection.Find(session, filter, options).FirstOrDefault();
        }
        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public T DynamicCollectionFindOne<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            MongoCollectionSettings settings = null,
            FindOptions options = null)
            where TForeign : BaseMongoEntity

        {
            return _database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}", settings).Find(filter, options).FirstOrDefault();
        }
        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public T DynamicCollectionFindOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            MongoCollectionSettings settings = null,
            FindOptions options = null)
            where TForeign : BaseMongoEntity

        {
            return _database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}", settings).Find(session, filter, options).FirstOrDefault();
        }
        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public T DynamicCollectionFindOne<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            MongoCollectionSettings settings = null,
            FindOptions options = null)
            where TForeign : BaseMongoEntity

        {
            return _database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}", settings).Find(filter, options).FirstOrDefault();
        }
        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public T DynamicCollectionFindOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            MongoCollectionSettings settings = null,
            FindOptions options = null)
            where TForeign : BaseMongoEntity

        {
            return _database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}", settings).Find(session, filter, options).FirstOrDefault();
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public IEnumerable<T> FindAll(MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return _collection.Find(_ => true, options).ToEnumerable();
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public IEnumerable<T> FindAll(IClientSessionHandle session, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return _collection.Find(session, _ => true, options).ToEnumerable();
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public IEnumerable<T> FindAll(string collectionName, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return _collection.Find(_ => true, options).ToEnumerable();
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public IEnumerable<T> FindAll(string collectionName, IClientSessionHandle session, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return _collection.Find(session, _ => true, options).ToEnumerable();
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public IEnumerable<T> DynamicCollectionFindAll<TForeign>(TForeign foreignDocument, MongoCollectionSettings settings = null, FindOptions options = null)
            where TForeign : BaseMongoEntity

        {
            return _database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}", settings).Find(_ => true, options).ToEnumerable();
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
        public IEnumerable<T> DynamicCollectionFindAll<TForeign>(IClientSessionHandle session, TForeign foreignDocument, MongoCollectionSettings settings = null, FindOptions options = null)
            where TForeign : BaseMongoEntity

        {
            return _database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}", settings).Find(session, _ => true, options).ToEnumerable();
        }
        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public IEnumerable<T> Where(FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return _collection.Find(filter, options).ToEnumerable();
        }
        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public IEnumerable<T> Where(IClientSessionHandle session, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return _collection.Find(session, filter, options).ToEnumerable();
        }
        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public IEnumerable<T> Where(string collectionName, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return _collection.Find(filter, options).ToEnumerable();
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
        public IEnumerable<T> Where(string collectionName, IClientSessionHandle session, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return _collection.Find(session, filter, options).ToEnumerable();
        }
        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public IEnumerable<T> Where(Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return _collection.Find(filter, options).ToEnumerable();
        }
        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public IEnumerable<T> Where(IClientSessionHandle session, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return _collection.Find(session, filter, options).ToEnumerable();
        }
        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public IEnumerable<T> Where(string collectionName, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return _collection.Find(filter, options).ToEnumerable();
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
        public IEnumerable<T> Where(string collectionName, IClientSessionHandle session, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null)
        {
            return _collection.Find(session, filter, options).ToEnumerable();
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
        public IEnumerable<T> DynamicCollectionWhere<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            MongoCollectionSettings settings = null,
            FindOptions options = null)
            where TForeign : BaseMongoEntity

        {
            return _database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}", settings).Find(filter, options).ToEnumerable();
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
        public IEnumerable<T> DynamicCollectionWhere<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            MongoCollectionSettings settings = null,
            FindOptions options = null)
            where TForeign : BaseMongoEntity

        {
            return _database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}", settings).Find(session, filter, options).ToEnumerable();
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
        public IEnumerable<T> DynamicCollectionWhere<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            MongoCollectionSettings settings = null,
            FindOptions options = null)
            where TForeign : BaseMongoEntity

        {
            return _database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}", settings).Find(filter, options).ToEnumerable();
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
        public IEnumerable<T> DynamicCollectionWhere<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            MongoCollectionSettings settings = null,
            FindOptions options = null)
            where TForeign : BaseMongoEntity

        {
            return _database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}", settings).Find(session, filter, options).ToEnumerable();
        }

        #endregion
    }
}