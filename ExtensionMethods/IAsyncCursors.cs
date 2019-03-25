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
        public static TDocument FindOne<TDocument>(this IMongoCollection<TDocument> collection, Expression<Func<TDocument, bool>> filter) where TDocument:BaseMongoEntity
        {
            //return collection.Find(Builders<TDocument>.Filter.Eq( )).FirstOrDefault();
            return collection.Find(filter).FirstOrDefault();
        }
        public static IEnumerable<TDocument> FindAll<TDocument>(this IMongoCollection<TDocument> collection)
        {
            return collection.Find(_ => true).ToList();
        }

        public static IEnumerable<TDocument> FindAll<TDocument>(this IMongoCollection<TDocument> collection, Expression<Func<TDocument, bool>> filte)
        {
            return collection.Find(filte).ToList();
        }
        #endregion

        #region 异步方法
        public async static Task<TDocument> FindOneAsync<TDocument>(this IMongoCollection<TDocument> collection, Expression<Func<TDocument, bool>> filter)
        {
            return await (await collection.FindAsync(filter)).FirstOrDefaultAsync();
        }
        public async static Task<IEnumerable<TDocument>> FindAllAsync<TDocument>(this IMongoCollection<TDocument> collection)
        {
            return await (await collection.FindAsync(_ => true)).ToListAsync();
        }
        public async static Task<IEnumerable<TDocument>> FindAllAsync<TDocument>(this IMongoCollection<TDocument> collection, Expression<Func<TDocument, bool>> filter)
        {
            return await (await collection.FindAsync(filter)).ToListAsync();
        }
        #endregion
    }
}
