using System;
using MongoDB.Driver;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Apteryx.MongoDB.Driver.Extend;
public static class MongoDBServiceCollectionExtensions
{
    /// <summary>
    /// 注册 MongoDbContext 及其依赖。
    /// <list type="bullet">
    /// <item><see cref="IMongoClient"/> 以 <b>Singleton</b> 注册：全进程唯一实例，复用连接池
    /// （官方驱动要求 Client 全局唯一，否则每请求新建 Client 会各自占用连接池）。</item>
    /// <item><typeparamref name="T"/> (MongoDbContext) 以 <b>Scoped</b> 注册：每个作用域（如一次 Web 请求）
    /// 拥有独立的 ChangeTracker，避免并发下的状态串号与线程安全问题（与 EF Core 的 DbContext 一致）。</item>
    /// <item><see cref="IMongoDbContextFactory{T}"/> 以 <b>Singleton</b> 注册：供 Singleton 服务
    /// （如后台任务、单例缓存）按需创建独立的 Scoped Context，避免 Captive Dependency（被俘获依赖）。</item>
    /// </list>
    /// </summary>
    public static IServiceCollection AddMongoDB<T>(this IServiceCollection services, Action<MongoDBOptions> options) where T : MongoDbContext
    {
        if (options != null)
            services.ConfigureMongoDB(options);

        // MongoClient 全局单例：连接池全进程复用，杜绝每请求 new MongoClient 的反模式。
        services.AddSingleton<IMongoClient>(sp =>
        {
            var conn = sp.GetRequiredService<IOptions<MongoDBOptions>>().Value.ConnectionString;
            return new MongoClient(new MongoUrlBuilder(conn).ToMongoUrl());
        });

        // Context 仍为 Scoped：每请求独立 ChangeTracker，但底层复用同一个 Singleton Client。
        services.AddScoped<T>();

        // 工厂为 Singleton：供 Singleton/后台服务按需创建独立 Context（每次返回全新实例，用完释放）。
        services.AddSingleton<IMongoDbContextFactory<T>, MongoDbContextFactory<T>>();
        return services;
    }

    public static void ConfigureMongoDB(this IServiceCollection services, Action<MongoDBOptions> options)
    {
        services.Configure(options);
    }
}
