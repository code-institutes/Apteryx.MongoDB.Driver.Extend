using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using Apteryx.MongoDB.Driver.Extend.Entities;
using MongoDB.Driver;
using System.Threading;

namespace Apteryx.MongoDB.Driver.Extend.ExtensionMethods
{
    /// <summary>
    /// MongoDb扩展方法:查询(同步)
    /// </summary>
    public static partial class MongoDbExtensionMethod
    {
        #region 查询(同步)

        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">集合类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="id">主键ID</param>
        /// <param name="options">查询操作设置</param>
        /// <returns></returns>
        public static T FindOne<T>(this IMongoCollection<T> collection, string id, FindOptions options = null)
            where T : BaseMongoEntity
        {
            return collection.Find(f => f.Id == id, options).FirstOrDefault();
        }

        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">集合类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="id">主键ID</param>
        /// <param name="options">查询操作设置</param>
        public static T FindOne<T>(this IMongoCollection<T> collection, IClientSessionHandle session, string id, FindOptions options = null)
            where T : BaseMongoEntity
        {
            return collection.Find(session, f => f.Id == id, options).FirstOrDefault();
        }

        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">集合类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="id">主键ID</param>
        /// <param name="options">聚合操作设置</param>
        /// <returns></returns>
        public static T MatchOne<T>(this IMongoCollection<T> collection, string id, AggregateOptions options = null)
            where T : BaseMongoEntity
        {
            return collection.AsQueryable(options).FirstOrDefault(f => f.Id == id);
        }

        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">集合类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="id">主键ID</param>
        /// <param name="options">聚合操作设置</param>
        /// <returns></returns>
        public static T MatchOne<T>(this IMongoCollection<T> collection, IClientSessionHandle session, string id, AggregateOptions options = null)
            where T : BaseMongoEntity
        {
            return collection.AsQueryable(session, options).FirstOrDefault(f => f.Id == id);
        }

        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">集合类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="filter">过滤器</param>
        /// <param name="options">查询操作设置</param>
        /// <returns></returns>
        public static T FindOne<T>(this IMongoCollection<T> collection, FilterDefinition<T> filter, FindOptions options = null)
            where T : BaseMongoEntity
        {
            return collection.Find(filter, options).FirstOrDefault();
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
        public static T FindOne<T>(this IMongoCollection<T> collection, IClientSessionHandle session, FilterDefinition<T> filter, FindOptions options = null)
            where T : BaseMongoEntity
        {
            return collection.Find(session, filter, options).FirstOrDefault();
        }

        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">集合类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="filter">Lmabda过滤器</param>
        /// <param name="options">查询操作设置</param>
        /// <returns></returns>
        public static T FindOne<T>(this IMongoCollection<T> collection, Expression<Func<T, bool>> filter, FindOptions options = null)
            where T : BaseMongoEntity
        {
            return collection.Find(filter, options).FirstOrDefault();
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
        public static T FindOne<T>(this IMongoCollection<T> collection, IClientSessionHandle session, Expression<Func<T, bool>> filter, FindOptions options = null)
            where T : BaseMongoEntity
        {
            return collection.Find(session, filter, options).FirstOrDefault();
        }

        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">集合类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="filter">Lmabda过滤器</param>
        /// <param name="options">聚合操作设置</param>
        /// <returns></returns>
        public static T MatchOne<T>(this IMongoCollection<T> collection, Expression<Func<T, bool>> filter, AggregateOptions options = null)
            where T : BaseMongoEntity
        {
            return collection.AsQueryable(options).FirstOrDefault(filter);
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
        public static T MatchOne<T>(this IMongoCollection<T> collection, IClientSessionHandle session, Expression<Func<T, bool>> filter, AggregateOptions options = null)
            where T : BaseMongoEntity
        {
            return collection.AsQueryable(session, options).FirstOrDefault(filter);
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="options">查询操作设置</param>
        /// <returns></returns>
        public static IEnumerable<T> FindAll<T>(this IMongoCollection<T> collection, FindOptions options = null)
            where T : BaseMongoEntity
        {
            return collection.Find(_ => true, options).ToEnumerable();
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="options">查询操作设置</param>
        /// <returns></returns>
        public static IEnumerable<T> FindAll<T>(this IMongoCollection<T> collection, IClientSessionHandle session, FindOptions options = null)
            where T : BaseMongoEntity
        {
            return collection.Find(session, _ => true, options).ToEnumerable();
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="filte">过滤器</param>
        /// <param name="options">查询操作设置</param>
        /// <returns></returns>
        public static IEnumerable<T> Where<T>(this IMongoCollection<T> collection, FilterDefinition<T> filte, FindOptions options = null)
            where T : BaseMongoEntity
        {
            return collection.Find(filte, options).ToEnumerable();
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
        public static IEnumerable<T> Where<T>(this IMongoCollection<T> collection, IClientSessionHandle session, FilterDefinition<T> filte, FindOptions options = null)
            where T : BaseMongoEntity
        {
            return collection.Find(session, filte, options).ToEnumerable();
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="filte">Lambda过滤器</param>
        /// <param name="options">查询操作设置</param>
        /// <returns></returns>
        public static IEnumerable<T> Where<T>(this IMongoCollection<T> collection, Expression<Func<T, bool>> filte, FindOptions options = null)
            where T : BaseMongoEntity
        {
            return collection.Find(filte, options).ToEnumerable();
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
        public static IEnumerable<T> Where<T>(this IMongoCollection<T> collection, IClientSessionHandle session, Expression<Func<T, bool>> filte, FindOptions options = null)
            where T : BaseMongoEntity
        {
            return collection.Find(session, filte, options).ToEnumerable();
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="filte">Lambda过滤器</param>
        /// <param name="options">聚合操作设置</param>
        /// <returns></returns>
        public static IEnumerable<T> Match<T>(this IMongoCollection<T> collection, Expression<Func<T, bool>> filte, AggregateOptions options = null)
            where T : BaseMongoEntity
        {
            return collection.AsQueryable(options).Where(filte);
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
        public static IEnumerable<T> Match<T>(this IMongoCollection<T> collection,IClientSessionHandle session, Expression<Func<T, bool>> filte, AggregateOptions options = null)
            where T : BaseMongoEntity
        {
            return collection.AsQueryable(session,options).Where(filte);
        }

        #endregion
    }
}
