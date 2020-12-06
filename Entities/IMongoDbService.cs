using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Apteryx.MongoDB.Driver.Extend.Entities
{
    public interface IMongoDbService
    {
        #region 插入(同步)

        void Add<T>(T obj) where T : BaseMongoEntity;
        void Add<T>(string tableName, T document) where T : BaseMongoEntity;
        void AddMany<T>(IEnumerable<T> documents) where T : BaseMongoEntity;
        void AddMany<T>(string tableName, IEnumerable<T> documents) where T : BaseMongoEntity;

        void DynamicTableAdd<TForeign, T>(TForeign foreignDocument, T document)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        #endregion

        #region 插入(异步)

        Task AddAsync<T>(T obj) where T : BaseMongoEntity;
        Task AddAsync<T>(string tableName, T obj) where T : BaseMongoEntity;
        void AddManyAsync<T>(IEnumerable<T> documents) where T : BaseMongoEntity;
        void AddManyAsync<T>(string tableName, IEnumerable<T> documents) where T : BaseMongoEntity;

        Task DynamicTableAddAsync<TForeign, T>(T foreignDocument, T obj)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        #endregion



        #region 查询(同步)

        IEnumerable<T> FindAll<T>() where T : BaseMongoEntity;
        IEnumerable<T> FindAll<T>(string tableName) where T : BaseMongoEntity;
        IEnumerable<T> Where<T>(Expression<Func<T, bool>> filter) where T : BaseMongoEntity;
        T FindOne<T>(Expression<Func<T, bool>> filter) where T : BaseMongoEntity;
        T FindOne<T>(string tableName, Expression<Func<T, bool>> filter) where T : BaseMongoEntity;

        #endregion

        #region 查询(异步)

        Task<IAsyncCursor<T>> FindAllAsync<T>() where T : BaseMongoEntity;
        Task<IAsyncCursor<T>> FindAsync<T>(string tableName) where T : BaseMongoEntity;
        Task<IAsyncCursor<T>> WhereAsync<T>(Expression<Func<T, bool>> filter) where T : BaseMongoEntity;
        Task<T> FindOneAsync<T>(Expression<Func<T, bool>> filter) where T : BaseMongoEntity;
        Task<T> FindOneAsync<T>(string tableName, Expression<Func<T, bool>> filter) where T : BaseMongoEntity;

        #endregion



        #region 更新(同步)

        /// <summary>
        /// 更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        UpdateResult WhereUpdateOne<T>(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : BaseMongoEntity;

        /// <summary>
        /// 更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        UpdateResult WhereUpdateOne<T>(
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : BaseMongoEntity;

        /// <summary>
        /// 替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ReplaceOneResult WhereReplaceOne<T>(
            FilterDefinition<T> filter,
            T obj,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : BaseMongoEntity;

        /// <summary>
        /// 替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ReplaceOneResult WhereReplaceOne<T>(
            Expression<Func<T, bool>> filter,
            T obj,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : BaseMongoEntity;

        /// <summary>
        /// 查询替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <param name="document"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        T FindOneAndUpdateOne<T>(
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T, T> options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity;

        /// <summary>
        /// 查询替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <param name="document"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        T FindOneAndUpdateOne<T>(
            Expression<Func<T, bool>> filter,
            T document,
            FindOneAndReplaceOptions<T, T> options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity;

        #endregion

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
        Task<UpdateResult> WhereUpdateOneAsync<T>(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : BaseMongoEntity;

        /// <summary>
        /// 更新单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<UpdateResult> WhereUpdateOneAsync<T>(
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : BaseMongoEntity;

        /// <summary>
        /// 替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ReplaceOneResult> WhereReplaceOneAsnyc<T>(
            FilterDefinition<T> filter,
            T obj,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : BaseMongoEntity;

        /// <summary>
        /// 替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ReplaceOneResult> WhereReplaceOneAsnyc<T>(
            Expression<Func<T, bool>> filter,
            T obj,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : BaseMongoEntity;

        /// <summary>
        /// 查询替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <param name="document"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<T> FindOneAndUpdateOneAsync<T>(
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T, T> options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity;

        /// <summary>
        /// 查询替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <param name="document"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<T> FindOneAndUpdateOneAsync<T>(
            Expression<Func<T, bool>> filter,
            T document,
            FindOneAndReplaceOptions<T, T> options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : BaseMongoEntity;

        #endregion
    }
}
