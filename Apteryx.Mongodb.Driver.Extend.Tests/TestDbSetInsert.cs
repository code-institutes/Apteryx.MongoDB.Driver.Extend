using MongoDB.Bson;
using Apteryx.Mongodb.Driver.Extend.Tests.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Apteryx.Mongodb.Driver.Extend.Tests;

[TestClass]
public class TestDbSetInsert : TestBase
{
    private readonly ApteryxDbContext? dbContext;

    private List<User> users = DataHelper.GetNewUsers();

    private User user = DataHelper.GetNewUser();

    [TestInitialize]
    public void TestInitialize()
    {
        // 确保 dbContext 不为 null
        Assert.IsNotNull(dbContext, "无法从服务提供程序获取ApteryxDbContext。"); ;
    }

    public TestDbSetInsert()
    {
        this.dbContext = ServiceProvider.GetService<ApteryxDbContext>();
    }

    /// <summary>
    /// 测试添加、查询、删除（同步方法）
    /// </summary>
    [TestMethod]
    public void TestAdd()
    {
        dbContext.Users.Commands.Insert(user);

        // 验证添加是否成功
        var addedUser = dbContext.Users.Commands.FindOne(user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 删除用户
        var result = dbContext.Users.Commands.DeleteOne(addedUser);

        // 验证删除是否成功
        var deletedUser = dbContext.Users.Commands.FindOne(user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    /// <summary>
    /// 测试动态添加、查询、删除（同步方法）
    /// </summary>
    [TestMethod]
    public void TestAddDynamic()
    {
        var userGroup = DataHelper.GetNewUserGroup();

        dbContext.Users.Commands.DynamicCollectionInsert(userGroup, user);

        // 验证添加是否成功
        var addedUser = dbContext.Users.Commands.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 删除用户
        dbContext.Users.Commands.DynamicCollectionDeleteOne(userGroup, addedUser);

        // 验证删除是否成功
        var deletedUser = dbContext.Users.Commands.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    /// <summary>
    /// 测试事务添加、查询、删除（同步方法）
    /// </summary>
    [TestMethod]
    public void TestAddSession()
    {
        // 创建一个新的 User 实例
        var newUser = new User { Id = ObjectId.GenerateNewId().ToString(), Name = "Test User" };

        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            dbContext.Users.Commands.Insert(session, newUser);

            // 验证添加是否成功
            var addedUser = dbContext.Users.Commands.FindOne(session, newUser.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 删除用户
            var result = dbContext.Users.Commands.DeleteOne(session, addedUser);

            // 验证删除是否成功
            var deletedUser = dbContext.Users.Commands.FindOne(session, newUser.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    /// <summary>
    /// 测试事务动态添加、查询、删除（同步方法）
    /// </summary>
    [TestMethod]
    public void TestAddDynamicSession()
    {
        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            var userGroup = DataHelper.GetNewUserGroup();

            dbContext.Users.Commands.DynamicCollectionInsert(session, userGroup, user);

            // 验证添加是否成功
            var addedUser = dbContext.Users.Commands.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 删除用户
            dbContext.Users.Commands.DynamicCollectionDeleteOne(session, userGroup, addedUser);

            // 验证删除是否成功
            var deletedUser = dbContext.Users.Commands.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");
        }
    }

    /// <summary>
    /// 测试添加、查询、删除（异步方法）
    /// </summary>
    /// <returns></returns>
    [TestMethod]
    public async Task TestAddAsync()
    {
        // 创建一个新的 User 实例
        var newUser = new User { Id = ObjectId.GenerateNewId().ToString(), Name = "Test User" };

        await dbContext.Users.Commands.InsertAsync(newUser);

        // 验证添加是否成功
        var addedUser = await dbContext.Users.Commands.FindOneAsync(newUser.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");

        // 删除用户
        var result = await dbContext.Users.Commands.DeleteOneAsync(addedUser);

        // 验证删除是否成功
        var deletedUser = await dbContext.Users.Commands.FindOneAsync(newUser.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    /// <summary>
    /// 测试动态添加、查询、删除（异步方法）
    /// </summary>
    /// <returns></returns>
    [TestMethod]
    public async Task TestAddDynamicAsync()
    {
        var userGroup = DataHelper.GetNewUserGroup();

        await dbContext.Users.Commands.DynamicCollectionInsertAsync(userGroup, user);

        // 验证添加是否成功
        var addedUser = dbContext.Users.Commands.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 删除用户
        dbContext.Users.Commands.DynamicCollectionDeleteOne(userGroup, addedUser);

        // 验证删除是否成功
        var deletedUser = dbContext.Users.Commands.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    /// <summary>
    /// 测试事务添加、查询、删除（异步方法）
    /// </summary>
    /// <returns></returns>
    [TestMethod]
    public async Task TestAddSessionAsync()
    {
        // 创建一个新的 User 实例
        var newUser = new User { Id = ObjectId.GenerateNewId().ToString(), Name = "Test User" };

        using (var session = await dbContext.Client.StartSessionAsync())
        {
            session.StartTransaction();

            await dbContext.Users.Commands.InsertAsync(session, newUser);

            // 验证添加是否成功
            var addedUser = await dbContext.Users.Commands.FindOneAsync(session, newUser.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");

            // 删除用户
            var result = await dbContext.Users.Commands.DeleteOneAsync(session, addedUser);

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.Commands.FindOneAsync(session, newUser.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    /// <summary>
    /// 测试事务动态添加、查询、删除（异步方法）
    /// </summary>
    /// <returns></returns>
    [TestMethod]
    public async Task TestAddDynamicSessionAsync()
    {
        using (var session = await dbContext.Client.StartSessionAsync())
        {
            session.StartTransaction();
            var userGroup = DataHelper.GetNewUserGroup();

            await dbContext.Users.Commands.DynamicCollectionInsertAsync(session, userGroup, user);

            // 验证添加是否成功
            var addedUser = await dbContext.Users.Commands.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 删除用户
            var result = await dbContext.Users.Commands.DynamicCollectionDeleteOneAsync(session, userGroup, addedUser);

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.Commands.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");
        }
    }

    /// <summary>
    /// 测试批量添加、查询、删除（同步方法）
    /// </summary>
    [TestMethod]
    public void TestAddMany()
    {
        dbContext.Users.Commands.InsertMany(users);

        // 验证添加是否成功
        var addedUserCount = dbContext.Users.Commands.Find(w => w.Email == "zhangfei@qq.com").CountDocuments();
        Assert.AreEqual(3, addedUserCount, "未成功添加，数量不正确");


        // 删除用户
        var result = dbContext.Users.Commands.DeleteMany(users);

        // 验证删除是否成功
        var deletedUserCount = dbContext.Users.Commands.Find(w => true).CountDocuments();
        Assert.AreEqual(0, deletedUserCount, "用户未成功删除。");
    }

    /// <summary>
    /// 测试动态批量添加、查询、删除（同步方法）
    /// </summary>
    [TestMethod]
    public void TestAddManyDynamic()
    {
        var userGroup = DataHelper.GetNewUserGroup();

        dbContext.Users.Commands.DynamicCollectionInsertMany(userGroup, users);

        // 验证添加是否成功
        var addedUserCount = dbContext.Users.Commands.DynamicCollectionFind(userGroup, w => w.Email == "zhangfei@qq.com").CountDocuments();
        Assert.AreEqual(3, addedUserCount, "未成功添加，数量不正确");


        // 删除用户
        dbContext.Users.Commands.DynamicCollectionDeleteMany(userGroup, users);

        // 验证删除是否成功
        var deletedUserCount = dbContext.Users.Commands.DynamicCollectionFind(userGroup, w => true).CountDocuments();
        Assert.AreEqual(0, deletedUserCount, "用户未成功删除。");
    }

    /// <summary>
    /// 测试事务批量添加、查询、删除（同步方法）
    /// </summary>
    [TestMethod]
    public void InsertManySession()
    {
        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            dbContext.Users.Commands.InsertMany(session, users);

            // 验证添加是否成功
            var addedUserCount = dbContext.Users.Commands.Find(session, w => w.Email == "zhangfei@qq.com").CountDocuments();

            Assert.IsNotNull(addedUserCount, "未成功添加用户。");

            Assert.AreEqual(3, addedUserCount, "未成功添加，数量不正确");


            // 删除用户
            var result = dbContext.Users.Commands.DeleteMany(session, users);

            // 验证删除是否成功
            var deletedUserCount = dbContext.Users.Commands.Find(session, w => true).CountDocuments();
            Assert.AreEqual(0, deletedUserCount, "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public void InsertManyDynamicSession()
    {
        var userGroup = DataHelper.GetNewUserGroup();

        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            dbContext.Users.Commands.DynamicCollectionDeleteMany(session, userGroup, d => d.Password == "123456");

            dbContext.Users.Commands.DynamicCollectionInsertMany(session, userGroup, users);

            // 验证添加是否成功
            var addedUserCount = dbContext.Users.Commands.DynamicCollectionFind(session, userGroup, w => w.Email == "zhangfei@qq.com").CountDocuments();
            Assert.AreEqual(3, addedUserCount, "未成功添加，数量不正确");


            // 删除用户
            dbContext.Users.Commands.DynamicCollectionDeleteMany(session, userGroup, users);

            // 验证删除是否成功
            var deletedUserCount = dbContext.Users.Commands.DynamicCollectionFind(session, userGroup, w => true).CountDocuments();
            Assert.AreEqual(0, deletedUserCount, "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    /// <summary>
    /// 测试批量添加、查询、删除（异步方法）
    /// </summary>
    /// <returns></returns>
    [TestMethod]
    public async Task TestAddManyAsync()
    {
        await dbContext.Users.Commands.InsertManyAsync(users);

        // 验证添加是否成功
        List<User> addedUser = new();
        await foreach (var user in dbContext.Users.Commands.FindAsync(w => w.Email == "zhangfei@qq.com"))
        {
            addedUser.Add(user);
        }
        Assert.AreEqual(3, addedUser.Count, "未成功添加，数量不正确");


        // 删除用户
        var result = await dbContext.Users.Commands.DeleteManyAsync(users);

        // 验证删除是否成功
        addedUser.Clear();
        await foreach (var user in dbContext.Users.Commands.FindAsync(w => true))
        {
            addedUser.Add(user);
        }
        Assert.AreEqual(0, addedUser.Count, "用户未成功删除。");
    }

    /// <summary>
    /// 测试动态批量添加、查询、删除（异步方法）
    /// </summary>
    /// <returns></returns>
    [TestMethod]
    public async Task TestAddManyDynamicAsync()
    {
        var userGroup = DataHelper.GetNewUserGroup();

        await dbContext.Users.Commands.DynamicCollectionInsertManyAsync(userGroup, users);

        // 验证添加是否成功
        List<User> addedUser = new();
        await foreach (var user in dbContext.Users.Commands.DynamicCollectionFindAsync(userGroup, w => w.Email == "zhangfei@qq.com"))
        {
            addedUser.Add(user);
        }
        Assert.AreEqual(3, addedUser.Count, "未成功添加，数量不正确");


        // 删除用户
        var result = await dbContext.Users.Commands.DynamicCollectionDeleteManyAsync(userGroup, users);

        // 验证删除是否成功
        addedUser.Clear();
        await foreach (var user in dbContext.Users.Commands.DynamicCollectionFindAsync(userGroup, w => true))
        {
            addedUser.Add(user);
        }
        Assert.AreEqual(0, addedUser.Count, "用户未成功删除。");
    }

    /// <summary>
    /// 测试事务批量添加、查询、删除（异步方法）
    /// </summary>
    /// <returns></returns>
    [TestMethod]
    public async Task TestAddManySessionAsync()
    {
        using (var session = await dbContext.Client.StartSessionAsync())
        {
            session.StartTransaction();

            await dbContext.Users.Commands.InsertManyAsync(session, users);

            // 验证添加是否成功
            List<User> addedUser = new();
            await foreach (var user in dbContext.Users.Commands.FindAsync(session, w => w.Email == "zhangfei@qq.com"))
            {
                addedUser.Add(user);
            }
            Assert.AreEqual(3, addedUser.Count, "未成功添加，数量不正确");


            // 删除用户
            var result = await dbContext.Users.Commands.DeleteManyAsync(session, users);

            // 验证删除是否成功
            addedUser.Clear();
            await foreach (var user in dbContext.Users.Commands.FindAsync(session, w => true))
            {
                addedUser.Add(user);
            }
            Assert.AreEqual(0, addedUser.Count, "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    /// <summary>
    /// 测试事务动态批量添加、查询、删除（异步方法）
    /// </summary>
    /// <returns></returns>
    [TestMethod]
    public async Task TestAddManyDynamicSessionAsync()
    {
        var userGroup = DataHelper.GetNewUserGroup();

        using (var session = await dbContext.Client.StartSessionAsync())
        {
            session.StartTransaction();

            await dbContext.Users.Commands.DynamicCollectionInsertManyAsync(session, userGroup, users);

            // 验证添加是否成功
            List<User> addedUser = new();
            await foreach (var user in dbContext.Users.Commands.DynamicCollectionFindAsync(session, userGroup, w => w.Email == "zhangfei@qq.com"))
            {
                addedUser.Add(user);
            }
            Assert.AreEqual(3, addedUser.Count, "未成功添加，数量不正确");

            // 删除用户
            var result = await dbContext.Users.Commands.DynamicCollectionDeleteManyAsync(session, userGroup, users);

            // 验证删除是否成功
            addedUser.Clear();
            await foreach (var user in dbContext.Users.Commands.DynamicCollectionFindAsync(session, userGroup, w => true))
            {
                addedUser.Add(user);
            }
            Assert.AreEqual(0, addedUser.Count, "用户未成功删除。");

            session.CommitTransaction();
        }
    }
}

