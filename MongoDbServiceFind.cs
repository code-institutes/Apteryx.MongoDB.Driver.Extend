using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Apteryx.MongoDB.Driver.Extend
{
    public abstract partial class MongoDbProvider
    {
        #region 查询(同步)
        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="id">文档默认ID</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public T FindOne<T>(string id, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return Database.GetCollection<T>(typeof(T).Name, settings).Find(f => f.Id == id, options).FirstOrDefault();
        }
        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public T FindOne<T>(IClientSessionHandle session, string id, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return Database.GetCollection<T>(typeof(T).Name, settings).Find(session, f => f.Id == id, options).FirstOrDefault();
        }
        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collectionName">集合名称</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public T FindOne<T>(string collectionName, string id, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return Database.GetCollection<T>(collectionName, settings).Find(f => f.Id == id, options).FirstOrDefault();
        }
        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collectionName">集合名称</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public T FindOne<T>(string collectionName, IClientSessionHandle session, string id, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return Database.GetCollection<T>(collectionName, settings).Find(session, f => f.Id == id, options).FirstOrDefault();
        }
        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public T FindOne<T>(FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return Database.GetCollection<T>(typeof(T).Name, settings).Find(filter, options).FirstOrDefault();
        }
        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public T FindOne<T>(IClientSessionHandle session, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return Database.GetCollection<T>(typeof(T).Name, settings).Find(session, filter, options).FirstOrDefault();
        }
        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collectionName">集合名称</param>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public T FindOne<T>(string collectionName, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return Database.GetCollection<T>(collectionName, settings).Find(filter, options).FirstOrDefault();
        }
        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collectionName">集合名称</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public T FindOne<T>(string collectionName, IClientSessionHandle session, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return Database.GetCollection<T>(collectionName, settings).Find(session, filter, options).FirstOrDefault();
        }
        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public T FindOne<T>(Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return Database.GetCollection<T>(typeof(T).Name, settings).Find(filter, options).FirstOrDefault();
        }
        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public T FindOne<T>(IClientSessionHandle session, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return Database.GetCollection<T>(typeof(T).Name, settings).Find(session, filter, options).FirstOrDefault();
        }
        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName">集合名称</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public T FindOne<T>(string collectionName, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return Database.GetCollection<T>(collectionName, settings).Find(filter, options).FirstOrDefault();
        }
        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName">集合名称</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public T FindOne<T>(string collectionName, IClientSessionHandle session, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return Database.GetCollection<T>(collectionName, settings).Find(session, filter, options).FirstOrDefault();
        }
        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public T DynamicCollectionFindOne<TForeign, T>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            MongoCollectionSettings settings = null,
            FindOptions options = null)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}", settings).Find(filter, options).FirstOrDefault();
        }
        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public T DynamicCollectionFindOne<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            MongoCollectionSettings settings = null,
            FindOptions options = null)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}", settings).Find(session, filter, options).FirstOrDefault();
        }
        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public T DynamicCollectionFindOne<TForeign, T>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            MongoCollectionSettings settings = null,
            FindOptions options = null)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}", settings).Find(filter, options).FirstOrDefault();
        }
        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public T DynamicCollectionFindOne<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            MongoCollectionSettings settings = null,
            FindOptions options = null)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}", settings).Find(session, filter, options).FirstOrDefault();
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public IEnumerable<T> FindAll<T>(MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return Database.GetCollection<T>(typeof(T).Name, settings).Find(_ => true, options).ToEnumerable();
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public IEnumerable<T> FindAll<T>(IClientSessionHandle session,MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return Database.GetCollection<T>(typeof(T).Name, settings).Find(session,_ => true, options).ToEnumerable();
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collectionName">集合名称</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public IEnumerable<T> FindAll<T>(string collectionName, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return Database.GetCollection<T>(collectionName, settings).Find(_ => true, options).ToEnumerable();
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collectionName">集合名称</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public IEnumerable<T> FindAll<T>(string collectionName,IClientSessionHandle session, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return Database.GetCollection<T>(collectionName, settings).Find(session,_ => true, options).ToEnumerable();
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public IEnumerable<T> DynamicCollectionFindAll<TForeign, T>(TForeign foreignDocument, MongoCollectionSettings settings = null, FindOptions options = null)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}", settings).Find(_ => true, options).ToEnumerable();
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public IEnumerable<T> DynamicCollectionFindAll<TForeign, T>(IClientSessionHandle session,TForeign foreignDocument, MongoCollectionSettings settings = null, FindOptions options = null)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}", settings).Find(session,_ => true, options).ToEnumerable();
        }
        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public IEnumerable<T> Where<T>(FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return Database.GetCollection<T>(typeof(T).Name, settings).Find(filter, options).ToEnumerable();
        }
        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public IEnumerable<T> Where<T>(IClientSessionHandle session,FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return Database.GetCollection<T>(typeof(T).Name, settings).Find(session,filter, options).ToEnumerable();
        }
        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collectionName">集合名称</param>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public IEnumerable<T> Where<T>(string collectionName, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return Database.GetCollection<T>(collectionName, settings).Find(filter, options).ToEnumerable();
        }
        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collectionName">集合名称</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public IEnumerable<T> Where<T>(string collectionName,IClientSessionHandle session, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return Database.GetCollection<T>(collectionName, settings).Find(session,filter, options).ToEnumerable();
        }
        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public IEnumerable<T> Where<T>(Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return Database.GetCollection<T>(typeof(T).Name, settings).Find(filter, options).ToEnumerable();
        }
        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public IEnumerable<T> Where<T>(IClientSessionHandle session,Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return Database.GetCollection<T>(typeof(T).Name, settings).Find(session,filter, options).ToEnumerable();
        }
        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collectionName">集合名称</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public IEnumerable<T> Where<T>(string collectionName, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return Database.GetCollection<T>(collectionName, settings).Find(filter, options).ToEnumerable();
        }
        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collectionName">集合名称</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public IEnumerable<T> Where<T>(string collectionName,IClientSessionHandle session, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return Database.GetCollection<T>(collectionName, settings).Find(session,filter, options).ToEnumerable();
        }
        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public IEnumerable<T> DynamicCollectionWhere<TForeign, T>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            MongoCollectionSettings settings = null,
            FindOptions options = null)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}", settings).Find(filter, options).ToEnumerable();
        }
        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public IEnumerable<T> DynamicCollectionWhere<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            MongoCollectionSettings settings = null,
            FindOptions options = null)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}", settings).Find(session,filter, options).ToEnumerable();
        }
        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public IEnumerable<T> DynamicCollectionWhere<TForeign, T>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            MongoCollectionSettings settings = null,
            FindOptions options = null)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}", settings).Find(filter, options).ToEnumerable();
        }
        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public IEnumerable<T> DynamicCollectionWhere<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            MongoCollectionSettings settings = null,
            FindOptions options = null)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}", settings).Find(session,filter, options).ToEnumerable();
        }

        #endregion
    }
}