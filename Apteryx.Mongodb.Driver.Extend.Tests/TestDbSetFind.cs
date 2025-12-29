using MongoDB.Driver;
using Apteryx.Mongodb.Driver.Extend.Tests.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Apteryx.Mongodb.Driver.Extend.Tests;

[TestClass]
public class TestDbSetFind : TestBase
{
    private readonly ApteryxDbContext? dbContext;

    [TestInitialize]
    public void TestInitialize()
    {
        // 确保 dbContext 不为 null
        Assert.IsNotNull(dbContext, "无法从服务提供程序获取ApteryxDbContext。"); ;
    }

    public TestDbSetFind()
    {
        this.dbContext = ServiceProvider.GetService<ApteryxDbContext>();
    }

    [TestMethod]
    public void TestWhere()
    {
        var pwd1 = Guid.NewGuid().ToString();
        var pwd2 = Guid.NewGuid().ToString();

        var users1 = DataHelper.GetNewUsers(pwd1);
        var users2 = DataHelper.GetNewUsers(pwd2);

        dbContext.Users.Commands.InsertMany(users1);
        dbContext.Users.Commands.InsertMany(users2);

        //验证查询是否成功
        var findUsers = dbContext.Users.Commands.Find(u => u.Password == pwd1).ToList();
        Assert.AreEqual(6, findUsers.Count(), "未成功查询用户。");

        //验证查询是否成功
        var findUsers2 = dbContext.Users.Commands.Find(Builders<User>.Filter.Eq(u => u.Password, pwd2)).ToList();
        Assert.AreEqual(6, findUsers2.Count(), "未成功查询用户。");

        var deletedUser = dbContext.Users.Commands.DeleteMany([.. users1, .. users2]);
    }

    [TestMethod]
    public async Task TestFindAsync()
    {
        var pwd1 = Guid.NewGuid().ToString();
        var pwd2 = Guid.NewGuid().ToString();

        var users1 = DataHelper.GetNewUsers(pwd1);
        var users2 = DataHelper.GetNewUsers(pwd2);

        await dbContext.Users.Commands.InsertManyAsync(users1);
        await dbContext.Users.Commands.InsertManyAsync(users2);

        List<User> whereUsers1 = new();
        //验证查询是否成功
        await foreach (var user in dbContext.Users.Commands.FindAsync(w => w.Password == pwd1))
        {
            whereUsers1.Add(user);
        }
        Assert.AreEqual(6, whereUsers1.Count(), "未成功查询用户。");


        List<User> whereUsers2 = new();
        //验证查询是否成功
        await foreach (var user in dbContext.Users.Commands.FindAsync(Builders<User>.Filter.Eq(u => u.Password, pwd2)))
        {
            whereUsers2.Add(user);
        }
        Assert.AreEqual(6, whereUsers2.Count(), "未成功查询用户。");

        var deletedUser = dbContext.Users.Commands.DeleteMany([.. users1, .. users2]);
    }

    [TestMethod]
    public void TestWhereSession()
    {
        var pwd1 = Guid.NewGuid().ToString();
        var pwd2 = Guid.NewGuid().ToString();

        var users1 = DataHelper.GetNewUsers(pwd1);
        var users2 = DataHelper.GetNewUsers(pwd2);

        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            dbContext.Users.Commands.InsertMany(session, users1);
            dbContext.Users.Commands.InsertMany(session, users2);

            //验证查询是否成功
            var findUsers = dbContext.Users.Commands.Find(session, u => u.Password == pwd1).ToList();
            Assert.AreEqual(6, findUsers.Count(), "未成功查询用户。");

            //验证查询是否成功
            var findUsers2 = dbContext.Users.Commands.Find(session, Builders<User>.Filter.Eq(u => u.Password, pwd2)).ToList();
            Assert.AreEqual(6, findUsers2.Count(), "未成功查询用户。");

            var deletedUser = dbContext.Users.Commands.DeleteMany(session, [.. users1, .. users2]);

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public async Task TestWhereSessionAsync()
    {
        var pwd1 = Guid.NewGuid().ToString();
        var pwd2 = Guid.NewGuid().ToString();

        var users1 = DataHelper.GetNewUsers(pwd1);
        var users2 = DataHelper.GetNewUsers(pwd2);

        using (var session = await dbContext.Client.StartSessionAsync())
        {
            session.StartTransaction();

            await dbContext.Users.Commands.InsertManyAsync(session, users1);
            await dbContext.Users.Commands.InsertManyAsync(session, users2);

            List<User> whereUsers1 = new();
            //验证查询是否成功
            await foreach (var user in dbContext.Users.Commands.FindAsync(session, w => w.Password == pwd1))
            {
                whereUsers1.Add(user);
            }
            Assert.AreEqual(6, whereUsers1.Count(), "未成功查询用户。");

            List<User> whereUsers2 = new();
            //验证查询是否成功
            await foreach (var user in dbContext.Users.Commands.FindAsync(session, Builders<User>.Filter.Eq(u => u.Password, pwd2)))
            {
                whereUsers2.Add(user);
            }
            Assert.AreEqual(6, whereUsers2.Count(), "未成功查询用户。");

            var deletedUser = dbContext.Users.Commands.DeleteMany(session, [.. users1, .. users2]);

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public void TestWhereDynamic()
    {
        var userGroup = DataHelper.GetNewUserGroup();

        var pwd1 = Guid.NewGuid().ToString();
        var pwd2 = Guid.NewGuid().ToString();

        var users1 = DataHelper.GetNewUsers(pwd1);
        var users2 = DataHelper.GetNewUsers(pwd2);

        dbContext.Users.Commands.DynamicCollectionInsertMany(userGroup, users1);
        dbContext.Users.Commands.DynamicCollectionInsertMany(userGroup, users2);

        //验证查询是否成功
        var findUsers = dbContext.Users.Commands.DynamicCollectionFind(userGroup, u => u.Password == pwd1).ToList();
        Assert.AreEqual(6, findUsers.Count(), "未成功查询用户。");

        //验证查询是否成功
        var findUsers2 = dbContext.Users.Commands.DynamicCollectionFind(userGroup, Builders<User>.Filter.Eq(u => u.Password, pwd2)).ToList();
        Assert.AreEqual(6, findUsers2.Count(), "未成功查询用户。");

        var deletedUser = dbContext.Users.Commands.DynamicCollectionDeleteMany(userGroup, [.. users1, .. users2]);
    }

    [TestMethod]
    public async Task TestWhereDynamicAsync()
    {
        var userGroup = DataHelper.GetNewUserGroup();

        var pwd1 = Guid.NewGuid().ToString();
        var pwd2 = Guid.NewGuid().ToString();

        var users1 = DataHelper.GetNewUsers(pwd1);
        var users2 = DataHelper.GetNewUsers(pwd2);

        await dbContext.Users.Commands.DynamicCollectionInsertManyAsync(userGroup, users1);
        await dbContext.Users.Commands.DynamicCollectionInsertManyAsync(userGroup, users2);

        List<User> whereUsers1 = new();
        //验证查询是否成功
        await foreach (var user in dbContext.Users.Commands.DynamicCollectionFindAsync(userGroup, w => w.Password == pwd1))
        {
            whereUsers1.Add(user);
        }
        Assert.AreEqual(6, whereUsers1.Count(), "未成功查询用户。");

        List<User> whereUsers2 = new();
        //验证查询是否成功
        await foreach (var user in dbContext.Users.Commands.DynamicCollectionFindAsync(userGroup, Builders<User>.Filter.Eq(u => u.Password, pwd2)))
        {
            whereUsers2.Add(user);
        }
        Assert.AreEqual(6, whereUsers2.Count(), "未成功查询用户。");

        var deletedUser = dbContext.Users.Commands.DynamicCollectionDeleteMany(userGroup, [.. users1, .. users2]);
    }

    [TestMethod]
    public void TestWhereDynamicSession()
    {
        var userGroup = DataHelper.GetNewUserGroup();

        var pwd1 = Guid.NewGuid().ToString();
        var pwd2 = Guid.NewGuid().ToString();

        var users1 = DataHelper.GetNewUsers(pwd1);
        var users2 = DataHelper.GetNewUsers(pwd2);

        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            dbContext.Users.Commands.DynamicCollectionInsertMany(session, userGroup, users1);
            dbContext.Users.Commands.DynamicCollectionInsertMany(session, userGroup, users2);

            //验证查询是否成功
            var findUsers = dbContext.Users.Commands.DynamicCollectionFind(session, userGroup, u => u.Password == pwd1).ToList();
            Assert.AreEqual(6, findUsers.Count(), "未成功查询用户。");

            //验证查询是否成功
            var findUsers2 = dbContext.Users.Commands.DynamicCollectionFind(session, userGroup, Builders<User>.Filter.Eq(u => u.Password, pwd2)).ToList();
            Assert.AreEqual(6, findUsers2.Count(), "未成功查询用户。");

            var deletedUser = dbContext.Users.Commands.DynamicCollectionDeleteMany(session, userGroup, [.. users1, .. users2]);

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public async Task TestWhereDynamicSessionAsync()
    {
        var userGroup = DataHelper.GetNewUserGroup();

        var pwd1 = Guid.NewGuid().ToString();
        var pwd2 = Guid.NewGuid().ToString();

        var users1 = DataHelper.GetNewUsers(pwd1);
        var users2 = DataHelper.GetNewUsers(pwd2);

        using (var session = await dbContext.Client.StartSessionAsync())
        {
            session.StartTransaction();

            await dbContext.Users.Commands.DynamicCollectionInsertManyAsync(session, userGroup, users1);
            await dbContext.Users.Commands.DynamicCollectionInsertManyAsync(session, userGroup, users2);

            List<User> whereUsers1 = new();
            //验证查询是否成功
            await foreach (var user in dbContext.Users.Commands.DynamicCollectionFindAsync(session, userGroup, w => w.Password == pwd1))
            {
                whereUsers1.Add(user);
            }
            Assert.AreEqual(6, whereUsers1.Count(), "未成功查询用户。");

            List<User> whereUsers2 = new();
            //验证查询是否成功
            await foreach (var user in dbContext.Users.Commands.DynamicCollectionFindAsync(session, userGroup, Builders<User>.Filter.Eq(u => u.Password, pwd2)))
            {
                whereUsers2.Add(user);
            }
            Assert.AreEqual(6, whereUsers2.Count(), "未成功查询用户。");

            var deletedUser = dbContext.Users.Commands.DynamicCollectionDeleteMany(session, userGroup, [.. users1, .. users2]);

        }
    }
}
