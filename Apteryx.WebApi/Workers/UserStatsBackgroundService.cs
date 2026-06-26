using Apteryx.MongoDB.Driver.Extend;
using Apteryx.WebApi.Data;

namespace Apteryx.WebApi.Workers;

/// <summary>
/// 后台统计服务示例。
/// <para>
/// ⚠️ <see cref="BackgroundService"/> 本身是 <b>Singleton</b> 生命周期，<b>切勿</b>在其构造函数里直接注入
/// <see cref="ApteryxDbContext"/>（Scoped）——那会让单个 Context 被永久"俘获"（Captive Dependency），
/// 导致 ChangeTracker 无法释放、多线程共享同一非线程安全实例，引发内存泄漏与数据串号。
/// </para>
/// <para>
/// 正确做法：注入 <see cref="IMongoDbContextFactory{T}"/>（由 <c>AddMongoDB</c> 自动注册为 Singleton），
/// 在每次循环里按需创建一个全新、独立的 Context，用完即释放。底层 <c>MongoClient</c> 仍复用全局单例，
/// 连接池照常复用。
/// </para>
/// </summary>
public class UserStatsBackgroundService : BackgroundService
{
    private readonly IMongoDbContextFactory<ApteryxDbContext> _factory;
    private readonly ILogger<UserStatsBackgroundService> _logger;

    public UserStatsBackgroundService(
        IMongoDbContextFactory<ApteryxDbContext> factory,
        ILogger<UserStatsBackgroundService> logger)
    {
        _factory = factory;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("UserStatsBackgroundService 启动。");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                // 工厂每次返回一个全新的 Scoped Context，与其它循环、其它请求互不干扰。
                using var db = _factory.CreateDbContext();

                long total = await db.Users.Commands.CountDocumentsAsync(_ => true, cancellationToken: stoppingToken);
                _logger.LogInformation("当前用户总数：{Count}", total);
            }
            catch (Exception ex) when (ex is not OperationCanceledException)
            {
                // 单次循环失败不应终止整个后台服务。
                _logger.LogError(ex, "统计用户数失败。");
            }

            try
            {
                await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
            }
            catch (OperationCanceledException)
            {
                break;
            }
        } // using 释放：ChangeTracker 随 Scope 一起回收，绝不泄漏。

        _logger.LogInformation("UserStatsBackgroundService 停止。");
    }
}
