//using System.Collections.Generic;
//using System.Threading;
//using MongoDB.Driver;

//namespace Apteryx.MongoDB.Driver.Extend
//{
//    public abstract partial class MongoDbProvider
//    {
//        #region 同步方法

//        /// <summary>
//        /// 插入单条
//        /// </summary>
//        /// <typeparam name="T">文档类型</typeparam>
//        /// <param name="document">文档对象</param>
//        /// <param name="options">插入操作设置</param>
//        /// <param name="cancellationToken">取消操作设置</param>
//        public void Add<T>(T document, InsertOneOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity
//        {
//            Database.GetCollection<T>(typeof(T).Name).InsertOne(document, options, cancellationToken);
//        }

//        /// <summary>
//        /// 插入单条
//        /// </summary>
//        /// <typeparam name="T">文档类型</typeparam>
//        /// <param name="session">会话句柄(作用于事务)</param>
//        /// <param name="document">文档对象</param>
//        /// <param name="options">插入操作设置</param>
//        /// <param name="cancellationToken">取消操作设置</param>
//        public void Add<T>(IClientSessionHandle session, T document, InsertOneOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity
//        {
//            Database.GetCollection<T>(typeof(T).Name).InsertOne(session, document, options, cancellationToken);
//        }

//        /// <summary>
//        /// 插入多条
//        /// </summary>
//        /// <typeparam name="T">文档类型</typeparam>
//        /// <param name="documents">文档对象</param>
//        /// <param name="options">插入操作设置</param>
//        /// <param name="cancellationToken">取消操作设置</param>
//        public void AddMany<T>(IEnumerable<T> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity
//        {
//            Database.GetCollection<T>(typeof(T).Name).InsertMany(documents, options, cancellationToken);
//        }

//        /// <summary>
//        /// 插入多条
//        /// </summary>
//        /// <typeparam name="T">文档类型</typeparam>
//        /// <param name="session">会话句柄(作用于事务)</param>
//        /// <param name="documents">文档对象</param>
//        /// <param name="options">插入操作设置</param>
//        /// <param name="cancellationToken">取消操作设置</param>
//        public void AddMany<T>(IClientSessionHandle session, IEnumerable<T> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity
//        {
//            Database.GetCollection<T>(typeof(T).Name).InsertMany(session, documents, options, cancellationToken);
//        }

//        /// <summary>
//        /// 根据主文档的默认id动态的创建附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
//        /// </summary>
//        /// <typeparam name="TForeign">文档类型</typeparam>
//        /// <typeparam name="T">文档类型</typeparam>
//        /// <param name="foreignDocument">上级文档</param>
//        /// <param name="document">文档对象</param>
//        public void DynamicCollectionAdd<TForeign, T>(TForeign foreignDocument, T document, InsertOneOptions options = null, CancellationToken cancellationToken = default)
//            where TForeign : BaseMongoEntity
//            where T : BaseMongoEntity
//        {
//            Database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}").InsertOne(document, options, cancellationToken);
//        }

//        /// <summary>
//        /// 根据主文档的默认id动态的创建附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
//        /// </summary>
//        /// <typeparam name="TForeign">文档类型</typeparam>
//        /// <typeparam name="T">文档类型</typeparam>
//        /// <param name="session">会话句柄(作用于事务)</param>
//        /// <param name="foreignDocument">上级文档</param>
//        /// <param name="document">文档对象</param>
//        public void DynamicCollectionAdd<TForeign, T>(IClientSessionHandle session, TForeign foreignDocument, T document, InsertOneOptions options = null, CancellationToken cancellationToken = default)
//            where TForeign : BaseMongoEntity
//            where T : BaseMongoEntity
//        {
//            Database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}").InsertOne(session, document, options, cancellationToken);
//        }

//        /// <summary>
//        /// 根据主文档的默认id动态的创建附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
//        /// </summary>
//        /// <typeparam name="TForeign">文档类型</typeparam>
//        /// <typeparam name="T">文档类型</typeparam>
//        /// <param name="foreignDocument">上级文档</param>
//        /// <param name="documents">文档对象</param>
//        public void DynamicCollectionAddMany<TForeign, T>(TForeign foreignDocument, IEnumerable<T> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default)
//            where TForeign : BaseMongoEntity
//            where T : BaseMongoEntity
//        {
//            Database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}").InsertMany(documents, options, cancellationToken);
//        }

//        /// <summary>
//        /// 根据主文档的默认id动态的创建附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
//        /// </summary>
//        /// <typeparam name="TForeign">文档类型</typeparam>
//        /// <typeparam name="T">文档类型</typeparam>
//        /// <param name="session">会话句柄(作用于事务)</param>
//        /// <param name="foreignDocument">上级文档</param>
//        /// <param name="documents">文档对象</param>
//        public void DynamicCollectionAddMany<TForeign, T>(IClientSessionHandle session, TForeign foreignDocument, IEnumerable<T> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default)
//            where TForeign : BaseMongoEntity
//            where T : BaseMongoEntity
//        {
//            Database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}").InsertMany(session, documents, options, cancellationToken);
//        }

//        #endregion
//    }
//}
