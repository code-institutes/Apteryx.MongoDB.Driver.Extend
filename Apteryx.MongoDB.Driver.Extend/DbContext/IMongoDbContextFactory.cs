namespace Apteryx.MongoDB.Driver.Extend;

/// <summary>
/// 用于在 Singleton 服务（如后台任务 <c>IHostedService</c>/<c>BackgroundService</c>、单例缓存）中
/// 安全创建 <see cref="MongoDbContext"/> 实例。工厂本身无状态、注册为 Singleton，按需制造
/// 全新、独立的 Scoped Context，避免 Captive Dependency（被俘获依赖）。
/// <para>用法对齐 EF Core 的 <c>IDbContextFactory&lt;TContext&gt;</c>：</para>
/// <code>
/// public class MyService(IMongoDbContextFactory&lt;MyDbContext&gt; factory)
/// {
///     using var db = factory.CreateDbContext();   // 全新独立 Context
///     db.Accounts.Add(new Account());
///     db.CommitCommands();
/// }   // using 释放：ChangeTracker 随 Scope 一起回收
/// </code>
/// </summary>
public interface IMongoDbContextFactory<T> where T : MongoDbContext
{
    /// <summary>
    /// 创建一个全新的 <typeparamref name="T"/> 实例（独立 Scope）。
    /// <para>调用方负责释放（推荐 <c>using</c>）；底层 <see cref="MongoDB.Driver.IMongoClient"/>
    /// 仍复用全局单例，连接池照常复用。</para>
    /// </summary>
    T CreateDbContext();
}
