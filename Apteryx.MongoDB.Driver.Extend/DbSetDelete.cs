using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using MongoDB.Driver;
using static System.Collections.Specialized.BitVector32;

namespace Apteryx.MongoDB.Driver.Extend
{
    public partial class DbSet<T>
    {
        #region 删除（同步）

        /// <summary>
        /// 删除（单个）
        /// </summary>
        /// <param name="id">文档对象ID</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public DeleteResult DeleteOne(string id, DeleteOptions options = null, CancellationToken cancellationToken = default)
        {
            return _collection.DeleteOne(d => d.Id == id, options, cancellationToken);
        }

        /// <summary>
        /// 删除（单个）
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="id">文档对象ID</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public DeleteResult DeleteOne(IClientSessionHandle session, string id, DeleteOptions options = null, CancellationToken cancellationToken = default)
        {
            return _collection.DeleteOne(session, d => d.Id == id, options, cancellationToken);
        }

        /// <summary>
        /// 删除（单个）
        /// </summary>
        /// <param name="document">文档对象</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public DeleteResult DeleteOne(T document, DeleteOptions options = null, CancellationToken cancellationToken = default)
        {
            return _collection.DeleteOne(d => d.Id == document.Id, options, cancellationToken);
        }

        /// <summary>
        /// 删除（单个）
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public DeleteResult DeleteOne(IClientSessionHandle session, T document, DeleteOptions options = null, CancellationToken cancellationToken = default)
        {
            return _collection.DeleteOne(session, d => d.Id == document.Id, options, cancellationToken);
        }

        /// <summary>
        /// 删除（单个）
        /// </summary>
        /// <param name="expression">表达式</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public DeleteResult DeleteOne(Expression<Func<T, bool>> expression, DeleteOptions options = null, CancellationToken cancellationToken = default)
        {
            return _collection.DeleteOne(expression, options, cancellationToken);
        }

        /// <summary>
        /// 删除（单个）
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="expression">表达式</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public DeleteResult DeleteOne(IClientSessionHandle session, Expression<Func<T, bool>> expression, DeleteOptions options = null, CancellationToken cancellationToken = default)
        {
            return _collection.DeleteOne(session, expression, options, cancellationToken);
        }

        /// <summary>
        /// 删除（批量）
        /// </summary>
        /// <param name="documents">文档对象</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public IEnumerable<DeleteResult> DeleteMany(IEnumerable<T> documents, DeleteOptions options = null, CancellationToken cancellationToken = default)
        {
            foreach (var document in documents)
            {
                yield return _collection.DeleteOne(d => d.Id == document.Id, options, cancellationToken);
            }
        }

        /// <summary>
        /// 删除（批量）
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="documents">文档对象</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public IEnumerable<DeleteResult> DeleteMany(IClientSessionHandle session, IEnumerable<T> documents, DeleteOptions options = null, CancellationToken cancellationToken = default)
        {
            foreach (var document in documents)
            {
                yield return _collection.DeleteOne(session, d => d.Id == document.Id, options, cancellationToken);
            }
        }

        /// <summary>
        /// 删除（批量）
        /// </summary>
        /// <param name="expression">文档对象</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public DeleteResult DeleteMany(Expression<Func<T, bool>> expression, DeleteOptions options = null, CancellationToken cancellationToken = default)
        {
            return _collection.DeleteMany(expression, options, cancellationToken);
        }

        /// <summary>
        /// 删除（批量）
        /// </summary>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="expression">文档对象</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public DeleteResult DeleteMany(IClientSessionHandle session, Expression<Func<T, bool>> expression, DeleteOptions options = null, CancellationToken cancellationToken = default)
        {
            return _collection.DeleteMany(session, expression, options, cancellationToken);
        }

        /// <summary>
        /// 根据主文档的默认id动态的删除附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="id">文档对象ID</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public DeleteResult DynamicCollectionDeleteOne<TForeign>(TForeign foreignDocument, string id, DeleteOptions options = null, CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}").DeleteOne(d => d.Id == id, options, cancellationToken);
        }

        /// <summary>
        /// 根据主文档的默认id动态的删除附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="id">文档对象ID</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public DeleteResult DynamicCollectionDeleteOne<TForeign>(IClientSessionHandle session, TForeign foreignDocument, string id, DeleteOptions options = null, CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}").DeleteOne<T>(session, d => d.Id == id, options, cancellationToken);
        }

        /// <summary>
        /// 根据主文档的默认id动态的删除附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public DeleteResult DynamicCollectionDeleteOne<TForeign>(TForeign foreignDocument, T document, DeleteOptions options = null, CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}").DeleteOne<T>(d => d.Id == document.Id, options, cancellationToken);
        }

        /// <summary>
        /// 根据主文档的默认id动态的删除附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public DeleteResult DynamicCollectionDeleteOne<TForeign>(IClientSessionHandle session, TForeign foreignDocument, T document, DeleteOptions options = null, CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}").DeleteOne<T>(session, d => d.Id == document.Id, options, cancellationToken);
        }

        /// <summary>
        /// 根据主文档的默认id动态的删除附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public DeleteResult DynamicCollectionDeleteOne<TForeign>(TForeign foreignDocument, Expression<Func<T, bool>> expression, DeleteOptions options = null, CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}").DeleteOne(expression, options, cancellationToken);
        }

        /// <summary>
        /// 根据主文档的默认id动态的删除附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public DeleteResult DynamicCollectionDeleteOne<TForeign>(IClientSessionHandle session, TForeign foreignDocument, Expression<Func<T, bool>> expression, DeleteOptions options = null, CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}").DeleteOne<T>(session, expression, options, cancellationToken);
        }

        /// <summary>
        /// 根据主文档的默认id动态的删除附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="documents">文档对象</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public IEnumerable<DeleteResult> DynamicCollectionDeleteMany<TForeign>(TForeign foreignDocument, IEnumerable<T> documents, DeleteOptions options = null, CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            foreach (var document in documents)
            {
                yield return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}").DeleteOne<T>(d => d.Id == document.Id, options, cancellationToken);
            }
        }

        /// <summary>
        /// 根据主文档的默认id动态的删除附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="documents">文档对象</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public IEnumerable<DeleteResult> DynamicCollectionDeleteMany<TForeign>(IClientSessionHandle session, TForeign foreignDocument, IEnumerable<T> documents, DeleteOptions options = null, CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            foreach (var document in documents)
            {
                yield return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}").DeleteOne<T>(session, d => d.Id == document.Id, options, cancellationToken);
            }
        }

        /// <summary>
        /// 根据主文档的默认id动态的删除附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="expression">表达式</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public DeleteResult DynamicCollectionDeleteMany<TForeign>(TForeign foreignDocument, Expression<Func<T, bool>> expression, DeleteOptions options = null, CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}").DeleteMany(expression, options, cancellationToken);

        }

        /// <summary>
        /// 根据主文档的默认id动态的删除附文档的集合,集合名称规则:"{主文档默认id}_{附文档名}"
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档</param>
        /// <param name="expression">表达式</param>
        /// <param name="options">删除操作选项</param>
        /// <param name="cancellationToken">取消令牌</param>
        public DeleteResult DynamicCollectionDeleteMany<TForeign>(IClientSessionHandle session, TForeign foreignDocument, Expression<Func<T, bool>> expression, DeleteOptions options = null, CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
        {
            return _database.GetCollection<T>($"{foreignDocument.Id}_{_collectionName}").DeleteMany(session, expression, options, cancellationToken);
        }

        #endregion
    }
}
