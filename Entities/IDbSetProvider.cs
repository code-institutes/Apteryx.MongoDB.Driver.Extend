﻿using MongoDB.Driver;
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
        void DynamicCollectionAdd<TForeign>(TForeign foreignDocument, T document, InsertOneOptions options = null, CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity;
        void DynamicCollectionAdd<TForeign>(IClientSessionHandle session, TForeign foreignDocument, T document, InsertOneOptions options = null, CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity;
        void DynamicCollectionAddMany<TForeign>(TForeign foreignDocument, IEnumerable<T> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity;
        void DynamicCollectionAddMany<TForeign>(IClientSessionHandle session, TForeign foreignDocument, IEnumerable<T> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity;

        #endregion



        #region 插入(异步)

        Task AddAsync(T document, InsertOneOptions options = null, CancellationToken cancellationToken = default);
        Task AddAsync(IClientSessionHandle session, T document, InsertOneOptions options = null, CancellationToken cancellationToken = default);
        Task AddManyAsync(IEnumerable<T> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default);
        Task AddManyAsync(IClientSessionHandle session, IEnumerable<T> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default);
        Task DynamicCollectionAddAsync<TForeign>(T foreignDocument, T document, InsertOneOptions options = null, CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity;
        Task DynamicCollectionAddAsync<TForeign>(IClientSessionHandle session, T foreignDocument, T document, InsertOneOptions options = null, CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity;
        Task DynamicCollectionAddManyAsync<TForeign>(T foreignDocument, IEnumerable<T> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity;
        Task DynamicCollectionAddManyAsync<TForeign>(IClientSessionHandle session, T foreignDocument, IEnumerable<T> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity;

        #endregion



        #region 查询(同步)

        T FindOne(string id, MongoCollectionSettings settings = null, FindOptions options = null);
        T FindOne(IClientSessionHandle session, string id, MongoCollectionSettings settings = null, FindOptions options = null);
        T FindOne(string collectionName, string id, MongoCollectionSettings settings = null, FindOptions options = null);
        T FindOne(string collectionName, IClientSessionHandle session, string id, MongoCollectionSettings settings = null, FindOptions options = null);
        T FindOne(FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null);
        T FindOne(IClientSessionHandle session, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null);
        T FindOne(string collectionName, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null);
        T FindOne(string collectionName, IClientSessionHandle session, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null);
        T FindOne(Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null);
        T FindOne(IClientSessionHandle session, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null);
        T FindOne(string collectionName, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null);
        T FindOne(string collectionName, IClientSessionHandle session, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null);
        T DynamicCollectionFindOne<TForeign>(TForeign foreignDocument, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity;
        T DynamicCollectionFindOne<TForeign>(IClientSessionHandle session, TForeign foreignDocument, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity;
        T DynamicCollectionFindOne<TForeign>(TForeign foreignDocument, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity;
        T DynamicCollectionFindOne<TForeign>(IClientSessionHandle session, TForeign foreignDocument, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity;
        IEnumerable<T> FindAll(MongoCollectionSettings settings = null, FindOptions options = null);
        IEnumerable<T> FindAll(IClientSessionHandle session, MongoCollectionSettings settings = null, FindOptions options = null);
        IEnumerable<T> FindAll(string collectionName, MongoCollectionSettings settings = null, FindOptions options = null);
        IEnumerable<T> FindAll(string collectionName, IClientSessionHandle session, MongoCollectionSettings settings = null, FindOptions options = null);
        IEnumerable<T> DynamicCollectionFindAll<TForeign>(TForeign foreignDocument, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity;
        IEnumerable<T> DynamicCollectionFindAll<TForeign>(IClientSessionHandle session, TForeign foreignDocument, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity;
        IEnumerable<T> Where(FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null);
        IEnumerable<T> Where(IClientSessionHandle session, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null);
        IEnumerable<T> Where(string collectionName, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null);
        IEnumerable<T> Where(string collectionName, IClientSessionHandle session, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null);
        IEnumerable<T> Where(Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null);
        IEnumerable<T> Where(IClientSessionHandle session, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null);
        IEnumerable<T> Where(string collectionName, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null);
        IEnumerable<T> Where(string collectionName, IClientSessionHandle session, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null);
        IEnumerable<T> DynamicCollectionWhere<TForeign>(TForeign foreignDocument, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity;
        IEnumerable<T> DynamicCollectionWhere<TForeign>(IClientSessionHandle session, TForeign foreignDocument, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity;
        IEnumerable<T> DynamicCollectionWhere<TForeign>(TForeign foreignDocument, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity;
        IEnumerable<T> DynamicCollectionWhere<TForeign>(IClientSessionHandle session, TForeign foreignDocument, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity;
        long CountDocuments(FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default);
        long CountDocuments(IClientSessionHandle session, FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default);
        long CountDocuments(string collectionName, FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default);
        long CountDocuments(string collectionName, IClientSessionHandle session, FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default);
        long CountDocuments(string collectionName, Expression<Func<T, bool>> filter, CountOptions options = null, CancellationToken cancellationToken = default);
        long CountDocuments(string collectionName, IClientSessionHandle session, Expression<Func<T, bool>> filter, CountOptions options = null, CancellationToken cancellationToken = default);
        long DynamicCollectionCountDocuments<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            CountOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;
        long DynamicCollectionCountDocuments<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            CountOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;
        long DynamicCollectionCountDocuments<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            CountOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;
        long DynamicCollectionCountDocuments<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            CountOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        #endregion



        #region 查询(异步)

        Task<T> FindOneAsync(string id, MongoCollectionSettings settings = null, FindOptions options = null);
        Task<T> FindOneAsync(IClientSessionHandle session, string id, MongoCollectionSettings settings = null, FindOptions options = null);
        Task<T> FindOneAsync(string collectionName, string id, MongoCollectionSettings settings = null, FindOptions options = null);
        Task<T> FindOneAsync(string collectionName, IClientSessionHandle session, string id, MongoCollectionSettings settings = null, FindOptions options = null);
        Task<T> FindOneAsync(FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null);
        Task<T> FindOneAsync(IClientSessionHandle session, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null);
        Task<T> FindOneAsync(string collectionName, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null);
        Task<T> FindOneAsync(string collectionName, IClientSessionHandle session, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null);
        Task<T> FindOneAsync(Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null);
        Task<T> FindOneAsync(IClientSessionHandle session, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null);
        Task<T> FindOneAsync(string collectionName, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null);
        Task<T> FindOneAsync(string collectionName, IClientSessionHandle session, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null);
        Task<T> DynamicCollectionFindOneAsync<TForeign>(TForeign foreignDocument, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity;
        Task<T> DynamicCollectionFindOneAsync<TForeign>(IClientSessionHandle session, TForeign foreignDocument, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity;
        Task<T> DynamicCollectionFindOneAsync<TForeign>(TForeign foreignDocument, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity;
        Task<T> DynamicCollectionFindOneAsync<TForeign>(IClientSessionHandle session, TForeign foreignDocument, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity;
        Task<IEnumerable<T>> FindAllAsync(MongoCollectionSettings settings = null, FindOptions options = null);
        Task<IEnumerable<T>> FindAllAsync(IClientSessionHandle session, MongoCollectionSettings settings = null, FindOptions options = null);
        Task<IEnumerable<T>> FindAllAsync(string collectionName, MongoCollectionSettings settings = null, FindOptions options = null);
        Task<IEnumerable<T>> FindAllAsync(string collectionName, IClientSessionHandle session, MongoCollectionSettings settings = null, FindOptions options = null);
        Task<IEnumerable<T>> DynamicCollectionFindAllAsync<TForeign>(TForeign foreignDocument, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity;
        Task<IEnumerable<T>> DynamicCollectionFindAllAsync<TForeign>(IClientSessionHandle session, TForeign foreignDocument, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity;
        Task<IEnumerable<T>> WhereAsync(FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null);
        Task<IEnumerable<T>> WhereAsync(IClientSessionHandle session, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null);
        Task<IEnumerable<T>> WhereAsync(string collectionName, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null);
        Task<IEnumerable<T>> WhereAsync(string collectionName, IClientSessionHandle session, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null);
        Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null);
        Task<IEnumerable<T>> WhereAsync(IClientSessionHandle session, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null);
        Task<IEnumerable<T>> WhereAsync(string collectionName, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null);
        Task<IEnumerable<T>> WhereAsync(string collectionName, IClientSessionHandle session, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null);
        Task<IEnumerable<T>> DynamicCollectionWhereAsync<TForeign>(TForeign foreignDocument, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity;
        Task<IEnumerable<T>> DynamicCollectionWhereAsync<TForeign>(IClientSessionHandle session, TForeign foreignDocument, FilterDefinition<T> filter, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity;
        Task<IEnumerable<T>> DynamicCollectionWhereAsync<TForeign>(TForeign foreignDocument, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity;
        Task<IEnumerable<T>> DynamicCollectionWhereAsync<TForeign>(IClientSessionHandle session, TForeign foreignDocument, Expression<Func<T, bool>> filter, MongoCollectionSettings settings = null, FindOptions options = null) where TForeign : BaseMongoEntity;
        Task<long> CountDocumentsAsync(FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default);
        Task<long> CountDocumentsAsync(IClientSessionHandle session, FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default);
        Task<long> CountDocumentsAsync(string collectionName, FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default);
        Task<long> CountDocumentsAsync(string collectionName, IClientSessionHandle session, FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default);
        Task<long> CountDocumentsAsync(string collectionName, Expression<Func<T, bool>> filter, CountOptions options = null, CancellationToken cancellationToken = default);
        Task<long> CountDocumentsAsync(string collectionName, IClientSessionHandle session, Expression<Func<T, bool>> filter, CountOptions options = null, CancellationToken cancellationToken = default);
        Task<long> DynamicCollectionCountDocumentsAsync<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            CountOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;
        Task<long> DynamicCollectionCountDocumentsAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            CountOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;
        Task<long> DynamicCollectionCountDocumentsAsync<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            CountOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;
        Task<long> DynamicCollectionCountDocumentsAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            CountOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        #endregion



        #region 替换(同步)
        ReplaceOneResult WhereReplaceOne(
            string id,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default);

        ReplaceOneResult WhereReplaceOne(
            IClientSessionHandle session,
            string id,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default);

        ReplaceOneResult WhereReplaceOne(
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default);

        ReplaceOneResult WhereReplaceOne(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default);

        ReplaceOneResult WhereReplaceOne(
            Expression<Func<T, bool>> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default);

        ReplaceOneResult WhereReplaceOne(
            IClientSessionHandle session,
            Expression<Func<T, bool>> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default);

        ReplaceOneResult DynamicCollectionWhereReplaceOne<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        ReplaceOneResult DynamicCollectionWhereReplaceOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        ReplaceOneResult DynamicCollectionWhereReplaceOne<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        ReplaceOneResult DynamicCollectionWhereReplaceOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            T document,
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
            Expression<Func<T, bool>> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default);

        T FindOneAndReplaceOne(
            IClientSessionHandle session,
            Expression<Func<T, bool>> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default);

        T DynamicCollectionFindOneAndReplaceOne<TForeign>(
            TForeign foreignDocument,
            string id,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        T DynamicCollectionFindOneAndReplaceOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            string id,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        T DynamicCollectionFindOneAndReplaceOne<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        T DynamicCollectionFindOneAndReplaceOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        T DynamicCollectionFindOneAndReplaceOne<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        T DynamicCollectionFindOneAndReplaceOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        #endregion



        #region 替换(异步)

        Task<ReplaceOneResult> WhereReplaceOneAsnyc(
            string id,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default);

        Task<ReplaceOneResult> WhereReplaceOneAsnyc(
            IClientSessionHandle session,
            string id,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default);

        Task<ReplaceOneResult> WhereReplaceOneAsnyc(
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default);

        Task<ReplaceOneResult> WhereReplaceOneAsnyc(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default);

        Task<ReplaceOneResult> WhereReplaceOneAsnyc(
            Expression<Func<T, bool>> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default);

        Task<ReplaceOneResult> WhereReplaceOneAsnyc(
            IClientSessionHandle session,
            Expression<Func<T, bool>> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default);

        Task<ReplaceOneResult> DynamicCollectionWhereReplaceOneAsnyc<TForeign>(
            TForeign foreignDocument,
            string id,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity;

        Task<ReplaceOneResult> DynamicCollectionWhereReplaceOneAsnyc<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            string id,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity;

        Task<ReplaceOneResult> DynamicCollectionWhereReplaceOneAsnyc<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity;

        Task<ReplaceOneResult> DynamicCollectionWhereReplaceOneAsnyc<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity;

        Task<ReplaceOneResult> DynamicCollectionWhereReplaceOneAsnyc<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity;

        Task<ReplaceOneResult> DynamicCollectionWhereReplaceOneAsnyc<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            T document,
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
            Expression<Func<T, bool>> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default);

        Task<T> FindOneAndReplaceOneAsync(
            IClientSessionHandle session,
            Expression<Func<T, bool>> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default);

        Task<T> DynamicCollectionFindOneAndReplaceOneAsync<TForeign>(
            TForeign foreignDocument,
            string id,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        Task<T> DynamicCollectionFindOneAndReplaceOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            string id,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        Task<T> DynamicCollectionFindOneAndReplaceOneAsync<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        Task<T> DynamicCollectionFindOneAndReplaceOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        Task<T> DynamicCollectionFindOneAndReplaceOneAsync<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity;

        Task<T> DynamicCollectionFindOneAndReplaceOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default) where TForeign : BaseMongoEntity;

        #endregion



        #region 更新(同步)

        UpdateResult WhereUpdateOne(
            string id,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        UpdateResult WhereUpdateOne(
            IClientSessionHandle session,
            string id,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        UpdateResult WhereUpdateOne(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        UpdateResult WhereUpdateOne(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        UpdateResult WhereUpdateOne(
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        UpdateResult WhereUpdateOne(
            IClientSessionHandle session,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        UpdateResult DynamicCollectionWhereUpdateOne<TForeign>(
            TForeign foreignDocument,
            string id,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        UpdateResult DynamicCollectionWhereUpdateOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            string id,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        UpdateResult DynamicCollectionWhereUpdateOne<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        UpdateResult DynamicCollectionWhereUpdateOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        UpdateResult DynamicCollectionWhereUpdateOne<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        UpdateResult DynamicCollectionWhereUpdateOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
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
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default);

        T FindOneAndUpdateOne(
            IClientSessionHandle session,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default);

        T DynamicCollectionFindOneAndUpdateOne<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        T DynamicCollectionFindOneAndUpdateOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        T DynamicCollectionFindOneAndUpdateOne<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        T DynamicCollectionFindOneAndUpdateOne<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        UpdateResult WhereUpdateMany(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        UpdateResult WhereUpdateMany(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        UpdateResult WhereUpdateMany(
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        UpdateResult WhereUpdateMany(
            IClientSessionHandle session,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        UpdateResult DynamicCollectionWhereUpdateMany<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        UpdateResult DynamicCollectionWhereUpdateMany<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        UpdateResult DynamicCollectionWhereUpdateMany<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        UpdateResult DynamicCollectionWhereUpdateMany<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        #endregion



        #region 更新(异步)

        Task<UpdateResult> WhereUpdateOneAsync(
            string id,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        Task<UpdateResult> WhereUpdateOneAsync(
            IClientSessionHandle session,
            string id,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        Task<UpdateResult> WhereUpdateOneAsync(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        Task<UpdateResult> WhereUpdateOneAsync(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        Task<UpdateResult> WhereUpdateOneAsync(
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        Task<UpdateResult> WhereUpdateOneAsync(
            IClientSessionHandle session,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        Task<UpdateResult> DynamicCollectionWhereUpdateOneAsync<TForeign>(
            TForeign foreignDocument,
            string id,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        Task<UpdateResult> DynamicCollectionWhereUpdateOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            string id,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        Task<UpdateResult> DynamicCollectionWhereUpdateOneAsync<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        Task<UpdateResult> DynamicCollectionWhereUpdateOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        Task<UpdateResult> DynamicCollectionWhereUpdateOneAsync<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        Task<UpdateResult> DynamicCollectionWhereUpdateOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
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
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default);

        Task<T> FindOneAndUpdateOneAsync(
            IClientSessionHandle session,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default);

        Task<T> DynamicCollectionFindOneAndUpdateOneAsync<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        Task<T> DynamicCollectionFindOneAndUpdateOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        Task<T> DynamicCollectionFindOneAndUpdateOneAsync<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        Task<T> DynamicCollectionFindOneAndUpdateOneAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        Task<UpdateResult> WhereUpdateManyAsync(
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        Task<UpdateResult> WhereUpdateManyAsync(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        Task<UpdateResult> WhereUpdateManyAsync(
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        Task<UpdateResult> WhereUpdateManyAsync(
            IClientSessionHandle session,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default);

        Task<UpdateResult> DynamicCollectionWhereUpdateManyAsync<TForeign>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        Task<UpdateResult> DynamicCollectionWhereUpdateManyAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        Task<UpdateResult> DynamicCollectionWhereUpdateManyAsync<TForeign>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        Task<UpdateResult> DynamicCollectionWhereUpdateManyAsync<TForeign>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            UpdateDefinition<T> update,
            UpdateOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
           ;

        #endregion
    }
}