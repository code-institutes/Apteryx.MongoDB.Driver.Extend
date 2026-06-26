using MongoDB.Bson;
using Apteryx.MongoDB.Driver.Extend.Tests.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Apteryx.MongoDB.Driver.Extend.Tests;

/// <summary>
/// 变更追踪（ChangeTracker）与提交（CommitCommands）相关测试。
/// 依赖真实 MongoDB 实例（连接串通过 UserSecrets/appsettings 提供）。
/// </summary>
[TestClass]
public class TestChangeTracker : TestBase
{
    private readonly ApteryxDbContext? dbContext;

    [TestInitialize]
    public void TestInitialize()
    {
        Assert.IsNotNull(dbContext, "无法从服务提供程序获取ApteryxDbContext。");
    }

    public TestChangeTracker()
    {
        this.dbContext = ServiceProvider.GetService<ApteryxDbContext>();
    }

    /// <summary>
    /// 通过 ChangeTracker 添加实体并提交后，应能查到。
    /// </summary>
    [TestMethod]
    public async Task TestAddAndCommit()
    {
        var user = new User { Id = ObjectId.GenerateNewId().ToString(), Name = "CT_Add" };

        dbContext!.Users.Add(user);
        // 尚未提交时不应入库
        Assert.IsNull(dbContext.Users.Commands.FindOne(user.Id), "提交前不应写入数据库。");

        int affected = await dbContext.CommitCommandsAsync();
        Assert.AreEqual(1, affected, "应提交 1 条变更。");

        var found = dbContext.Users.Commands.FindOne(user.Id);
        Assert.IsNotNull(found, "提交后应能查到。");
        Assert.AreEqual("CT_Add", found!.Name);

        // 清理
        dbContext.Users.Commands.DeleteOne(user.Id);
    }

    /// <summary>
    /// Update + Remove + Add 应触发 EF Core 风格的状态合并：Add + Remove → Detached（不入库）。
    /// </summary>
    [TestMethod]
    public async Task TestStateMergeAddThenRemove()
    {
        var user = new User { Id = ObjectId.GenerateNewId().ToString(), Name = "CT_Merge" };

        dbContext!.Users.Add(user);
        dbContext.Users.Remove(user); // Add + Remove → Detached

        int affected = await dbContext.CommitCommandsAsync();
        Assert.AreEqual(0, affected, "Add 后立即 Remove 应合并为 Detached，不产生入库。");

        Assert.IsNull(dbContext.Users.Commands.FindOne(user.Id), "Detached 实体不应入库。");
    }

    /// <summary>
    /// 同一 Id 的两个不同对象实例，追踪应按 Id 去重，最终只入库一条。
    /// </summary>
    [TestMethod]
    public async Task TestTrackByIdDedup()
    {
        string id = ObjectId.GenerateNewId().ToString();
        var a = new User { Id = id, Name = "A" };
        var b = new User { Id = id, Name = "B" };

        dbContext!.Users.Add(a);
        dbContext.Users.Add(b); // 同一 Id，后一次覆盖意图

        int affected = await dbContext.CommitCommandsAsync();
        Assert.AreEqual(1, affected, "同一 Id 应只入库一条。");

        var found = dbContext.Users.Commands.FindOne(id);
        Assert.IsNotNull(found);

        // 清理
        dbContext.Users.Commands.DeleteOne(id);
    }

    /// <summary>
    /// CommitCommandsInTransaction 中途异常应回滚整批，已提交内容不落库。
    /// </summary>
    [TestMethod]
    public async Task TestTransactionRollback()
    {
        var user = new User { Id = ObjectId.GenerateNewId().ToString(), Name = "CT_Tx" };

        dbContext!.Users.Add(user);
        await dbContext.CommitCommandsInTransactionAsync();
        Assert.IsNotNull(dbContext.Users.Commands.FindOne(user.Id), "正常提交应入库。");

        // 构造一个会失败的提交：插入重复 _id 会抛异常，验证事务回滚
        var dup = new User { Id = user.Id, Name = "dup" };
        var other = new User { Id = ObjectId.GenerateNewId().ToString(), Name = "CT_Other" };

        dbContext.Users.Add(dup);    // 与已存在记录 _id 冲突
        dbContext.Users.Add(other);  // 这条不应入库

        await Assert.ThrowsAsync<Exception>(async () =>
        {
            await dbContext.CommitCommandsInTransactionAsync();
        });

        Assert.IsNull(dbContext.Users.Commands.FindOne(other.Id), "事务回滚后 other 不应入库。");

        // 清理
        dbContext.Users.Commands.DeleteOne(user.Id);
    }

    /// <summary>
    /// 追踪前未设置 Id 的实体，应被自动分配 Id 并成功入库。
    /// </summary>
    [TestMethod]
    public async Task TestAutoAssignId()
    {
        var user = new User { Name = "CT_AutoId" }; // 无 Id

        dbContext!.Users.Add(user);
        Assert.IsFalse(string.IsNullOrEmpty(user.Id), "追踪后应自动分配 Id。");

        await dbContext.CommitCommandsAsync();
        Assert.IsNotNull(dbContext.Users.Commands.FindOne(user.Id), "自动分配 Id 的实体应入库。");

        // 清理
        dbContext.Users.Commands.DeleteOne(user.Id);
    }
}
