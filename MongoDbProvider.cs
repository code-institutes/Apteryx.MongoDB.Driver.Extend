using MongoDB.Driver;

namespace Apteryx.MongoDB.Driver.Extend
{
    public abstract partial class MongoDbProvider
    {
        //定义数据库
        public readonly IMongoDatabase _database = null;

        private MongoDbProvider()
        {
        }
        public MongoDbProvider(string conn, string database = "apteryx_mongodb_extend")
        {
            ////连接服务器名称  mongo的默认端口27017
            var client = new MongoClient(conn);
            _database = client.GetDatabase(database);
        }
    }
}
