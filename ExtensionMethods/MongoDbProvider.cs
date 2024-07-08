using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Reflection;

namespace Apteryx.MongoDB.Driver.Extend
{
    public abstract partial class MongoDbProvider
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
            var properties = GetType().GetProperties()
                .Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>));

            foreach (var property in properties)
            {
                var entityType = property.PropertyType.GetGenericArguments()[0];
                var collectionName = property.Name;
                var dbSetType = typeof(DbSet<>).MakeGenericType(entityType);
                var dbSetInstance = Activator.CreateInstance(dbSetType, Database, collectionName);
                property.SetValue(this, dbSetInstance);
            }
        }

        private void InitializeCollections()
        {
            var properties = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(IMongoCollection<>))
                {
                    var collectionName = property.Name;
                    var collectionType = property.PropertyType.GetGenericArguments()[0];
                    var method = typeof(IMongoDatabase).GetMethod("GetCollection", new[] { typeof(string), typeof(MongoCollectionSettings) });
                    var genericMethod = method.MakeGenericMethod(collectionType);
                    var collection = genericMethod.Invoke(Database, new object[] { collectionName, null });
                    property.SetValue(this, collection);
                }
            }
        }
    }
}
