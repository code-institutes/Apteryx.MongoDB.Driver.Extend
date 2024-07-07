using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Linq;

namespace Apteryx.MongoDB.Driver.Extend
{
    public abstract partial class MongoDbProvider /*: IMongoDbProvider*/
    {
        //定义数据库
        public IMongoDatabase Database { get; set; }
        public MongoClient Client {get; set;}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        public MongoDbProvider(string conn)
        {
            var connsetting = new MongoUrlBuilder(conn);
            Client = new MongoClient(connsetting.ToMongoUrl());
            Database = Client.GetDatabase(connsetting.DatabaseName);

            InitializeDbSets();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public MongoDbProvider(IOptionsMonitor<MongoDBOptions> options):this(options.CurrentValue.ConnectionString)
        {
        }

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
    }
}
