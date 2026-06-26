using Microsoft.Extensions.DependencyInjection;

namespace Apteryx.MongoDB.Driver.Extend;

/// <summary>
/// <see cref="IMongoDbContextFactory{T}"/> 的默认实现。
/// <para>通过 <see cref="IServiceScopeFactory"/> 开临时作用域解析 Context，保证每次返回全新实例，
/// 由 Context 自身的 <see cref="System.IDisposable"/> 释放时连带释放 Scope，
/// ChangeTracker 不残留。工厂自身无状态，安全注册为 Singleton。</para>
/// </summary>
public sealed class MongoDbContextFactory<T> : IMongoDbContextFactory<T> where T : MongoDbContext
{
    private readonly IServiceScopeFactory _scopeFactory;

    public MongoDbContextFactory(IServiceScopeFactory scopeFactory)
        => _scopeFactory = scopeFactory;

    /// <inheritdoc/>
    public T CreateDbContext()
    {
        var scope = _scopeFactory.CreateScope();
        try
        {
            var context = scope.ServiceProvider.GetRequiredService<T>();
            // 把 scope 交给 Context 持有，使其在 Dispose 时连带释放 Scope（含 ChangeTracker）。
            context.AttachScope(scope);
            return context;
        }
        catch
        {
            // 解析失败时立即释放 Scope，避免泄漏；成功则由 Context.Dispose() 释放。
            scope.Dispose();
            throw;
        }
    }
}
