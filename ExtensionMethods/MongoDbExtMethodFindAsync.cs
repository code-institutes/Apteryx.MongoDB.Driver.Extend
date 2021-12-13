using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Apteryx.MongoDB.Driver.Extend;
using MongoDB.Driver;

namespace Apteryx.MongoDB.Driver.Extend
{
    /// <summary>
    /// MongoDb扩展方法:查询(异步)
    /// </summary>
    public static partial class MongoDbExtensionMethod
    {
        #region 查询(异步)

        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">集合类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="options">查询操作设置</param>
        /// <returns></returns>
        public static Task<T> FindOneAsync<T>(this IMongoCollection<T> collection, string id,FindOptions options = null)
            where T : BaseMongoEntity
        {
            return Task.Run(() => FindOne(collection, id,options));
        }

        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">集合类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="options">查询操作设置</param>
        public static Task<T> FindOneAsync<T>(this IMongoCollection<T> collection,IClientSessionHandle session, string id, FindOptions options = null)
            where T : BaseMongoEntity
        {
            return Task.Run(() => FindOne(collection,session, id, options));
        }

        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">集合类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="options">聚合操作设置</param>
        /// <returns></returns>
        public static Task<T> MatchOneAsync<T>(this IMongoCollection<T> collection, string id,AggregateOptions options = null)
            where T : BaseMongoEntity
        {
            return Task.Run(() => MatchOne(collection, id,options));
        }

        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">集合类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="options">聚合操作设置</param>
        /// <returns></returns>
        public static Task<T> MatchOneAsync<T>(this IMongoCollection<T> collection,IClientSessionHandle session, string id, AggregateOptions options = null)
            where T : BaseMongoEntity
        {
            return Task.Run(() => MatchOne(collection,session, id, options));
        }

        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">集合类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="filter">过滤器</param>
        /// <param name="options">查询操作设置</param>
        /// <returns></returns>
        public static Task<T> FindOneAsync<T>(this IMongoCollection<T> collection, FilterDefinition<T> filter,FindOptions options = null)
            where T : BaseMongoEntity
        {
            return Task.Run(() => FindOne(collection, filter,options));
        }

        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">集合类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>
        /// <param name="options">查询操作设置</param>
        /// <returns></returns>
        public static Task<T> FindOneAsync<T>(this IMongoCollection<T> collection,IClientSessionHandle session, FilterDefinition<T> filter, FindOptions options = null)
            where T : BaseMongoEntity
        {
            return Task.Run(() => FindOne(collection,session, filter, options));
        }

        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">集合类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="filter">Lmabda过滤器</param>
        /// <param name="options">查询操作设置</param>
        /// <returns></returns>
        public static Task<T> FindOneAsync<T>(this IMongoCollection<T> collection, Expression<Func<T, bool>> filter,FindOptions options = null)
            where T : BaseMongoEntity
        {
            return Task.Run(() => FindOne(collection, filter,options));
        }

        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">集合类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">Lmabda过滤器</param>
        /// <param name="options">查询操作设置</param>
        /// <returns></returns>
        public static Task<T> FindOneAsync<T>(this IMongoCollection<T> collection,IClientSessionHandle session, Expression<Func<T, bool>> filter, FindOptions options = null)
            where T : BaseMongoEntity
        {
            return Task.Run(() => FindOne(collection,session, filter, options));
        }

        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">集合类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="filter">Lmabda过滤器</param>
        /// <param name="options">聚合操作设置</param>
        /// <returns></returns>
        public static Task<T> MatchOneAsync<T>(this IMongoCollection<T> collection, Expression<Func<T, bool>> filter,AggregateOptions options = null)
            where T : BaseMongoEntity
        {
            return Task.Run(() => MatchOne(collection, filter,options));
        }

        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">集合类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">Lmabda过滤器</param>
        /// <param name="options">聚合操作设置</param>
        /// <returns></returns>
        public static Task<T> MatchOneAsync<T>(this IMongoCollection<T> collection,IClientSessionHandle session, Expression<Func<T, bool>> filter, AggregateOptions options = null)
            where T : BaseMongoEntity
        {
            return Task.Run(() => MatchOne(collection,session, filter, options));
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="options">查询操作设置</param>
        /// <returns></returns>
        public static Task<IEnumerable<T>> FindAllAsync<T>(this IMongoCollection<T> collection,FindOptions options = null)
            where T : BaseMongoEntity
        {
            return Task.Run(() => FindAll(collection,options));
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="options">查询操作设置</param>
        /// <returns></returns>
        public static Task<IEnumerable<T>> FindAllAsync<T>(this IMongoCollection<T> collection,IClientSessionHandle session, FindOptions options = null)
            where T : BaseMongoEntity
        {
            return Task.Run(() => FindAll(collection,session, options));
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="filte">过滤器</param>
        /// <param name="options">查询操作设置</param>
        /// <returns></returns>
        public static Task<IEnumerable<T>> WhereAsync<T>(this IMongoCollection<T> collection, FilterDefinition<T> filter,FindOptions options = null)
            where T : BaseMongoEntity
        {
            return Task.Run(() => Where(collection, filter,options));
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filte">过滤器</param>
        /// <param name="options">查询操作设置</param>
        /// <returns></returns>
        public static Task<IEnumerable<T>> WhereAsync<T>(this IMongoCollection<T> collection,IClientSessionHandle session, FilterDefinition<T> filter, FindOptions options = null)
            where T : BaseMongoEntity
        {
            return Task.Run(() => Where(collection,session, filter, options));
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="filte">Lambda过滤器</param>
        /// <param name="options">查询操作设置</param>
        /// <returns></returns>
        public static Task<IEnumerable<T>> WhereAsync<T>(this IMongoCollection<T> collection, Expression<Func<T, bool>> filter,FindOptions options = null)
            where T : BaseMongoEntity
        {
            return Task.Run(() => Where(collection, filter,options));
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filte">Lambda过滤器</param>
        /// <param name="options">查询操作设置</param>
        /// <returns></returns>
        public static Task<IEnumerable<T>> WhereAsync<T>(this IMongoCollection<T> collection,IClientSessionHandle session, Expression<Func<T, bool>> filter, FindOptions options = null)
            where T : BaseMongoEntity
        {
            return Task.Run(() => Where(collection,session, filter, options));
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="filte">Lambda过滤器</param>
        /// <param name="options">聚合操作设置</param>
        /// <returns></returns>
        public static Task<IEnumerable<T>> MatchAsync<T>(this IMongoCollection<T> collection, Expression<Func<T, bool>> filter,AggregateOptions options = null)
            where T : BaseMongoEntity
        {
            return Task.Run(() => Match(collection, filter,options));
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filte">Lambda过滤器</param>
        /// <param name="options">聚合操作设置</param>
        /// <returns></returns>
        public static Task<IEnumerable<T>> MatchAsync<T>(this IMongoCollection<T> collection,IClientSessionHandle session, Expression<Func<T, bool>> filter, AggregateOptions options = null)
            where T : BaseMongoEntity
        {
            return Task.Run(() => Match(collection,session, filter, options));
        }

        #endregion
    }
}
