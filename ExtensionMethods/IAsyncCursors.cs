using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Apteryx.MongoDB.Driver.Extend.Entities;

namespace Apteryx.MongoDB.Driver.Extend.ExtensionMethods
{
    public static class IAsyncCursors
    {
        #region 同步方法
        public static T FindOne<T>(this IMongoCollection<T> collection, Expression<Func<T, bool>> filter) where T:BaseMongoEntity
        {
            return collection.Find(filter).FirstOrDefault();
        }
        public static IEnumerable<T> FindAll<T>(this IMongoCollection<T> collection)
        {
            return collection.Find(_ => true).ToList();
        }

        public static IEnumerable<T> Where<T>(this IMongoCollection<T> collection, Expression<Func<T, bool>> filte)
        {
            return collection.Find(filte).ToList();
        }

        public static void Add<T>(this IMongoCollection<T> collection, T document)
        {
            collection.InsertOne(document);
        }

        public static ReplaceOneResult Update<T>(this IMongoCollection<T> collection, FilterDefinition<T> filter, T document)
        {
            return collection.ReplaceOne(filter, document);
        }
        #endregion

        #region 异步方法
        public static Task<T> FindOneAsync<T>(this IMongoCollection<T> collection, Expression<Func<T, bool>> filter)
        {
            return (collection.Find(filter)).FirstOrDefaultAsync();
        }
        public static Task<IAsyncCursor<T>> FindAllAsync<T>(this IMongoCollection<T> collection)
        {
            return collection.FindAsync(_ => true);
        }
        public static Task<IAsyncCursor<T>> WhereAsync<T>(this IMongoCollection<T> collection, Expression<Func<T, bool>> filter)
        {
            return collection.FindAsync(filter);
        }
        public static Task AddAsync<T>(this IMongoCollection<T> collection, T document)
        {
            return collection.InsertOneAsync(document);
        }
        public static Task<ReplaceOneResult> UpdateAsync<T>(this IMongoCollection<T> collection, FilterDefinition<T> filter, T document)
        {
            return collection.ReplaceOneAsync(filter, document);
        }
        #endregion
    }
}
