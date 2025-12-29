using Apteryx.MongoDB.Driver.Extend;
using Microsoft.Extensions.Options;

namespace Apteryx.Mongodb.Driver.Extend.Tests.Data
{
    public class ApteryxDbContext : MongoDbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="serviceProvider"></param>
        public ApteryxDbContext(IOptionsMonitor<MongoDBOptions> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<UserGroup> UserGroups { get; set; }
    }
}
