using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Apteryx.MongoDB.Driver.Extend.Entities;
using MongoDB.Driver;

namespace Apteryx.MongoDB.Driver.Extend
{
    public abstract partial class MongoDbService
    {

        #region 更新(异步)
        /// <summary>
        /// 更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<UpdateResult> WhereUpdateOneAsync<T>(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>(typeof(T).Name).UpdateOneAsync(filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<UpdateResult> WhereUpdateOneAsync<T>(
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>(typeof(T).Name).UpdateOneAsync(filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 查询更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<T> FindOneAndUpdateOneAsync<T>(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>(typeof(T).Name).FindOneAndUpdateAsync(filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 查询更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<T> FindOneAndUpdateOneAsync<T>(
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>(typeof(T).Name).FindOneAndUpdateAsync(filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 更新多条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<UpdateResult> WhereUpdateManyAsync<T>(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>(typeof(T).Name).UpdateManyAsync(filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 更新多条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<UpdateResult> WhereUpdateManyAsync<T>(
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>(typeof(T).Name).UpdateManyAsync(filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        #endregion
    }
}
