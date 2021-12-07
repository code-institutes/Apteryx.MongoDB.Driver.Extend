using Apteryx.MongoDB.Driver.Extend.Entities;
using MongoDB.Driver;
using System;
using System.Linq.Expressions;

namespace Apteryx.MongoDB.Driver.Extend
{
    public abstract partial class MongoDbService
    {
        public long CountDocuments<T>(string tableName, FilterDefinition<T> filter) where T : BaseMongoEntity
        {
            return database.GetCollection<T>(tableName).CountDocuments(filter);
        }
        public long CountDocuments<T>(string tableName, Expression<Func<T, bool>> filter) where T : BaseMongoEntity
        {
            return database.GetCollection<T>(tableName).CountDocuments(filter);
        }
    }
}
