using System;
using Microsoft.Extensions.DependencyInjection;
using Apteryx.MongoDB.Driver.Extend.Entities;

namespace Apteryx.MongoDB.Driver.Extend.ExtensionMethods
{
    public static class MongoDBServiceCollectionExtensions
    {
        public static IServiceCollection AddMongoDB<T>(this IServiceCollection serviceCollection, Action<MongoDBOptions> optionsAction) where T:MongoDbService
        {
            serviceCollection.AddScoped<T>();
            if (optionsAction != null)
                serviceCollection.ConfigureMongoDB(optionsAction);
            return serviceCollection;
        }
        public static void ConfigureMongoDB(this IServiceCollection services, Action<MongoDBOptions> setupAction)
        {
            services.Configure(setupAction);
        }
    }
}
