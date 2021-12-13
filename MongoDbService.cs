using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Apteryx.MongoDB.Driver.Extend
{
    public abstract partial class MongoDbService : IMongoDbService
    {
        //定义数据库
        public IMongoDatabase Database { get; set; }
        public MongoClient Client {get; set;}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        public MongoDbService(string conn)
        {
            var connsetting = new MongoUrlBuilder(conn);
            var client = new MongoClient(connsetting.ToMongoUrl());
            Database = client.GetDatabase(connsetting.DatabaseName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public MongoDbService(IOptionsMonitor<MongoDBOptions> options)
        {
            var connsetting = new MongoUrlBuilder(options.CurrentValue.ConnectionString);
            Client = new MongoClient(connsetting.ToMongoUrl());
            Database = Client.GetDatabase(connsetting.DatabaseName);
        }
    }
}
