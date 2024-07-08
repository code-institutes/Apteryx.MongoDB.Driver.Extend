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
        /// 查询返回（单个）
        /// </summary>        
        /// <param name="id">文档默认ID</param>
        /// <param name="options">选项</param>
        /// <returns></returns>
        public T FindOne(string id, FindOptions options = null)
        {
            return _collection.Find(f=>f.Id == id, options).FirstOrDefault();
        }

        /// <summary>
        /// 查询返回（单个）
        /// </summary>        
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="options">选项</param>
        /// <returns></returns>
        public T FindOne(IClientSessionHandle session, string id,  FindOptions options = null)
        {
            return _collection.Find(session, f => f.Id == id, options).FirstOrDefault();
        }

        /// <summary>
        /// 查询返回（单个）
        /// </summary>
        /// <param name="filter">过滤器</param>
        /// <param name="options">选项</param>
        /// <returns></returns>
        public T FindOne(FilterDefinition<T> filter,  FindOptions options = null)
        {
            return _collection.Find(filter, options).FirstOrDefault();
        }

        /// <summary>
        /// 查询返回（单个）
        /// </summary>
        /// <param name="filter">过滤器</param>
        /// <param name="options">选项</param>
        /// <returns></returns>
        public T FindOne(IClientSessionHandle session, FilterDefinition<T> filter,  FindOptions options = null)
        {
            return _collection.Find(session, filter, options).FirstOrDefault();
        }
                
        /// <summary>
        /// 查询返回（单个）
        /// </summary>
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="options">选项</param>
        /// <returns></returns>
        public T FindOne(Expression<Func<T, bool>> expression,  FindOptions options = null)
        {
            return _collection.Find(expression, options).FirstOrDefault();
        }

        /// <summary>
        /// 查询返回（单个）
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="options">选项</param>
        /// <returns></returns>
        public T FindOne(IClientSessionHandle session, Expression<Func<T, bool>> expression,  FindOptions options = null)
        {
            return _collection.Find(session, expression, options).FirstOrDefault();
        }

        /// <summary>
        /// 查询返回（单个）
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <param name="options">选项</param>
        /// <returns></returns>
        public T DynamicCollectionFindOne<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            MongoCollectionSettings settings = null,
            FindOptions options = null)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).Find(filter, options).FirstOrDefault();
        }

        /// <summary>
        /// 查询返回（单个）
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <param name="options">选项</param>
        /// <returns></returns>
        public T DynamicCollectionFindOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            MongoCollectionSettings settings = null,
            FindOptions options = null)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).Find(session, filter, options).FirstOrDefault();
        }

        /// <summary>
        /// 查询返回（单个）
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="settings">设置</param>
        /// <param name="options">选项</param>
        /// <returns></returns>
        public T DynamicCollectionFindOne<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            MongoCollectionSettings settings = null,
            FindOptions options = null)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).Find(expression, options).FirstOrDefault();
        }
        /// <summary>
        /// 查询返回（单个）
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="settings">设置</param>
        /// <param name="options">选项</param>
        /// <returns></returns>
        public T DynamicCollectionFindOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            MongoCollectionSettings settings = null,
            FindOptions options = null)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).Find(session, expression, options).FirstOrDefault();
        }
        /// <summary>
        /// 查询全部
        /// </summary>        
        /// <param name="options">选项</param>
        /// <returns></returns>
        public IEnumerable<T> FindAll( FindOptions options = null)
        {
            return _collection.Find(_ => true, options).ToEnumerable();
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>        
        /// <param name="options">选项</param>
        /// <returns></returns>
        public IEnumerable<T> FindAll(IClientSessionHandle session,  FindOptions options = null)
        {
            return _collection.Find(session, _ => true, options).ToEnumerable();
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="settings">设置</param>
        /// <param name="options">选项</param>
        /// <returns></returns>
        public IEnumerable<T> DynamicCollectionFindAll<TForeign>(TForeign foreignDocument, MongoCollectionSettings settings = null, FindOptions options = null)
            where TForeign : BaseMongoEntity

        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).Find(_ => true, options).ToEnumerable();
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="settings">设置</param>
        /// <param name="options">选项</param>
        /// <returns></returns>
        public IEnumerable<T> DynamicCollectionFindAll<TForeign>(IClientSessionHandle session, TForeign foreignDocument, MongoCollectionSettings settings = null, FindOptions options = null)
            where TForeign : BaseMongoEntity

        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).Find(session, _ => true, options).ToEnumerable();
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <param name="filter">过滤器</param>        
        /// <param name="options">选项</param>
        /// <returns></returns>
        public IFindFluent<T,T> Where(FilterDefinition<T> filter,  FindOptions options = null)
        {
            return _collection.Find(filter, options);
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>        
        /// <param name="options">选项</param>
        /// <returns></returns>
        public IFindFluent<T, T> Where(IClientSessionHandle session, FilterDefinition<T> filter,  FindOptions options = null)
        {
            return _collection.Find(session, filter, options);
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <param name="expression">Lambda过滤器</param>        
        /// <param name="options">选项</param>
        /// <returns></returns>
        public IFindFluent<T, T> Where(Expression<Func<T, bool>> expression,  FindOptions options = null)
        {
            return _collection.Find(expression, options);
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="expression">Lambda过滤器</param>        
        /// <param name="options">选项</param>
        /// <returns></returns>
        public IFindFluent<T, T> Where(IClientSessionHandle session, Expression<Func<T, bool>> expression,  FindOptions options = null)
        {
            return _collection.Find(session, expression, options);
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <param name="settings">设置</param>
        /// <param name="options">选项</param>
        /// <returns></returns>
        public IFindFluent<T, T> DynamicCollectionWhere<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            MongoCollectionSettings settings = null,
            FindOptions options = null)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).Find(filter, options);
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">过滤器</param>        
        /// <param name="options">选项</param>
        /// <returns></returns>
        public IFindFluent<T, T> DynamicCollectionWhere<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            MongoCollectionSettings settings = null,
            FindOptions options = null)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).Find(session, filter, options);
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="settings">设置</param>
        /// <param name="options">选项</param>
        /// <returns></returns>
        public IFindFluent<T, T> DynamicCollectionWhere<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            MongoCollectionSettings settings = null,
            FindOptions options = null)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).Find(expression, options);
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="settings">设置</param>
        /// <param name="options">选项</param>
        /// <returns></returns>
        public IFindFluent<T, T> DynamicCollectionWhere<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            MongoCollectionSettings settings = null,
            FindOptions options = null)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).Find(session, expression, options);
        }

        #endregion
    }
}