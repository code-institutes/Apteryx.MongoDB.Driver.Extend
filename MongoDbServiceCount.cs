using Apteryx.MongoDB.Driver.Extend.Entities;
using MongoDB.Driver;
using System;
using System.Linq.Expressions;
using System.Threading;

namespace Apteryx.MongoDB.Driver.Extend
{
    public abstract partial class MongoDbService
    {
        public long CountDocuments<T>(FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity
        {
            return database.GetCollection<T>(typeof(T).Name).CountDocuments(filter, options, cancellationToken);
        }
        public long CountDocuments<T>(IClientSessionHandle session, FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity
        {
            return database.GetCollection<T>(typeof(T).Name).CountDocuments(session, filter, options, cancellationToken);
        }
        public long CountDocuments<T>(string tableName, FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity
        {
            return database.GetCollection<T>(tableName).CountDocuments(filter, options, cancellationToken);
        }
        public long CountDocuments<T>(string tableName, IClientSessionHandle session, FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity
        {
            return database.GetCollection<T>(tableName).CountDocuments(session, filter, options, cancellationToken);
        }
        public long CountDocuments<T>(string tableName, Expression<Func<T, bool>> filter, CountOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity
        {
            return database.GetCollection<T>(tableName).CountDocuments(filter, options, cancellationToken);
        }
        public long CountDocuments<T>(string tableName, IClientSessionHandle session, Expression<Func<T, bool>> filter, CountOptions options = null, CancellationToken cancellationToken = default) where T : BaseMongoEntity
        {
            return database.GetCollection<T>(tableName).CountDocuments(session, filter, options, cancellationToken);
        }
    }
}
