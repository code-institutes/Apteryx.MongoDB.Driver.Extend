using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Apteryx.MongoDB.Driver.Extend.Entities;
using MongoDB.Driver;

namespace Apteryx.MongoDB.Driver.Extend.ExtensionMethods
{
    public static partial class MongoDbExtensionMethod
    {
        #region 替换(异步)

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
        public static Task<ReplaceOneResult> WhereReplaceOneAsync<T>(
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
        public static Task<ReplaceOneResult> WhereReplaceOneAsync<T>(
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
        /// 动态表替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="foreignDocument"></param>
        /// <param name="filter"></param>
        /// <param name="document"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<ReplaceOneResult> DynamicTableWhereReplaceOneAsync<TForeign, T>(
            this IMongoCollection<T> collection,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return collection.Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}")
                .ReplaceOneAsync(filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 动态表替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="foreignDocument"></param>
        /// <param name="filter"></param>
        /// <param name="document"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<ReplaceOneResult> DynamicTableWhereReplaceOneAsync<TForeign, T>(
            this IMongoCollection<T> collection,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return collection.Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}")
                .ReplaceOneAsync(filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 查询替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="filter"></param>
        /// <param name="document"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<T> FindOneAndReplaceOneAsync<T>(
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
        /// 查询替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="filter"></param>
        /// <param name="document"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<T> FindOneAndReplaceOneAsync<T>(
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
        /// 动态表查询替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="foreignDocument"></param>
        /// <param name="filter"></param>
        /// <param name="document"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<T> DynamicTableFindOneAndReplaceOneAsync<TForeign, T>(
            this IMongoCollection<T> collection,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return collection.Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}")
                .FindOneAndReplaceAsync(filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 动态表查询替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="foreignDocument"></param>
        /// <param name="filter"></param>
        /// <param name="document"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<T> DynamicTableFindOneAndReplaceOneAsync<TForeign, T>(
            this IMongoCollection<T> collection,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return collection.Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}")
                .FindOneAndReplaceAsync(filter, document, options, cancellationToken);
        }

        #endregion
    }
}
