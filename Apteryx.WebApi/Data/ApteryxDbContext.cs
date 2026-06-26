using Apteryx.MongoDB.Driver.Extend;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Apteryx.WebApi.Data;
public class ApteryxDbContext : MongoDbContext
{
    /// <summary>
    /// MongoClient 由 DI 以 Singleton 注入并复用连接池；options 仅用于解析数据库名。
    /// </summary>
    public ApteryxDbContext(IMongoClient client, IOptions<MongoDBOptions> options) : base(client, options) { }

    public IDbSet<User> Users { get; set; }

    public IDbSet<User> UserMany { get; set; }

    public IMongoCollection<User> UsersCollection { get; set; }
}
