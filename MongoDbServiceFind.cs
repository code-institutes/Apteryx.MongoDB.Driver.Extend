using Apteryx.MongoDB.Driver.Extend.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Apteryx.MongoDB.Driver.Extend
{
    public abstract partial class MongoDbService
    {
        #region 查询(同步)
        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="id">主键ID</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public T FindOne<T>(string id,MongoCollectionSettings settings=null,FindOptions options=null) where T : BaseMongoEntity
        {
            return database.GetCollection<T>(typeof(T).Name,settings).Find(f=>f.Id == id,options).FirstOrDefault();
        }
        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="name">集合名称</param>
        /// <param name="id">主键ID</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public T FindOne<T>(string name, string id, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return database.GetCollection<T>(name,settings).Find(f => f.Id == id,options).FirstOrDefault();
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
            return database.GetCollection<T>(typeof(T).Name,settings).Find(filter,options).FirstOrDefault();
        }
        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="name">集合名称</param>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public T FindOne<T>(string name,FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return database.GetCollection<T>(name, settings).Find(filter,options).FirstOrDefault();
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
            return database.GetCollection<T>(typeof(T).Name,settings).Find(filter,options).FirstOrDefault();
        }
        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">集合名称</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public T FindOne<T>(string name,Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return database.GetCollection<T>(name, settings).Find(filter, options).FirstOrDefault();
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
        public T DynamicTableFindOne<TForeign, T>(
            TForeign foreignDocument, 
            FilterDefinition<T> filter, 
            MongoCollectionSettings settings = null, 
            FindOptions options = null)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}",settings).Find(filter,options).FirstOrDefault();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public T DynamicTableFindOne<TForeign, T>(
            TForeign foreignDocument, 
            Expression<Func<T, bool>> filter, 
            MongoCollectionSettings settings = null, 
            FindOptions options = null)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}",settings).Find(filter,options).FirstOrDefault();
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
            return database.GetCollection<T>(typeof(T).Name,settings).Find(_ => true,options).ToEnumerable();
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="name">集合名称</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public IEnumerable<T> FindAll<T>(string name,MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return database.GetCollection<T>(name, settings).Find(_ => true, options).ToEnumerable();
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
        public IEnumerable<T> DynamicTableFindAll<TForeign, T>(TForeign foreignDocument, MongoCollectionSettings settings = null, FindOptions options = null)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}",settings).Find(_=>true,options).ToEnumerable();
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
            return database.GetCollection<T>(typeof(T).Name,settings).Find(filter,options).ToEnumerable();
        }
        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="name">集合名称</param>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public IEnumerable<T> Where<T>(string name,FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return database.GetCollection<T>(name, settings).Find(filter, options).ToEnumerable();
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
            return database.GetCollection<T>(typeof(T).Name,settings).Find(filter,options).ToEnumerable();
        }
        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="name">集合名称</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public IEnumerable<T> Where<T>(string name,Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return database.GetCollection<T>(name, settings).Find(filter, options).ToEnumerable();
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
        public IEnumerable<T> DynamicTableWhere<TForeign, T>(
            TForeign foreignDocument, 
            FilterDefinition<T> filter, 
            MongoCollectionSettings settings = null, 
            FindOptions options = null)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}",settings).Find(filter,options).ToEnumerable();
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
        public IEnumerable<T> DynamicTableWhere<TForeign, T>(
            TForeign foreignDocument, 
            Expression<Func<T, bool>> filter, 
            MongoCollectionSettings settings = null, 
            FindOptions options = null)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}",settings).Find(filter,options).ToEnumerable();
        }

        #endregion
    }
}