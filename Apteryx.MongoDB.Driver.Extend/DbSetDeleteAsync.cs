using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Apteryx.MongoDB.Driver.Extend
{
    public partial class DbSet<T>
    {
        #region 删除（异步）

        /// <summary>
        /// 删除（单个）
        /// </summary>
        /// <param name="id">文档对象ID</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task<DeleteResult> DeleteOneAsync(string id, DeleteOptions options = null, CancellationToken cancellationToken = default)
        {
            return _collection.DeleteOneAsync(d => d.Id == id, options, cancellationToken);
        }

        /// <summary>
        /// 删除（单个）
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="id">文档对象ID</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task<DeleteResult> DeleteOneAsync(IClientSessionHandle session, string id, DeleteOptions options = null, CancellationToken cancellationToken = default)
        {
            return _collection.DeleteOneAsync(session, d => d.Id == id, options, cancellationToken);
        }

        /// <summary>
        /// 删除（单个）
        /// </summary>
        /// <param name="document">文档对象</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task<DeleteResult> DeleteOneAsync(T document, DeleteOptions options = null, CancellationToken cancellationToken = default)
        {
            return _collection.DeleteOneAsync(d => d.Id == document.Id, options, cancellationToken);
        }

        /// <summary>
        /// 删除（单个）
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task<DeleteResult> DeleteOneAsync(IClientSessionHandle session, T document, DeleteOptions options = null, CancellationToken cancellationToken = default)
        {
            return _collection.DeleteOneAsync(session, d => d.Id == document.Id, options, cancellationToken);
        }

        /// <summary>
        /// 删除（单个）
        /// </summary>
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task<DeleteResult> DeleteOneAsync(Expression<Func<T, bool>> expression, DeleteOptions options = null, CancellationToken cancellationToken = default)
        {
            return _collection.DeleteOneAsync(expression, options, cancellationToken);
        }

        /// <summary>
        /// 删除（单个）
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task<DeleteResult> DeleteOneAsync(IClientSessionHandle session, Expression<Func<T, bool>> expression, DeleteOptions options = null, CancellationToken cancellationToken = default)
        {
            return _collection.DeleteOneAsync(session, expression, options, cancellationToken);
        }

        /// <summary>
        /// 删除（批量）
        /// </summary>
        /// <param name="documents">文档对象</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public async Task<List<DeleteResult>> DeleteManyAsync(IEnumerable<T> documents, DeleteOptions options = null, CancellationToken cancellationToken = default)
        {
            var results = new List<DeleteResult>();
            foreach (var document in documents)
            {
                var result = await _collection.DeleteOneAsync(d => d.Id == document.Id, options, cancellationToken);
                results.Add(result);
            }
            return results;
        }

        /// <summary>
        /// 删除（批量）
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="documents">文档对象</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public async Task<List<DeleteResult>> DeleteManyAsync(IClientSessionHandle session, IEnumerable<T> documents, DeleteOptions options = null, CancellationToken cancellationToken = default)
        {
            var results = new List<DeleteResult>();
            foreach (var document in documents)
            {
                var result = await _collection.DeleteOneAsync(session, d => d.Id == document.Id, options, cancellationToken);
                results.Add(result);
            }
            return results;
        }

        /// <summary>
        /// 删除（批量）
        /// </summary>
        /// <param name="expression">文档对象</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task<DeleteResult> DeleteManyAsync(Expression<Func<T, bool>> expression, DeleteOptions options = null, CancellationToken cancellationToken = default)
        {
            return _collection.DeleteManyAsync(expression, options, cancellationToken);
        }

        /// <summary>
        /// 删除（批量）
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="expression">文档对象</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task<DeleteResult> DeleteManyAsync(IClientSessionHandle session, Expression<Func<T, bool>> expression, DeleteOptions options = null, CancellationToken cancellationToken = default)
        {
            return _collection.DeleteManyAsync(session, expression, options, cancellationToken);
        }

        /// <summary>
        /// 根据主文档的默认id动态的删除附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="id">文档对象ID</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task<DeleteResult> DynamicCollectionDeleteOneAsync<TForeign>(
            TForeign foreignDocument,
            string id,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).DeleteOneAsync(d => d.Id == id, options, cancellationToken);
        }

        /// <summary>
        /// 根据主文档的默认id动态的删除附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="id">文档对象ID</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task<DeleteResult> DynamicCollectionDeleteOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            string id,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).DeleteOneAsync(session, d => d.Id == id, options, cancellationToken);
        }

        /// <summary>
        /// 根据主文档的默认id动态的删除附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="document">文档对象</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task<DeleteResult> DynamicCollectionDeleteOneAsync<TForeign>(
            TForeign foreignDocument,
            T document,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).DeleteOneAsync(d => d.Id == document.Id, options, cancellationToken);
        }

        /// <summary>
        /// 根据主文档的默认id动态的删除附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="document">文档对象</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task<DeleteResult> DynamicCollectionDeleteOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            T document,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).DeleteOneAsync(session, d => d.Id == document.Id, options, cancellationToken);
        }

        /// <summary>
        /// 根据主文档的默认id动态的删除附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task<DeleteResult> DynamicCollectionDeleteOneAsync<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).DeleteOneAsync(expression, options, cancellationToken);
        }

        /// <summary>
        /// 根据主文档的默认id动态的删除附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task<DeleteResult> DynamicCollectionDeleteOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).DeleteOneAsync(session, expression, options, cancellationToken);
        }

        /// <summary>
        /// 根据主文档的默认id动态的删除附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="documents">文档对象</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public async Task<List<DeleteResult>> DynamicCollectionDeleteManyAsync<TForeign>(
            TForeign foreignDocument,
            IEnumerable<T> documents,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            var results = new List<DeleteResult>();
            foreach (var document in documents)
            {
                var result = await _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).DeleteOneAsync(d => d.Id == document.Id, options, cancellationToken);
                results.Add(result);
            }
            return results;
        }

        /// <summary>
        /// 根据主文档的默认id动态的删除附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="documents">文档对象</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public async Task<List<DeleteResult>> DynamicCollectionDeleteManyAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            IEnumerable<T> documents,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            var results = new List<DeleteResult>();
            foreach (var document in documents)
            {
                var result = await _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).DeleteOneAsync(session, d => d.Id == document.Id, options, cancellationToken);
                results.Add(result);
            }
            return results;
        }

        /// <summary>
        /// 根据主文档的默认id动态的删除附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task<DeleteResult> DynamicCollectionDeleteManyAsync<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).DeleteOneAsync(expression, options, cancellationToken);

        }

        /// <summary>
        /// 根据主文档的默认id动态的删除附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="expression">Lambda过滤器</param>
        /// <param name="settings">集合设置</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task<DeleteResult> DynamicCollectionDeleteManyAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}", settings).DeleteOneAsync(session, expression, options, cancellationToken);
        }

        #endregion
    }
}
