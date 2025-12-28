using MongoDB.Driver;
using Apteryx.Mongodb.Driver.Extend.Tests.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Apteryx.Mongodb.Driver.Extend.Tests;

[TestClass]
public class TestDbSetCount : TestBase
{
    private readonly ApteryxDbContext? dbContext;

    private User user = DataHelper.GetNewUser();

    [TestInitialize]
    public void TestInitialize()
    {
        // 确保 dbContext 不为 null
        Assert.IsNotNull(dbContext, "无法从服务提供程序获取ApteryxDbContext。"); ;
    }

    public TestDbSetCount()
    {
        this.dbContext = ServiceProvider.GetService<ApteryxDbContext>();
    }

    [TestMethod]
    public void TestCount()
    {
        var pwd1 = Guid.NewGuid().ToString();
        var pwd2 = Guid.NewGuid().ToString();

        var users1 = DataHelper.GetNewUsers(pwd1);
        var users2 = DataHelper.GetNewUsers(pwd2);

        dbContext.Users.InsertMany(users1);
        dbContext.Users.InsertMany(users2);

        //验证查询数量是否成功
        var userCount1 = dbContext.Users.CountDocuments(Builders<User>.Filter.Eq(e => e.Password, pwd1));
        Assert.AreEqual(6, userCount1, "未成功统计用户数量。");

        var userCount2 = dbContext.Users.CountDocuments(c => c.Password == pwd2);
        Assert.AreEqual(6, userCount2, "未成功统计用户数量。");

        var deletedUser = dbContext.Users.DeleteMany([.. users1, .. users2]);
    }

    [TestMethod]
    public async Task TestCountAsync()
    {
        var pwd1 = Guid.NewGuid().ToString();
        var pwd2 = Guid.NewGuid().ToString();

        var users1 = DataHelper.GetNewUsers(pwd1);
        var users2 = DataHelper.GetNewUsers(pwd2);

        await dbContext.Users.InsertManyAsync(users1);
        await dbContext.Users.InsertManyAsync(users2);

        //验证查询数量是否成功
        var userCount1 = await dbContext.Users.CountDocumentsAsync(Builders<User>.Filter.Eq(e => e.Password, pwd1));
        Assert.AreEqual(6, userCount1, "未成功统计用户数量。");

        var userCount2 = await dbContext.Users.CountDocumentsAsync(c => c.Password == pwd2);
        Assert.AreEqual(6, userCount2, "未成功统计用户数量。");

        var deletedUser = await dbContext.Users.DeleteManyAsync([.. users1, .. users2]);
    }

    [TestMethod]
    public void TestCountSession()
    {
        var pwd1 = Guid.NewGuid().ToString();
        var pwd2 = Guid.NewGuid().ToString();

        var users1 = DataHelper.GetNewUsers(pwd1);
        var users2 = DataHelper.GetNewUsers(pwd2);

        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            dbContext.Users.InsertMany(session, users1);
            dbContext.Users.InsertMany(session, users2);

            //验证查询数量是否成功
            var userCount1 = dbContext.Users.CountDocuments(session, Builders<User>.Filter.Eq(e => e.Password, pwd1));
            Assert.AreEqual(6, userCount1, "未成功统计用户数量。");

            var userCount2 = dbContext.Users.CountDocuments(session, c => c.Password == pwd2);
            Assert.AreEqual(6, userCount2, "未成功统计用户数量。");

            var deletedUser = dbContext.Users.DeleteMany(session, [.. users1, .. users2]);

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public async Task TestCountSessionAsync()
    {
        var pwd1 = Guid.NewGuid().ToString();
        var pwd2 = Guid.NewGuid().ToString();

        var users1 = DataHelper.GetNewUsers(pwd1);
        var users2 = DataHelper.GetNewUsers(pwd2);

        using (var session = await dbContext.Client.StartSessionAsync())
        {
            session.StartTransaction();

            await dbContext.Users.InsertManyAsync(session, users1);
            await dbContext.Users.InsertManyAsync(session, users2);

            //验证查询数量是否成功
            var userCount1 = await dbContext.Users.CountDocumentsAsync(session, Builders<User>.Filter.Eq(e => e.Password, pwd1));
            Assert.AreEqual(6, userCount1, "未成功统计用户数量。");

            var userCount2 = await dbContext.Users.CountDocumentsAsync(session, c => c.Password == pwd2);
            Assert.AreEqual(6, userCount2, "未成功统计用户数量。");

            var deletedUser = await dbContext.Users.DeleteManyAsync(session, [.. users1, .. users2]);

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public void TestCountDynamic()
    {
        var userGroup = DataHelper.GetNewUserGroup();

        var pwd1 = Guid.NewGuid().ToString();
        var pwd2 = Guid.NewGuid().ToString();

        var users1 = DataHelper.GetNewUsers(pwd1);
        var users2 = DataHelper.GetNewUsers(pwd2);

        dbContext.Users.DynamicCollectionInsertMany(userGroup, users1);
        dbContext.Users.DynamicCollectionInsertMany(userGroup, users2);

        //验证查询数量是否成功
        var userCount1 = dbContext.Users.DynamicCollectionCountDocuments(userGroup, Builders<User>.Filter.Eq(e => e.Password, pwd1));
        Assert.AreEqual(6, userCount1, "未成功统计用户数量。");

        var userCount2 = dbContext.Users.DynamicCollectionCountDocuments(userGroup, c => c.Password == pwd2);
        Assert.AreEqual(6, userCount2, "未成功统计用户数量。");

        var deletedUser = dbContext.Users.DynamicCollectionDeleteMany(userGroup, [.. users1, .. users2]);
    }

    [TestMethod]
    public async Task TestCountDynamicAsync()
    {
        var userGroup = DataHelper.GetNewUserGroup();

        var pwd1 = Guid.NewGuid().ToString();
        var pwd2 = Guid.NewGuid().ToString();

        var users1 = DataHelper.GetNewUsers(pwd1);
        var users2 = DataHelper.GetNewUsers(pwd2);

        await dbContext.Users.DynamicCollectionInsertManyAsync(userGroup, users1);
        await dbContext.Users.DynamicCollectionInsertManyAsync(userGroup, users2);

        //验证查询数量是否成功
        var userCount1 = await dbContext.Users.DynamicCollectionCountDocumentsAsync(userGroup, Builders<User>.Filter.Eq(e => e.Password, pwd1));
        Assert.AreEqual(6, userCount1, "未成功统计用户数量。");

        var userCount2 = await dbContext.Users.DynamicCollectionCountDocumentsAsync(userGroup, c => c.Password == pwd2);
        Assert.AreEqual(6, userCount2, "未成功统计用户数量。");

        var deletedUser = await dbContext.Users.DynamicCollectionDeleteManyAsync(userGroup, [.. users1, .. users2]);
    }

    [TestMethod]
    public void TestCountDynamicSession()
    {
        var userGroup = DataHelper.GetNewUserGroup();

        var pwd1 = Guid.NewGuid().ToString();
        var pwd2 = Guid.NewGuid().ToString();

        var users1 = DataHelper.GetNewUsers(pwd1);
        var users2 = DataHelper.GetNewUsers(pwd2);

        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            dbContext.Users.DynamicCollectionInsertMany(session, userGroup, users1);
            dbContext.Users.DynamicCollectionInsertMany(session, userGroup, users2);

            //验证查询数量是否成功
            var userCount1 = dbContext.Users.DynamicCollectionCountDocuments(session, userGroup, Builders<User>.Filter.Eq(e => e.Password, pwd1));
            Assert.AreEqual(6, userCount1, "未成功统计用户数量。");

            var userCount2 = dbContext.Users.DynamicCollectionCountDocuments(session, userGroup, c => c.Password == pwd2);
            Assert.AreEqual(6, userCount2, "未成功统计用户数量。");

            var deletedUser = dbContext.Users.DynamicCollectionDeleteMany(session, userGroup, [.. users1, .. users2]);

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public async Task TestCountDynamicSessionAsync()
    {
        var userGroup = DataHelper.GetNewUserGroup();

        var pwd1 = Guid.NewGuid().ToString();
        var pwd2 = Guid.NewGuid().ToString();

        var users1 = DataHelper.GetNewUsers(pwd1);
        var users2 = DataHelper.GetNewUsers(pwd2);

        using (var session = await dbContext.Client.StartSessionAsync())
        {
            session.StartTransaction();

            await dbContext.Users.DynamicCollectionInsertManyAsync(session, userGroup, users1);
            await dbContext.Users.DynamicCollectionInsertManyAsync(session, userGroup, users2);

            //验证查询数量是否成功
            var userCount1 = await dbContext.Users.DynamicCollectionCountDocumentsAsync(session, userGroup, Builders<User>.Filter.Eq(e => e.Password, pwd1));
            Assert.AreEqual(6, userCount1, "未成功统计用户数量。");

            var userCount2 = await dbContext.Users.DynamicCollectionCountDocumentsAsync(session, userGroup, c => c.Password == pwd2);
            Assert.AreEqual(6, userCount2, "未成功统计用户数量。");

            var deletedUser = await dbContext.Users.DynamicCollectionDeleteManyAsync(session, userGroup, [.. users1, .. users2]);

            session.CommitTransaction();

        }
    }
}

