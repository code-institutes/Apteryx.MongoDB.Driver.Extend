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

        void Add<T>(T document) where T : BaseMongoEntity;
        void AddMany<T>(IEnumerable<T> documents) where T : BaseMongoEntity;
        void DynamicTableAdd<TForeign, T>(TForeign foreignDocument, T document) where TForeign : BaseMongoEntity where T : BaseMongoEntity;
        void DynamicTableAddMany<TForeign, T>(TForeign foreignDocument, IEnumerable<T> documents) where TForeign : BaseMongoEntity where T : BaseMongoEntity;

        #endregion



        #region 插入(异步)

        Task AddAsync<T>(T document) where T : BaseMongoEntity;
        Task AddManyAsync<T>(IEnumerable<T> documents) where T : BaseMongoEntity;
        Task DynamicTableAddAsync<TForeign, T>(T foreignDocument, T document) where TForeign : BaseMongoEntity where T : BaseMongoEntity;
        Task DynamicTableAddManyAsync<TForeign, T>(T foreignDocument, IEnumerable<T> documents) where TForeign : BaseMongoEntity where T : BaseMongoEntity;

        #endregion



        #region 查询(同步)

        T FindOne<T>(FilterDefinition<T> filter) where T : BaseMongoEntity;
        T FindOne<T>(Expression<Func<T, bool>> filter) where T : BaseMongoEntity;
        T DynamicTableFindOne<TForeign, T>(TForeign foreignDocument, FilterDefinition<T> filter) where TForeign : BaseMongoEntity where T : BaseMongoEntity;
        T DynamicTableFindOne<TForeign, T>(TForeign foreignDocument, Expression<Func<T, bool>> filter) where TForeign : BaseMongoEntity where T : BaseMongoEntity;
        IEnumerable<T> FindAll<T>() where T : BaseMongoEntity;
        IEnumerable<T> DynamicTableFindAll<TForeign, T>(TForeign foreignDocument) where TForeign : BaseMongoEntity where T : BaseMongoEntity;
        IEnumerable<T> Where<T>(FilterDefinition<T> filter) where T : BaseMongoEntity;
        IEnumerable<T> Where<T>(Expression<Func<T, bool>> filter) where T : BaseMongoEntity;
        IEnumerable<T> DynamicTableWhere<TForeign, T>(TForeign foreignDocument, FilterDefinition<T> filter) where TForeign : BaseMongoEntity where T : BaseMongoEntity;
        IEnumerable<T> DynamicTableWhere<TForeign, T>(TForeign foreignDocument, Expression<Func<T, bool>> filter) where TForeign : BaseMongoEntity where T : BaseMongoEntity;

        #endregion



        #region 查询(异步)

        Task<T> FindOneAsync<T>(FilterDefinition<T> filter) where T : BaseMongoEntity;
        Task<T> FindOneAsync<T>(Expression<Func<T, bool>> filter) where T : BaseMongoEntity;
        Task<T> DynamicTableFindOneAsync<TForeign, T>(TForeign foreignDocument, FilterDefinition<T> filter) where TForeign : BaseMongoEntity where T : BaseMongoEntity;
        Task<T> DynamicTableFindOneAsync<TForeign, T>(TForeign foreignDocument, Expression<Func<T, bool>> filter) where TForeign : BaseMongoEntity where T : BaseMongoEntity;
        Task<IEnumerable<T>> FindAllAsync<T>() where T : BaseMongoEntity;
        Task<IEnumerable<T>> DynamicTableFindAllAsync<TForeign, T>(TForeign foreignDocument) where TForeign : BaseMongoEntity where T : BaseMongoEntity;
        Task<IEnumerable<T>> WhereAsync<T>(FilterDefinition<T> filter) where T : BaseMongoEntity;
        Task<IEnumerable<T>> WhereAsync<T>(Expression<Func<T, bool>> filter) where T : BaseMongoEntity;
        Task<IEnumerable<T>> DynamicTableWhereAsync<TForeign, T>(TForeign foreignDocument, FilterDefinition<T> filter) where TForeign : BaseMongoEntity where T : BaseMongoEntity;
        Task<IEnumerable<T>> DynamicTableWhereAsync<TForeign, T>(TForeign foreignDocument, Expression<Func<T, bool>> filter) where TForeign : BaseMongoEntity where T : BaseMongoEntity;

        #endregion



        #region 替换(同步)

        ReplaceOneResult WhereReplaceOne<T>(
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : BaseMongoEntity;

        ReplaceOneResult WhereReplaceOne<T>(
            Expression<Func<T, bool>> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : BaseMongoEntity;

        ReplaceOneResult DynamicTableWhereReplaceOne<TForeign, T>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken)) 
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        ReplaceOneResult DynamicTableWhereReplaceOne<TForeign, T>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        T FindOneAndReplaceOne<T>(
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : BaseMongoEntity;

        T FindOneAndReplaceOne<T>(
            Expression<Func<T, bool>> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : BaseMongoEntity;

        T DynamicTableFindOneAndReplaceOne<TForeign, T>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        T DynamicTableFindOneAndReplaceOne<TForeign, T>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        #endregion



        #region 替换(异步)

        Task<ReplaceOneResult> WhereReplaceOneAsnyc<T>(
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : BaseMongoEntity;

        Task<ReplaceOneResult> WhereReplaceOneAsnyc<T>(
            Expression<Func<T, bool>> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : BaseMongoEntity;

        Task<ReplaceOneResult> DynamicTableWhereReplaceOneAsnyc<TForeign, T>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where TForeign : BaseMongoEntity where T : BaseMongoEntity;

        Task<ReplaceOneResult> DynamicTableWhereReplaceOneAsnyc<TForeign, T>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where TForeign : BaseMongoEntity where T : BaseMongoEntity;

        Task<T> FindOneAndReplaceOneAsync<T>(
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : BaseMongoEntity;

        Task<T> FindOneAndReplaceOneAsync<T>(
            Expression<Func<T, bool>> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : BaseMongoEntity;

        Task<T> DynamicTableFindOneAndReplaceOneAsync<TForeign, T>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where TForeign : BaseMongoEntity where T : BaseMongoEntity;

        Task<T> DynamicTableFindOneAndReplaceOneAsync<TForeign, T>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where TForeign : BaseMongoEntity where T : BaseMongoEntity;

        #endregion



        #region 更新(同步)

        UpdateResult WhereUpdateOne<T>(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : BaseMongoEntity;

        UpdateResult WhereUpdateOne<T>(
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : BaseMongoEntity;

        UpdateResult DynamicTableWhereUpdateOne<TForeign, T>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where TForeign : BaseMongoEntity where T : BaseMongoEntity;

        UpdateResult DynamicTableWhereUpdateOne<TForeign, T>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where TForeign : BaseMongoEntity where T : BaseMongoEntity;

        T FindOneAndUpdateOne<T>(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : BaseMongoEntity;

        T FindOneAndUpdateOne<T>(
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : BaseMongoEntity;

        T DynamicTableFindOneAndUpdateOne<TForeign, T>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where TForeign : BaseMongoEntity where T : BaseMongoEntity;

        T DynamicTableFindOneAndUpdateOne<TForeign, T>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where TForeign : BaseMongoEntity where T : BaseMongoEntity;

        UpdateResult WhereUpdateMany<T>(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : BaseMongoEntity;

        UpdateResult WhereUpdateMany<T>(
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : BaseMongoEntity;

        UpdateResult DynamicTableWhereUpdateMany<TForeign, T>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where TForeign : BaseMongoEntity where T : BaseMongoEntity;

        UpdateResult DynamicTableWhereUpdateMany<TForeign, T>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where TForeign : BaseMongoEntity where T : BaseMongoEntity;

        #endregion



        #region 更新(异步)

        Task<UpdateResult> WhereUpdateOneAsync<T>(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : BaseMongoEntity;

        Task<UpdateResult> WhereUpdateOneAsync<T>(
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : BaseMongoEntity;

        Task<UpdateResult> DynamicTableWhereUpdateOneAsync<TForeign, T>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where TForeign : BaseMongoEntity where T : BaseMongoEntity;

        Task<UpdateResult> DynamicTableWhereUpdateOneAsync<TForeign, T>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where TForeign : BaseMongoEntity where T : BaseMongoEntity;

        Task<T> FindOneAndUpdateOneAsync<T>(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : BaseMongoEntity;

        Task<T> FindOneAndUpdateOneAsync<T>(
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : BaseMongoEntity;
        Task<T> DynamicTableFindOneAndUpdateOneAsync<TForeign, T>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where TForeign : BaseMongoEntity where T : BaseMongoEntity;

        Task<T> DynamicTableFindOneAndUpdateOneAsync<TForeign, T>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where TForeign : BaseMongoEntity where T : BaseMongoEntity;

        Task<UpdateResult> WhereUpdateManyAsync<T>(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : BaseMongoEntity;

        Task<UpdateResult> WhereUpdateManyAsync<T>(
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : BaseMongoEntity;
        Task<UpdateResult> DynamicTableWhereUpdateManyAsync<TForeign, T>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where TForeign : BaseMongoEntity where T : BaseMongoEntity;

        Task<UpdateResult> DynamicTableWhereUpdateManyAsync<TForeign, T>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken)) where TForeign : BaseMongoEntity where T : BaseMongoEntity;

        #endregion
    }
}
