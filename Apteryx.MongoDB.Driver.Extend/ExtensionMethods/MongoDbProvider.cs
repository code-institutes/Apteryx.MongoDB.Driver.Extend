using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Reflection;

namespace Apteryx.MongoDB.Driver.Extend
{
    public abstract class MongoDbProvider
    {
        //定义数据库
        public IMongoDatabase Database { get; set; }
        public MongoClient Client { get; set; }

        /// <summary>
        /// 连接字符串
        /// </summary>
        /// <param name="conn"></param>
        public MongoDbProvider(string conn)
        {
            var connsetting = new MongoUrlBuilder(conn);
            Client = new MongoClient(connsetting.ToMongoUrl());
            Database = Client.GetDatabase(connsetting.DatabaseName);

            InitializeDbSets();
            InitializeCollections();
        }

        /// <summary>
        /// 连接选项
        /// </summary>
        /// <param name="options"></param>
        public MongoDbProvider(IOptionsMonitor<MongoDBOptions> options) : this(options.CurrentValue.ConnectionString) { }

        private void InitializeDbSets()
        {
            var properties = GetType().GetProperties();
            var dbSetProperties = properties.Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>));
            foreach (var property in dbSetProperties)
            {
                var collectionName = property.Name;
                var arguments = property.PropertyType.GetGenericArguments();
                var entityType = arguments[0];
                var dbSetType = typeof(DbSet<>).MakeGenericType(entityType);
                var dbSetInstance = Activator.CreateInstance(dbSetType, Database, collectionName);
                property.SetValue(this, dbSetInstance);
            }
        }

        private void InitializeCollections()
        {
            var properties = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var collectionProperties = properties.Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(IMongoCollection<>));
            foreach (var property in collectionProperties)
            {
                var collectionName = property.Name;
                var arguments = property.PropertyType.GetGenericArguments();
                var entityType = arguments[0];
                var method = typeof(IMongoDatabase).GetMethod("GetCollection", new[] { typeof(string), typeof(MongoCollectionSettings) });
                var genericMethod = method.MakeGenericMethod(entityType);
                var collection = genericMethod.Invoke(Database, new object[] { collectionName, null });
                property.SetValue(this, collection);
            }
        }
    }
}
