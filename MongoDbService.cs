using Apteryx.MongoDB.Driver.Extend.Entities;
using MongoDB.Driver;

namespace Apteryx.MongoDB.Driver.Extend
{
    public abstract partial class MongoDbService: IMongoDbService
    {
        //定义数据库
        public readonly IMongoDatabase _database = null;

        public MongoDbService(MongoDBOptions options)
        {
            var client = new MongoClient(options.ConnectionString);
            _database = client.GetDatabase(options.DbName);
        }
        //public MongoDbService(string conn, string database = "apteryx_mongodb_extend")
        //{
        //    ////连接服务器名称  mongo的默认端口27017
        //    var client = new MongoClient(conn);
        //    _database = client.GetDatabase(database);
        //}
    }
}
