using Apteryx.MongoDB.Driver.Extend;
using MongoDB.Driver;

namespace Apteryx.MongoDB.Driver.Extend;

public partial class ImmediateExecutor<T> : IImmediateExecutor<T> where T : BaseMongoEntity
{
    private readonly IMongoCollection<T> _collection;
    private readonly IMongoDatabase _database;
    private readonly string _collectionName;
    public ImmediateExecutor(IMongoDatabase database, IMongoCollection<T> collection)
    {
        _collection = collection;
        _database = database;
    }
}
