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

        dbContext.Users.Insert(user);

        // 验证添加是否成功
        var addedUser = dbContext.Users.FindOne(user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 验证查询是否成功
        var findUser1 = dbContext.Users.FindOne(user.Id);
        Assert.IsNotNull(findUser1, "未成功查询用户。");

        // 验证查询是否成功
        var findUser2 = dbContext.Users.FindOne(r => r.Id == user.Id);
        Assert.IsNotNull(findUser2, "未成功查询用户。");

        // 验证查询是否成功
        var findUser3 = dbContext.Users.FindOne(Builders<User>.Filter.Eq(r => r.Id, user.Id));
        Assert.IsNotNull(findUser3, "未成功查询用户。");


        // 删除用户
        var result = dbContext.Users.DeleteOne(addedUser);

        // 验证删除是否成功
        var deletedUser = dbContext.Users.FindOne(user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public async Task TestFindOneAsync()
    {
        var user = DataHelper.GetNewUser();

        await dbContext.Users.InsertAsync(user);

        // 验证添加是否成功
        var addedUser = await dbContext.Users.FindOneAsync(user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 验证查询是否成功
        var findUser1 = await dbContext.Users.FindOneAsync(user.Id);
        Assert.IsNotNull(findUser1, "未成功查询用户。");

        // 验证查询是否成功
        var findUser2 = await dbContext.Users.FindOneAsync(r => r.Id == user.Id);
        Assert.IsNotNull(findUser2, "未成功查询用户。");

        // 验证查询是否成功
        var findUser3 = await dbContext.Users.FindOneAsync(Builders<User>.Filter.Eq(r => r.Id, user.Id));
        Assert.IsNotNull(findUser3, "未成功查询用户。");


        // 删除用户
        var result = await dbContext.Users.DeleteOneAsync(addedUser);

        // 验证删除是否成功
        var deletedUser = await dbContext.Users.FindOneAsync(user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public void TestFindOneSession()
    {
        var user = DataHelper.GetNewUser();

        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            dbContext.Users.Insert(session, user);

            // 验证添加是否成功
            var addedUser = dbContext.Users.FindOne(session, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 验证查询是否成功
            var findUser1 = dbContext.Users.FindOne(session, user.Id);
            Assert.IsNotNull(findUser1, "未成功查询用户。");

            // 验证查询是否成功
            var findUser2 = dbContext.Users.FindOne(session, r => r.Id == user.Id);
            Assert.IsNotNull(findUser2, "未成功查询用户。");

            // 验证查询是否成功
            var findUser3 = dbContext.Users.FindOne(session, Builders<User>.Filter.Eq(r => r.Id, user.Id));
            Assert.IsNotNull(findUser3, "未成功查询用户。");


            // 删除用户
            var result = dbContext.Users.DeleteOne(session, addedUser);

            // 验证删除是否成功
            var deletedUser = dbContext.Users.FindOne(session, user.Id);
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

            await dbContext.Users.InsertAsync(session, user);

            // 验证添加是否成功
            var addedUser = await dbContext.Users.FindOneAsync(session, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 验证查询是否成功
            var findUser1 = await dbContext.Users.FindOneAsync(session, user.Id);
            Assert.IsNotNull(findUser1, "未成功查询用户。");

            // 验证查询是否成功
            var findUser2 = await dbContext.Users.FindOneAsync(session, r => r.Id == user.Id);
            Assert.IsNotNull(findUser2, "未成功查询用户。");

            // 验证查询是否成功
            var findUser3 = await dbContext.Users.FindOneAsync(session, Builders<User>.Filter.Eq(r => r.Id, user.Id));
            Assert.IsNotNull(findUser3, "未成功查询用户。");


            // 删除用户
            var result = await dbContext.Users.DeleteOneAsync(session, addedUser);

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.FindOneAsync(session, user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public void TestFindOneDynamic()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        var user = DataHelper.GetNewUser();

        dbContext.Users.DynamicCollectionInsert(userGroup, user);

        // 验证添加是否成功
        var addedUser = dbContext.Users.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 验证查询是否成功
        var findUser1 = dbContext.Users.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.IsNotNull(findUser1, "未成功查询用户。");

        // 验证查询是否成功
        var findUser2 = dbContext.Users.DynamicCollectionFindOne(userGroup, r => r.Id == user.Id);
        Assert.IsNotNull(findUser2, "未成功查询用户。");

        // 验证查询是否成功
        var findUser3 = dbContext.Users.DynamicCollectionFindOne(userGroup, Builders<User>.Filter.Eq(r => r.Id, user.Id));
        Assert.IsNotNull(findUser3, "未成功查询用户。");


        // 删除用户
        var result = dbContext.Users.DynamicCollectionDeleteOne(userGroup, addedUser);

        // 验证删除是否成功
        var deletedUser = dbContext.Users.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public async Task TestFindOneDynamicAsync()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        var user = DataHelper.GetNewUser();

        await dbContext.Users.DynamicCollectionInsertAsync(userGroup, user);

        // 验证添加是否成功
        var addedUser = await dbContext.Users.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 验证查询是否成功
        var findUser1 = await dbContext.Users.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.IsNotNull(findUser1, "未成功查询用户。");

        // 验证查询是否成功
        var findUser2 = await dbContext.Users.DynamicCollectionFindOneAsync(userGroup, r => r.Id == user.Id);
        Assert.IsNotNull(findUser2, "未成功查询用户。");

        // 验证查询是否成功
        var findUser3 = await dbContext.Users.DynamicCollectionFindOneAsync(userGroup, Builders<User>.Filter.Eq(r => r.Id, user.Id));
        Assert.IsNotNull(findUser3, "未成功查询用户。");


        // 删除用户
        var result = await dbContext.Users.DynamicCollectionDeleteOneAsync(userGroup, addedUser);

        // 验证删除是否成功
        var deletedUser = await dbContext.Users.DynamicCollectionFindOneAsync(userGroup, user.Id);
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

            dbContext.Users.DynamicCollectionInsert(session, userGroup, user);

            // 验证添加是否成功
            var addedUser = dbContext.Users.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 验证查询是否成功
            var findUser1 = dbContext.Users.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.IsNotNull(findUser1, "未成功查询用户。");

            // 验证查询是否成功
            var findUser2 = dbContext.Users.DynamicCollectionFindOne(session, userGroup, r => r.Id == user.Id);
            Assert.IsNotNull(findUser2, "未成功查询用户。");

            // 验证查询是否成功
            var findUser3 = dbContext.Users.DynamicCollectionFindOne(session, userGroup, Builders<User>.Filter.Eq(r => r.Id, user.Id));
            Assert.IsNotNull(findUser3, "未成功查询用户。");


            // 删除用户
            var result = dbContext.Users.DynamicCollectionDeleteOne(session, userGroup, addedUser);

            // 验证删除是否成功
            var deletedUser = dbContext.Users.DynamicCollectionFindOne(session, userGroup, user.Id);
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

            await dbContext.Users.DynamicCollectionInsertAsync(session, userGroup, user);

            // 验证添加是否成功
            var addedUser = await dbContext.Users.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 验证查询是否成功
            var findUser1 = await dbContext.Users.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.IsNotNull(findUser1, "未成功查询用户。");

            // 验证查询是否成功
            var findUser2 = await dbContext.Users.DynamicCollectionFindOneAsync(session, userGroup, r => r.Id == user.Id);
            Assert.IsNotNull(findUser2, "未成功查询用户。");

            // 验证查询是否成功
            var findUser3 = await dbContext.Users.DynamicCollectionFindOneAsync(session, userGroup, Builders<User>.Filter.Eq(r => r.Id, user.Id));
            Assert.IsNotNull(findUser3, "未成功查询用户。");


            // 删除用户
            var result = await dbContext.Users.DynamicCollectionDeleteOneAsync(session, userGroup, addedUser);

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");


            session.CommitTransaction();
        }
    }

    [TestMethod]
    public void TestFindAll()
    {
        var users = DataHelper.GetNewUsers();

        dbContext.Users.InsertMany(users);

        //验证查询是否成功
        var findUsers = dbContext.Users.FindAll();
        Assert.AreEqual(6, findUsers.Count(), "未成功查询用户。");

        // 验证删除是否成功
        var deletedUser = dbContext.Users.DeleteMany(users);
        Assert.AreEqual(6, deletedUser.Count(a => a.DeletedCount == 1), "用户未成功删除。");
    }

    [TestMethod]
    public async Task TestFindAllAsync()
    {
        var users = DataHelper.GetNewUsers();

        await dbContext.Users.InsertManyAsync(users);

        //验证查询是否成功
        List<User> findUsers = new();
        await foreach (var user in dbContext.Users.FindAllAsync())
        {
            findUsers.Add(user);
        }
        Assert.AreEqual(6, findUsers.Count(), "未成功查询用户。");

        // 验证删除是否成功
        var deletedUser = await dbContext.Users.DeleteManyAsync(users);
        Assert.AreEqual(6, deletedUser.Count(a => a.DeletedCount == 1), "用户未成功删除。");
    }

    [TestMethod]
    public void TestFindAllSession()
    {
        var users = DataHelper.GetNewUsers();

        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            dbContext.Users.InsertMany(session, users);

            //验证查询是否成功
            var findUsers = dbContext.Users.FindAll(session);
            Assert.AreEqual(6, findUsers.Count(), "未成功查询用户。");

            // 验证删除是否成功
            var deletedUser = dbContext.Users.DeleteMany(session, users);
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

            await dbContext.Users.InsertManyAsync(session, users);

            //验证查询是否成功
            List<User> findUsers = new();
            await foreach (var user in dbContext.Users.FindAllAsync(session))
            {
                findUsers.Add(user);
            }
            Assert.AreEqual(6, findUsers.Count(), "未成功查询用户。");

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.DeleteManyAsync(session, users);
            Assert.AreEqual(6, deletedUser.Count(a => a.DeletedCount == 1), "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public void TestFindAllDynamic()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        var users = DataHelper.GetNewUsers();

        dbContext.Users.DynamicCollectionInsertMany(userGroup, users);

        //验证查询是否成功
        var findUsers = dbContext.Users.DynamicCollectionFindAll(userGroup);
        Assert.AreEqual(6, findUsers.Count(), "未成功查询用户。");

        // 验证删除是否成功
        var deletedUser = dbContext.Users.DynamicCollectionDeleteMany(userGroup, users);
        Assert.AreEqual(6, deletedUser.Count(a => a.DeletedCount == 1), "用户未成功删除。");
    }

    [TestMethod]
    public async Task TestFindAllDynamicAsync()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        var users = DataHelper.GetNewUsers();

        await dbContext.Users.DynamicCollectionInsertManyAsync(userGroup, users);

        //验证查询是否成功
        List<User> findUsers = new();
        await foreach (var user in dbContext.Users.DynamicCollectionFindAllAsync(userGroup))
        {
            findUsers.Add(user);
        }
        Assert.AreEqual(6, findUsers.Count(), "未成功查询用户。");

        // 验证删除是否成功
        var deletedUser = await dbContext.Users.DynamicCollectionDeleteManyAsync(userGroup, users);
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

            dbContext.Users.DynamicCollectionInsertMany(session, userGroup, users);

            //验证查询是否成功
            var findUsers = dbContext.Users.DynamicCollectionFindAll(session, userGroup);
            Assert.AreEqual(6, findUsers.Count(), "未成功查询用户。");

            // 验证删除是否成功
            var deletedUser = dbContext.Users.DynamicCollectionDeleteMany(session, userGroup, users);
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

            await dbContext.Users.DynamicCollectionInsertManyAsync(session, userGroup, users);

            //验证查询是否成功
            List<User> findUsers = new();
            await foreach (var user in dbContext.Users.DynamicCollectionFindAllAsync(session, userGroup))
            {
                findUsers.Add(user);
            }
            Assert.AreEqual(6, findUsers.Count(), "未成功查询用户。");

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.DynamicCollectionDeleteManyAsync(session, userGroup, users);
            Assert.AreEqual(6, deletedUser.Count(a => a.DeletedCount == 1), "用户未成功删除。");

            session.CommitTransaction();
        }
    }
}
