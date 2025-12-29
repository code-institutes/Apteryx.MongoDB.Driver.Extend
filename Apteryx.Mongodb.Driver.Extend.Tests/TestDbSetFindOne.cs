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

        dbContext.Users.Immediate.Insert(user);

        // 验证添加是否成功
        var addedUser = dbContext.Users.Immediate.FindOne(user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 验证查询是否成功
        var findUser1 = dbContext.Users.Immediate.FindOne(user.Id);
        Assert.IsNotNull(findUser1, "未成功查询用户。");

        // 验证查询是否成功
        var findUser2 = dbContext.Users.Immediate.FindOne(r => r.Id == user.Id);
        Assert.IsNotNull(findUser2, "未成功查询用户。");

        // 验证查询是否成功
        var findUser3 = dbContext.Users.Immediate.FindOne(Builders<User>.Filter.Eq(r => r.Id, user.Id));
        Assert.IsNotNull(findUser3, "未成功查询用户。");


        // 删除用户
        var result = dbContext.Users.Immediate.DeleteOne(addedUser);

        // 验证删除是否成功
        var deletedUser = dbContext.Users.Immediate.FindOne(user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public async Task TestFindOneAsync()
    {
        var user = DataHelper.GetNewUser();

        await dbContext.Users.Immediate.InsertAsync(user);

        // 验证添加是否成功
        var addedUser = await dbContext.Users.Immediate.FindOneAsync(user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 验证查询是否成功
        var findUser1 = await dbContext.Users.Immediate.FindOneAsync(user.Id);
        Assert.IsNotNull(findUser1, "未成功查询用户。");

        // 验证查询是否成功
        var findUser2 = await dbContext.Users.Immediate.FindOneAsync(r => r.Id == user.Id);
        Assert.IsNotNull(findUser2, "未成功查询用户。");

        // 验证查询是否成功
        var findUser3 = await dbContext.Users.Immediate.FindOneAsync(Builders<User>.Filter.Eq(r => r.Id, user.Id));
        Assert.IsNotNull(findUser3, "未成功查询用户。");


        // 删除用户
        var result = await dbContext.Users.Immediate.DeleteOneAsync(addedUser);

        // 验证删除是否成功
        var deletedUser = await dbContext.Users.Immediate.FindOneAsync(user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public void TestFindOneSession()
    {
        var user = DataHelper.GetNewUser();

        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            dbContext.Users.Immediate.Insert(session, user);

            // 验证添加是否成功
            var addedUser = dbContext.Users.Immediate.FindOne(session, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 验证查询是否成功
            var findUser1 = dbContext.Users.Immediate.FindOne(session, user.Id);
            Assert.IsNotNull(findUser1, "未成功查询用户。");

            // 验证查询是否成功
            var findUser2 = dbContext.Users.Immediate.FindOne(session, r => r.Id == user.Id);
            Assert.IsNotNull(findUser2, "未成功查询用户。");

            // 验证查询是否成功
            var findUser3 = dbContext.Users.Immediate.FindOne(session, Builders<User>.Filter.Eq(r => r.Id, user.Id));
            Assert.IsNotNull(findUser3, "未成功查询用户。");


            // 删除用户
            var result = dbContext.Users.Immediate.DeleteOne(session, addedUser);

            // 验证删除是否成功
            var deletedUser = dbContext.Users.Immediate.FindOne(session, user.Id);
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

            await dbContext.Users.Immediate.InsertAsync(session, user);

            // 验证添加是否成功
            var addedUser = await dbContext.Users.Immediate.FindOneAsync(session, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 验证查询是否成功
            var findUser1 = await dbContext.Users.Immediate.FindOneAsync(session, user.Id);
            Assert.IsNotNull(findUser1, "未成功查询用户。");

            // 验证查询是否成功
            var findUser2 = await dbContext.Users.Immediate.FindOneAsync(session, r => r.Id == user.Id);
            Assert.IsNotNull(findUser2, "未成功查询用户。");

            // 验证查询是否成功
            var findUser3 = await dbContext.Users.Immediate.FindOneAsync(session, Builders<User>.Filter.Eq(r => r.Id, user.Id));
            Assert.IsNotNull(findUser3, "未成功查询用户。");


            // 删除用户
            var result = await dbContext.Users.Immediate.DeleteOneAsync(session, addedUser);

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.Immediate.FindOneAsync(session, user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public void TestFindOneDynamic()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        var user = DataHelper.GetNewUser();

        dbContext.Users.Immediate.DynamicCollectionInsert(userGroup, user);

        // 验证添加是否成功
        var addedUser = dbContext.Users.Immediate.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 验证查询是否成功
        var findUser1 = dbContext.Users.Immediate.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.IsNotNull(findUser1, "未成功查询用户。");

        // 验证查询是否成功
        var findUser2 = dbContext.Users.Immediate.DynamicCollectionFindOne(userGroup, r => r.Id == user.Id);
        Assert.IsNotNull(findUser2, "未成功查询用户。");

        // 验证查询是否成功
        var findUser3 = dbContext.Users.Immediate.DynamicCollectionFindOne(userGroup, Builders<User>.Filter.Eq(r => r.Id, user.Id));
        Assert.IsNotNull(findUser3, "未成功查询用户。");


        // 删除用户
        var result = dbContext.Users.Immediate.DynamicCollectionDeleteOne(userGroup, addedUser);

        // 验证删除是否成功
        var deletedUser = dbContext.Users.Immediate.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public async Task TestFindOneDynamicAsync()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        var user = DataHelper.GetNewUser();

        await dbContext.Users.Immediate.DynamicCollectionInsertAsync(userGroup, user);

        // 验证添加是否成功
        var addedUser = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 验证查询是否成功
        var findUser1 = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.IsNotNull(findUser1, "未成功查询用户。");

        // 验证查询是否成功
        var findUser2 = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(userGroup, r => r.Id == user.Id);
        Assert.IsNotNull(findUser2, "未成功查询用户。");

        // 验证查询是否成功
        var findUser3 = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(userGroup, Builders<User>.Filter.Eq(r => r.Id, user.Id));
        Assert.IsNotNull(findUser3, "未成功查询用户。");


        // 删除用户
        var result = await dbContext.Users.Immediate.DynamicCollectionDeleteOneAsync(userGroup, addedUser);

        // 验证删除是否成功
        var deletedUser = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(userGroup, user.Id);
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

            dbContext.Users.Immediate.DynamicCollectionInsert(session, userGroup, user);

            // 验证添加是否成功
            var addedUser = dbContext.Users.Immediate.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 验证查询是否成功
            var findUser1 = dbContext.Users.Immediate.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.IsNotNull(findUser1, "未成功查询用户。");

            // 验证查询是否成功
            var findUser2 = dbContext.Users.Immediate.DynamicCollectionFindOne(session, userGroup, r => r.Id == user.Id);
            Assert.IsNotNull(findUser2, "未成功查询用户。");

            // 验证查询是否成功
            var findUser3 = dbContext.Users.Immediate.DynamicCollectionFindOne(session, userGroup, Builders<User>.Filter.Eq(r => r.Id, user.Id));
            Assert.IsNotNull(findUser3, "未成功查询用户。");


            // 删除用户
            var result = dbContext.Users.Immediate.DynamicCollectionDeleteOne(session, userGroup, addedUser);

            // 验证删除是否成功
            var deletedUser = dbContext.Users.Immediate.DynamicCollectionFindOne(session, userGroup, user.Id);
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

            await dbContext.Users.Immediate.DynamicCollectionInsertAsync(session, userGroup, user);

            // 验证添加是否成功
            var addedUser = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 验证查询是否成功
            var findUser1 = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.IsNotNull(findUser1, "未成功查询用户。");

            // 验证查询是否成功
            var findUser2 = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(session, userGroup, r => r.Id == user.Id);
            Assert.IsNotNull(findUser2, "未成功查询用户。");

            // 验证查询是否成功
            var findUser3 = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(session, userGroup, Builders<User>.Filter.Eq(r => r.Id, user.Id));
            Assert.IsNotNull(findUser3, "未成功查询用户。");


            // 删除用户
            var result = await dbContext.Users.Immediate.DynamicCollectionDeleteOneAsync(session, userGroup, addedUser);

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");


            session.CommitTransaction();
        }
    }

    [TestMethod]
    public void TestFindAll()
    {
        var users = DataHelper.GetNewUsers();

        dbContext.Users.Immediate.InsertMany(users);

        //验证查询是否成功
        var findUsers = dbContext.Users.Immediate.FindAll();
        Assert.AreEqual(6, findUsers.Count(), "未成功查询用户。");

        // 验证删除是否成功
        var deletedUser = dbContext.Users.Immediate.DeleteMany(users);
        Assert.AreEqual(6, deletedUser.Count(a => a.DeletedCount == 1), "用户未成功删除。");
    }

    [TestMethod]
    public async Task TestFindAllAsync()
    {
        var users = DataHelper.GetNewUsers();

        await dbContext.Users.Immediate.InsertManyAsync(users);

        //验证查询是否成功
        List<User> findUsers = new();
        await foreach (var user in dbContext.Users.Immediate.FindAllAsync())
        {
            findUsers.Add(user);
        }
        Assert.AreEqual(6, findUsers.Count(), "未成功查询用户。");

        // 验证删除是否成功
        var deletedUser = await dbContext.Users.Immediate.DeleteManyAsync(users);
        Assert.AreEqual(6, deletedUser.Count(a => a.DeletedCount == 1), "用户未成功删除。");
    }

    [TestMethod]
    public void TestFindAllSession()
    {
        var users = DataHelper.GetNewUsers();

        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            dbContext.Users.Immediate.InsertMany(session, users);

            //验证查询是否成功
            var findUsers = dbContext.Users.Immediate.FindAll(session);
            Assert.AreEqual(6, findUsers.Count(), "未成功查询用户。");

            // 验证删除是否成功
            var deletedUser = dbContext.Users.Immediate.DeleteMany(session, users);
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

            await dbContext.Users.Immediate.InsertManyAsync(session, users);

            //验证查询是否成功
            List<User> findUsers = new();
            await foreach (var user in dbContext.Users.Immediate.FindAllAsync(session))
            {
                findUsers.Add(user);
            }
            Assert.AreEqual(6, findUsers.Count(), "未成功查询用户。");

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.Immediate.DeleteManyAsync(session, users);
            Assert.AreEqual(6, deletedUser.Count(a => a.DeletedCount == 1), "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public void TestFindAllDynamic()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        var users = DataHelper.GetNewUsers();

        dbContext.Users.Immediate.DynamicCollectionInsertMany(userGroup, users);

        //验证查询是否成功
        var findUsers = dbContext.Users.Immediate.DynamicCollectionFindAll(userGroup);
        Assert.AreEqual(6, findUsers.Count(), "未成功查询用户。");

        // 验证删除是否成功
        var deletedUser = dbContext.Users.Immediate.DynamicCollectionDeleteMany(userGroup, users);
        Assert.AreEqual(6, deletedUser.Count(a => a.DeletedCount == 1), "用户未成功删除。");
    }

    [TestMethod]
    public async Task TestFindAllDynamicAsync()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        var users = DataHelper.GetNewUsers();

        await dbContext.Users.Immediate.DynamicCollectionInsertManyAsync(userGroup, users);

        //验证查询是否成功
        List<User> findUsers = new();
        await foreach (var user in dbContext.Users.Immediate.DynamicCollectionFindAllAsync(userGroup))
        {
            findUsers.Add(user);
        }
        Assert.AreEqual(6, findUsers.Count(), "未成功查询用户。");

        // 验证删除是否成功
        var deletedUser = await dbContext.Users.Immediate.DynamicCollectionDeleteManyAsync(userGroup, users);
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

            dbContext.Users.Immediate.DynamicCollectionInsertMany(session, userGroup, users);

            //验证查询是否成功
            var findUsers = dbContext.Users.Immediate.DynamicCollectionFindAll(session, userGroup);
            Assert.AreEqual(6, findUsers.Count(), "未成功查询用户。");

            // 验证删除是否成功
            var deletedUser = dbContext.Users.Immediate.DynamicCollectionDeleteMany(session, userGroup, users);
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

            await dbContext.Users.Immediate.DynamicCollectionInsertManyAsync(session, userGroup, users);

            //验证查询是否成功
            List<User> findUsers = new();
            await foreach (var user in dbContext.Users.Immediate.DynamicCollectionFindAllAsync(session, userGroup))
            {
                findUsers.Add(user);
            }
            Assert.AreEqual(6, findUsers.Count(), "未成功查询用户。");

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.Immediate.DynamicCollectionDeleteManyAsync(session, userGroup, users);
            Assert.AreEqual(6, deletedUser.Count(a => a.DeletedCount == 1), "用户未成功删除。");

            session.CommitTransaction();
        }
    }
}
