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
using MongoDB.Driver;

public class MyDbContext : MongoDbContext
{
    // MongoClient 由 DI 以 Singleton 注入（全局唯一，复用连接池）；
    // options 仅用于从连接串解析数据库名。
    public MyDbContext(IMongoClient client, IOptions<MongoDBOptions> options) : base(client, options) { }

    public DbSet<Account> Accounts { get; set; }
}
```

### 3. 注册

```csharp
builder.Services.AddMongoDB<MyDbContext>(options =>
{
    options.ConnectionString =
        builder.Configuration.GetConnectionString("MongoDbConnection");
});
```

> `AddMongoDB` 内部做了两件事：
> - **`MongoClient` 注册为 Singleton**（全局唯一）。官方驱动要求 `MongoClient` 进程级唯一，其内部管理连接池——若每个请求各 `new` 一个，连接池将无法复用，高并发下连接数会失控。本库自动保证这一点，无需手动注册。
> - **`MongoDbContext` 注册为 Scoped**（每个请求一个实例），与 EF Core 一致。请勿把上下文本身注册为 Singleton，否则多个请求会共享同一份 ChangeTracker，造成数据串号与线程安全问题。
> - **`IMongoDbContextFactory<T>` 注册为 Singleton**：供 Singleton 服务（后台任务、单例缓存）按需创建独立的 Scoped Context，用法见下节。

### 4. 在 Singleton / 后台服务中使用

⚠️ **切勿把 `MongoDbContext` 直接注入到 Singleton 服务**（如 `IHostedService`/`BackgroundService`、单例缓存）。Context 是 Scoped 生命周期，被 Singleton 持有会被永久"俘获"（Captive Dependency）：ChangeTracker 无法释放、多请求共享同一非线程安全实例，导致内存泄漏与数据串号。

正确做法是注入 `IMongoDbContextFactory<T>`（`AddMongoDB` 已自动注册），按需创建**全新、独立**的 Context，用完释放：

```csharp
using Apteryx.MongoDB.Driver.Extend;

// 后台服务本身是 Singleton 生命周期 —— 注入工厂，而不是 Context
public class ReportService(IMongoDbContextFactory<MyDbContext> factory) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken ct)
    {
        while (!ct.IsCancellationRequested)
        {
            // 工厂每次返回一个全新的 Scoped Context
            using var db = factory.CreateDbContext();

            db.Accounts.Add(new Account { Name = "tick" });
            await db.CommitCommandsAsync(ct);

            await Task.Delay(TimeSpan.FromSeconds(30), ct);
        } // using 释放：ChangeTracker 随 Scope 一起回收，绝不泄漏
    }
}
```

工厂创建是纯内存操作（开临时作用域 + 实例化 Context），底层 `MongoClient` 仍复用全局单例，连接池照常复用——既避开 Captive Dependency，又不损失连接池复用的好处。普通请求路径仍直接注入 `MongoDbContext`，两条路并存，互不影响。

### 5. 使用

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
- **`MongoClient` 改为由 DI 以 Singleton 注入**（`AddMongoDB` 自动注册）。旧版每个上下文实例各自 `new MongoClient`，导致连接池无法复用、高并发下连接数失控；新版全进程复用同一个 Client。数据库名仍从连接串解析，**`AddMongoDB` 调用代码无需改动**。
- **`MongoDbContext` 构造函数签名变更**：删除 `MongoDbContext(string conn)` 与 `MongoDbContext(IOptionsMonitor<MongoDBOptions>)` 两个重载（内部 `new MongoClient` 是已移除的反模式）。新增 `MongoDbContext(IMongoClient client, string databaseName)` 及便捷重载 `MongoDbContext(IMongoClient client, IOptions<MongoDBOptions> options)`。子类构造需相应改为 `: base(client, options)`。
- 时间字段（`CreateTime`/`UpdateTime`）统一存储为 **UTC**。
- `IDbSet<T>` 移除了重复成员 `AsMongoCollection`（请改用 `Native`）。
- `IDbSet.DataBase` 重命名为 **`Database`**，与上下文统一。
