using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Apteryx.MongoDB.Driver.Extend
{
    public interface IMongoDbProvider
    {
        #region 插入(同步)

        void Add<T>(T document, InsertOneOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity;
        void Add<T>(IClientSessionHandle session, T document, InsertOneOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity;
        void AddMany<T>(IEnumerable<T> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity;
        void AddMany<T>(IClientSessionHandle session, IEnumerable<T> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity;
        void DynamicCollectionAdd<TForeign, T>(TForeign foreignDocument, T document, InsertOneOptions options = null, CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity where T : BaseMongoEntity;
        void DynamicCollectionAdd<TForeign, T>(IClientSessionHandle session, TForeign foreignDocument, T document, InsertOneOptions options = null, CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity where T : BaseMongoEntity;
        void DynamicCollectionAddMany<TForeign, T>(TForeign foreignDocument, IEnumerable<T> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity where T : BaseMongoEntity;
        void DynamicCollectionAddMany<TForeign, T>(IClientSessionHandle session, TForeign foreignDocument, IEnumerable<T> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity where T : BaseMongoEntity;

        #endregion



        #region 插入(异步)

        Task AddAsync<T>(T document, InsertOneOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity;
        Task AddAsync<T>(IClientSessionHandle session, T document, InsertOneOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity;
        Task AddManyAsync<T>(IEnumerable<T> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity;
        Task AddManyAsync<T>(IClientSessionHandle session, IEnumerable<T> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity;
        Task DynamicCollectionAddAsync<TForeign, T>(T foreignDocument, T document, InsertOneOptions options = null, CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity where T : BaseMongoEntity;
        Task DynamicCollectionAddAsync<TForeign, T>(IClientSessionHandle session, T foreignDocument, T document, InsertOneOptions options = null, CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity where T : BaseMongoEntity;
        Task DynamicCollectionAddManyAsync<TForeign, T>(T foreignDocument, IEnumerable<T> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity where T : BaseMongoEntity;
        Task DynamicCollectionAddManyAsync<TForeign, T>(IClientSessionHandle session, T foreignDocument, IEnumerable<T> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity where T : BaseMongoEntity;

        #endregion



        #region 查询(同步)

        T FindOne<T>(string id, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        T FindOne<T>(IClientSessionHandle session, string id, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        T FindOne<T>(string collectionName, string id, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        T FindOne<T>(string collectionName, IClientSessionHandle session, string id, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        T FindOne<T>(FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        T FindOne<T>(IClientSessionHandle session, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        T FindOne<T>(string collectionName, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        T FindOne<T>(string collectionName, IClientSessionHandle session, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        T FindOne<T>(Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        T FindOne<T>(IClientSessionHandle session, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        T FindOne<T>(string collectionName, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        T FindOne<T>(string collectionName, IClientSessionHandle session, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        T DynamicCollectionFindOne<TForeign, T>(TForeign foreignDocument, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity where T : BaseMongoEntity;
        T DynamicCollectionFindOne<TForeign, T>(IClientSessionHandle session, TForeign foreignDocument, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity where T : BaseMongoEntity;
        T DynamicCollectionFindOne<TForeign, T>(TForeign foreignDocument, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity where T : BaseMongoEntity;
        T DynamicCollectionFindOne<TForeign, T>(IClientSessionHandle session, TForeign foreignDocument, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity where T : BaseMongoEntity;
        IEnumerable<T> FindAll<T>(MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        IEnumerable<T> FindAll<T>(IClientSessionHandle session, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        IEnumerable<T> FindAll<T>(string collectionName, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        IEnumerable<T> FindAll<T>(string collectionName, IClientSessionHandle session, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        IEnumerable<T> DynamicCollectionFindAll<TForeign, T>(TForeign foreignDocument, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity where T : BaseMongoEntity;
        IEnumerable<T> DynamicCollectionFindAll<TForeign, T>(IClientSessionHandle session, TForeign foreignDocument, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity where T : BaseMongoEntity;
        IEnumerable<T> Where<T>(FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        IEnumerable<T> Where<T>(IClientSessionHandle session, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        IEnumerable<T> Where<T>(string collectionName, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        IEnumerable<T> Where<T>(string collectionName, IClientSessionHandle session, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        IEnumerable<T> Where<T>(Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        IEnumerable<T> Where<T>(IClientSessionHandle session, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        IEnumerable<T> Where<T>(string collectionName, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        IEnumerable<T> Where<T>(string collectionName, IClientSessionHandle session, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        IEnumerable<T> DynamicCollectionWhere<TForeign, T>(TForeign foreignDocument, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity where T : BaseMongoEntity;
        IEnumerable<T> DynamicCollectionWhere<TForeign, T>(IClientSessionHandle session, TForeign foreignDocument, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity where T : BaseMongoEntity;
        IEnumerable<T> DynamicCollectionWhere<TForeign, T>(TForeign foreignDocument, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity where T : BaseMongoEntity;
        IEnumerable<T> DynamicCollectionWhere<TForeign, T>(IClientSessionHandle session, TForeign foreignDocument, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity where T : BaseMongoEntity;
        long CountDocuments<T>(FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity;
        long CountDocuments<T>(IClientSessionHandle session, FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity;
        long CountDocuments<T>(string collectionName, FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity;
        long CountDocuments<T>(string collectionName, IClientSessionHandle session, FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity;
        long CountDocuments<T>(string collectionName, Expression<Func<T, bool>> filter, CountOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity;
        long CountDocuments<T>(string collectionName, IClientSessionHandle session, Expression<Func<T, bool>> filter, CountOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity;
        long DynamicCollectionCountDocuments<TForeign, T>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            CountOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;
        long DynamicCollectionCountDocuments<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            CountOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;
        long DynamicCollectionCountDocuments<TForeign, T>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            CountOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;
        long DynamicCollectionCountDocuments<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            CountOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        #endregion



        #region 查询(异步)

        Task<T> FindOneAsync<T>(string id, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        Task<T> FindOneAsync<T>(IClientSessionHandle session, string id, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        Task<T> FindOneAsync<T>(string collectionName, string id, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        Task<T> FindOneAsync<T>(string collectionName, IClientSessionHandle session, string id, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        Task<T> FindOneAsync<T>(FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        Task<T> FindOneAsync<T>(IClientSessionHandle session, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        Task<T> FindOneAsync<T>(string collectionName, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        Task<T> FindOneAsync<T>(string collectionName, IClientSessionHandle session, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        Task<T> FindOneAsync<T>(Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        Task<T> FindOneAsync<T>(IClientSessionHandle session, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        Task<T> FindOneAsync<T>(string collectionName, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        Task<T> FindOneAsync<T>(string collectionName, IClientSessionHandle session, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        Task<T> DynamicCollectionFindOneAsync<TForeign, T>(TForeign foreignDocument, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity where T : BaseMongoEntity;
        Task<T> DynamicCollectionFindOneAsync<TForeign, T>(IClientSessionHandle session, TForeign foreignDocument, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity where T : BaseMongoEntity;
        Task<T> DynamicCollectionFindOneAsync<TForeign, T>(TForeign foreignDocument, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity where T : BaseMongoEntity;
        Task<T> DynamicCollectionFindOneAsync<TForeign, T>(IClientSessionHandle session, TForeign foreignDocument, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity where T : BaseMongoEntity;
        Task<IEnumerable<T>> FindAllAsync<T>(MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        Task<IEnumerable<T>> FindAllAsync<T>(IClientSessionHandle session, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        Task<IEnumerable<T>> FindAllAsync<T>(string collectionName, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        Task<IEnumerable<T>> FindAllAsync<T>(string collectionName, IClientSessionHandle session, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        Task<IEnumerable<T>> DynamicCollectionFindAllAsync<TForeign, T>(TForeign foreignDocument, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity where T : BaseMongoEntity;
        Task<IEnumerable<T>> DynamicCollectionFindAllAsync<TForeign, T>(IClientSessionHandle session, TForeign foreignDocument, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity where T : BaseMongoEntity;
        Task<IEnumerable<T>> WhereAsync<T>(FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        Task<IEnumerable<T>> WhereAsync<T>(IClientSessionHandle session, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        Task<IEnumerable<T>> WhereAsync<T>(string collectionName, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        Task<IEnumerable<T>> WhereAsync<T>(string collectionName, IClientSessionHandle session, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        Task<IEnumerable<T>> WhereAsync<T>(Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        Task<IEnumerable<T>> WhereAsync<T>(IClientSessionHandle session, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        Task<IEnumerable<T>> WhereAsync<T>(string collectionName, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        Task<IEnumerable<T>> WhereAsync<T>(string collectionName, IClientSessionHandle session, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where T : BaseMongoEntity;
        Task<IEnumerable<T>> DynamicCollectionWhereAsync<TForeign, T>(TForeign foreignDocument, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity where T : BaseMongoEntity;
        Task<IEnumerable<T>> DynamicCollectionWhereAsync<TForeign, T>(IClientSessionHandle session, TForeign foreignDocument, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity where T : BaseMongoEntity;
        Task<IEnumerable<T>> DynamicCollectionWhereAsync<TForeign, T>(TForeign foreignDocument, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity where T : BaseMongoEntity;
        Task<IEnumerable<T>> DynamicCollectionWhereAsync<TForeign, T>(IClientSessionHandle session, TForeign foreignDocument, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity where T : BaseMongoEntity;
        Task<long> CountDocumentsAsync<T>(FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity;
        Task<long> CountDocumentsAsync<T>(IClientSessionHandle session, FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity;
        Task<long> CountDocumentsAsync<T>(string collectionName, FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity;
        Task<long> CountDocumentsAsync<T>(string collectionName, IClientSessionHandle session, FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity;
        Task<long> CountDocumentsAsync<T>(string collectionName, Expression<Func<T, bool>> filter, CountOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity;
        Task<long> CountDocumentsAsync<T>(string collectionName, IClientSessionHandle session, Expression<Func<T, bool>> filter, CountOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity;
        Task<long> DynamicCollectionCountDocumentsAsync<TForeign, T>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            CountOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;
        Task<long> DynamicCollectionCountDocumentsAsync<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            CountOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;
        Task<long> DynamicCollectionCountDocumentsAsync<TForeign, T>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            CountOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;
        Task<long> DynamicCollectionCountDocumentsAsync<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            CountOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        #endregion



        #region 替换(同步)
        ReplaceOneResult WhereReplaceOne<T>(
            string id,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        ReplaceOneResult WhereReplaceOne<T>(
            IClientSessionHandle session,
            string id,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        ReplaceOneResult WhereReplaceOne<T>(
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        ReplaceOneResult WhereReplaceOne<T>(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        ReplaceOneResult WhereReplaceOne<T>(
            Expression<Func<T, bool>> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        ReplaceOneResult WhereReplaceOne<T>(
            IClientSessionHandle session,
            Expression<Func<T, bool>> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        ReplaceOneResult DynamicCollectionWhereReplaceOne<TForeign, T>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        ReplaceOneResult DynamicCollectionWhereReplaceOne<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        ReplaceOneResult DynamicCollectionWhereReplaceOne<TForeign, T>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        ReplaceOneResult DynamicCollectionWhereReplaceOne<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        T FindOneAndReplaceOne<T>(
            string id,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        T FindOneAndReplaceOne<T>(
            IClientSessionHandle session,
            string id,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        T FindOneAndReplaceOne<T>(
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        T FindOneAndReplaceOne<T>(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        T FindOneAndReplaceOne<T>(
            Expression<Func<T, bool>> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        T FindOneAndReplaceOne<T>(
            IClientSessionHandle session,
            Expression<Func<T, bool>> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        T DynamicCollectionFindOneAndReplaceOne<TForeign, T>(
            TForeign foreignDocument,
            string id,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        T DynamicCollectionFindOneAndReplaceOne<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            string id,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        T DynamicCollectionFindOneAndReplaceOne<TForeign, T>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        T DynamicCollectionFindOneAndReplaceOne<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        T DynamicCollectionFindOneAndReplaceOne<TForeign, T>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        T DynamicCollectionFindOneAndReplaceOne<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        #endregion



        #region 替换(异步)

        Task<ReplaceOneResult> WhereReplaceOneAsnyc<T>(
            string id,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        Task<ReplaceOneResult> WhereReplaceOneAsnyc<T>(
            IClientSessionHandle session,
            string id,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        Task<ReplaceOneResult> WhereReplaceOneAsnyc<T>(
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        Task<ReplaceOneResult> WhereReplaceOneAsnyc<T>(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        Task<ReplaceOneResult> WhereReplaceOneAsnyc<T>(
            Expression<Func<T, bool>> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        Task<ReplaceOneResult> WhereReplaceOneAsnyc<T>(
            IClientSessionHandle session,
            Expression<Func<T, bool>> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        Task<ReplaceOneResult> DynamicCollectionWhereReplaceOneAsnyc<TForeign, T>(
            TForeign foreignDocument,
            string id,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity where T : BaseMongoEntity;

        Task<ReplaceOneResult> DynamicCollectionWhereReplaceOneAsnyc<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            string id,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity where T : BaseMongoEntity;

        Task<ReplaceOneResult> DynamicCollectionWhereReplaceOneAsnyc<TForeign, T>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity where T : BaseMongoEntity;

        Task<ReplaceOneResult> DynamicCollectionWhereReplaceOneAsnyc<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity where T : BaseMongoEntity;

        Task<ReplaceOneResult> DynamicCollectionWhereReplaceOneAsnyc<TForeign, T>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity where T : BaseMongoEntity;

        Task<ReplaceOneResult> DynamicCollectionWhereReplaceOneAsnyc<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity where T : BaseMongoEntity;

        Task<T> FindOneAndReplaceOneAsync<T>(
            string id,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        Task<T> FindOneAndReplaceOneAsync<T>(
            IClientSessionHandle session,
            string id,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        Task<T> FindOneAndReplaceOneAsync<T>(
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        Task<T> FindOneAndReplaceOneAsync<T>(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        Task<T> FindOneAndReplaceOneAsync<T>(
            Expression<Func<T, bool>> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        Task<T> FindOneAndReplaceOneAsync<T>(
            IClientSessionHandle session,
            Expression<Func<T, bool>> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        Task<T> DynamicCollectionFindOneAndReplaceOneAsync<TForeign, T>(
            TForeign foreignDocument,
            string id,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        Task<T> DynamicCollectionFindOneAndReplaceOneAsync<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            string id,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        Task<T> DynamicCollectionFindOneAndReplaceOneAsync<TForeign, T>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        Task<T> DynamicCollectionFindOneAndReplaceOneAsync<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        Task<T> DynamicCollectionFindOneAndReplaceOneAsync<TForeign, T>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity where T : BaseMongoEntity;

        Task<T> DynamicCollectionFindOneAndReplaceOneAsync<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity where T : BaseMongoEntity;

        #endregion



        #region 更新(同步)

        UpdateResult WhereUpdateOne<T>(
            string id,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        UpdateResult WhereUpdateOne<T>(
            IClientSessionHandle session,
            string id,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        UpdateResult WhereUpdateOne<T>(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        UpdateResult WhereUpdateOne<T>(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        UpdateResult WhereUpdateOne<T>(
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        UpdateResult WhereUpdateOne<T>(
            IClientSessionHandle session,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        UpdateResult DynamicCollectionWhereUpdateOne<TForeign, T>(
            TForeign foreignDocument,
            string id,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        UpdateResult DynamicCollectionWhereUpdateOne<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            string id,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        UpdateResult DynamicCollectionWhereUpdateOne<TForeign, T>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default) 
            where TForeign : BaseMongoEntity 
            where T : BaseMongoEntity;

        UpdateResult DynamicCollectionWhereUpdateOne<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        UpdateResult DynamicCollectionWhereUpdateOne<TForeign, T>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default) 
            where TForeign : BaseMongoEntity 
            where T : BaseMongoEntity;

        UpdateResult DynamicCollectionWhereUpdateOne<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        T FindOneAndUpdateOne<T>(
            string id,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        T FindOneAndUpdateOne<T>(
            IClientSessionHandle session,
            string id,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        T FindOneAndUpdateOne<T>(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        T FindOneAndUpdateOne<T>(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        T FindOneAndUpdateOne<T>(
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        T FindOneAndUpdateOne<T>(
            IClientSessionHandle session,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        T DynamicCollectionFindOneAndUpdateOne<TForeign, T>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default) 
            where TForeign : BaseMongoEntity 
            where T : BaseMongoEntity;

        T DynamicCollectionFindOneAndUpdateOne<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        T DynamicCollectionFindOneAndUpdateOne<TForeign, T>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default) 
            where TForeign : BaseMongoEntity 
            where T : BaseMongoEntity;

        T DynamicCollectionFindOneAndUpdateOne<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        UpdateResult WhereUpdateMany<T>(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        UpdateResult WhereUpdateMany<T>(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        UpdateResult WhereUpdateMany<T>(
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        UpdateResult WhereUpdateMany<T>(
            IClientSessionHandle session,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        UpdateResult DynamicCollectionWhereUpdateMany<TForeign, T>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default) 
            where TForeign : BaseMongoEntity 
            where T : BaseMongoEntity;

        UpdateResult DynamicCollectionWhereUpdateMany<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        UpdateResult DynamicCollectionWhereUpdateMany<TForeign, T>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default) 
            where TForeign : BaseMongoEntity 
            where T : BaseMongoEntity;

        UpdateResult DynamicCollectionWhereUpdateMany<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        #endregion



        #region 更新(异步)

        Task<UpdateResult> WhereUpdateOneAsync<T>(
            string id,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        Task<UpdateResult> WhereUpdateOneAsync<T>(
            IClientSessionHandle session,
            string id,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        Task<UpdateResult> WhereUpdateOneAsync<T>(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        Task<UpdateResult> WhereUpdateOneAsync<T>(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        Task<UpdateResult> WhereUpdateOneAsync<T>(
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        Task<UpdateResult> WhereUpdateOneAsync<T>(
            IClientSessionHandle session,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        Task<UpdateResult> DynamicCollectionWhereUpdateOneAsync<TForeign, T>(
            TForeign foreignDocument,
            string id,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        Task<UpdateResult> DynamicCollectionWhereUpdateOneAsync<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            string id,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        Task<UpdateResult> DynamicCollectionWhereUpdateOneAsync<TForeign, T>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default) 
            where TForeign : BaseMongoEntity 
            where T : BaseMongoEntity;

        Task<UpdateResult> DynamicCollectionWhereUpdateOneAsync<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        Task<UpdateResult> DynamicCollectionWhereUpdateOneAsync<TForeign, T>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default) 
            where TForeign : BaseMongoEntity 
            where T : BaseMongoEntity;

        Task<UpdateResult> DynamicCollectionWhereUpdateOneAsync<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        Task<T> FindOneAndUpdateOneAsync<T>(
            string id,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        Task<T> FindOneAndUpdateOneAsync<T>(
            IClientSessionHandle session,
            string id,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        Task<T> FindOneAndUpdateOneAsync<T>(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        Task<T> FindOneAndUpdateOneAsync<T>(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        Task<T> FindOneAndUpdateOneAsync<T>(
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        Task<T> FindOneAndUpdateOneAsync<T>(
            IClientSessionHandle session,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        Task<T> DynamicCollectionFindOneAndUpdateOneAsync<TForeign, T>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default) 
            where TForeign : BaseMongoEntity 
            where T : BaseMongoEntity;

        Task<T> DynamicCollectionFindOneAndUpdateOneAsync<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        Task<T> DynamicCollectionFindOneAndUpdateOneAsync<TForeign, T>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default) 
            where TForeign : BaseMongoEntity 
            where T : BaseMongoEntity;

        Task<T> DynamicCollectionFindOneAndUpdateOneAsync<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        Task<UpdateResult> WhereUpdateManyAsync<T>(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        Task<UpdateResult> WhereUpdateManyAsync<T>(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        Task<UpdateResult> WhereUpdateManyAsync<T>(
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        Task<UpdateResult> WhereUpdateManyAsync<T>(
            IClientSessionHandle session,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity;

        Task<UpdateResult> DynamicCollectionWhereUpdateManyAsync<TForeign, T>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default) 
            where TForeign : BaseMongoEntity 
            where T : BaseMongoEntity;

        Task<UpdateResult> DynamicCollectionWhereUpdateManyAsync<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        Task<UpdateResult> DynamicCollectionWhereUpdateManyAsync<TForeign, T>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default) 
            where TForeign : BaseMongoEntity 
            where T : BaseMongoEntity;

        Task<UpdateResult> DynamicCollectionWhereUpdateManyAsync<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity;

        #endregion
    }
}
