﻿using System;
using Microsoft.Extensions.DependencyInjection;

namespace Apteryx.MongoDB.Driver.Extend
{
    public static class MongoDBServiceCollectionExtensions
    {
        public static IServiceCollection AddMongoDB<T>(this IServiceCollection serviceCollection, Action<MongoDBOptions> optionsAction) where T:MongoDbProvider
        {
            serviceCollection.AddScoped<T>();
            if (optionsAction != null)
                serviceCollection.ConfigureMongoDB(optionsAction);
            return serviceCollection;
        }
        public static void ConfigureMongoDB(this IServiceCollection services, Action<MongoDBOptions> optionsAction)
        {
            services.Configure(optionsAction);
        }
    }
}
