using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using Apteryx.MongoDB.Driver.Extend.Entities;
using MongoDB.Driver;

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
        /// <returns></returns>
        public static T FindOne<T>(this IMongoCollection<T> collection, string id)
            where T : BaseMongoEntity
        {
            return collection.Find(f=>f.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">集合类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public static T MatchOne<T>(this IMongoCollection<T> collection, string id)
            where T : BaseMongoEntity
        {
            return collection.AsQueryable().FirstOrDefault(f => f.Id == id);
        }

        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">集合类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="filter">过滤器</param>
        /// <returns></returns>
        public static T FindOne<T>(this IMongoCollection<T> collection, FilterDefinition<T> filter)
            where T : BaseMongoEntity
        {
            return collection.Find(filter).FirstOrDefault();
        }

        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">集合类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="filter">Lmabda过滤器</param>
        /// <returns></returns>
        public static T FindOne<T>(this IMongoCollection<T> collection, Expression<Func<T, bool>> filter)
            where T : BaseMongoEntity
        {
            return collection.Find(filter).FirstOrDefault();
        }
        /// <summary>
        /// 查询返回单条
        /// </summary>
        /// <typeparam name="T">集合类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="filter">Lmabda过滤器</param>
        /// <returns></returns>
        public static T MatchOne<T>(this IMongoCollection<T> collection, Expression<Func<T, bool>> filter)
            where T : BaseMongoEntity
        {
            return collection.AsQueryable().FirstOrDefault(filter);
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static IEnumerable<T> FindAll<T>(this IMongoCollection<T> collection)
            where T : BaseMongoEntity
        {
            return collection.Find(_ => true).ToEnumerable();
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="filte">Lambda过滤器</param>
        /// <returns></returns>
        public static IEnumerable<T> Where<T>(this IMongoCollection<T> collection, FilterDefinition<T> filte)
            where T : BaseMongoEntity
        {
            return collection.Find(filte).ToEnumerable();
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="filte">Lambda过滤器</param>
        /// <returns></returns>
        public static IEnumerable<T> Where<T>(this IMongoCollection<T> collection, Expression<Func<T, bool>> filte)
            where T : BaseMongoEntity
        {
            return collection.Find(filte).ToEnumerable();
        }

        /// <summary>
        /// 查询返回集合
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="filte">Lambda过滤器</param>
        /// <returns></returns>
        public static IEnumerable<T> Match<T>(this IMongoCollection<T> collection, Expression<Func<T, bool>> filte)
            where T : BaseMongoEntity
        {
            return collection.AsQueryable().Where(filte);
        }

        /// <summary>
        /// 动态表查询返回单条
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public static T DynamicTableFindOne<TForeign, T>(this IMongoCollection<T> collection, TForeign foreignDocument, string id)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return collection.Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").Find(f=>f.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// 动态表查询返回单条
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public static T DynamicTableMatchOne<TForeign, T>(this IMongoCollection<T> collection, TForeign foreignDocument, string id)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return collection.Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").AsQueryable().FirstOrDefault(f => f.Id == id);
        }

        /// <summary>
        /// 动态表查询返回单条
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <returns></returns>
        public static T DynamicTableFindOne<TForeign, T>(this IMongoCollection<T> collection, TForeign foreignDocument, FilterDefinition<T> filter)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return collection.Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").Find(filter).FirstOrDefault();
        }

        /// <summary>
        /// 动态表查询返回单条
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <returns></returns>
        public static T DynamicTableFindOne<TForeign, T>(this IMongoCollection<T> collection, TForeign foreignDocument, Expression<Func<T, bool>> filter)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return collection.Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").Find(filter).FirstOrDefault();
        }

        /// <summary>
        /// 动态表查询返回单条
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <returns></returns>
        public static T DynamicTableMatchOne<TForeign, T>(this IMongoCollection<T> collection, TForeign foreignDocument, Expression<Func<T, bool>> filter)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return collection.Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").AsQueryable().FirstOrDefault(filter);
        }

        /// <summary>
        /// 动态表查询全部
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="foreignDocument">文档对象</param>
        /// <returns></returns>
        public static IEnumerable<T> DynamicTableFindAll<TForeign, T>(this IMongoCollection<T> collection, TForeign foreignDocument)
        where TForeign : BaseMongoEntity
        where T : BaseMongoEntity
        {
            return collection.Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").Find(_ => true).ToEnumerable();
        }

        /// <summary>
        /// 动态表查询返回集合
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <returns></returns>
        public static IEnumerable<T> DynamicTableWhere<TForeign, T>(this IMongoCollection<T> collection, TForeign foreignDocument, FilterDefinition<T> filter)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return collection.Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").Find(filter).ToEnumerable();
        }

        /// <summary>
        /// 动态表查询返回集合
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <returns></returns>
        public static IEnumerable<T> DynamicTableWhere<TForeign, T>(this IMongoCollection<T> collection, TForeign foreignDocument, Expression<Func<T, bool>> filter)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return collection.Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").Find(filter).ToEnumerable();
        }

        /// <summary>
        /// 动态表查询返回集合
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="foreignDocument">文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <returns></returns>
        public static IEnumerable<T> DynamicTableMatch<TForeign, T>(this IMongoCollection<T> collection, TForeign foreignDocument, Expression<Func<T, bool>> filter)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return collection.Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").AsQueryable().Where(filter);
        }

        #endregion
    }
}
