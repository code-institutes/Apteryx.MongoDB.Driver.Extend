using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Apteryx.MongoDB.Driver.Extend
{
    public interface IDbSetProvider<T>
    {
        #region 插入(同步)

        void Add(T document, InsertOneOptions options = null, CancellationToken cancellationToken = default);
        void Add(IClientSessionHandle session, T document, InsertOneOptions options = null, CancellationToken cancellationToken = default);
        void AddMany(IEnumerable<T> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default);
        void AddMany(IClientSessionHandle session, IEnumerable<T> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default);
        void DynamicCollectionAdd<TForeign>(TForeign foreignDocument, T document, MongoCollectionSettings settings = null, InsertOneOptions options = null, CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity;
        void DynamicCollectionAdd<TForeign>(IClientSessionHandle session, TForeign foreignDocument, T document, MongoCollectionSettings settings = null, InsertOneOptions options = null, CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity;
        void DynamicCollectionAddMany<TForeign>(TForeign foreignDocument, IEnumerable<T> documents, MongoCollectionSettings settings = null, InsertManyOptions options = null, CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity;
        void DynamicCollectionAddMany<TForeign>(IClientSessionHandle session, TForeign foreignDocument, IEnumerable<T> documents, MongoCollectionSettings settings = null, InsertManyOptions options = null, CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity;

        #endregion



        #region 插入(异步)

        Task AddAsync(T document, InsertOneOptions options = null, CancellationToken cancellationToken = default);
        Task AddAsync(IClientSessionHandle session, T document, InsertOneOptions options = null, CancellationToken cancellationToken = default);
        Task AddManyAsync(IEnumerable<T> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default);
        Task AddManyAsync(IClientSessionHandle session, IEnumerable<T> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default);
        Task DynamicCollectionAddAsync<TForeign>(TForeign foreignDocument, T document, MongoCollectionSettings settings = null, InsertOneOptions options = null, CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity;
        Task DynamicCollectionAddAsync<TForeign>(IClientSessionHandle session, TForeign foreignDocument, T document, MongoCollectionSettings settings = null, InsertOneOptions options = null, CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity;
        Task DynamicCollectionAddManyAsync<TForeign>(TForeign foreignDocument, IEnumerable<T> documents, MongoCollectionSettings settings = null, InsertManyOptions options = null, CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity;
        Task DynamicCollectionAddManyAsync<TForeign>(IClientSessionHandle session, TForeign foreignDocument, IEnumerable<T> documents, MongoCollectionSettings settings = null, InsertManyOptions options = null, CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity;

        #endregion



        #region 查询(同步)

        T FindOne(string id, FindOptions options = null);
        T FindOne(IClientSessionHandle session, string id, FindOptions options = null);
        T FindOne(FilterDefinition<T> filter, FindOptions options = null);
        T FindOne(IClientSessionHandle session, FilterDefinition<T> filter, FindOptions options = null);
        T FindOne(Expression<Func<T, bool>> expression, FindOptions options = null);
        T FindOne(IClientSessionHandle session, Expression<Func<T, bool>> expression, FindOptions options = null);
        T DynamicCollectionFindOne<TForeign>(TForeign foreignDocument, string id, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity;
        T DynamicCollectionFindOne<TForeign>(IClientSessionHandle session, TForeign foreignDocument, string id, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity;
        T DynamicCollectionFindOne<TForeign>(TForeign foreignDocument, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity;
        T DynamicCollectionFindOne<TForeign>(IClientSessionHandle session, TForeign foreignDocument, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity;
        T DynamicCollectionFindOne<TForeign>(TForeign foreignDocument, Expression<Func<T, bool>> expression, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity;
        T DynamicCollectionFindOne<TForeign>(IClientSessionHandle session, TForeign foreignDocument, Expression<Func<T, bool>> expression, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity;
        IEnumerable<T> FindAll(FindOptions options = null);
        IEnumerable<T> FindAll(IClientSessionHandle session, FindOptions options = null);
        IEnumerable<T> DynamicCollectionFindAll<TForeign>(TForeign foreignDocument, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity;
        IEnumerable<T> DynamicCollectionFindAll<TForeign>(IClientSessionHandle session, TForeign foreignDocument, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity;
        IFindFluent<T, T> Where(FilterDefinition<T> filter, FindOptions options = null);
        IFindFluent<T, T> Where(IClientSessionHandle session, FilterDefinition<T> filter, FindOptions options = null);
        IFindFluent<T, T> Where(Expression<Func<T, bool>> expression, FindOptions options = null);
        IFindFluent<T, T> Where(IClientSessionHandle session, Expression<Func<T, bool>> expression, FindOptions options = null);
        IFindFluent<T, T> DynamicCollectionWhere<TForeign>(TForeign foreignDocument, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity;
        IFindFluent<T, T> DynamicCollectionWhere<TForeign>(IClientSessionHandle session, TForeign foreignDocument, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity;
        IFindFluent<T, T> DynamicCollectionWhere<TForeign>(TForeign foreignDocument, Expression<Func<T, bool>> expression, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity;
        IFindFluent<T, T> DynamicCollectionWhere<TForeign>(IClientSessionHandle session, TForeign foreignDocument, Expression<Func<T, bool>> expression, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity;
        long CountDocuments(FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default);
        long CountDocuments(IClientSessionHandle session, FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default);
        long CountDocuments(Expression<Func<T, bool>> expression, CountOptions options = null, CancellationToken cancellationToken = default);
        long CountDocuments(IClientSessionHandle session, Expression<Func<T, bool>> expression, CountOptions options = null, CancellationToken cancellationToken = default);
        long DynamicCollectionCountDocuments<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            MongoCollectionSettings settings = null,
            CountOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;
        long DynamicCollectionCountDocuments<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            MongoCollectionSettings settings = null,
            CountOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;
        long DynamicCollectionCountDocuments<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            MongoCollectionSettings settings = null,
            CountOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;
        long DynamicCollectionCountDocuments<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            MongoCollectionSettings settings = null,
            CountOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;
        #endregion



        #region 查询(异步)

        Task<T> FindOneAsync(string id, FindOptions<T> options = null);
        Task<T> FindOneAsync(IClientSessionHandle session, string id, FindOptions<T> options = null);
        Task<T> FindOneAsync(FilterDefinition<T> filter, FindOptions<T> options = null);
        Task<T> FindOneAsync(IClientSessionHandle session, FilterDefinition<T> filter, FindOptions<T> options = null);
        Task<T> FindOneAsync(Expression<Func<T, bool>> expression, FindOptions<T> options = null);
        Task<T> FindOneAsync(IClientSessionHandle session, Expression<Func<T, bool>> expression, FindOptions<T> options = null);
        Task<T> DynamicCollectionFindOneAsync<TForeign>(TForeign foreignDocument, string id, MongoCollectionSettings settings = null, FindOptions<T> options = null) where TForeign : BaseMongoEntity;
        Task<T> DynamicCollectionFindOneAsync<TForeign>(IClientSessionHandle session, TForeign foreignDocument, string id, MongoCollectionSettings settings = null, FindOptions<T> options = null) where TForeign : BaseMongoEntity;
        Task<T> DynamicCollectionFindOneAsync<TForeign>(TForeign foreignDocument, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions<T> options = null) where TForeign : BaseMongoEntity;
        Task<T> DynamicCollectionFindOneAsync<TForeign>(IClientSessionHandle session, TForeign foreignDocument, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions<T> options = null) where TForeign : BaseMongoEntity;
        Task<T> DynamicCollectionFindOneAsync<TForeign>(TForeign foreignDocument, Expression<Func<T, bool>> expression, MongoCollectionSettings settings = null, FindOptions<T> options = null) where TForeign : BaseMongoEntity;
        Task<T> DynamicCollectionFindOneAsync<TForeign>(IClientSessionHandle session, TForeign foreignDocument, Expression<Func<T, bool>> expression, MongoCollectionSettings settings = null, FindOptions<T> options = null) where TForeign : BaseMongoEntity;
        IAsyncEnumerable<T> FindAllAsync(FindOptions<T> options = null);
        IAsyncEnumerable<T> FindAllAsync(IClientSessionHandle session, FindOptions<T> options = null);
        IAsyncEnumerable<T> DynamicCollectionFindAllAsync<TForeign>(TForeign foreignDocument, MongoCollectionSettings settings = null, FindOptions<T> options = null) where TForeign : BaseMongoEntity;
        IAsyncEnumerable<T> DynamicCollectionFindAllAsync<TForeign>(IClientSessionHandle session, TForeign foreignDocument, MongoCollectionSettings settings = null, FindOptions<T> options = null) where TForeign : BaseMongoEntity;
        IAsyncEnumerable<T> WhereAsync(FilterDefinition<T> filter, FindOptions<T> options = null);
        IAsyncEnumerable<T> WhereAsync(IClientSessionHandle session, FilterDefinition<T> filter, FindOptions<T> options = null);
        IAsyncEnumerable<T> WhereAsync(Expression<Func<T, bool>> expression, FindOptions<T> options = null);
        IAsyncEnumerable<T> WhereAsync(IClientSessionHandle session, Expression<Func<T, bool>> expression, FindOptions<T> options = null);
        IAsyncEnumerable<T> DynamicCollectionWhereAsync<TForeign>(TForeign foreignDocument, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions<T> options = null) where TForeign : BaseMongoEntity;
        IAsyncEnumerable<T> DynamicCollectionWhereAsync<TForeign>(IClientSessionHandle session, TForeign foreignDocument, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions<T> options = null) where TForeign : BaseMongoEntity;
        IAsyncEnumerable<T> DynamicCollectionWhereAsync<TForeign>(TForeign foreignDocument, Expression<Func<T, bool>> expression, MongoCollectionSettings settings = null, FindOptions<T> options = null) where TForeign : BaseMongoEntity;
        IAsyncEnumerable<T> DynamicCollectionWhereAsync<TForeign>(IClientSessionHandle session, TForeign foreignDocument, Expression<Func<T, bool>> expression, MongoCollectionSettings settings = null, FindOptions<T> options = null) where TForeign : BaseMongoEntity;
        Task<long> CountDocumentsAsync(FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default);
        Task<long> CountDocumentsAsync(IClientSessionHandle session, FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default);
        Task<long> CountDocumentsAsync(Expression<Func<T, bool>> expression, CountOptions options = null, CancellationToken cancellationToken = default);
        Task<long> CountDocumentsAsync(IClientSessionHandle session, Expression<Func<T, bool>> expression, CountOptions options = null, CancellationToken cancellationToken = default);
        Task<long> DynamicCollectionCountDocumentsAsync<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            MongoCollectionSettings settings = null,
            CountOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;
        Task<long> DynamicCollectionCountDocumentsAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            MongoCollectionSettings settings = null,
            CountOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;
        Task<long> DynamicCollectionCountDocumentsAsync<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            MongoCollectionSettings settings = null,
            CountOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;
        Task<long> DynamicCollectionCountDocumentsAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            MongoCollectionSettings settings = null,
            CountOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        #endregion



        #region 替换(同步)
        ReplaceOneResult ReplaceOne(
            string id,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default);

        ReplaceOneResult ReplaceOne(
            IClientSessionHandle session,
            string id,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default);

        ReplaceOneResult ReplaceOne(
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default);

        ReplaceOneResult ReplaceOne(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default);

        ReplaceOneResult ReplaceOne(
            Expression<Func<T, bool>> expression,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default);

        ReplaceOneResult ReplaceOne(
            IClientSessionHandle session,
            Expression<Func<T, bool>> expression,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default);

        ReplaceOneResult DynamicCollectionReplaceOne<TForeign>(
            TForeign foreignDocument,
            string id,
            T document,
            MongoCollectionSettings settings = null,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        ReplaceOneResult DynamicCollectionReplaceOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            string id,
            T document,
            MongoCollectionSettings settings = null,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        ReplaceOneResult DynamicCollectionReplaceOne<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            MongoCollectionSettings settings = null,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        ReplaceOneResult DynamicCollectionReplaceOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            MongoCollectionSettings settings = null,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        ReplaceOneResult DynamicCollectionReplaceOne<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            T document,
            MongoCollectionSettings settings = null,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        ReplaceOneResult DynamicCollectionReplaceOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            T document,
            MongoCollectionSettings settings = null,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        T FindOneAndReplaceOne(
            string id,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default);

        T FindOneAndReplaceOne(
            IClientSessionHandle session,
            string id,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default);

        T FindOneAndReplaceOne(
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default);

        T FindOneAndReplaceOne(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default);

        T FindOneAndReplaceOne(
            Expression<Func<T, bool>> expression,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default);

        T FindOneAndReplaceOne(
            IClientSessionHandle session,
            Expression<Func<T, bool>> expression,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default);

        T DynamicCollectionFindOneAndReplaceOne<TForeign>(
            TForeign foreignDocument,
            string id,
            T document,
            MongoCollectionSettings settings = null,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        T DynamicCollectionFindOneAndReplaceOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            string id,
            T document,
            MongoCollectionSettings settings = null,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        T DynamicCollectionFindOneAndReplaceOne<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            MongoCollectionSettings settings = null,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        T DynamicCollectionFindOneAndReplaceOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            MongoCollectionSettings settings = null,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        T DynamicCollectionFindOneAndReplaceOne<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            T document,
            MongoCollectionSettings settings = null,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        T DynamicCollectionFindOneAndReplaceOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            T document,
            MongoCollectionSettings settings = null,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        #endregion



        #region 替换(异步)

        Task<ReplaceOneResult> ReplaceOneAsync(
            string id,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default);

        Task<ReplaceOneResult> ReplaceOneAsync(
            IClientSessionHandle session,
            string id,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default);

        Task<ReplaceOneResult> ReplaceOneAsync(
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default);

        Task<ReplaceOneResult> ReplaceOneAsync(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default);

        Task<ReplaceOneResult> ReplaceOneAsync(
            Expression<Func<T, bool>> expression,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default);

        Task<ReplaceOneResult> ReplaceOneAsync(
            IClientSessionHandle session,
            Expression<Func<T, bool>> expression,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default);

        Task<ReplaceOneResult> DynamicCollectionReplaceOneAsync<TForeign>(
            TForeign foreignDocument,
            string id,
            T document,
            MongoCollectionSettings settings = null,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity;

        Task<ReplaceOneResult> DynamicCollectionReplaceOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            string id,
            T document,
            MongoCollectionSettings settings = null,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity;

        Task<ReplaceOneResult> DynamicCollectionReplaceOneAsync<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            MongoCollectionSettings settings = null,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity;

        Task<ReplaceOneResult> DynamicCollectionReplaceOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            MongoCollectionSettings settings = null,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity;

        Task<ReplaceOneResult> DynamicCollectionReplaceOneAsync<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            T document,
            MongoCollectionSettings settings = null,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity;

        Task<ReplaceOneResult> DynamicCollectionReplaceOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            T document,
            MongoCollectionSettings settings = null,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity;

        Task<T> FindOneAndReplaceOneAsync(
            string id,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default);

        Task<T> FindOneAndReplaceOneAsync(
            IClientSessionHandle session,
            string id,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default);

        Task<T> FindOneAndReplaceOneAsync(
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default);

        Task<T> FindOneAndReplaceOneAsync(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default);

        Task<T> FindOneAndReplaceOneAsync(
            Expression<Func<T, bool>> expression,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default);

        Task<T> FindOneAndReplaceOneAsync(
            IClientSessionHandle session,
            Expression<Func<T, bool>> expression,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default);

        Task<T> DynamicCollectionFindOneAndReplaceOneAsync<TForeign>(
            TForeign foreignDocument,
            string id,
            T document,
            MongoCollectionSettings settings = null,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        Task<T> DynamicCollectionFindOneAndReplaceOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            string id,
            T document,
            MongoCollectionSettings settings = null,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        Task<T> DynamicCollectionFindOneAndReplaceOneAsync<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            MongoCollectionSettings settings = null,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        Task<T> DynamicCollectionFindOneAndReplaceOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            MongoCollectionSettings settings = null,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        Task<T> DynamicCollectionFindOneAndReplaceOneAsync<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            T document,
            MongoCollectionSettings settings = null,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity;

        Task<T> DynamicCollectionFindOneAndReplaceOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            T document,
            MongoCollectionSettings settings = null,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity;

        #endregion



        #region 更新(同步)

        UpdateResult UpdateOne(
            string id,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        UpdateResult UpdateOne(
            IClientSessionHandle session,
            string id,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        UpdateResult UpdateOne(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        UpdateResult UpdateOne(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        UpdateResult UpdateOne(
            Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        UpdateResult UpdateOne(
            IClientSessionHandle session,
            Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        UpdateResult DynamicCollectionUpdateOne<TForeign>(
            TForeign foreignDocument,
            string id,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        UpdateResult DynamicCollectionUpdateOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            string id,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        UpdateResult DynamicCollectionUpdateOne<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        UpdateResult DynamicCollectionUpdateOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        UpdateResult DynamicCollectionUpdateOne<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        UpdateResult DynamicCollectionUpdateOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        T FindOneAndUpdateOne(
            string id,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default);

        T FindOneAndUpdateOne(
            IClientSessionHandle session,
            string id,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default);

        T FindOneAndUpdateOne(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default);

        T FindOneAndUpdateOne(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default);

        T FindOneAndUpdateOne(
            Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default);

        T FindOneAndUpdateOne(
            IClientSessionHandle session,
            Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default);

        public T DynamicCollectionFindOneAndUpdateOne<TForeign>(
            TForeign foreignDocument,
            string id,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            ;

        public T DynamicCollectionFindOneAndUpdateOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            string id,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            ;

        T DynamicCollectionFindOneAndUpdateOne<TForeign>(
             TForeign foreignDocument,
             FilterDefinition<T> filter,
             UpdateDefinition<T> update,
             MongoCollectionSettings settings = null,
             FindOneAndUpdateOptions<T> options = null,
             CancellationToken cancellationToken = default)
             where TForeign : BaseMongoEntity
            ;

        T DynamicCollectionFindOneAndUpdateOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        T DynamicCollectionFindOneAndUpdateOne<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        T DynamicCollectionFindOneAndUpdateOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        UpdateResult UpdateMany(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        UpdateResult UpdateMany(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        UpdateResult UpdateMany(
            Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        UpdateResult UpdateMany(
            IClientSessionHandle session,
            Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        UpdateResult DynamicCollectionUpdateMany<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        UpdateResult DynamicCollectionUpdateMany<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        UpdateResult DynamicCollectionUpdateMany<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        UpdateResult DynamicCollectionUpdateMany<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        #endregion



        #region 更新(异步)

        Task<UpdateResult> UpdateOneAsync(
            string id,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        Task<UpdateResult> UpdateOneAsync(
            IClientSessionHandle session,
            string id,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        Task<UpdateResult> UpdateOneAsync(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        Task<UpdateResult> UpdateOneAsync(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        Task<UpdateResult> UpdateOneAsync(
            Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        Task<UpdateResult> UpdateOneAsync(
            IClientSessionHandle session,
            Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        Task<UpdateResult> DynamicCollectionUpdateOneAsync<TForeign>(
            TForeign foreignDocument,
            string id,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        Task<UpdateResult> DynamicCollectionUpdateOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            string id,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        Task<UpdateResult> DynamicCollectionUpdateOneAsync<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        Task<UpdateResult> DynamicCollectionUpdateOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        Task<UpdateResult> DynamicCollectionUpdateOneAsync<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        Task<UpdateResult> DynamicCollectionUpdateOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        Task<T> FindOneAndUpdateOneAsync(
            string id,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default);

        Task<T> FindOneAndUpdateOneAsync(
            IClientSessionHandle session,
            string id,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default);

        Task<T> FindOneAndUpdateOneAsync(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default);

        Task<T> FindOneAndUpdateOneAsync(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default);

        Task<T> FindOneAndUpdateOneAsync(
            Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default);

        Task<T> FindOneAndUpdateOneAsync(
            IClientSessionHandle session,
            Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default);

        Task<T> DynamicCollectionFindOneAndUpdateOneAsync<TForeign>(
            TForeign foreignDocument,
            string id,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        Task<T> DynamicCollectionFindOneAndUpdateOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            string id,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        Task<T> DynamicCollectionFindOneAndUpdateOneAsync<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        Task<T> DynamicCollectionFindOneAndUpdateOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        Task<T> DynamicCollectionFindOneAndUpdateOneAsync<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        Task<T> DynamicCollectionFindOneAndUpdateOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        Task<UpdateResult> UpdateManyAsync(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        Task<UpdateResult> UpdateManyAsync(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        Task<UpdateResult> UpdateManyAsync(
            Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        Task<UpdateResult> UpdateManyAsync(
            IClientSessionHandle session,
            Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        Task<UpdateResult> DynamicCollectionUpdateManyAsync<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        Task<UpdateResult> DynamicCollectionUpdateManyAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        Task<UpdateResult> DynamicCollectionUpdateManyAsync<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        Task<UpdateResult> DynamicCollectionUpdateManyAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update,
            MongoCollectionSettings settings = null,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        #endregion



        #region 删除(同步)
        public DeleteResult DeleteOne(string id, DeleteOptions options = null, CancellationToken cancellationToken = default);
        public DeleteResult DeleteOne(IClientSessionHandle session, string id, DeleteOptions options = null, CancellationToken cancellationToken = default);
        public DeleteResult DeleteOne(T document, DeleteOptions options = null, CancellationToken cancellationToken = default);
        public DeleteResult DeleteOne(IClientSessionHandle session, T document, DeleteOptions options = null, CancellationToken cancellationToken = default);
        public DeleteResult DeleteOne(Expression<Func<T, bool>> expression, DeleteOptions options = null, CancellationToken cancellationToken = default);
        public DeleteResult DeleteOne(IClientSessionHandle session, Expression<Func<T, bool>> expression, DeleteOptions options = null, CancellationToken cancellationToken = default);
        public List<DeleteResult> DeleteMany(IEnumerable<T> documents, DeleteOptions options = null, CancellationToken cancellationToken = default);
        public List<DeleteResult> DeleteMany(IClientSessionHandle session, IEnumerable<T> documents, DeleteOptions options = null, CancellationToken cancellationToken = default);
        public DeleteResult DeleteMany(FilterDefinition<T> filter, DeleteOptions options = null, CancellationToken cancellationToken = default);
        public DeleteResult DeleteMany(IClientSessionHandle session, FilterDefinition<T> filter, DeleteOptions options = null, CancellationToken cancellationToken = default);
        public DeleteResult DeleteMany(Expression<Func<T, bool>> expression, DeleteOptions options = null, CancellationToken cancellationToken = default);
        public DeleteResult DeleteMany(IClientSessionHandle session, Expression<Func<T, bool>> expression, DeleteOptions options = null, CancellationToken cancellationToken = default);
        public DeleteResult DynamicCollectionDeleteOne<TForeign>(
            TForeign foreignDocument,
            string id,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            ;
        public DeleteResult DynamicCollectionDeleteOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            string id,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            ;
        public DeleteResult DynamicCollectionDeleteOne<TForeign>(
            TForeign foreignDocument,
            T document,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            ;
        public DeleteResult DynamicCollectionDeleteOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            T document,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            ;
        public DeleteResult DynamicCollectionDeleteOne<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            ;
        public DeleteResult DynamicCollectionDeleteOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            ;
        public DeleteResult DynamicCollectionDeleteOne<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            ;
        public DeleteResult DynamicCollectionDeleteOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            ;
        public List<DeleteResult> DynamicCollectionDeleteMany<TForeign>(
            TForeign foreignDocument,
            IEnumerable<T> documents,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            ;
        public List<DeleteResult> DynamicCollectionDeleteMany<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            IEnumerable<T> documents,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            ;
        public DeleteResult DynamicCollectionDeleteMany<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            ;
        public DeleteResult DynamicCollectionDeleteMany<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            ;
        public DeleteResult DynamicCollectionDeleteMany<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            ;
        public DeleteResult DynamicCollectionDeleteMany<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            ;
        #endregion



        #region 删除(异步)
        public Task<DeleteResult> DeleteOneAsync(string id, DeleteOptions options = null, CancellationToken cancellationToken = default);
        public Task<DeleteResult> DeleteOneAsync(IClientSessionHandle session, string id, DeleteOptions options = null, CancellationToken cancellationToken = default);
        public Task<DeleteResult> DeleteOneAsync(T document, DeleteOptions options = null, CancellationToken cancellationToken = default);
        public Task<DeleteResult> DeleteOneAsync(IClientSessionHandle session, T document, DeleteOptions options = null, CancellationToken cancellationToken = default);
        public Task<DeleteResult> DeleteOneAsync(FilterDefinition<T> filter, DeleteOptions options = null, CancellationToken cancellationToken = default);
        public Task<DeleteResult> DeleteOneAsync(IClientSessionHandle session, FilterDefinition<T> filter, DeleteOptions options = null, CancellationToken cancellationToken = default);
        public Task<DeleteResult> DeleteOneAsync(Expression<Func<T, bool>> expression, DeleteOptions options = null, CancellationToken cancellationToken = default);
        public Task<DeleteResult> DeleteOneAsync(IClientSessionHandle session, Expression<Func<T, bool>> expression, DeleteOptions options = null, CancellationToken cancellationToken = default);
        public Task<List<DeleteResult>> DeleteManyAsync(IEnumerable<T> documents, DeleteOptions options = null, CancellationToken cancellationToken = default);
        public Task<List<DeleteResult>> DeleteManyAsync(IClientSessionHandle session, IEnumerable<T> documents, DeleteOptions options = null, CancellationToken cancellationToken = default);

        public Task<DeleteResult> DeleteManyAsync(FilterDefinition<T> filter, DeleteOptions options = null, CancellationToken cancellationToken = default);
        public Task<DeleteResult> DeleteManyAsync(IClientSessionHandle session, FilterDefinition<T> filter, DeleteOptions options = null, CancellationToken cancellationToken = default);
        public Task<DeleteResult> DeleteManyAsync(Expression<Func<T, bool>> expression, DeleteOptions options = null, CancellationToken cancellationToken = default);
        public Task<DeleteResult> DeleteManyAsync(IClientSessionHandle session, Expression<Func<T, bool>> expression, DeleteOptions options = null, CancellationToken cancellationToken = default);
        public Task<DeleteResult> DynamicCollectionDeleteOneAsync<TForeign>(
            TForeign foreignDocument,
            string id,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            ;
        public Task<DeleteResult> DynamicCollectionDeleteOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            string id,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            ;
        public Task<DeleteResult> DynamicCollectionDeleteOneAsync<TForeign>(
            TForeign foreignDocument,
            T document,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            ;
        public Task<DeleteResult> DynamicCollectionDeleteOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            T document,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            ;
        public Task<DeleteResult> DynamicCollectionDeleteOneAsync<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            ;
        public Task<DeleteResult> DynamicCollectionDeleteOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            ;
        public Task<DeleteResult> DynamicCollectionDeleteOneAsync<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            ;
        public Task<DeleteResult> DynamicCollectionDeleteOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            ;
        public Task<List<DeleteResult>> DynamicCollectionDeleteManyAsync<TForeign>(
            TForeign foreignDocument,
            IEnumerable<T> documents,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            ;
        public Task<List<DeleteResult>> DynamicCollectionDeleteManyAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            IEnumerable<T> documents,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            ;
        public Task<DeleteResult> DynamicCollectionDeleteManyAsync<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            ;
        public Task<DeleteResult> DynamicCollectionDeleteManyAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            ;
        public Task<DeleteResult> DynamicCollectionDeleteManyAsync<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            ;
        public Task<DeleteResult> DynamicCollectionDeleteManyAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> expression,
            MongoCollectionSettings settings = null,
            DeleteOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            ;

        #endregion
    }
}
