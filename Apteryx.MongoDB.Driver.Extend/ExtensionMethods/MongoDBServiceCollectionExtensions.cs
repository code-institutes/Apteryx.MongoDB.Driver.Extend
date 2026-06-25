using System;
using Microsoft.Extensions.DependencyInjection;

namespace Apteryx.MongoDB.Driver.Extend;
public static class MongoDBServiceCollectionExtensions
{
    /// <summary>
    /// 注册 MongoDbContext。上下文以 Scoped 生命周期注入:
    /// 每个作用域(如一次 Web 请求)拥有独立的 ChangeTracker,
    /// 避免并发下的状态串号与线程安全问题(与 EF Core 的 DbContext 一致)。
    /// </summary>
    public static IServiceCollection AddMongoDB<T>(this IServiceCollection services, Action<MongoDBOptions> options) where T : MongoDbContext
    {
        services.AddScoped<T>();
        if (options != null)
            services.ConfigureMongoDB(options);
        return services;
    }

    public static void ConfigureMongoDB(this IServiceCollection services, Action<MongoDBOptions> options)
    {
        services.Configure(options);
    }
}
