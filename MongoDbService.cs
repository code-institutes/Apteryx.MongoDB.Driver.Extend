using System.Collections.Generic;
using Apteryx.MongoDB.Driver.Extend.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Apteryx.MongoDB.Driver.Extend
{
    public abstract partial class MongoDbService: IMongoDbService
    {
        //定义数据库
        public readonly IMongoDatabase database = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        public MongoDbService(string conn)
        {
            var connsetting = new MongoUrlBuilder(conn);
            var client = new MongoClient(connsetting.ToMongoUrl());
            database = client.GetDatabase(connsetting.DatabaseName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public MongoDbService(IOptionsMonitor<MongoDBOptions> options)
        {
            var connsetting = new MongoUrlBuilder(options.CurrentValue.ConnectionString);
            var client = new MongoClient(connsetting.ToMongoUrl());
            database = client.GetDatabase(connsetting.DatabaseName);
        }
    }
}
