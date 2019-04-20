using Apteryx.MongoDB.Driver.Extend.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Apteryx.MongoDB.Driver.Extend
{
    public abstract partial class MongoDbService: IMongoDbService
    {
        //定义数据库
        public readonly IMongoDatabase _database = null;

        public MongoDbService(string conn)
        {
            var connsetting = new MongoUrlBuilder(conn);
            var client = new MongoClient(connsetting.ToMongoUrl());
            _database = client.GetDatabase(connsetting.DatabaseName);
        }

        public MongoDbService(IOptionsMonitor<MongoDBOptions> options)
        {
            var connsetting = new MongoUrlBuilder(options.CurrentValue.ConnectionString);
            var client = new MongoClient(connsetting.ToMongoUrl());
            _database = client.GetDatabase(connsetting.DatabaseName);
        }
    }
}
