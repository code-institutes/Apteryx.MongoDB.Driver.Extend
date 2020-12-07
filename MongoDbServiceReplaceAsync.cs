using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Apteryx.MongoDB.Driver.Extend.Entities;
using MongoDB.Driver;

namespace Apteryx.MongoDB.Driver.Extend
{
    public abstract partial class MongoDbService
    {
        #region 替换(异步)

        /// <summary>
        /// 替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <param name="document"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ReplaceOneResult> WhereReplaceOneAsnyc<T>(
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return database.GetCollection<T>(typeof(T).Name).ReplaceOneAsync(filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <param name="document"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ReplaceOneResult> WhereReplaceOneAsnyc<T>(
            Expression<Func<T, bool>> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return database.GetCollection<T>(typeof(T).Name).ReplaceOneAsync(filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 动态表替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="foreignDocument"></param>
        /// <param name="filter"></param>
        /// <param name="document"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ReplaceOneResult> DynamicTableWhereReplaceOneAsnyc<TForeign, T>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").ReplaceOneAsync(filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 动态表替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="foreignDocument"></param>
        /// <param name="filter"></param>
        /// <param name="document"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ReplaceOneResult> DynamicTableWhereReplaceOneAsnyc<TForeign, T>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").ReplaceOneAsync(filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 查询替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <param name="document"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<T> FindOneAndReplaceOneAsync<T>(
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return database.GetCollection<T>(typeof(T).Name).FindOneAndReplaceAsync(filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 查询替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <param name="document"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<T> FindOneAndReplaceOneAsync<T>(
            Expression<Func<T, bool>> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return database.GetCollection<T>(typeof(T).Name).FindOneAndReplaceAsync(filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TForeign"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="foreignDocument"></param>
        /// <param name="filter"></param>
        /// <param name="document"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<T> DynamicTableFindOneAndReplaceOneAsync<TForeign, T>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").FindOneAndReplaceAsync(filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TForeign"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="foreignDocument"></param>
        /// <param name="filter"></param>
        /// <param name="document"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<T> DynamicTableFindOneAndReplaceOneAsync<TForeign, T>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").FindOneAndReplaceAsync(filter, document, options, cancellationToken);
        }

        #endregion
    }
}
