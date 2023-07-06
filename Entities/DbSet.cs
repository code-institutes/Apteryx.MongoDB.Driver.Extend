
using MongoDB.Driver;

namespace Apteryx.MongoDB.Driver.Extend
{
    public class DbSet<T>  where T : BaseMongoEntity
    {
        public IMongoDatabase Database { get; set; }

        public IMongoCollection<T> Collection
        {
            get
            {
                return Database.GetCollection<T>(typeof(T).Name);
            }
        }
       
        public DbSet(IMongoDatabase database)
        {
            Database = database;
        }
    }
}
