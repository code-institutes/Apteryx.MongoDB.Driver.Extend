using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Apteryx.MongoDB.Driver.Extend.Entities;
using MongoDB.Driver;

namespace Apteryx.MongoDB.Driver.Extend.ExtensionMethods
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class MongoDbExtensionMethod
    {
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
            return Task.Run(() => WhereUpdateOne(collection, filter, update, options, cancellationToken));
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
            return Task.Run(() => WhereUpdateOne(collection, filter, update, options, cancellationToken));
        }

        /// <summary>
        /// 动态表更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="foreignDocument"></param>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<UpdateResult> DynamicTableWhereUpdateOneAsync<TForeign, T>(
            this IMongoCollection<T> collection,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return Task.Run(() => DynamicTableWhereUpdateOne(collection,foreignDocument, filter, update, options, cancellationToken));
        }

        /// <summary>
        /// 动态表更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="foreignDocument"></param>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<UpdateResult> DynamicTableWhereUpdateOneAsync<TForeign, T>(
            this IMongoCollection<T> collection,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return Task.Run(() => DynamicTableWhereUpdateOne(collection, foreignDocument, filter, update, options, cancellationToken));
        }

        /// <summary>
        /// 查询更新单条(自动更新UpdateTime字段)
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
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            return Task.Run(() => FindOneAndUpdateOne(collection, filter, update, options, cancellationToken));
        }

        /// <summary>
        /// 查询更新单条(自动更新UpdateTime字段)
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
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            return Task.Run(() => FindOneAndUpdateOne(collection, filter, update, options, cancellationToken));
        }

        /// <summary>
        /// 动态表查询更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="foreignDocument"></param>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<T> DynamicTableFindOneAndUpdateOneAsync<TForeign, T>(
            this IMongoCollection<T> collection,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return Task.Run(() => DynamicTableFindOneAndUpdateOne(collection,foreignDocument, filter, update, options, cancellationToken));
        }

        /// <summary>
        /// 动态表查询更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="foreignDocument"></param>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<T> DynamicTableFindOneAndUpdateOneAsync<TForeign, T>(
            this IMongoCollection<T> collection,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return Task.Run(() => DynamicTableFindOneAndUpdateOne(collection, foreignDocument, filter, update, options, cancellationToken));
        }

        /// <summary>
        /// 查询更新多条(自动更新UpdateTime字段)
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
            return Task.Run(() => WhereUpdateMany(collection, filter, update, options, cancellationToken));
        }

        /// <summary>
        /// 查询更新多条(自动更新UpdateTime字段)
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
            return Task.Run(() => WhereUpdateMany(collection, filter, update, options, cancellationToken));
        }

        /// <summary>
        /// 动态表查询更新多条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="foreignDocument"></param>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<UpdateResult> DynamicTableWhereUpdateManyAsync<TForeign, T>(
            this IMongoCollection<T> collection,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return Task.Run(() => WhereUpdateMany(collection, filter, update, options, cancellationToken));
        }

        /// <summary>
        /// 动态表查询更新多条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="foreignDocument"></param>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<UpdateResult> DynamicTableWhereUpdateManyAsync<TForeign, T>(
            this IMongoCollection<T> collection,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return Task.Run(() => DynamicTableWhereUpdateMany(collection,foreignDocument, filter, update, options, cancellationToken));
        }

        #endregion
    }
}
