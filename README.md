# Apteryx.MongoDB.Driver.Extend

针对 [MongoDB C# Driver](https://www.nuget.org/packages/MongoDB.Driver/) 的扩展库，提供类 **Entity Framework Core** 的开发体验：通过 `MongoDbContext` + `DbSet<T>` 管理集合，内置变更追踪（ChangeTracker）、事务化提交与声明式索引。

> 目标框架：`net10.0`　依赖：`MongoDB.Driver 3.9.0`

## 特性

- **`MongoDbContext`**：声明式集合，自动按属性名映射集合。
- **`DbSet<T>`**：实现 `IQueryable<T>`，可直接 LINQ；内置 `Commands` 执行器提供完整同步/异步 CRUD。
- **变更追踪（ChangeTracker）**：`Add/Update/Remove` 先进入追踪，`CommitCommands` 统一提交；状态合并规则与 EF Core 一致（如 `Add + Remove → Detached`），按主键 `Id` 去重。
- **事务化提交**：`CommitCommandsInTransaction` 自动开启/提交/回滚事务。
- **声明式索引**：在实体类上标注 `[MongoIndex]`，支持升序/降序/Hashed/Text/Geo、唯一、稀疏、TTL、部分索引。
- **原生访问**：通过 `DbSet.Native` 或 `DbSet.Commands` 随时回退到底层 `IMongoCollection<T>`。

## 快速开始

### 1. 定义实体

```csharp
using Apteryx.MongoDB.Driver.Extend;

public class Account : BaseMongoEntity
{
    public string? Name { get; set; }
    public string? Mobile { get; set; }
}
```

`BaseMongoEntity` 已提供 `Id`、`CreateTime`、`UpdateTime`（均为 UTC）、`TimeStamp`。

### 2. 定义上下文

```csharp
using Apteryx.MongoDB.Driver.Extend;
using Microsoft.Extensions.Options;

public class MyDbContext : MongoDbContext
{
    public MyDbContext(IOptionsMonitor<MongoDBOptions> options) : base(options) { }

    public DbSet<Account> Accounts { get; set; }
}
```

### 3. 注册（Scoped 生命周期）

```csharp
builder.Services.AddMongoDB<MyDbContext>(options =>
{
    options.ConnectionString =
        builder.Configuration.GetConnectionString("MongoDbConnection");
});
```

> ⚠️ 上下文以 **Scoped** 注入（每个请求一个实例），与 EF Core 一致。请勿注册为 Singleton，否则多个请求会共享同一份 ChangeTracker，造成数据串号与线程安全问题。

### 4. 使用

```csharp
public class AccountController(MyDbContext db)
{
    public async Task<IActionResult> Post()
    {
        // 方式一：直接执行（立即写库）
        db.Accounts.Commands.Insert(new Account { Name = "张三", Mobile = "13812345678" });

        // 方式二：变更追踪 + 统一提交
        var entity = await db.Accounts.Commands.FindOneAsync(f => f.Name == "张三");
        if (entity != null)
        {
            entity.Name = "李四";
            db.Accounts.Update(entity);        // 进入追踪（Modified）
            await db.CommitCommandsAsync();     // 统一提交（ReplaceOne，自动刷新 UpdateTime）
        }

        // LINQ 查询
        var list = db.Accounts.Where(a => a.Name!.StartsWith("张")).ToList();

        return Ok(list);
    }
}
```

### 事务提交

```csharp
db.Accounts.Add(new Account { Name = "A" });
db.Accounts.Update(existing);
// 开启事务统一提交；任意一步失败自动回滚
await db.CommitCommandsInTransactionAsync();
```

## 声明式索引

```csharp
[MongoIndex("Name", Unique = true)]
[MongoIndex("CreateTime:desc", Name = "idx_create")]
[MongoIndex("Mobile", Sparse = true, PartialFilterJson = "{ Mobile: { $type: 'string' } }")]
[MongoIndex("ExpireAt", TtlSeconds = 86400)]
public class Account : BaseMongoEntity
{
    public string? Name { get; set; }
    public string? Mobile { get; set; }
    public DateTime? ExpireAt { get; set; }
}
```

索引在首次调用 `dbContext.EnsureIndexesCreated()` 时创建（惰性，幂等，重复定义不会报错）。

> 字段格式为 `字段名[:类型]`，类型取值：`asc`(默认)、`desc`、`hashed`、`text`、`2d`、`2dsphere`。TTL 索引要求字段为 `DateTime`/`DateTimeOffset`。

## v4 相对旧版的变更（Breaking Changes）

- 上下文基类 `MongoDbProvider` → **`MongoDbContext`**。
- `Add/Update/Remove` 不再立即写库，改为进入变更追踪，需 `CommitCommands` 提交。
- DI 生命周期由 Singleton → **Scoped**。
- 时间字段（`CreateTime`/`UpdateTime`）统一存储为 **UTC**。
- `IDbSet<T>` 移除了重复成员 `AsMongoCollection`（请改用 `Native`）。
- `IDbSet.DataBase` 重命名为 **`Database`**，与上下文统一。
