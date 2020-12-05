using MongoDB.Driver;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Apteryx.MongoDB.Driver.Extend.Entities;

namespace Apteryx.MongoDB.Driver.Extend
{
    public abstract partial class MongoDbService
    {
        #region 同步方法

        /// <summary>
        /// 更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public UpdateResult WhereUpdateOne<T>(
            FilterDefinition<T> filter, 
            UpdateDefinition<T> update,
            UpdateOptions options = null, 
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            return _database.GetCollection<T>(typeof(T).Name).UpdateOne(filter,
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
        public UpdateResult WhereUpdateOne<T>(
            Expression<Func<T, bool>> filter, 
            UpdateDefinition<T> update,
            UpdateOptions options = null, 
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            return _database.GetCollection<T>(typeof(T).Name).UpdateOne(filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public ReplaceOneResult WhereReplaceOne<T>(
            FilterDefinition<T> filter, 
            T obj, 
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : BaseMongoEntity
        {
            obj.UpdateTime = DateTime.Now;
            return _database.GetCollection<T>(typeof(T).Name).ReplaceOne(filter, obj,options,cancellationToken);
        }

        /// <summary>
        /// 替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public ReplaceOneResult WhereReplaceOne<T>(
            Expression<Func<T, bool>> filter, 
            T obj,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            obj.UpdateTime = DateTime.Now;
            return _database.GetCollection<T>(typeof(T).Name).ReplaceOne(filter, obj, options, cancellationToken);
        }

        /// <summary>
        /// 查找替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <param name="document"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public T FindOneAndUpdateOne<T>(
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T, T> options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return _database.GetCollection<T>(typeof(T).Name).FindOneAndReplace(filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 查找替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <param name="document"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public T FindOneAndUpdateOne<T>(
            Expression<Func<T, bool>> filter,
            T document,
            FindOneAndReplaceOptions<T, T> options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return _database.GetCollection<T>(typeof(T).Name).FindOneAndReplace(filter, document, options, cancellationToken);
        }

        #endregion


        #region 异步方法
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
            return _database.GetCollection<T>(typeof(T).Name).UpdateOneAsync(filter,
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
            return _database.GetCollection<T>(typeof(T).Name).UpdateOneAsync(filter,
                update.Set(s => s.UpdateTime, DateTime.Now), options, cancellationToken);
        }

        /// <summary>
        /// 替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ReplaceOneResult> WhereReplaceOneAsnyc<T>(
            FilterDefinition<T> filter, 
            T obj,
            ReplaceOptions options = null, 
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            obj.UpdateTime = DateTime.Now;
            return _database.GetCollection<T>(typeof(T).Name).ReplaceOneAsync(filter, obj, options, cancellationToken);
        }

        /// <summary>
        /// 替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ReplaceOneResult> WhereReplaceOneAsnyc<T>(
            Expression<Func<T, bool>> filter, 
            T obj,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            obj.UpdateTime = DateTime.Now;
            return _database.GetCollection<T>(typeof(T).Name).ReplaceOneAsync(filter, obj, options, cancellationToken);
        }

        /// <summary>
        /// 查找替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <param name="document"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<T> FindOneAndUpdateOneAsync<T>(
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T, T> options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return _database.GetCollection<T>(typeof(T).Name).FindOneAndReplaceAsync(filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 查找替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <param name="document"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<T> FindOneAndUpdateOneAsync<T>(
            Expression<Func<T, bool>> filter,
            T document,
            FindOneAndReplaceOptions<T, T> options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return _database.GetCollection<T>(typeof(T).Name).FindOneAndReplaceAsync(filter, document, options, cancellationToken);
        }

        #endregion
    }
}
