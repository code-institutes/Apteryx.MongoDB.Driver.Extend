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
        dbContext.Users.Immediate.Insert(user);

        // 验证添加是否成功
        var addedUser = dbContext.Users.Immediate.FindOne(user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 删除用户
        var result = dbContext.Users.Immediate.DeleteOne(addedUser);

        // 验证删除是否成功
        var deletedUser = dbContext.Users.Immediate.FindOne(user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    /// <summary>
    /// 测试动态添加、查询、删除（同步方法）
    /// </summary>
    [TestMethod]
    public void TestAddDynamic()
    {
        var userGroup = DataHelper.GetNewUserGroup();

        dbContext.Users.Immediate.DynamicCollectionInsert(userGroup, user);

        // 验证添加是否成功
        var addedUser = dbContext.Users.Immediate.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 删除用户
        dbContext.Users.Immediate.DynamicCollectionDeleteOne(userGroup, addedUser);

        // 验证删除是否成功
        var deletedUser = dbContext.Users.Immediate.DynamicCollectionFindOne(userGroup, user.Id);
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

            dbContext.Users.Immediate.Insert(session, newUser);

            // 验证添加是否成功
            var addedUser = dbContext.Users.Immediate.FindOne(session, newUser.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 删除用户
            var result = dbContext.Users.Immediate.DeleteOne(session, addedUser);

            // 验证删除是否成功
            var deletedUser = dbContext.Users.Immediate.FindOne(session, newUser.Id);
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

            dbContext.Users.Immediate.DynamicCollectionInsert(session, userGroup, user);

            // 验证添加是否成功
            var addedUser = dbContext.Users.Immediate.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 删除用户
            dbContext.Users.Immediate.DynamicCollectionDeleteOne(session, userGroup, addedUser);

            // 验证删除是否成功
            var deletedUser = dbContext.Users.Immediate.DynamicCollectionFindOne(session, userGroup, user.Id);
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

        await dbContext.Users.Immediate.InsertAsync(newUser);

        // 验证添加是否成功
        var addedUser = await dbContext.Users.Immediate.FindOneAsync(newUser.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");

        // 删除用户
        var result = await dbContext.Users.Immediate.DeleteOneAsync(addedUser);

        // 验证删除是否成功
        var deletedUser = await dbContext.Users.Immediate.FindOneAsync(newUser.Id);
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

        await dbContext.Users.Immediate.DynamicCollectionInsertAsync(userGroup, user);

        // 验证添加是否成功
        var addedUser = dbContext.Users.Immediate.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 删除用户
        dbContext.Users.Immediate.DynamicCollectionDeleteOne(userGroup, addedUser);

        // 验证删除是否成功
        var deletedUser = dbContext.Users.Immediate.DynamicCollectionFindOne(userGroup, user.Id);
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

            await dbContext.Users.Immediate.InsertAsync(session, newUser);

            // 验证添加是否成功
            var addedUser = await dbContext.Users.Immediate.FindOneAsync(session, newUser.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");

            // 删除用户
            var result = await dbContext.Users.Immediate.DeleteOneAsync(session, addedUser);

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.Immediate.FindOneAsync(session, newUser.Id);
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

            await dbContext.Users.Immediate.DynamicCollectionInsertAsync(session, userGroup, user);

            // 验证添加是否成功
            var addedUser = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 删除用户
            var result = await dbContext.Users.Immediate.DynamicCollectionDeleteOneAsync(session, userGroup, addedUser);

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");
        }
    }

    /// <summary>
    /// 测试批量添加、查询、删除（同步方法）
    /// </summary>
    [TestMethod]
    public void TestAddMany()
    {
        dbContext.Users.Immediate.InsertMany(users);

        // 验证添加是否成功
        var addedUserCount = dbContext.Users.Immediate.Find(w => w.Email == "zhangfei@qq.com").CountDocuments();
        Assert.AreEqual(3, addedUserCount, "未成功添加，数量不正确");


        // 删除用户
        var result = dbContext.Users.Immediate.DeleteMany(users);

        // 验证删除是否成功
        var deletedUserCount = dbContext.Users.Immediate.Find(w => true).CountDocuments();
        Assert.AreEqual(0, deletedUserCount, "用户未成功删除。");
    }

    /// <summary>
    /// 测试动态批量添加、查询、删除（同步方法）
    /// </summary>
    [TestMethod]
    public void TestAddManyDynamic()
    {
        var userGroup = DataHelper.GetNewUserGroup();

        dbContext.Users.Immediate.DynamicCollectionInsertMany(userGroup, users);

        // 验证添加是否成功
        var addedUserCount = dbContext.Users.Immediate.DynamicCollectionFind(userGroup, w => w.Email == "zhangfei@qq.com").CountDocuments();
        Assert.AreEqual(3, addedUserCount, "未成功添加，数量不正确");


        // 删除用户
        dbContext.Users.Immediate.DynamicCollectionDeleteMany(userGroup, users);

        // 验证删除是否成功
        var deletedUserCount = dbContext.Users.Immediate.DynamicCollectionFind(userGroup, w => true).CountDocuments();
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

            dbContext.Users.Immediate.InsertMany(session, users);

            // 验证添加是否成功
            var addedUserCount = dbContext.Users.Immediate.Find(session, w => w.Email == "zhangfei@qq.com").CountDocuments();

            Assert.IsNotNull(addedUserCount, "未成功添加用户。");

            Assert.AreEqual(3, addedUserCount, "未成功添加，数量不正确");


            // 删除用户
            var result = dbContext.Users.Immediate.DeleteMany(session, users);

            // 验证删除是否成功
            var deletedUserCount = dbContext.Users.Immediate.Find(session, w => true).CountDocuments();
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

            dbContext.Users.Immediate.DynamicCollectionDeleteMany(session, userGroup, d => d.Password == "123456");

            dbContext.Users.Immediate.DynamicCollectionInsertMany(session, userGroup, users);

            // 验证添加是否成功
            var addedUserCount = dbContext.Users.Immediate.DynamicCollectionFind(session, userGroup, w => w.Email == "zhangfei@qq.com").CountDocuments();
            Assert.AreEqual(3, addedUserCount, "未成功添加，数量不正确");


            // 删除用户
            dbContext.Users.Immediate.DynamicCollectionDeleteMany(session, userGroup, users);

            // 验证删除是否成功
            var deletedUserCount = dbContext.Users.Immediate.DynamicCollectionFind(session, userGroup, w => true).CountDocuments();
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
        await dbContext.Users.Immediate.InsertManyAsync(users);

        // 验证添加是否成功
        List<User> addedUser = new();
        await foreach (var user in dbContext.Users.Immediate.FindAsync(w => w.Email == "zhangfei@qq.com"))
        {
            addedUser.Add(user);
        }
        Assert.AreEqual(3, addedUser.Count, "未成功添加，数量不正确");


        // 删除用户
        var result = await dbContext.Users.Immediate.DeleteManyAsync(users);

        // 验证删除是否成功
        addedUser.Clear();
        await foreach (var user in dbContext.Users.Immediate.FindAsync(w => true))
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

        await dbContext.Users.Immediate.DynamicCollectionInsertManyAsync(userGroup, users);

        // 验证添加是否成功
        List<User> addedUser = new();
        await foreach (var user in dbContext.Users.Immediate.DynamicCollectionFindAsync(userGroup, w => w.Email == "zhangfei@qq.com"))
        {
            addedUser.Add(user);
        }
        Assert.AreEqual(3, addedUser.Count, "未成功添加，数量不正确");


        // 删除用户
        var result = await dbContext.Users.Immediate.DynamicCollectionDeleteManyAsync(userGroup, users);

        // 验证删除是否成功
        addedUser.Clear();
        await foreach (var user in dbContext.Users.Immediate.DynamicCollectionFindAsync(userGroup, w => true))
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

            await dbContext.Users.Immediate.InsertManyAsync(session, users);

            // 验证添加是否成功
            List<User> addedUser = new();
            await foreach (var user in dbContext.Users.Immediate.FindAsync(session, w => w.Email == "zhangfei@qq.com"))
            {
                addedUser.Add(user);
            }
            Assert.AreEqual(3, addedUser.Count, "未成功添加，数量不正确");


            // 删除用户
            var result = await dbContext.Users.Immediate.DeleteManyAsync(session, users);

            // 验证删除是否成功
            addedUser.Clear();
            await foreach (var user in dbContext.Users.Immediate.FindAsync(session, w => true))
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

            await dbContext.Users.Immediate.DynamicCollectionInsertManyAsync(session, userGroup, users);

            // 验证添加是否成功
            List<User> addedUser = new();
            await foreach (var user in dbContext.Users.Immediate.DynamicCollectionFindAsync(session, userGroup, w => w.Email == "zhangfei@qq.com"))
            {
                addedUser.Add(user);
            }
            Assert.AreEqual(3, addedUser.Count, "未成功添加，数量不正确");

            // 删除用户
            var result = await dbContext.Users.Immediate.DynamicCollectionDeleteManyAsync(session, userGroup, users);

            // 验证删除是否成功
            addedUser.Clear();
            await foreach (var user in dbContext.Users.Immediate.DynamicCollectionFindAsync(session, userGroup, w => true))
            {
                addedUser.Add(user);
            }
            Assert.AreEqual(0, addedUser.Count, "用户未成功删除。");

            session.CommitTransaction();
        }
    }
}

