using Apteryx.MongoDB.Driver.Extend.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Apteryx.MongoDB.Driver.Extend
{
    public abstract partial class MongoDbService
    {
        #region 查询(同步)

        public T FindOne<T>(FilterDefinition<T> filter) where T : BaseMongoEntity
        {
            return database.GetCollection<T>(typeof(T).Name).Find(filter).FirstOrDefault();
        }
        public T FindOne<T>(Expression<Func<T, bool>> filter) where T : BaseMongoEntity
        {
            return database.GetCollection<T>(typeof(T).Name).Find(filter).FirstOrDefault();
        }
        public T DynamicTableFindOne<TForeign, T>(TForeign foreignDocument, FilterDefinition<T> filter)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").Find(filter).FirstOrDefault();
        }
        public T DynamicTableFindOne<TForeign, T>(TForeign foreignDocument, Expression<Func<T, bool>> filter)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").Find(filter).FirstOrDefault();
        }
        public IEnumerable<T> FindAll<T>() where T : BaseMongoEntity
        {
            return database.GetCollection<T>(typeof(T).Name).Find(_ => true).ToEnumerable();
        }
        public IEnumerable<T> DynamicTableFindAll<TForeign, T>(TForeign foreignDocument)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").Find(_=>true).ToEnumerable();
        }
        public IEnumerable<T> Where<T>(FilterDefinition<T> filter) where T : BaseMongoEntity
        {
            return database.GetCollection<T>(typeof(T).Name).Find(filter).ToEnumerable();
        }
        public IEnumerable<T> Where<T>(Expression<Func<T, bool>> filter) where T : BaseMongoEntity
        {
            return database.GetCollection<T>(typeof(T).Name).Find(filter).ToEnumerable();
        }
        public IEnumerable<T> DynamicTableWhere<TForeign, T>(TForeign foreignDocument, FilterDefinition<T> filter)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").Find(filter).ToEnumerable();
        }

        public IEnumerable<T> DynamicTableWhere<TForeign, T>(TForeign foreignDocument, Expression<Func<T, bool>> filter)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            return database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").Find(filter).ToEnumerable();
        }

        #endregion
    }
}
