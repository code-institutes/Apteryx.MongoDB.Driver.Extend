using MongoDB.Driver;
using Apteryx.WebApi.Data;
using Apteryx.MongoDB.Driver.Extend;
using Microsoft.AspNetCore.Mvc;

namespace Apteryx.WebApi.Controllers;

/// <summary>
/// 用户接口示例。
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly ApteryxDbContext _db;

    // 普通请求路径：Controller 是 Scoped，可直接注入 Scoped 的 ApteryxDbContext。
    // （Controller 自身在每请求结束时由框架释放，与 Context 生命周期一致，安全。）
    public UsersController(ApteryxDbContext db) => _db = db;

    /// <summary>
    /// 直接注入 Context 的常规用法（请求作用域内）。
    /// </summary>
    [HttpGet]
    public IEnumerable<User> List()
    {
        // 方式一：LINQ 查询
        return _db.Users.Where(u => u.Name != null).ToList();
    }

    /// <summary>
    /// 变更追踪 + 统一提交。
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create(string name)
    {
        var user = new User { Name = name };
        _db.Users.Add(user);          // 进入追踪
        await _db.CommitCommandsAsync(); // 统一提交
        return Ok(user);
    }

    /// <summary>
    /// 演示：即便在请求作用域内，也可用工厂创建一个独立 Context，
    /// 用于隔离某段工作单元（用完即弃，不污染当前请求的 ChangeTracker）。
    /// </summary>
    [HttpPost("isolated")]
    public IActionResult CreateIsolated(
        string name,
        IMongoDbContextFactory<ApteryxDbContext> factory) // 也可注入为字段，这里按参数演示
    {
        // 工厂每次返回一个全新、独立的 Context
        using var db = factory.CreateDbContext();

        var user = new User { Name = name };
        db.Users.Add(user);
        db.CommitCommands();
        // 注意：此 Context 的提交与当前请求的 _db 互不影响（各自独立 ChangeTracker）。

        return Ok(user);
    } // using 释放：工厂创建的 Context 及其 ChangeTracker 随 Scope 回收。
}
