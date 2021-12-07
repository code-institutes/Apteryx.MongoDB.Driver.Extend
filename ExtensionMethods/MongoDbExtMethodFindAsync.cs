using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Apteryx.MongoDB.Driver.Extend.Entities;
using MongoDB.Driver;

namespace Apteryx.MongoDB.Driver.Extend.ExtensionMethods
{
    /// <summary>
    /// MongoDb扩展方法:查询(异步)
    /// </summary>
    public static partial class MongoDbExtensionMethod
    {
        #region 查询(异步)

        /// <summary>
        ///  查询返回单条
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public static Task<T> FindOneAsync<T>(this IMongoCollection<T> collection, string id)
            where T : BaseMongoEntity
        {
            return Task.Run(() => FindOne(collection, id));
        }

        /// <summary>
        ///  查询返回单条
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public static Task<T> MatchOneAsync<T>(this IMongoCollection<T> collection, string id)
            where T : BaseMongoEntity
        {
            return Task.Run(() => MatchOne(collection, id));
        }

        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="filter">过滤器</param>
        /// <returns></returns>
        public static Task<T> FindOneAsync<T>(this IMongoCollection<T> collection, FilterDefinition<T> filter)
            where T : BaseMongoEntity
        {
            return Task.Run(() => FindOne(collection, filter));
        }

        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <returns></returns>
        public static Task<T> FindOneAsync<T>(this IMongoCollection<T> collection, Expression<Func<T, bool>> filter)
            where T : BaseMongoEntity
        {
            return Task.Run(() => FindOne(collection, filter));
        }

        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <returns></returns>
        public static Task<T> MatchOneAsync<T>(this IMongoCollection<T> collection, Expression<Func<T, bool>> filter)
            where T : BaseMongoEntity
        {
            return Task.Run(() => MatchOne(collection, filter));
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static Task<IEnumerable<T>> FindAllAsync<T>(this IMongoCollection<T> collection)
            where T : BaseMongoEntity
        {
            return Task.Run(() => FindAll(collection));
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static Task<IEnumerable<T>> WhereAsync<T>(this IMongoCollection<T> collection, FilterDefinition<T> filter)
            where T : BaseMongoEntity
        {
            return Task.Run(() => Where(collection, filter));
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static Task<IEnumerable<T>> WhereAsync<T>(this IMongoCollection<T> collection, Expression<Func<T, bool>> filter)
            where T : BaseMongoEntity
        {
            return Task.Run(() => Where(collection, filter));
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <returns></returns>
        public static Task<IEnumerable<T>> MatchAsync<T>(this IMongoCollection<T> collection, Expression<Func<T, bool>> filter)
            where T : BaseMongoEntity
        {
            return Task.Run(() => Match(collection, filter));
        }

        /// <summary>
        /// 动态表查询单条
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public static Task<T> DynamicTableFindOneAsync<TForeign, T>(this IMongoCollection<T> collection, TForeign foreignDocument, string id)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return Task.Run(() => DynamicTableFindOne(collection, foreignDocument, id));
        }

        /// <summary>
        /// 动态表查询单条
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public static Task<T> DynamicTableMatchOneAsync<TForeign, T>(this IMongoCollection<T> collection, TForeign foreignDocument, string id)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return Task.Run(() => DynamicTableMatchOne(collection, foreignDocument, id));
        }

        /// <summary>
        /// 动态表查询单条
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <returns></returns>
        public static Task<T> DynamicTableFindOneAsync<TForeign, T>(this IMongoCollection<T> collection, TForeign foreignDocument, FilterDefinition<T> filter)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return Task.Run(() => DynamicTableFindOne(collection, foreignDocument, filter));
        }

        /// <summary>
        /// 动态表查询单条
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <returns></returns>
        public static Task<T> DynamicTableFindOneAsync<TForeign, T>(this IMongoCollection<T> collection, TForeign foreignDocument, Expression<Func<T, bool>> filter)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return Task.Run(() => DynamicTableFindOne(collection, foreignDocument, filter));
        }

        /// <summary>
        /// 动态表查询单条
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <returns></returns>
        public static Task<T> DynamicTableMatchOneAsync<TForeign, T>(this IMongoCollection<T> collection, TForeign foreignDocument, Expression<Func<T, bool>> filter)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return Task.Run(() => DynamicTableMatchOne(collection, foreignDocument, filter));
        }

        /// <summary>
        /// 动态表查询全部
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="foreignDocument">文档对象</param>
        /// <returns></returns>
        public static Task<IEnumerable<T>> DynamicTableFindAllAsync<TForeign, T>(this IMongoCollection<T> collection, TForeign foreignDocument)
        where TForeign : BaseMongoEntity
        where T : BaseMongoEntity
        {
            return Task.Run(() => DynamicTableFindAll(collection, foreignDocument));
        }

        /// <summary>
        /// 动态表条件查询
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <returns></returns>
        public static Task<IEnumerable<T>> DynamicTableWhereAsync<TForeign, T>(this IMongoCollection<T> collection, TForeign foreignDocument, FilterDefinition<T> filter)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return Task.Run(() => DynamicTableWhere(collection, foreignDocument, filter));
        }

        /// <summary>
        /// 动态表条件查询
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <returns></returns>
        public static Task<IEnumerable<T>> DynamicTableWhereAsync<TForeign, T>(this IMongoCollection<T> collection, TForeign foreignDocument, Expression<Func<T, bool>> filter)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return Task.Run(() => DynamicTableWhere(collection, foreignDocument, filter));
        }

        /// <summary>
        /// 动态表条件查询
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <returns></returns>
        public static Task<IEnumerable<T>> DynamicTableMatchAsync<TForeign, T>(this IMongoCollection<T> collection, TForeign foreignDocument, Expression<Func<T, bool>> filter)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return Task.Run(() => DynamicTableMatch(collection, foreignDocument, filter));
        }

        #endregion
    }
}
