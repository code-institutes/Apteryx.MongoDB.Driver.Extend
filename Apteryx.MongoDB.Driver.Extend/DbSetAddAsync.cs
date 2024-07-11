using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Apteryx.MongoDB.Driver.Extend
{
    public partial class DbSet<T>
    {
        #region 添加（异步）

        /// <summary>
        /// 插入（单个）
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="document">文档对象</param>
        /// <param name="options">插入操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task AddAsync(T document, InsertOneOptions options = null, CancellationToken cancellationToken = default)
        {
            return _collection.InsertOneAsync(document, options, cancellationToken);
        }

        /// <summary>
        /// 插入（单个）
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">插入操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task AddAsync(IClientSessionHandle session, T document, InsertOneOptions options = null, CancellationToken cancellationToken = default)
        {
            return _collection.InsertOneAsync(session, document, options, cancellationToken);
        }

        /// <summary>
        /// 插入（批量）
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="documents">文档对象</param>
        /// <param name="options">插入操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task AddManyAsync(IEnumerable<T> documents, InsertManyOptions options= null, CancellationToken cancellationToken = default)
        {
            return _collection.InsertManyAsync(documents, options, cancellationToken);
        }

        /// <summary>
        /// 插入（批量）
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="documents">文档对象</param>
        /// <param name="options">插入操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task AddManyAsync(IClientSessionHandle session, IEnumerable<T> documents, InsertManyOptions options= null, CancellationToken cancellationToken = default)
        {
            return _collection.InsertManyAsync(session, documents, options, cancellationToken);
        }

        /// <summary>
        /// 根据主文档的默认id动态的创建附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="document">文档对象</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">插入操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task DynamicCollectionAddAsync<TForeign>(
            TForeign foreignDocument,
            T document,
            MongoCollectionSettings settings = null,
            InsertOneOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).InsertOneAsync(document, options, cancellationToken);
        }

        /// <summary>
        /// 根据主文档的默认id动态的创建附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="document">文档对象</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">插入操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task DynamicCollectionAddAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            T document,
            MongoCollectionSettings settings = null,
            InsertOneOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).InsertOneAsync(session, document, options, cancellationToken);
        }

        /// <summary>
        /// 根据主文档的默认id动态的创建附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="documents">文档对象</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">插入操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task DynamicCollectionAddManyAsync<TForeign>(
            TForeign foreignDocument,
            IEnumerable<T> documents,
            MongoCollectionSettings settings = null,
            InsertManyOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).InsertManyAsync(documents, options, cancellationToken);
        }

        /// <summary>
        /// 根据主文档的默认id动态的创建附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="documents">文档对象</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">插入操作设置</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task DynamicCollectionAddManyAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            IEnumerable<T> documents,
            MongoCollectionSettings settings = null,
            InsertManyOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).InsertManyAsync(session, documents, options, cancellationToken);
        }

        #endregion
    }
}
