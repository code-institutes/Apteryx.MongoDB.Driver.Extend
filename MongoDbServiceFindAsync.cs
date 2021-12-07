using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Apteryx.MongoDB.Driver.Extend.Entities;
using MongoDB.Driver;

namespace Apteryx.MongoDB.Driver.Extend
{
    public abstract partial class MongoDbService
    {
        #region 查询(异步)
        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="id">主键ID</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<T> FindOneAsync<T>(string id, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return Task.Run(() => FindOne<T>(id, settings, options));
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
        public Task<T> FindOneAsync<T>(string name, string id, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return Task.Run(() => FindOne<T>(name,id, settings, options));
        }
        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<T> FindOneAsync<T>(FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return Task.Run(() => FindOne<T>(filter, settings, options));
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
        public Task<T> FindOneAsync<T>(string name, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return Task.Run(() => FindOne<T>(name,filter, settings, options));
        }
        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<T> FindOneAsync<T>(Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return Task.Run(() => FindOne<T>(filter, settings, options));
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
        public Task<T> FindOneAsync<T>(string name, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return Task.Run(() => FindOne<T>(name, filter, settings, options));
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
        public Task<T> DynamicCollectionFindOneAsync<TForeign, T>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            MongoCollectionSettings settings = null,
            FindOptions options = null)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return Task.Run(() => DynamicCollectionFindOne<TForeign,T>(foreignDocument, filter, settings, options));
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
        public Task<T> DynamicCollectionFindOneAsync<TForeign, T>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            MongoCollectionSettings settings = null,
            FindOptions options = null)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return Task.Run(() => DynamicCollectionFindOne<TForeign, T>(foreignDocument, filter, settings, options));
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<IEnumerable<T>> FindAllAsync<T>(MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return Task.Run(() => FindAll<T>(settings, options));
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="name">集合名称</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<IEnumerable<T>> FindAllAsync<T>(string name, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return Task.Run(() => FindAll<T>(name,settings, options));
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
        public Task<IEnumerable<T>> DynamicCollectionFindAllAsync<TForeign, T>(TForeign foreignDocument, MongoCollectionSettings settings = null, FindOptions options = null)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return Task.Run(() => DynamicCollectionFindAll<TForeign,T>(foreignDocument,settings, options));
        }
        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<IEnumerable<T>> WhereAsync<T>(FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return Task.Run(() => Where<T>(filter, settings, options));
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
        public Task<IEnumerable<T>> WhereAsync<T>(string name, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return Task.Run(() => Where<T>(name,filter, settings, options));
        }
        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="settings">数据库设置</param>
        /// <param name="options">查找操作设置</param>
        /// <returns></returns>
        public Task<IEnumerable<T>> WhereAsync<T>(Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return Task.Run(() => Where<T>(filter, settings, options));
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
        public Task<IEnumerable<T>> WhereAsync<T>(string name,Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity
        {
            return Task.Run(() => Where<T>(name,filter, settings, options));
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
        public Task<IEnumerable<T>> DynamicCollectionWhereAsync<TForeign, T>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            MongoCollectionSettings settings = null,
            FindOptions options = null)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return Task.Run(() => DynamicCollectionWhere<TForeign,T>(foreignDocument,filter, settings, options));
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
        public Task<IEnumerable<T>> DynamicCollectionWhereAsync<TForeign, T>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            MongoCollectionSettings settings = null,
            FindOptions options = null)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return Task.Run(() => DynamicCollectionWhere<TForeign, T>(foreignDocument, filter, settings, options));
        }

        #endregion
    }
}
