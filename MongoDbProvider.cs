using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Apteryx.MongoDB.Driver.Extend
{
    public abstract partial class MongoDbProvider : IMongoDbProvider
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public MongoDbProvider(IOptionsMonitor<MongoDBOptions> options):this(options.CurrentValue.ConnectionString)
        {
        }
    }
}
