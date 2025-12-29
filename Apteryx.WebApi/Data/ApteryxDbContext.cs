using Apteryx.MongoDB.Driver.Extend;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Apteryx.WebApi.Data;
public class ApteryxDbContext : MongoDbContext
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    /// <param name="serviceProvider"></param>
    public ApteryxDbContext(IOptionsMonitor<MongoDBOptions> options) : base(options) { }

    public IDbSet<User> Users { get; set; }

    public IDbSet<User> UserMany { get; set; }

    public IMongoCollection<User> UsersCollection { get; set; }
}
