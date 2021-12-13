﻿using System;
using System.Linq.Expressions;
using System.Threading;
using Apteryx.MongoDB.Driver.Extend.Entities;
using MongoDB.Driver;

namespace Apteryx.MongoDB.Driver.Extend.ExtensionMethods
{
    public static partial class MongoDbExtensionMethod
    {
        #region 替换(同步)

        /// <summary>
        /// 替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public static ReplaceOneResult WhereReplaceOne<T>(
            this IMongoCollection<T> collection,
            string id,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return collection.ReplaceOne(r => r.Id == id, document, options, cancellationToken);
        }

        /// <summary>
        /// 替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public static ReplaceOneResult WhereReplaceOne<T>(
            this IMongoCollection<T> collection,
            IClientSessionHandle session,
            string id,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return collection.ReplaceOne(session, r => r.Id == id, document, options, cancellationToken);
        }

        /// <summary>
        /// 替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="filter">过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public static ReplaceOneResult WhereReplaceOne<T>(
            this IMongoCollection<T> collection,
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return collection.ReplaceOne(filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public static ReplaceOneResult WhereReplaceOne<T>(
            this IMongoCollection<T> collection,
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return collection.ReplaceOne(session, filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public static ReplaceOneResult WhereReplaceOne<T>(
            this IMongoCollection<T> collection,
            Expression<Func<T, bool>> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return collection.ReplaceOne(filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public static ReplaceOneResult WhereReplaceOne<T>(
            this IMongoCollection<T> collection,
            IClientSessionHandle session,
            Expression<Func<T, bool>> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return collection.ReplaceOne(session, filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 查询替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public static T FindOneAndReplaceOne<T>(
            this IMongoCollection<T> collection,
            string id,
            T document,
            FindOneAndReplaceOptions<T, T> options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return collection.FindOneAndReplace<T, T>(fr => fr.Id == id, document, options, cancellationToken);
        }

        /// <summary>
        /// 查询替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public static T FindOneAndReplaceOne<T>(
            this IMongoCollection<T> collection,
            IClientSessionHandle session,
            string id,
            T document,
            FindOneAndReplaceOptions<T, T> options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return collection.FindOneAndReplace<T, T>(session, fr => fr.Id == id, document, options, cancellationToken);
        }

        /// <summary>
        /// 查询替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="filter">过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public static T FindOneAndReplaceOne<T>(
            this IMongoCollection<T> collection,
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T, T> options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return collection.FindOneAndReplace(filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 查询替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public static T FindOneAndReplaceOne<T>(
            this IMongoCollection<T> collection,
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T, T> options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return collection.FindOneAndReplace(session, filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 查询替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public static T FindOneAndReplaceOne<T>(
            this IMongoCollection<T> collection,
            Expression<Func<T, bool>> filter,
            T document,
            FindOneAndReplaceOptions<T, T> options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return collection.FindOneAndReplace(filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 查询替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public static T FindOneAndReplaceOne<T>(
            this IMongoCollection<T> collection,
            IClientSessionHandle session,
            Expression<Func<T, bool>> filter,
            T document,
            FindOneAndReplaceOptions<T, T> options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return collection.FindOneAndReplace(session, filter, document, options, cancellationToken);
        }

        #endregion
    }
}
