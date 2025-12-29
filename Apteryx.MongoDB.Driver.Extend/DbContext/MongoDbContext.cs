using Apteryx.Mongodb.Driver.Extend;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Apteryx.MongoDB.Driver.Extend;

public abstract class MongoDbContext
{
    //定义数据库
    public IMongoDatabase Database { get; set; }
    public MongoClient Client { get; set; }

    /// <summary>
    /// 连接字符串
    /// </summary>
    /// <param name="conn"></param>
    public MongoDbContext(string conn)
    {
        var connsetting = new MongoUrlBuilder(conn);
        Client = new MongoClient(connsetting.ToMongoUrl());
        Database = Client.GetDatabase(connsetting.DatabaseName);

        InitializeDbSets();
        InitializeCollections();
        InitializeIndexes(); // 在这里调用
    }

    /// <summary>
    /// 连接选项
    /// </summary>
    /// <param name="options"></param>
    public MongoDbContext(IOptionsMonitor<MongoDBOptions> options) : this(options.CurrentValue.ConnectionString) { }

    // --------------------------------------------------------------------
    // SaveChanges（默认开启事务）
    // --------------------------------------------------------------------

    public int SaveChanges(CancellationToken cancellationToken = default)
    {
        using var session = Client.StartSession(cancellationToken: cancellationToken);
        session.StartTransaction();

        try
        {
            int total = SaveChangesInternal(session, cancellationToken);
            session.CommitTransaction(cancellationToken);
            return total;
        }
        catch
        {
            session.AbortTransaction(cancellationToken);
            throw;
        }
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        using var session = await Client.StartSessionAsync(cancellationToken: cancellationToken);
        session.StartTransaction();

        try
        {
            int total = await SaveChangesInternalAsync(session, cancellationToken);
            await session.CommitTransactionAsync(cancellationToken);
            return total;
        }
        catch
        {
            await session.AbortTransactionAsync(cancellationToken);
            throw;
        }
    }

    // --------------------------------------------------------------------
    // 遍历所有 DbSet<T> 并调用内部 SaveChanges
    // --------------------------------------------------------------------

    private int SaveChangesInternal(IClientSessionHandle session, CancellationToken ct)
    {
        int total = 0;

        var dbSets = GetType().GetProperties()
            .Where(p => typeof(IDbSet)
            .IsAssignableFrom(p.PropertyType))
            .Select(p => (IDbSet)p.GetValue(this))
            .Where(s => s.HasChanges); // 只处理有变更的 DbSet

        foreach (var set in dbSets)
        {
            total += set.SaveChanges(session, ct);
        }

        return total;
    }

    private async Task<int> SaveChangesInternalAsync(IClientSessionHandle session, CancellationToken ct)
    {
        int total = 0;

        var dbSets = GetType().GetProperties()
            .Where(p => typeof(IDbSet)
            .IsAssignableFrom(p.PropertyType))
            .Select(p => (IDbSet)p.GetValue(this))
            .Where(s => s.HasChanges); // 只处理有变更的 DbSet

        foreach (var set in dbSets)
        {
            total += await set.SaveChangesAsync(session, ct);
        }

        return total;
    }

    /// <summary>
    /// 初始化以DbSet<>声明的Mongo集合
    /// </summary>
    private void InitializeDbSets()
    {
        var properties = GetType().GetProperties();
        var dbSetProperties = properties.Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>) ||
        p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(IDbSet<>));
        foreach (var property in dbSetProperties)
        {
            var collectionName = property.Name;
            var arguments = property.PropertyType.GetGenericArguments();
            var entityType = arguments[0];
            var dbSetType = typeof(DbSet<>).MakeGenericType(entityType);
            var dbSetInstance = Activator.CreateInstance(dbSetType, Database, collectionName);
            property.SetValue(this, dbSetInstance);
        }
    }

    /// <summary>
    /// 初始化以IMongoCollection<>声明的Mongo集合
    /// </summary>
    private void InitializeCollections()
    {
        var properties = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var collectionProperties = properties.Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(IMongoCollection<>));
        foreach (var property in collectionProperties)
        {
            var collectionName = property.Name;
            var arguments = property.PropertyType.GetGenericArguments();
            var entityType = arguments[0];
            var method = typeof(IMongoDatabase).GetMethod("GetCollection", new[] { typeof(string), typeof(MongoCollectionSettings) });
            var genericMethod = method.MakeGenericMethod(entityType);
            var collection = genericMethod.Invoke(Database, new object[] { collectionName, null });
            property.SetValue(this, collection);
        }
    }
    /// <summary>
    /// 初始化索引
    /// </summary>
    private void InitializeIndexes()
    {
        var contextType = GetType();
        var properties = contextType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        var dbSetProperties = properties.Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>));

        foreach (var prop in dbSetProperties)
        {
            var entityType = prop.PropertyType.GetGenericArguments()[0];
            var collectionName = prop.Name;

            ApplyIndexesForEntity(entityType, collectionName);
        }
    }
    /// <summary>
    /// 根据给定实体类型上定义的索引属性，在指定的 MongoDB 集合上创建索引。
    /// </summary>
    /// <remarks>T此方法检查所提供的实体类型是否存在自定义索引属性，并将相应的索引应用于指定的集合。
    /// 如果未找到任何索引属性，则不执行任何操作。不会重复创建具有相同定义的现有索引。/remarks>
    /// <param name="entityType">用于为集合定义索引的实体索引属性的类型。不能为空。</param>
    /// <param name="collectionName">要应用索引的MongoDB集合名称。不能为空或空字符串。</param>
    private void ApplyIndexesForEntity(Type entityType, string collectionName)
    {
        var indexAttributes = entityType
            .GetCustomAttributes(typeof(MongoIndexAttribute), inherit: true)
            .Cast<MongoIndexAttribute>()
            .ToArray();

        if (indexAttributes.Length == 0)
            return;

        var collection = GetCollection(entityType, collectionName);

        foreach (var attr in indexAttributes)
        {
            var keys = BuildIndexKeys(entityType, attr);
            var options = BuildIndexOptions(entityType, attr);

            var modelType = typeof(CreateIndexModel<>).MakeGenericType(entityType);
            var model = Activator.CreateInstance(modelType, keys, options);

            var indexManager = collection.GetType().GetProperty("Indexes").GetValue(collection);
            var createMethod = indexManager.GetType().GetMethod("CreateOne", new[] { modelType, typeof(CreateOneIndexOptions), typeof(CancellationToken) });

            createMethod.Invoke(indexManager, new object[] { model, null, default(CancellationToken) });
        }
    }
    /// <summary>
    /// 根据提供的索引属性，为指定的实体类型构建 MongoDB 索引键定义。
    /// </summary>
    /// <param name="entityType">用于为集合定义索引的实体索引属性的类型。不能为空。</param>
    /// <param name="attr">MongoIndexAttribute 属性，用于指定索引键中包含的字段和索引类型。该属性不能为空。</param>
    /// <returns>表示为指定实体类型和索引属性构建的 MongoDB 索引键定义的对象。</returns>
    /// <exception cref="NotSupportedException">如果属性中指定的索引类型不受支持，则会抛出异常。</exception>
    private object BuildIndexKeys(Type entityType, MongoIndexAttribute attr)
    {
        var buildersType = typeof(Builders<>).MakeGenericType(entityType);
        var indexKeysProp = buildersType.GetProperty("IndexKeys");
        var indexKeysBuilder = indexKeysProp.GetValue(null);
        var indexKeysBuilderType = indexKeysBuilder.GetType();

        object indexKey = null;

        foreach (var rawField in attr.Fields)
        {
            var (field, type) = MongoIndexFieldParser.Parse(rawField);

            var methodName = type switch
            {
                IndexType.Asc => "Ascending",
                IndexType.Desc => "Descending",
                IndexType.Hashed => "Hashed",
                IndexType.Text => "Text",
                IndexType.Geo2D => "Geo2D",
                IndexType.Geo2DSphere => "Geo2DSphere",
                _ => throw new NotSupportedException()
            };

            // 构造 FieldDefinition<T>
            var fieldDefType = typeof(StringFieldDefinition<>).MakeGenericType(entityType);
            var fieldDef = Activator.CreateInstance(fieldDefType, field);

            var method = indexKeysBuilderType.GetMethods()
                .First(m =>
                    m.Name == methodName &&
                    m.GetParameters().Length == 1 &&
                    m.GetParameters()[0].ParameterType.IsGenericType &&
                    m.GetParameters()[0].ParameterType.GetGenericTypeDefinition() == typeof(FieldDefinition<>)
                );

            var currentKey = method.Invoke(indexKeysBuilder, new[] { fieldDef });

            if (indexKey == null)
            {
                indexKey = currentKey;
            }
            else
            {
                var combineMethod = indexKeysBuilderType.GetMethods()
                    .First(m => m.Name == "Combine" && m.GetParameters()[0].ParameterType.IsArray);

                var array = Array.CreateInstance(currentKey.GetType(), 2);
                array.SetValue(indexKey, 0);
                array.SetValue(currentKey, 1);

                indexKey = combineMethod.Invoke(indexKeysBuilder, new object[] { array });
            }
        }

        return indexKey;
    }
    private CreateIndexOptions BuildIndexOptions(Type entityType, MongoIndexAttribute attr)
    {
        var options = new CreateIndexOptions
        {
            Unique = attr.Unique,
            Sparse = attr.Sparse,
            Name = attr.Name
        };

        if (attr.TtlSeconds != -1)
        {
            ValidateTtlIndex(entityType, attr);
            options.ExpireAfter = TimeSpan.FromSeconds(attr.TtlSeconds);
        }

        return options;
    }

    private void ValidateTtlIndex(Type entityType, MongoIndexAttribute attr)
    {
        if (attr.Fields.Length != 1)
            throw new InvalidOperationException(
                $"TTL 索引只能作用于单字段索引。实体：{entityType.Name}");

        var (fieldName, _) = MongoIndexFieldParser.Parse(attr.Fields[0]);

        var property = entityType.GetProperty(fieldName,
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);

        if (property == null)
            throw new InvalidOperationException(
                $"TTL 索引字段不存在：{entityType.Name}.{fieldName}");

        var type = Nullable.GetUnderlyingType(property.PropertyType)
                   ?? property.PropertyType;

        if (type != typeof(DateTime) && type != typeof(DateTimeOffset))
            throw new InvalidOperationException(
                $"TTL 索引字段必须是 DateTime 或 DateTimeOffset。实体：{entityType.Name}.{fieldName}");
    }

    private object GetCollection(Type entityType, string collectionName)
    {
        var method = typeof(IMongoDatabase)
            .GetMethod("GetCollection", new[] { typeof(string), typeof(MongoCollectionSettings) })
            .MakeGenericMethod(entityType);

        return method.Invoke(Database, new object[] { collectionName, null });
    }
}

