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

        dbContext.Users.AddMany(users1);
        dbContext.Users.AddMany(users2);

        //验证查询是否成功
        var findUsers = dbContext.Users.Find(u => u.Password == pwd1).ToList();
        Assert.AreEqual(6, findUsers.Count(), "未成功查询用户。");

        //验证查询是否成功
        var findUsers2 = dbContext.Users.Find(Builders<User>.Filter.Eq(u => u.Password, pwd2)).ToList();
        Assert.AreEqual(6, findUsers2.Count(), "未成功查询用户。");

        var deletedUser = dbContext.Users.DeleteMany([.. users1, .. users2]);
    }

    [TestMethod]
    public async Task TestFindAsync()
    {
        var pwd1 = Guid.NewGuid().ToString();
        var pwd2 = Guid.NewGuid().ToString();

        var users1 = DataHelper.GetNewUsers(pwd1);
        var users2 = DataHelper.GetNewUsers(pwd2);

        await dbContext.Users.AddManyAsync(users1);
        await dbContext.Users.AddManyAsync(users2);

        List<User> whereUsers1 = new();
        //验证查询是否成功
        await foreach (var user in dbContext.Users.FindAsync(w => w.Password == pwd1))
        {
            whereUsers1.Add(user);
        }
        Assert.AreEqual(6, whereUsers1.Count(), "未成功查询用户。");


        List<User> whereUsers2 = new();
        //验证查询是否成功
        await foreach (var user in dbContext.Users.FindAsync(Builders<User>.Filter.Eq(u => u.Password, pwd2)))
        {
            whereUsers2.Add(user);
        }
        Assert.AreEqual(6, whereUsers2.Count(), "未成功查询用户。");

        var deletedUser = dbContext.Users.DeleteMany([.. users1, .. users2]);
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

            dbContext.Users.AddMany(session, users1);
            dbContext.Users.AddMany(session, users2);

            //验证查询是否成功
            var findUsers = dbContext.Users.Find(session, u => u.Password == pwd1).ToList();
            Assert.AreEqual(6, findUsers.Count(), "未成功查询用户。");

            //验证查询是否成功
            var findUsers2 = dbContext.Users.Find(session, Builders<User>.Filter.Eq(u => u.Password, pwd2)).ToList();
            Assert.AreEqual(6, findUsers2.Count(), "未成功查询用户。");

            var deletedUser = dbContext.Users.DeleteMany(session, [.. users1, .. users2]);

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

            await dbContext.Users.AddManyAsync(session, users1);
            await dbContext.Users.AddManyAsync(session, users2);

            List<User> whereUsers1 = new();
            //验证查询是否成功
            await foreach (var user in dbContext.Users.FindAsync(session, w => w.Password == pwd1))
            {
                whereUsers1.Add(user);
            }
            Assert.AreEqual(6, whereUsers1.Count(), "未成功查询用户。");

            List<User> whereUsers2 = new();
            //验证查询是否成功
            await foreach (var user in dbContext.Users.FindAsync(session, Builders<User>.Filter.Eq(u => u.Password, pwd2)))
            {
                whereUsers2.Add(user);
            }
            Assert.AreEqual(6, whereUsers2.Count(), "未成功查询用户。");

            var deletedUser = dbContext.Users.DeleteMany(session, [.. users1, .. users2]);

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

        dbContext.Users.DynamicCollectionAddMany(userGroup, users1);
        dbContext.Users.DynamicCollectionAddMany(userGroup, users2);

        //验证查询是否成功
        var findUsers = dbContext.Users.DynamicCollectionFind(userGroup, u => u.Password == pwd1).ToList();
        Assert.AreEqual(6, findUsers.Count(), "未成功查询用户。");

        //验证查询是否成功
        var findUsers2 = dbContext.Users.DynamicCollectionFind(userGroup, Builders<User>.Filter.Eq(u => u.Password, pwd2)).ToList();
        Assert.AreEqual(6, findUsers2.Count(), "未成功查询用户。");

        var deletedUser = dbContext.Users.DynamicCollectionDeleteMany(userGroup, [.. users1, .. users2]);
    }

    [TestMethod]
    public async Task TestWhereDynamicAsync()
    {
        var userGroup = DataHelper.GetNewUserGroup();

        var pwd1 = Guid.NewGuid().ToString();
        var pwd2 = Guid.NewGuid().ToString();

        var users1 = DataHelper.GetNewUsers(pwd1);
        var users2 = DataHelper.GetNewUsers(pwd2);

        await dbContext.Users.DynamicCollectionAddManyAsync(userGroup, users1);
        await dbContext.Users.DynamicCollectionAddManyAsync(userGroup, users2);

        List<User> whereUsers1 = new();
        //验证查询是否成功
        await foreach (var user in dbContext.Users.DynamicCollectionFindAsync(userGroup, w => w.Password == pwd1))
        {
            whereUsers1.Add(user);
        }
        Assert.AreEqual(6, whereUsers1.Count(), "未成功查询用户。");

        List<User> whereUsers2 = new();
        //验证查询是否成功
        await foreach (var user in dbContext.Users.DynamicCollectionFindAsync(userGroup, Builders<User>.Filter.Eq(u => u.Password, pwd2)))
        {
            whereUsers2.Add(user);
        }
        Assert.AreEqual(6, whereUsers2.Count(), "未成功查询用户。");

        var deletedUser = dbContext.Users.DynamicCollectionDeleteMany(userGroup, [.. users1, .. users2]);
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

            dbContext.Users.DynamicCollectionAddMany(session, userGroup, users1);
            dbContext.Users.DynamicCollectionAddMany(session, userGroup, users2);

            //验证查询是否成功
            var findUsers = dbContext.Users.DynamicCollectionFind(session, userGroup, u => u.Password == pwd1).ToList();
            Assert.AreEqual(6, findUsers.Count(), "未成功查询用户。");

            //验证查询是否成功
            var findUsers2 = dbContext.Users.DynamicCollectionFind(session, userGroup, Builders<User>.Filter.Eq(u => u.Password, pwd2)).ToList();
            Assert.AreEqual(6, findUsers2.Count(), "未成功查询用户。");

            var deletedUser = dbContext.Users.DynamicCollectionDeleteMany(session, userGroup, [.. users1, .. users2]);

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

            await dbContext.Users.DynamicCollectionAddManyAsync(session, userGroup, users1);
            await dbContext.Users.DynamicCollectionAddManyAsync(session, userGroup, users2);

            List<User> whereUsers1 = new();
            //验证查询是否成功
            await foreach (var user in dbContext.Users.DynamicCollectionFindAsync(session, userGroup, w => w.Password == pwd1))
            {
                whereUsers1.Add(user);
            }
            Assert.AreEqual(6, whereUsers1.Count(), "未成功查询用户。");

            List<User> whereUsers2 = new();
            //验证查询是否成功
            await foreach (var user in dbContext.Users.DynamicCollectionFindAsync(session, userGroup, Builders<User>.Filter.Eq(u => u.Password, pwd2)))
            {
                whereUsers2.Add(user);
            }
            Assert.AreEqual(6, whereUsers2.Count(), "未成功查询用户。");

            var deletedUser = dbContext.Users.DynamicCollectionDeleteMany(session, userGroup, [.. users1, .. users2]);

        }
    }
}
