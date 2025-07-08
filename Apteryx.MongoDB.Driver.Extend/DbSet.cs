using MongoDB.Driver;

namespace Apteryx.MongoDB.Driver.Extend;

public partial class DbSet<T> : IDbSetProvider<T> where T : BaseMongoEntity
{
    private readonly IMongoCollection<T> _collection;
    private readonly IMongoDatabase _database;
    private readonly string _collectionName;
    public DbSet(IMongoDatabase database, string collectionName)
    {
        _database = database;
        _collectionName = collectionName;
        _collection = database.GetCollection<T>(collectionName);
    }

    public IMongoCollection<T> AsMongoCollection
    {
        get
        {
            return _collection;
        }
    }

    public IMongoDatabase DataBase { get { return _database; } }
}
