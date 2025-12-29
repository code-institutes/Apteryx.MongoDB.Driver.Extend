using MongoDB.Driver;
using Apteryx.Mongodb.Driver.Extend.Tests.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Apteryx.Mongodb.Driver.Extend.Tests;

[TestClass]
public class TestDbSetFindOne : TestBase
{
    private readonly ApteryxDbContext? dbContext;

    [TestInitialize]
    public void TestInitialize()
    {
        // 确保 dbContext 不为 null
        Assert.IsNotNull(dbContext, "无法从服务提供程序获取ApteryxDbContext。"); ;
    }

    public TestDbSetFindOne()
    {
        this.dbContext = ServiceProvider.GetService<ApteryxDbContext>();
    }

    [TestMethod]
    public void TestFindOne()
    {
        var user = DataHelper.GetNewUser();

        dbContext.Users.Commands.Insert(user);

        // 验证添加是否成功
        var addedUser = dbContext.Users.Commands.FindOne(user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 验证查询是否成功
        var findUser1 = dbContext.Users.Commands.FindOne(user.Id);
        Assert.IsNotNull(findUser1, "未成功查询用户。");

        // 验证查询是否成功
        var findUser2 = dbContext.Users.Commands.FindOne(r => r.Id == user.Id);
        Assert.IsNotNull(findUser2, "未成功查询用户。");

        // 验证查询是否成功
        var findUser3 = dbContext.Users.Commands.FindOne(Builders<User>.Filter.Eq(r => r.Id, user.Id));
        Assert.IsNotNull(findUser3, "未成功查询用户。");


        // 删除用户
        var result = dbContext.Users.Commands.DeleteOne(addedUser);

        // 验证删除是否成功
        var deletedUser = dbContext.Users.Commands.FindOne(user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public async Task TestFindOneAsync()
    {
        var user = DataHelper.GetNewUser();

        await dbContext.Users.Commands.InsertAsync(user);

        // 验证添加是否成功
        var addedUser = await dbContext.Users.Commands.FindOneAsync(user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 验证查询是否成功
        var findUser1 = await dbContext.Users.Commands.FindOneAsync(user.Id);
        Assert.IsNotNull(findUser1, "未成功查询用户。");

        // 验证查询是否成功
        var findUser2 = await dbContext.Users.Commands.FindOneAsync(r => r.Id == user.Id);
        Assert.IsNotNull(findUser2, "未成功查询用户。");

        // 验证查询是否成功
        var findUser3 = await dbContext.Users.Commands.FindOneAsync(Builders<User>.Filter.Eq(r => r.Id, user.Id));
        Assert.IsNotNull(findUser3, "未成功查询用户。");


        // 删除用户
        var result = await dbContext.Users.Commands.DeleteOneAsync(addedUser);

        // 验证删除是否成功
        var deletedUser = await dbContext.Users.Commands.FindOneAsync(user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public void TestFindOneSession()
    {
        var user = DataHelper.GetNewUser();

        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            dbContext.Users.Commands.Insert(session, user);

            // 验证添加是否成功
            var addedUser = dbContext.Users.Commands.FindOne(session, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 验证查询是否成功
            var findUser1 = dbContext.Users.Commands.FindOne(session, user.Id);
            Assert.IsNotNull(findUser1, "未成功查询用户。");

            // 验证查询是否成功
            var findUser2 = dbContext.Users.Commands.FindOne(session, r => r.Id == user.Id);
            Assert.IsNotNull(findUser2, "未成功查询用户。");

            // 验证查询是否成功
            var findUser3 = dbContext.Users.Commands.FindOne(session, Builders<User>.Filter.Eq(r => r.Id, user.Id));
            Assert.IsNotNull(findUser3, "未成功查询用户。");


            // 删除用户
            var result = dbContext.Users.Commands.DeleteOne(session, addedUser);

            // 验证删除是否成功
            var deletedUser = dbContext.Users.Commands.FindOne(session, user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");


            session.CommitTransaction();
        }
    }

    [TestMethod]
    public async Task TestFindOneSessionAsync()
    {
        var user = DataHelper.GetNewUser();

        using (var session = await dbContext.Client.StartSessionAsync())
        {
            session.StartTransaction();

            await dbContext.Users.Commands.InsertAsync(session, user);

            // 验证添加是否成功
            var addedUser = await dbContext.Users.Commands.FindOneAsync(session, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 验证查询是否成功
            var findUser1 = await dbContext.Users.Commands.FindOneAsync(session, user.Id);
            Assert.IsNotNull(findUser1, "未成功查询用户。");

            // 验证查询是否成功
            var findUser2 = await dbContext.Users.Commands.FindOneAsync(session, r => r.Id == user.Id);
            Assert.IsNotNull(findUser2, "未成功查询用户。");

            // 验证查询是否成功
            var findUser3 = await dbContext.Users.Commands.FindOneAsync(session, Builders<User>.Filter.Eq(r => r.Id, user.Id));
            Assert.IsNotNull(findUser3, "未成功查询用户。");


            // 删除用户
            var result = await dbContext.Users.Commands.DeleteOneAsync(session, addedUser);

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.Commands.FindOneAsync(session, user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public void TestFindOneDynamic()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        var user = DataHelper.GetNewUser();

        dbContext.Users.Commands.DynamicCollectionInsert(userGroup, user);

        // 验证添加是否成功
        var addedUser = dbContext.Users.Commands.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 验证查询是否成功
        var findUser1 = dbContext.Users.Commands.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.IsNotNull(findUser1, "未成功查询用户。");

        // 验证查询是否成功
        var findUser2 = dbContext.Users.Commands.DynamicCollectionFindOne(userGroup, r => r.Id == user.Id);
        Assert.IsNotNull(findUser2, "未成功查询用户。");

        // 验证查询是否成功
        var findUser3 = dbContext.Users.Commands.DynamicCollectionFindOne(userGroup, Builders<User>.Filter.Eq(r => r.Id, user.Id));
        Assert.IsNotNull(findUser3, "未成功查询用户。");


        // 删除用户
        var result = dbContext.Users.Commands.DynamicCollectionDeleteOne(userGroup, addedUser);

        // 验证删除是否成功
        var deletedUser = dbContext.Users.Commands.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public async Task TestFindOneDynamicAsync()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        var user = DataHelper.GetNewUser();

        await dbContext.Users.Commands.DynamicCollectionInsertAsync(userGroup, user);

        // 验证添加是否成功
        var addedUser = await dbContext.Users.Commands.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 验证查询是否成功
        var findUser1 = await dbContext.Users.Commands.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.IsNotNull(findUser1, "未成功查询用户。");

        // 验证查询是否成功
        var findUser2 = await dbContext.Users.Commands.DynamicCollectionFindOneAsync(userGroup, r => r.Id == user.Id);
        Assert.IsNotNull(findUser2, "未成功查询用户。");

        // 验证查询是否成功
        var findUser3 = await dbContext.Users.Commands.DynamicCollectionFindOneAsync(userGroup, Builders<User>.Filter.Eq(r => r.Id, user.Id));
        Assert.IsNotNull(findUser3, "未成功查询用户。");


        // 删除用户
        var result = await dbContext.Users.Commands.DynamicCollectionDeleteOneAsync(userGroup, addedUser);

        // 验证删除是否成功
        var deletedUser = await dbContext.Users.Commands.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public void TestFindOneDynamicSession()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        var user = DataHelper.GetNewUser();

        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            dbContext.Users.Commands.DynamicCollectionInsert(session, userGroup, user);

            // 验证添加是否成功
            var addedUser = dbContext.Users.Commands.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 验证查询是否成功
            var findUser1 = dbContext.Users.Commands.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.IsNotNull(findUser1, "未成功查询用户。");

            // 验证查询是否成功
            var findUser2 = dbContext.Users.Commands.DynamicCollectionFindOne(session, userGroup, r => r.Id == user.Id);
            Assert.IsNotNull(findUser2, "未成功查询用户。");

            // 验证查询是否成功
            var findUser3 = dbContext.Users.Commands.DynamicCollectionFindOne(session, userGroup, Builders<User>.Filter.Eq(r => r.Id, user.Id));
            Assert.IsNotNull(findUser3, "未成功查询用户。");


            // 删除用户
            var result = dbContext.Users.Commands.DynamicCollectionDeleteOne(session, userGroup, addedUser);

            // 验证删除是否成功
            var deletedUser = dbContext.Users.Commands.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");


            session.CommitTransaction();
        }
    }

    [TestMethod]
    public async Task TestFindOneDynamicSessionAsync()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        var user = DataHelper.GetNewUser();

        using (var session = await dbContext.Client.StartSessionAsync())
        {
            session.StartTransaction();

            await dbContext.Users.Commands.DynamicCollectionInsertAsync(session, userGroup, user);

            // 验证添加是否成功
            var addedUser = await dbContext.Users.Commands.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 验证查询是否成功
            var findUser1 = await dbContext.Users.Commands.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.IsNotNull(findUser1, "未成功查询用户。");

            // 验证查询是否成功
            var findUser2 = await dbContext.Users.Commands.DynamicCollectionFindOneAsync(session, userGroup, r => r.Id == user.Id);
            Assert.IsNotNull(findUser2, "未成功查询用户。");

            // 验证查询是否成功
            var findUser3 = await dbContext.Users.Commands.DynamicCollectionFindOneAsync(session, userGroup, Builders<User>.Filter.Eq(r => r.Id, user.Id));
            Assert.IsNotNull(findUser3, "未成功查询用户。");


            // 删除用户
            var result = await dbContext.Users.Commands.DynamicCollectionDeleteOneAsync(session, userGroup, addedUser);

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.Commands.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");


            session.CommitTransaction();
        }
    }

    [TestMethod]
    public void TestFindAll()
    {
        var users = DataHelper.GetNewUsers();

        dbContext.Users.Commands.InsertMany(users);

        //验证查询是否成功
        var findUsers = dbContext.Users.Commands.FindAll();
        Assert.AreEqual(6, findUsers.Count(), "未成功查询用户。");

        // 验证删除是否成功
        var deletedUser = dbContext.Users.Commands.DeleteMany(users);
        Assert.AreEqual(6, deletedUser.Count(a => a.DeletedCount == 1), "用户未成功删除。");
    }

    [TestMethod]
    public async Task TestFindAllAsync()
    {
        var users = DataHelper.GetNewUsers();

        await dbContext.Users.Commands.InsertManyAsync(users);

        //验证查询是否成功
        List<User> findUsers = new();
        await foreach (var user in dbContext.Users.Commands.FindAllAsync())
        {
            findUsers.Add(user);
        }
        Assert.AreEqual(6, findUsers.Count(), "未成功查询用户。");

        // 验证删除是否成功
        var deletedUser = await dbContext.Users.Commands.DeleteManyAsync(users);
        Assert.AreEqual(6, deletedUser.Count(a => a.DeletedCount == 1), "用户未成功删除。");
    }

    [TestMethod]
    public void TestFindAllSession()
    {
        var users = DataHelper.GetNewUsers();

        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            dbContext.Users.Commands.InsertMany(session, users);

            //验证查询是否成功
            var findUsers = dbContext.Users.Commands.FindAll(session);
            Assert.AreEqual(6, findUsers.Count(), "未成功查询用户。");

            // 验证删除是否成功
            var deletedUser = dbContext.Users.Commands.DeleteMany(session, users);
            Assert.AreEqual(6, deletedUser.Count(a => a.DeletedCount == 1), "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public async Task TestFindAllSessionAsync()
    {
        var users = DataHelper.GetNewUsers();

        using (var session = await dbContext.Client.StartSessionAsync())
        {
            session.StartTransaction();

            await dbContext.Users.Commands.InsertManyAsync(session, users);

            //验证查询是否成功
            List<User> findUsers = new();
            await foreach (var user in dbContext.Users.Commands.FindAllAsync(session))
            {
                findUsers.Add(user);
            }
            Assert.AreEqual(6, findUsers.Count(), "未成功查询用户。");

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.Commands.DeleteManyAsync(session, users);
            Assert.AreEqual(6, deletedUser.Count(a => a.DeletedCount == 1), "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public void TestFindAllDynamic()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        var users = DataHelper.GetNewUsers();

        dbContext.Users.Commands.DynamicCollectionInsertMany(userGroup, users);

        //验证查询是否成功
        var findUsers = dbContext.Users.Commands.DynamicCollectionFindAll(userGroup);
        Assert.AreEqual(6, findUsers.Count(), "未成功查询用户。");

        // 验证删除是否成功
        var deletedUser = dbContext.Users.Commands.DynamicCollectionDeleteMany(userGroup, users);
        Assert.AreEqual(6, deletedUser.Count(a => a.DeletedCount == 1), "用户未成功删除。");
    }

    [TestMethod]
    public async Task TestFindAllDynamicAsync()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        var users = DataHelper.GetNewUsers();

        await dbContext.Users.Commands.DynamicCollectionInsertManyAsync(userGroup, users);

        //验证查询是否成功
        List<User> findUsers = new();
        await foreach (var user in dbContext.Users.Commands.DynamicCollectionFindAllAsync(userGroup))
        {
            findUsers.Add(user);
        }
        Assert.AreEqual(6, findUsers.Count(), "未成功查询用户。");

        // 验证删除是否成功
        var deletedUser = await dbContext.Users.Commands.DynamicCollectionDeleteManyAsync(userGroup, users);
        Assert.AreEqual(6, deletedUser.Count(a => a.DeletedCount == 1), "用户未成功删除。");
    }

    [TestMethod]
    public void TestFindAllDynamicSession()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        var users = DataHelper.GetNewUsers();

        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            dbContext.Users.Commands.DynamicCollectionInsertMany(session, userGroup, users);

            //验证查询是否成功
            var findUsers = dbContext.Users.Commands.DynamicCollectionFindAll(session, userGroup);
            Assert.AreEqual(6, findUsers.Count(), "未成功查询用户。");

            // 验证删除是否成功
            var deletedUser = dbContext.Users.Commands.DynamicCollectionDeleteMany(session, userGroup, users);
            Assert.AreEqual(6, deletedUser.Count(a => a.DeletedCount == 1), "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public async Task TestFindAllDynamicSessionAsync()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        var users = DataHelper.GetNewUsers();

        using (var session = await dbContext.Client.StartSessionAsync())
        {
            session.StartTransaction();

            await dbContext.Users.Commands.DynamicCollectionInsertManyAsync(session, userGroup, users);

            //验证查询是否成功
            List<User> findUsers = new();
            await foreach (var user in dbContext.Users.Commands.DynamicCollectionFindAllAsync(session, userGroup))
            {
                findUsers.Add(user);
            }
            Assert.AreEqual(6, findUsers.Count(), "未成功查询用户。");

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.Commands.DynamicCollectionDeleteManyAsync(session, userGroup, users);
            Assert.AreEqual(6, deletedUser.Count(a => a.DeletedCount == 1), "用户未成功删除。");

            session.CommitTransaction();
        }
    }
}
