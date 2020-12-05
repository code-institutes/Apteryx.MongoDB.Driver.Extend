using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Apteryx.MongoDB.Driver.Extend.Entities;

namespace Apteryx.MongoDB.Driver.Extend.ExtensionMethods
{
    public static class IAsyncCursors
    {
        #region 插入(同步)

        /// <summary>
        /// 插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="document"></param>
        public static void Add<T>(this IMongoCollection<T> collection, T document)
        {
            collection.InsertOne(document);
        }

        /// <summary>
        /// 插入多条
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="documents"></param>
        public static void AddMany<T>(this IMongoCollection<T> collection, IEnumerable<T> documents)
        {
            collection.InsertMany(documents);
        }

        /// <summary>
        /// 根据关联对象动态的创建与关联对象相关的数据表
        /// </summary>
        /// <typeparam name="TForeign"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="foreignDocument">上级对象</param>
        /// <param name="document"></param>
        public static void DynamicTableAdd<TForeign, T>(this IMongoCollection<T> collection, TForeign foreignDocument,
            T document)
            where T : BaseMongoEntity
            where TForeign : BaseMongoEntity
        {
            collection.Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").InsertOne(document);
        }

        #endregion

        #region 插入(异步)

        /// <summary>
        /// 插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="document"></param>
        /// <returns></returns>
        public static Task AddAsync<T>(this IMongoCollection<T> collection, T document)
        {
            return collection.InsertOneAsync(document);
        }

        /// <summary>
        /// 插入多条
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="documents"></param>
        public static Task AddManyAsync<T>(this IMongoCollection<T> collection, IEnumerable<T> documents)
        {
            return collection.InsertManyAsync(documents);
        }

        /// <summary>
        /// 根据关联对象动态的创建与关联对象相关的数据表
        /// </summary>
        /// <typeparam name="TForeign"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="foreignDocument">上级对象</param>
        /// <param name="document"></param>
        public static Task DynamicTableAddAsync<TForeign, T>(this IMongoCollection<T> collection,
            TForeign foreignDocument, T document)
            where T : BaseMongoEntity
            where TForeign : BaseMongoEntity
        {
            return collection.Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}")
                .InsertOneAsync(document);
        }

        #endregion



        #region 查找(同步)

        /// <summary>
        /// 查找单条
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static T FindOne<T>(this IMongoCollection<T> collection, Expression<Func<T, bool>> filter)
            where T : BaseMongoEntity
        {
            return collection.Find(filter).FirstOrDefault();
        }

        /// <summary>
        /// 查找全部
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static IEnumerable<T> FindAll<T>(this IMongoCollection<T> collection)
        {
            return collection.Find(_ => true).ToEnumerable();
        }

        /// <summary>
        /// 根据条件查找
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="filte"></param>
        /// <returns></returns>
        public static IEnumerable<T> Where<T>(this IMongoCollection<T> collection, Expression<Func<T, bool>> filte)
        {
            return collection.Find(filte).ToEnumerable();
        }

        #endregion

        #region 查找(异步)

        /// <summary>
        /// 查找单条
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static Task<T> FindOneAsync<T>(this IMongoCollection<T> collection, Expression<Func<T, bool>> filter)
        {
            return (collection.Find(filter)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 查找全部
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static Task<IAsyncCursor<T>> FindAllAsync<T>(this IMongoCollection<T> collection)
        {
            return collection.FindAsync(_ => true);
        }

        /// <summary>
        /// 根据条件查找
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static Task<IAsyncCursor<T>> WhereAsync<T>(this IMongoCollection<T> collection,
            Expression<Func<T, bool>> filter)
        {
            return collection.FindAsync(filter);
        }

        #endregion



        #region 更新(同步)

        /// <summary>
        /// 更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static UpdateResult WhereUpdateOne<T>(
            this IMongoCollection<T> collection,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            return collection.UpdateOne(
                filter,
                update.Set(s => s.UpdateTime, DateTime.Now),
                options,
                cancellationToken);
        }

        /// <summary>
        /// 更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static UpdateResult WhereUpdateOne<T>(
            this IMongoCollection<T> collection,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            return collection.UpdateOne(
                filter,
                update.Set(s => s.UpdateTime, DateTime.Now),
                options,
                cancellationToken);
        }

        /// <summary>
        /// 替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="filter"></param>
        /// <param name="document"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static ReplaceOneResult WhereReplaceOne<T>(
            this IMongoCollection<T> collection,
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return collection.ReplaceOne(filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="filter"></param>
        /// <param name="document"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static ReplaceOneResult WhereReplaceOne<T>(
            this IMongoCollection<T> collection,
            Expression<Func<T, bool>> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return collection.ReplaceOne(filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 查找更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static T FindOneAndUpdateOne<T>(
            this IMongoCollection<T> collection,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T, T> options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            return collection.FindOneAndUpdate(
                filter,
                update.Set(s => s.UpdateTime, DateTime.Now),
                options,
                cancellationToken);
        }

        /// <summary>
        /// 查找更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static T FindOneAndUpdateOne<T>(
            this IMongoCollection<T> collection,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T, T> options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            return collection.FindOneAndUpdate(
                filter,
                update.Set(s => s.UpdateTime, DateTime.Now),
                options,
                cancellationToken);
        }

        /// <summary>
        /// 查找替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="filter"></param>
        /// <param name="document"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static T FindOneAndUpdateOne<T>(
            this IMongoCollection<T> collection,
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T, T> options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return collection.FindOneAndReplace(filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 查找替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="filter"></param>
        /// <param name="document"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static T FindOneAndUpdateOne<T>(
            this IMongoCollection<T> collection,
            Expression<Func<T, bool>> filter,
            T document,
            FindOneAndReplaceOptions<T, T> options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return collection.FindOneAndReplace(filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 查找更新多条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static UpdateResult WhereUpdateMany<T>(
            this IMongoCollection<T> collection,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            return collection.UpdateMany(
                filter,
                update.Set(s => s.UpdateTime, DateTime.Now),
                options,
                cancellationToken);
        }

        #endregion

        #region 更新(异步)

        /// <summary>
        /// 更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<UpdateResult> WhereUpdateOneAsync<T>(
            this IMongoCollection<T> collection,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            return collection.UpdateOneAsync(
                filter,
                update.Set(s => s.UpdateTime, DateTime.Now),
                options,
                cancellationToken);
        }

        /// <summary>
        /// 更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<UpdateResult> WhereUpdateOneAsync<T>(
            this IMongoCollection<T> collection,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            return collection.UpdateOneAsync(
                filter,
                update.Set(s => s.UpdateTime, DateTime.Now),
                options,
                cancellationToken);
        }

        /// <summary>
        /// 替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="filter"></param>
        /// <param name="document"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<ReplaceOneResult> WhereUpdateOneAsync<T>(
            this IMongoCollection<T> collection,
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return collection.ReplaceOneAsync(filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="filter"></param>
        /// <param name="document"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<ReplaceOneResult> WhereUpdateOneAsync<T>(
            this IMongoCollection<T> collection,
            Expression<Func<T, bool>> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return collection.ReplaceOneAsync(filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 查找更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<T> FindOneAndUpdateOneAsync<T>(
            this IMongoCollection<T> collection,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T, T> options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            return collection.FindOneAndUpdateAsync(
                filter,
                update.Set(s => s.UpdateTime, DateTime.Now),
                options,
                cancellationToken);
        }

        /// <summary>
        /// 查找更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<T> FindOneAndUpdateOneAsync<T>(
            this IMongoCollection<T> collection,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T, T> options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            return collection.FindOneAndUpdateAsync(
                filter,
                update.Set(s => s.UpdateTime, DateTime.Now),
                options,
                cancellationToken);
        }

        /// <summary>
        /// 查找更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="filter"></param>
        /// <param name="document"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<T> FindOneAndUpdateOneAsync<T>(
            this IMongoCollection<T> collection,
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T, T> options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return collection.FindOneAndReplaceAsync(filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 查找更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="filter"></param>
        /// <param name="document"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<T> FindOneAndUpdateOneAsync<T>(
            this IMongoCollection<T> collection,
            Expression<Func<T, bool>> filter,
            T document,
            FindOneAndReplaceOptions<T, T> options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return collection.FindOneAndReplaceAsync(filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 查找更新多条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<UpdateResult> WhereUpdateManyAsync<T>(
            this IMongoCollection<T> collection,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            return collection.UpdateManyAsync(
                filter,
                update.Set(s => s.UpdateTime, DateTime.Now),
                options,
                cancellationToken);
        }

        /// <summary>
        /// 查找更新多条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<UpdateResult> WhereUpdateManyAsync<T>(
            this IMongoCollection<T> collection,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            return collection.UpdateManyAsync(
                filter,
                update.Set(s => s.UpdateTime, DateTime.Now),
                options,
                cancellationToken);
        }

        #endregion
    }
}
