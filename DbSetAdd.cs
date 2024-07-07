﻿using System.Collections.Generic;
using System.Threading;
using MongoDB.Driver;

namespace Apteryx.MongoDB.Driver.Extend
{
    public partial class DbSet<T>
    {
        #region 添加（同步）

        /// <summary>
        /// 插入单条
        /// </summary>
        /// <param name="document">文档对象</param>
        /// <param name="options">插入操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        public void Add(T document, InsertOneOptions options = null, CancellationToken cancellationToken = default)
        {
            _collection.InsertOne(document, options, cancellationToken);
        }

        /// <summary>
        /// 插入单条
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">插入操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        public void Add(IClientSessionHandle session, T document, InsertOneOptions options = null, CancellationToken cancellationToken = default)
        {
            _collection.InsertOne(session, document, options, cancellationToken);
        }

        /// <summary>
        /// 插入多条
        /// </summary>
        /// <param name="documents">文档对象</param>
        /// <param name="options">插入操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        public void AddMany(IEnumerable<T> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default)
        {
            _collection.InsertMany(documents, options, cancellationToken);
        }

        /// <summary>
        /// 插入多条
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="documents">文档对象</param>
        /// <param name="options">插入操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        public void AddMany(IClientSessionHandle session, IEnumerable<T> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default)
        {
            _collection.InsertMany(session, documents, options, cancellationToken);
        }

        /// <summary>
        /// 根据主文档的默认id动态的创建附文档的集合,集合名称规则:"{附文档名}_{主文档默认id}"
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">插入操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        public void DynamicCollectionAdd<TForeign>(TForeign foreignDocument, T document, InsertOneOptions options = null, CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            _database.GetCollection<T>($"{_collectionName}_{foreignDocument.Id}").InsertOne(document, options, cancellationToken);
        }

        /// <summary>
        /// 根据主文档的默认id动态的创建附文档的集合,集合名称规则:"{附文档名}_{主文档默认id}"
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">插入操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        public void DynamicCollectionAdd<TForeign>(IClientSessionHandle session, TForeign foreignDocument, T document, InsertOneOptions options = null, CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            _database.GetCollection<T>($"{_collectionName}_{foreignDocument.Id}").InsertOne(session, document, options, cancellationToken);
        }

        /// <summary>
        /// 根据主文档的默认id动态的创建附文档的集合,集合名称规则:"{附文档名}_{主文档默认id}"
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="documents">文档对象</param>
        /// <param name="options">插入操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        public void DynamicCollectionAddMany<TForeign>(TForeign foreignDocument, IEnumerable<T> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            _database.GetCollection<T>($"{_collectionName}_{foreignDocument.Id}").InsertMany(documents, options, cancellationToken);
        }

        /// <summary>
        /// 根据主文档的默认id动态的创建附文档的集合,集合名称规则:"{附文档名}_{主文档默认id}"
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="documents">文档对象</param>
        /// <param name="options">插入操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        public void DynamicCollectionAddMany<TForeign>(IClientSessionHandle session, TForeign foreignDocument, IEnumerable<T> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            _database.GetCollection<T>($"{_collectionName}_{foreignDocument.Id}").InsertMany(session, documents, options, cancellationToken);
        }

        #endregion
    }
}
