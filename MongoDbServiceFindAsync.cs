using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Apteryx.MongoDB.Driver.Extend.Entities;
using MongoDB.Driver;

namespace Apteryx.MongoDB.Driver.Extend
{
    public abstract partial class MongoDbService
    {
        #region 查询(异步)

        public Task<T> FindOneAsync<T>(FilterDefinition<T> filter) where T : BaseMongoEntity
        {
            return database.GetCollection<T>(typeof(T).Name).Find(filter).FirstOrDefaultAsync();
        }

        public Task<T> FindOneAsync<T>(Expression<Func<T, bool>> filter) where T : BaseMongoEntity
        {
            return database.GetCollection<T>(typeof(T).Name).Find(filter).FirstOrDefaultAsync();
        }

        public Task<T> DynamicTableFindOneAsync<TForeign, T>(TForeign foreignDocument, FilterDefinition<T> filter)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").Find(filter)
                .FirstOrDefaultAsync();
        }

        public Task<T> DynamicTableFindOneAsync<TForeign, T>(TForeign foreignDocument, Expression<Func<T, bool>> filter)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").Find(filter)
                .FirstOrDefaultAsync();
        }

        public Task<IEnumerable<T>> FindAllAsync<T>() where T : BaseMongoEntity
        {
            return Task.Run(() => FindAll<T>());
        }

        public Task<IEnumerable<T>> DynamicTableFindAllAsync<TForeign, T>(TForeign foreignDocument)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return Task.Run(() => DynamicTableFindAll<TForeign, T>(foreignDocument));
        }

        public Task<IEnumerable<T>> WhereAsync<T>(FilterDefinition<T> filter) where T : BaseMongoEntity
        {
            return Task.Run(() => Where(filter));
        }

        public Task<IEnumerable<T>> WhereAsync<T>(Expression<Func<T, bool>> filter) where T : BaseMongoEntity
        {
            return Task.Run(() => Where(filter));
        }

        public Task<IEnumerable<T>> DynamicTableWhereAsync<TForeign, T>(
            TForeign foreignDocument,
            FilterDefinition<T> filter)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return Task.Run(() => DynamicTableWhere(foreignDocument, filter));
        }

        public Task<IEnumerable<T>> DynamicTableWhereAsync<TForeign, T>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return Task.Run(() => DynamicTableWhere(foreignDocument, filter));
        }

        #endregion
    }
}
