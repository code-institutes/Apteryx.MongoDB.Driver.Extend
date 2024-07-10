using Apteryx.Mongodb.Driver.Extend.Tests.Data;
using Microsoft.Extensions.DependencyInjection;
using Apteryx.MongoDB.Driver.Extend;
using Microsoft.Extensions.Configuration;

namespace Apteryx.Mongodb.Driver.Extend.Tests
{
    public class TestBase
    {
        protected ServiceProvider ServiceProvider { get; private set; }
        protected IConfiguration Configuration { get; private set; }

        public TestBase()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // 构建配置
            var configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddUserSecrets<TestBase>(); // 添加用户机密

            Configuration = configurationBuilder.Build();

            // 注册你需要的服务
            services.AddMongoDB<ApteryxDbContext>(options =>
            {
                options.ConnectionString = Configuration.GetConnectionString("MongoDbConnection");
            });

            // 其他服务注册
        }
    }
}
