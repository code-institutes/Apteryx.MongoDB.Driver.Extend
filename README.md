# 针对MongoDB.Driver的扩展

使用方法一：

    public class Account:BaseMongoEntity
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
    }

    public class MyDbService:MongoDbProvider
    {
        public MyDbService(IOptionsMonitor<MongoDBOptions> options) : base(options){}
        public DbSet<Account> Account { get; set; }
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
        private MyDbService _db = null;
        public ValuesController(MyDbService db)
        {
            this._db = db;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _db.Account.Add(new Account(){Name = "张三",Mobile = "13812345678"});
            return new string[] { "value1", "value2" };
        }
    }
    
    
使用方法二：

    public class Account:BaseMongoEntity
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
    }

    public class MyDbService:MongoDbProvider
    {        
        public MyDbService(string conn):base(conn){}
        //public MyDbService(IOptionsMonitor<MongoDBOptions> options) : base(options){}
        public DbSet<Account> Account { get; set; }
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
    
