using System;
using Microsoft.Extensions.DependencyInjection;

namespace Apteryx.MongoDB.Driver.Extend
{
    public static class MongoDBServiceCollectionExtensions
    {
        public static IServiceCollection AddMongoDB<T>(this IServiceCollection services, Action<MongoDBOptions> options) where T:MongoDbProvider
        {
            services.AddSingleton<T>();
            if (options != null)
                services.ConfigureMongoDB(options);
            return services;
        }
        public static void ConfigureMongoDB(this IServiceCollection services, Action<MongoDBOptions> options)
        {
            services.Configure(options);
            services.AddSingleton(typeof(DbSet<>));
        }
    }
}
