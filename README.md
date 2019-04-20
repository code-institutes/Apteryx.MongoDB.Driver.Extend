# 针对MongoDB.Driver的扩展

使用方法一：

    public class Account:BaseMongoEntity
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
    }

    public class MyDbService:MongoDbService
    {
        public MyDbService(IOptionsMonitor<MongoDBOptions> options) : base(options){}
        public IMongoCollection<Account> Account => _database.GetCollection<Account>("Account");
    }

    public class Startup
    {
      public Startup(IConfiguration configuration)
      {
        Configuration = configuration;
      }

      public IConfiguration Configuration { get; }

      public void ConfigureServices(IServiceCollection services)
      {
        services.AddMongoDB<MyDbService>(options =>
        {
          options.ConnectionString = Configuration.GetConnectionString("MongoDbConnection");
        });
        //.....................
      }
    }
    
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private MyDbService db = null;
        public ValuesController(IMongoDbService db)
        {
            this.db = (MyDbService)db;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            db.Account.Add(new Account(){Name = "张三",Mobile = "13812345678"});
            return new string[] { "value1", "value2" };
        }
    }
    
使用方法二：
    public class Account:BaseMongoEntity
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
    }

    public class MyDbService:MongoDbService
    {        
        public MyDbService(string conn):base(conn){}
        //public MyDbService(IOptionsMonitor<MongoDBOptions> options) : base(options){}
        public IMongoCollection<Account> Account => _database.GetCollection<Account>("Account");
    }
    
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var db = new MyDbService("mongodb://user:pwd@xxx.xxx.xxx.xxx:27017/testdb?authSource=admin");
            db.Account.Add(new Account(){Name = "张三",Mobile = "13812345678"});
            return new string[] { "value1", "value2" };
        }
    }
    
