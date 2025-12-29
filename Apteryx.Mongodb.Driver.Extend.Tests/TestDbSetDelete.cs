using MongoDB.Driver;
using Apteryx.Mongodb.Driver.Extend.Tests.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Apteryx.Mongodb.Driver.Extend.Tests;

[TestClass]
public class TestDbSetDelete : TestBase
{
    private readonly ApteryxDbContext? dbContext;

    [TestInitialize]
    public void TestInitialize()
    {
        // 确保 dbContext 不为 null
        Assert.IsNotNull(dbContext, "无法从服务提供程序获取ApteryxDbContext。"); ;
    }

    public TestDbSetDelete()
    {
        this.dbContext = ServiceProvider.GetService<ApteryxDbContext>();
    }

    [TestMethod]
    public void TestDeleteOne()
    {
        var users = DataHelper.GetNewUsers();

        dbContext.Users.Immediate.InsertMany(users);

        // 删除用户
        var result1 = dbContext.Users.Immediate.DeleteOne(users[0]);
        Assert.AreEqual(true, result1.IsAcknowledged, "用户1，未成功删除。");

        // 删除用户
        var result2 = dbContext.Users.Immediate.DeleteOne(users[1].Id);
        Assert.AreEqual(true, result2.IsAcknowledged, "用户2，未成功删除。");

        // 删除用户
        var result3 = dbContext.Users.Immediate.DeleteOne(d => d.Id == users[2].Id);
        Assert.AreEqual(true, result3.IsAcknowledged, "用户3，未成功删除。");

        // 删除用户
        var result4 = dbContext.Users.Immediate.DeleteOne(Builders<User>.Filter.Eq(f => f.Id, users[3].Id));
        Assert.AreEqual(true, result4.IsAcknowledged, "用户4，未成功删除。");

        // 验证删除是否成功
        var deletedUser = dbContext.Users.Immediate.DeleteMany(users);
        Assert.AreEqual(2, deletedUser.Count(a => a.DeletedCount == 1), "用户未成功删除。");
    }

    [TestMethod]
    public async Task TestDeleteOneAsync()
    {
        var users = DataHelper.GetNewUsers();

        await dbContext.Users.Immediate.InsertManyAsync(users);

        // 删除用户
        var result1 = await dbContext.Users.Immediate.DeleteOneAsync(users[0]);
        Assert.AreEqual(true, result1.IsAcknowledged, "用户1，未成功删除。");

        // 删除用户
        var result2 = await dbContext.Users.Immediate.DeleteOneAsync(users[1].Id);
        Assert.AreEqual(true, result2.IsAcknowledged, "用户2，未成功删除。");

        // 删除用户
        var result3 = await dbContext.Users.Immediate.DeleteOneAsync(d => d.Id == users[2].Id);
        Assert.AreEqual(true, result3.IsAcknowledged, "用户3，未成功删除。");

        // 删除用户
        var result4 = await dbContext.Users.Immediate.DeleteOneAsync(Builders<User>.Filter.Eq(f => f.Id, users[3].Id));
        Assert.AreEqual(true, result4.IsAcknowledged, "用户4，未成功删除。");

        // 验证删除是否成功
        var deletedUser = await dbContext.Users.Immediate.DeleteManyAsync(users);
        Assert.AreEqual(2, deletedUser.Count(a => a.DeletedCount == 1), "用户未成功删除。");
    }

    [TestMethod]
    public void TestDeleteOneSession()
    {
        var users = DataHelper.GetNewUsers();

        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            dbContext.Users.Immediate.InsertMany(session, users);

            // 删除用户
            var result1 = dbContext.Users.Immediate.DeleteOne(session, users[0]);
            Assert.AreEqual(true, result1.IsAcknowledged, "用户1，未成功删除。");

            // 删除用户
            var result2 = dbContext.Users.Immediate.DeleteOne(session, users[1].Id);
            Assert.AreEqual(true, result2.IsAcknowledged, "用户2，未成功删除。");

            // 删除用户
            var result3 = dbContext.Users.Immediate.DeleteOne(session, d => d.Id == users[2].Id);
            Assert.AreEqual(true, result3.IsAcknowledged, "用户3，未成功删除。");

            // 删除用户
            var result4 = dbContext.Users.Immediate.DeleteOne(session, Builders<User>.Filter.Eq(f => f.Id, users[3].Id));
            Assert.AreEqual(true, result4.IsAcknowledged, "用户4，未成功删除。");

            // 验证删除是否成功
            var deletedUser = dbContext.Users.Immediate.DeleteMany(session, users);
            Assert.AreEqual(2, deletedUser.Count(a => a.DeletedCount == 1), "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public async Task TestDeleteOneSessionAsync()
    {
        var users = DataHelper.GetNewUsers();

        using (var session = await dbContext.Client.StartSessionAsync())
        {
            session.StartTransaction();

            await dbContext.Users.Immediate.InsertManyAsync(session, users);

            // 删除用户
            var result1 = await dbContext.Users.Immediate.DeleteOneAsync(session, users[0]);
            Assert.AreEqual(true, result1.IsAcknowledged, "用户1，未成功删除。");

            // 删除用户
            var result2 = await dbContext.Users.Immediate.DeleteOneAsync(session, users[1].Id);
            Assert.AreEqual(true, result2.IsAcknowledged, "用户2，未成功删除。");

            // 删除用户
            var result3 = await dbContext.Users.Immediate.DeleteOneAsync(session, d => d.Id == users[2].Id);
            Assert.AreEqual(true, result3.IsAcknowledged, "用户3，未成功删除。");

            // 删除用户
            var result4 = await dbContext.Users.Immediate.DeleteOneAsync(session, Builders<User>.Filter.Eq(f => f.Id, users[3].Id));
            Assert.AreEqual(true, result4.IsAcknowledged, "用户4，未成功删除。");

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.Immediate.DeleteManyAsync(session, users);
            Assert.AreEqual(2, deletedUser.Count(a => a.DeletedCount == 1), "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public void TestDeleteOneDynamic()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        var users = DataHelper.GetNewUsers();

        dbContext.Users.Immediate.DynamicCollectionInsertMany(userGroup, users);

        // 删除用户
        var result1 = dbContext.Users.Immediate.DynamicCollectionDeleteOne(userGroup, users[0]);
        Assert.AreEqual(true, result1.IsAcknowledged, "用户1，未成功删除。");

        // 删除用户
        var result2 = dbContext.Users.Immediate.DynamicCollectionDeleteOne(userGroup, users[1].Id);
        Assert.AreEqual(true, result2.IsAcknowledged, "用户2，未成功删除。");

        // 删除用户
        var result3 = dbContext.Users.Immediate.DynamicCollectionDeleteOne(userGroup, d => d.Id == users[2].Id);
        Assert.AreEqual(true, result3.IsAcknowledged, "用户3，未成功删除。");

        // 删除用户
        var result4 = dbContext.Users.Immediate.DynamicCollectionDeleteOne(userGroup, Builders<User>.Filter.Eq(f => f.Id, users[3].Id));
        Assert.AreEqual(true, result4.IsAcknowledged, "用户4，未成功删除。");

        // 验证删除是否成功
        var deletedUser = dbContext.Users.Immediate.DynamicCollectionDeleteMany(userGroup, users);
        Assert.AreEqual(2, deletedUser.Count(a => a.DeletedCount == 1), "用户未成功删除。");
    }

    [TestMethod]
    public async Task TestDeleteOneDynamicAsync()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        var users = DataHelper.GetNewUsers();

        await dbContext.Users.Immediate.DynamicCollectionInsertManyAsync(userGroup, users);

        // 删除用户
        var result1 = await dbContext.Users.Immediate.DynamicCollectionDeleteOneAsync(userGroup, users[0]);
        Assert.AreEqual(true, result1.IsAcknowledged, "用户1，未成功删除。");

        // 删除用户
        var result2 = await dbContext.Users.Immediate.DynamicCollectionDeleteOneAsync(userGroup, users[1].Id);
        Assert.AreEqual(true, result2.IsAcknowledged, "用户2，未成功删除。");

        // 删除用户
        var result3 = await dbContext.Users.Immediate.DynamicCollectionDeleteOneAsync(userGroup, d => d.Id == users[2].Id);
        Assert.AreEqual(true, result3.IsAcknowledged, "用户3，未成功删除。");

        // 删除用户
        var result4 = await dbContext.Users.Immediate.DynamicCollectionDeleteOneAsync(userGroup, Builders<User>.Filter.Eq(f => f.Id, users[3].Id));
        Assert.AreEqual(true, result4.IsAcknowledged, "用户4，未成功删除。");

        // 验证删除是否成功
        var deletedUser = await dbContext.Users.Immediate.DynamicCollectionDeleteManyAsync(userGroup, users);
        Assert.AreEqual(2, deletedUser.Count(a => a.DeletedCount == 1), "用户未成功删除。");
    }

    [TestMethod]
    public void TestDeleteOneDynamicSession()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        var users = DataHelper.GetNewUsers();

        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            dbContext.Users.Immediate.DynamicCollectionInsertMany(session, userGroup, users);

            // 删除用户
            var result1 = dbContext.Users.Immediate.DynamicCollectionDeleteOne(session, userGroup, users[0]);
            Assert.AreEqual(true, result1.IsAcknowledged, "用户1，未成功删除。");

            // 删除用户
            var result2 = dbContext.Users.Immediate.DynamicCollectionDeleteOne(session, userGroup, users[1].Id);
            Assert.AreEqual(true, result2.IsAcknowledged, "用户2，未成功删除。");

            // 删除用户
            var result3 = dbContext.Users.Immediate.DynamicCollectionDeleteOne(session, userGroup, d => d.Id == users[2].Id);
            Assert.AreEqual(true, result3.IsAcknowledged, "用户3，未成功删除。");

            // 删除用户
            var result4 = dbContext.Users.Immediate.DynamicCollectionDeleteOne(session, userGroup, Builders<User>.Filter.Eq(f => f.Id, users[3].Id));
            Assert.AreEqual(true, result4.IsAcknowledged, "用户4，未成功删除。");

            // 验证删除是否成功
            var deletedUser = dbContext.Users.Immediate.DynamicCollectionDeleteMany(session, userGroup, users);
            Assert.AreEqual(2, deletedUser.Count(a => a.DeletedCount == 1), "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public async Task TestDeleteOneDynamicSessionAsync()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        var users = DataHelper.GetNewUsers();

        using (var session = await dbContext.Client.StartSessionAsync())
        {
            session.StartTransaction();

            await dbContext.Users.Immediate.DynamicCollectionInsertManyAsync(session, userGroup, users);

            // 删除用户
            var result1 = await dbContext.Users.Immediate.DynamicCollectionDeleteOneAsync(session, userGroup, users[0]);
            Assert.AreEqual(true, result1.IsAcknowledged, "用户1，未成功删除。");

            // 删除用户
            var result2 = await dbContext.Users.Immediate.DynamicCollectionDeleteOneAsync(session, userGroup, users[1].Id);
            Assert.AreEqual(true, result2.IsAcknowledged, "用户2，未成功删除。");

            // 删除用户
            var result3 = await dbContext.Users.Immediate.DynamicCollectionDeleteOneAsync(session, userGroup, d => d.Id == users[2].Id);
            Assert.AreEqual(true, result3.IsAcknowledged, "用户3，未成功删除。");

            // 删除用户
            var result4 = await dbContext.Users.Immediate.DynamicCollectionDeleteOneAsync(session, userGroup, Builders<User>.Filter.Eq(f => f.Id, users[3].Id));
            Assert.AreEqual(true, result4.IsAcknowledged, "用户4，未成功删除。");

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.Immediate.DynamicCollectionDeleteManyAsync(session, userGroup, users);
            Assert.AreEqual(2, deletedUser.Count(a => a.DeletedCount == 1), "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public void TestFindOneAndDeleteOne()
    {
        var users = DataHelper.GetNewUsers();

        dbContext.Users.Immediate.InsertMany(users);

        // 删除用户
        var result1 = dbContext.Users.Immediate.FindOneAndDelete(users[0].Id);
        Assert.IsNotNull(result1, "用户1，未成功删除。");

        // 删除用户
        var result2 = dbContext.Users.Immediate.FindOneAndDelete(d => d.Id == users[1].Id);
        Assert.IsNotNull(result2, "用户2，未成功删除。");

        // 删除用户
        var result3 = dbContext.Users.Immediate.FindOneAndDelete(Builders<User>.Filter.Eq(f => f.Id, users[2].Id));
        Assert.IsNotNull(result3, "用户3，未成功删除。");

        var deletedUser = dbContext.Users.Immediate.DeleteMany(users);
    }

    [TestMethod]
    public async Task TestFindOneAndDeleteOneAsync()
    {
        var users = DataHelper.GetNewUsers();

        await dbContext.Users.Immediate.InsertManyAsync(users);

        // 删除用户
        var result1 = await dbContext.Users.Immediate.FindOneAndDeleteAsync(users[0].Id);
        Assert.IsNotNull(result1, "用户1，未成功删除。");

        // 删除用户
        var result2 = await dbContext.Users.Immediate.FindOneAndDeleteAsync(d => d.Id == users[1].Id);
        Assert.IsNotNull(result2, "用户2，未成功删除。");

        // 删除用户
        var result3 = await dbContext.Users.Immediate.FindOneAndDeleteAsync(Builders<User>.Filter.Eq(f => f.Id, users[2].Id));
        Assert.IsNotNull(result3, "用户3，未成功删除。");

        var deletedUser = dbContext.Users.Immediate.DeleteMany(users);
    }

    [TestMethod]
    public void TestFindOneAndDeleteOneSession()
    {
        var users = DataHelper.GetNewUsers();

        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            dbContext.Users.Immediate.InsertMany(session, users);

            // 删除用户
            var result1 = dbContext.Users.Immediate.FindOneAndDelete(session, users[0].Id);
            Assert.IsNotNull(result1, "用户1，未成功删除。");

            // 删除用户
            var result2 = dbContext.Users.Immediate.FindOneAndDelete(session, d => d.Id == users[1].Id);
            Assert.IsNotNull(result2, "用户2，未成功删除。");

            // 删除用户
            var result3 = dbContext.Users.Immediate.FindOneAndDelete(session, Builders<User>.Filter.Eq(f => f.Id, users[2].Id));
            Assert.IsNotNull(result3, "用户3，未成功删除。");

            var deletedUser = dbContext.Users.Immediate.DeleteMany(session, users);

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public async Task TestFindOneAndDeleteOneSessionAsync()
    {
        var users = DataHelper.GetNewUsers();

        using (var session = await dbContext.Client.StartSessionAsync())
        {
            session.StartTransaction();

            await dbContext.Users.Immediate.InsertManyAsync(session, users);

            // 删除用户
            var result1 = await dbContext.Users.Immediate.FindOneAndDeleteAsync(session, users[0].Id);
            Assert.IsNotNull(result1, "用户1，未成功删除。");

            // 删除用户
            var result2 = await dbContext.Users.Immediate.FindOneAndDeleteAsync(session, d => d.Id == users[1].Id);
            Assert.IsNotNull(result2, "用户2，未成功删除。");

            // 删除用户
            var result3 = await dbContext.Users.Immediate.FindOneAndDeleteAsync(session, Builders<User>.Filter.Eq(f => f.Id, users[2].Id));
            Assert.IsNotNull(result3, "用户3，未成功删除。");

            var deletedUser = dbContext.Users.Immediate.DeleteMany(session, users);

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public void TestFindOneAndDeleteOneDynamic()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        var users = DataHelper.GetNewUsers();

        dbContext.Users.Immediate.DynamicCollectionInsertMany(userGroup, users);

        // 删除用户
        var result1 = dbContext.Users.Immediate.DynamicCollectionFindOneAndDelete(userGroup, users[0].Id);
        Assert.IsNotNull(result1, "用户1，未成功删除。");

        // 删除用户
        var result2 = dbContext.Users.Immediate.DynamicCollectionFindOneAndDelete(userGroup, d => d.Id == users[1].Id);
        Assert.IsNotNull(result2, "用户2，未成功删除。");

        // 删除用户
        var result3 = dbContext.Users.Immediate.DynamicCollectionFindOneAndDelete(userGroup, Builders<User>.Filter.Eq(f => f.Id, users[2].Id));
        Assert.IsNotNull(result3, "用户3，未成功删除。");

        var deletedUser = dbContext.Users.Immediate.DynamicCollectionDeleteMany(userGroup, users);
    }

    [TestMethod]
    public async Task TestFindOneAndDeleteOneDynamicAsync()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        var users = DataHelper.GetNewUsers();

        await dbContext.Users.Immediate.DynamicCollectionInsertManyAsync(userGroup, users);

        // 删除用户
        var result1 = await dbContext.Users.Immediate.DynamicCollectionFindOneAndDeleteAsync(userGroup, users[0].Id);
        Assert.IsNotNull(result1, "用户1，未成功删除。");

        // 删除用户
        var result2 = await dbContext.Users.Immediate.DynamicCollectionFindOneAndDeleteAsync(userGroup, d => d.Id == users[1].Id);
        Assert.IsNotNull(result2, "用户2，未成功删除。");

        // 删除用户
        var result3 = await dbContext.Users.Immediate.DynamicCollectionFindOneAndDeleteAsync(userGroup, Builders<User>.Filter.Eq(f => f.Id, users[2].Id));
        Assert.IsNotNull(result3, "用户3，未成功删除。");

        var deletedUser = await dbContext.Users.Immediate.DynamicCollectionDeleteManyAsync(userGroup, users);
    }

    [TestMethod]
    public void TestFindOneAndDeleteOneDynamicSession()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        var users = DataHelper.GetNewUsers();

        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            dbContext.Users.Immediate.DynamicCollectionInsertMany(session, userGroup, users);

            // 删除用户
            var result1 = dbContext.Users.Immediate.DynamicCollectionFindOneAndDelete(session, userGroup, users[0].Id);
            Assert.IsNotNull(result1, "用户1，未成功删除。");

            // 删除用户
            var result2 = dbContext.Users.Immediate.DynamicCollectionFindOneAndDelete(session, userGroup, d => d.Id == users[1].Id);
            Assert.IsNotNull(result2, "用户2，未成功删除。");

            // 删除用户
            var result3 = dbContext.Users.Immediate.DynamicCollectionFindOneAndDelete(session, userGroup, Builders<User>.Filter.Eq(f => f.Id, users[2].Id));
            Assert.IsNotNull(result3, "用户3，未成功删除。");

            var deletedUser = dbContext.Users.Immediate.DynamicCollectionDeleteMany(session, userGroup, users);

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public async Task TestFindOneAndDeleteOneDynamicSessionAsync()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        var users = DataHelper.GetNewUsers();

        using (var session = await dbContext.Client.StartSessionAsync())
        {
            session.StartTransaction();

            await dbContext.Users.Immediate.DynamicCollectionInsertManyAsync(session, userGroup, users);

            // 删除用户
            var result1 = await dbContext.Users.Immediate.DynamicCollectionFindOneAndDeleteAsync(session, userGroup, users[0].Id);
            Assert.IsNotNull(result1, "用户1，未成功删除。");

            // 删除用户
            var result2 = await dbContext.Users.Immediate.DynamicCollectionFindOneAndDeleteAsync(session, userGroup, d => d.Id == users[1].Id);
            Assert.IsNotNull(result2, "用户2，未成功删除。");

            // 删除用户
            var result3 = await dbContext.Users.Immediate.DynamicCollectionFindOneAndDeleteAsync(session, userGroup, Builders<User>.Filter.Eq(f => f.Id, users[2].Id));
            Assert.IsNotNull(result3, "用户3，未成功删除。");

            var deletedUser = await dbContext.Users.Immediate.DynamicCollectionDeleteManyAsync(session, userGroup, users);

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public void TestDeleteMany()
    {
        var users1 = DataHelper.GetNewUsers();
        var users2 = DataHelper.GetNewUsers();
        var users3 = DataHelper.GetNewUsers();

        //添加用户
        dbContext.Users.Immediate.InsertMany(users1);
        // 验证删除是否成功
        var deletedUser1 = dbContext.Users.Immediate.DeleteMany(users1);
        Assert.AreEqual(6, deletedUser1.Count(a => a.DeletedCount == 1), "用户1，未成功删除。");

        //添加用户
        dbContext.Users.Immediate.InsertMany(users2);
        // 验证删除是否成功
        var deletedUser2 = dbContext.Users.Immediate.DeleteMany(Builders<User>.Filter.Eq(f => f.Password, "123456"));
        Assert.AreEqual(6, deletedUser2.DeletedCount, "用户2，未成功删除。");

        //添加用户
        dbContext.Users.Immediate.InsertMany(users3);
        // 验证删除是否成功
        var deletedUser3 = dbContext.Users.Immediate.DeleteMany(d => d.Password == "123456");
        Assert.AreEqual(6, deletedUser3.DeletedCount, "用户3，未成功删除。");
    }

    [TestMethod]
    public async Task TestDeleteManyAsync()
    {
        var users1 = DataHelper.GetNewUsers();
        var users2 = DataHelper.GetNewUsers();
        var users3 = DataHelper.GetNewUsers();

        //添加用户
        await dbContext.Users.Immediate.InsertManyAsync(users1);
        // 验证删除是否成功
        var deletedUser1 = await dbContext.Users.Immediate.DeleteManyAsync(users1);
        Assert.AreEqual(6, deletedUser1.Count(a => a.DeletedCount == 1), "用户1，未成功删除。");

        //添加用户
        await dbContext.Users.Immediate.InsertManyAsync(users2);
        // 验证删除是否成功
        var deletedUser2 = await dbContext.Users.Immediate.DeleteManyAsync(Builders<User>.Filter.Eq(f => f.Password, "123456"));
        Assert.AreEqual(6, deletedUser2.DeletedCount, "用户2，未成功删除。");

        //添加用户
        await dbContext.Users.Immediate.InsertManyAsync(users3);
        // 验证删除是否成功
        var deletedUser3 = await dbContext.Users.Immediate.DeleteManyAsync(d => d.Password == "123456");
        Assert.AreEqual(6, deletedUser3.DeletedCount, "用户3，未成功删除。");
    }

    [TestMethod]
    public void TestDeleteManySession()
    {
        var pwd1 = Guid.NewGuid().ToString();
        var pwd2 = Guid.NewGuid().ToString();
        var pwd3 = Guid.NewGuid().ToString();

        var users1 = DataHelper.GetNewUsers(pwd1);
        var users2 = DataHelper.GetNewUsers(pwd2);
        var users3 = DataHelper.GetNewUsers(pwd3);

        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            //添加用户
            dbContext.Users.Immediate.InsertMany(session, users1);
            // 验证删除是否成功
            var deletedUser1 = dbContext.Users.Immediate.DeleteMany(session, users1);
            Assert.AreEqual(6, deletedUser1.Count(a => a.DeletedCount == 1), "用户1，未成功删除。");

            //添加用户
            dbContext.Users.Immediate.InsertMany(session, users2);
            // 验证删除是否成功
            var deletedUser2 = dbContext.Users.Immediate.DeleteMany(session, Builders<User>.Filter.Eq(f => f.Password, pwd2));
            Assert.AreEqual(6, deletedUser2.DeletedCount, "用户2，未成功删除。");

            //添加用户
            dbContext.Users.Immediate.InsertMany(session, users3);
            // 验证删除是否成功
            var deletedUser3 = dbContext.Users.Immediate.DeleteMany(session, d => d.Password == pwd3);
            Assert.AreEqual(6, deletedUser3.DeletedCount, "用户3，未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public async Task TestDeleteManySessionAsync()
    {
        var pwd1 = Guid.NewGuid().ToString();
        var pwd2 = Guid.NewGuid().ToString();
        var pwd3 = Guid.NewGuid().ToString();

        var users1 = DataHelper.GetNewUsers(pwd1);
        var users2 = DataHelper.GetNewUsers(pwd2);
        var users3 = DataHelper.GetNewUsers(pwd3);

        using (var session = await dbContext.Client.StartSessionAsync())
        {
            session.StartTransaction();

            //添加用户
            await dbContext.Users.Immediate.InsertManyAsync(session, users1);
            // 验证删除是否成功
            var deletedUser1 = await dbContext.Users.Immediate.DeleteManyAsync(session, users1);
            Assert.AreEqual(6, deletedUser1.Count(a => a.DeletedCount == 1), "用户1，未成功删除。");

            //添加用户
            await dbContext.Users.Immediate.InsertManyAsync(session, users2);
            // 验证删除是否成功
            var deletedUser2 = await dbContext.Users.Immediate.DeleteManyAsync(session, Builders<User>.Filter.Eq(f => f.Password, pwd2));
            Assert.AreEqual(6, deletedUser2.DeletedCount, "用户2，未成功删除。");

            //添加用户
            await dbContext.Users.Immediate.InsertManyAsync(session, users3);
            // 验证删除是否成功
            var deletedUser3 = await dbContext.Users.Immediate.DeleteManyAsync(session, d => d.Password == pwd3);
            Assert.AreEqual(6, deletedUser3.DeletedCount, "用户3，未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public void TestDeleteManyDynamic()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        var users1 = DataHelper.GetNewUsers();
        var users2 = DataHelper.GetNewUsers();
        var users3 = DataHelper.GetNewUsers();

        //添加用户
        dbContext.Users.Immediate.DynamicCollectionInsertMany(userGroup, users1);
        // 验证删除是否成功
        var deletedUser1 = dbContext.Users.Immediate.DynamicCollectionDeleteMany(userGroup, users1);
        Assert.AreEqual(6, deletedUser1.Count(a => a.DeletedCount == 1), "用户1，未成功删除。");

        //添加用户
        dbContext.Users.Immediate.DynamicCollectionInsertMany(userGroup, users2);
        // 验证删除是否成功
        var deletedUser2 = dbContext.Users.Immediate.DynamicCollectionDeleteMany(userGroup, Builders<User>.Filter.Eq(f => f.Password, "123456"));
        Assert.AreEqual(6, deletedUser2.DeletedCount, "用户2，未成功删除。");

        //添加用户
        dbContext.Users.Immediate.DynamicCollectionInsertMany(userGroup, users3);
        // 验证删除是否成功
        var deletedUser3 = dbContext.Users.Immediate.DynamicCollectionDeleteMany(userGroup, d => d.Password == "123456");
        Assert.AreEqual(6, deletedUser3.DeletedCount, "用户3，未成功删除。");
    }

    [TestMethod]
    public async Task TestDeleteManyDynamicAsync()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        var users1 = DataHelper.GetNewUsers();
        var users2 = DataHelper.GetNewUsers();
        var users3 = DataHelper.GetNewUsers();

        //添加用户
        await dbContext.Users.Immediate.DynamicCollectionInsertManyAsync(userGroup, users1);
        // 验证删除是否成功
        var deletedUser1 = await dbContext.Users.Immediate.DynamicCollectionDeleteManyAsync(userGroup, users1);
        Assert.AreEqual(6, deletedUser1.Count(a => a.DeletedCount == 1), "用户1，未成功删除。");

        //添加用户
        await dbContext.Users.Immediate.DynamicCollectionInsertManyAsync(userGroup, users2);
        // 验证删除是否成功
        var deletedUser2 = await dbContext.Users.Immediate.DynamicCollectionDeleteManyAsync(userGroup, Builders<User>.Filter.Eq(f => f.Password, "123456"));
        Assert.AreEqual(6, deletedUser2.DeletedCount, "用户2，未成功删除。");

        //添加用户
        await dbContext.Users.Immediate.DynamicCollectionInsertManyAsync(userGroup, users3);
        // 验证删除是否成功
        var deletedUser3 = await dbContext.Users.Immediate.DynamicCollectionDeleteManyAsync(userGroup, d => d.Password == "123456");
        Assert.AreEqual(6, deletedUser3.DeletedCount, "用户3，未成功删除。");
    }

    [TestMethod]
    public void TestDeleteManyDynamicSession()
    {
        var userGroup = DataHelper.GetNewUserGroup();

        var pwd1 = Guid.NewGuid().ToString();
        var pwd2 = Guid.NewGuid().ToString();
        var pwd3 = Guid.NewGuid().ToString();

        var users1 = DataHelper.GetNewUsers(pwd1);
        var users2 = DataHelper.GetNewUsers(pwd2);
        var users3 = DataHelper.GetNewUsers(pwd3);

        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            //添加用户
            dbContext.Users.Immediate.DynamicCollectionInsertMany(session, userGroup, users1);
            // 验证删除是否成功
            var deletedUser1 = dbContext.Users.Immediate.DynamicCollectionDeleteMany(session, userGroup, users1);
            Assert.AreEqual(6, deletedUser1.Count(a => a.DeletedCount == 1), "用户1，未成功删除。");

            //添加用户
            dbContext.Users.Immediate.DynamicCollectionInsertMany(session, userGroup, users2);
            // 验证删除是否成功
            var deletedUser2 = dbContext.Users.Immediate.DynamicCollectionDeleteMany(session, userGroup, Builders<User>.Filter.Eq(f => f.Password, pwd2));
            Assert.AreEqual(6, deletedUser2.DeletedCount, "用户2，未成功删除。");

            //添加用户
            dbContext.Users.Immediate.DynamicCollectionInsertMany(session, userGroup, users3);
            // 验证删除是否成功
            var deletedUser3 = dbContext.Users.Immediate.DynamicCollectionDeleteMany(session, userGroup, d => d.Password == pwd3);
            Assert.AreEqual(6, deletedUser3.DeletedCount, "用户3，未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public async Task TestDeleteManyDynamicSessionAsync()
    {
        var userGroup = DataHelper.GetNewUserGroup();

        var pwd1 = Guid.NewGuid().ToString();
        var pwd2 = Guid.NewGuid().ToString();
        var pwd3 = Guid.NewGuid().ToString();

        var users1 = DataHelper.GetNewUsers(pwd1);
        var users2 = DataHelper.GetNewUsers(pwd2);
        var users3 = DataHelper.GetNewUsers(pwd3);

        using (var session = await dbContext.Client.StartSessionAsync())
        {
            session.StartTransaction();

            //添加用户
            await dbContext.Users.Immediate.DynamicCollectionInsertManyAsync(session, userGroup, users1);
            // 验证删除是否成功
            var deletedUser1 = await dbContext.Users.Immediate.DynamicCollectionDeleteManyAsync(session, userGroup, users1);
            Assert.AreEqual(6, deletedUser1.Count(a => a.DeletedCount == 1), "用户1，未成功删除。");

            //添加用户
            await dbContext.Users.Immediate.DynamicCollectionInsertManyAsync(session, userGroup, users2);
            // 验证删除是否成功
            var deletedUser2 = await dbContext.Users.Immediate.DynamicCollectionDeleteManyAsync(session, userGroup, Builders<User>.Filter.Eq(f => f.Password, pwd2));
            Assert.AreEqual(6, deletedUser2.DeletedCount, "用户2，未成功删除。");

            //添加用户
            await dbContext.Users.Immediate.DynamicCollectionInsertManyAsync(session, userGroup, users3);
            // 验证删除是否成功
            var deletedUser3 = await dbContext.Users.Immediate.DynamicCollectionDeleteManyAsync(session, userGroup, d => d.Password == pwd3);
            Assert.AreEqual(6, deletedUser3.DeletedCount, "用户3，未成功删除。");

            session.CommitTransaction();
        }
    }
}
