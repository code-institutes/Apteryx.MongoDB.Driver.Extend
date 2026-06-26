using Apteryx.MongoDB.Driver.Extend;
using Apteryx.WebApi.Data;
using Apteryx.WebApi.Workers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMongoDB<ApteryxDbContext>(options =>
{
    options.ConnectionString = builder.Configuration.GetConnectionString("MongoDbConnection");
});

// 后台服务（Singleton 生命周期）：演示 IMongoDbContextFactory 的用法。
// AddMongoDB 已自动注册 IMongoDbContextFactory<ApteryxDbContext>，无需额外配置。
builder.Services.AddHostedService<UserStatsBackgroundService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
