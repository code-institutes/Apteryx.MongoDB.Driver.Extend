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

        dbContext.Users.AddMany(users);

        // 删除用户
        var result1 = dbContext.Users.DeleteOne(users[0]);
        Assert.AreEqual(true, result1.IsAcknowledged, "用户1，未成功删除。");

        // 删除用户
        var result2 = dbContext.Users.DeleteOne(users[1].Id);
        Assert.AreEqual(true, result2.IsAcknowledged, "用户2，未成功删除。");

        // 删除用户
        var result3 = dbContext.Users.DeleteOne(d => d.Id == users[2].Id);
        Assert.AreEqual(true, result3.IsAcknowledged, "用户3，未成功删除。");

        // 删除用户
        var result4 = dbContext.Users.DeleteOne(Builders<User>.Filter.Eq(f => f.Id, users[3].Id));
        Assert.AreEqual(true, result4.IsAcknowledged, "用户4，未成功删除。");

        // 验证删除是否成功
        var deletedUser = dbContext.Users.DeleteMany(users);
        Assert.AreEqual(2, deletedUser.Count(a => a.DeletedCount == 1), "用户未成功删除。");
    }

    [TestMethod]
    public async Task TestDeleteOneAsync()
    {
        var users = DataHelper.GetNewUsers();

        await dbContext.Users.AddManyAsync(users);

        // 删除用户
        var result1 = await dbContext.Users.DeleteOneAsync(users[0]);
        Assert.AreEqual(true, result1.IsAcknowledged, "用户1，未成功删除。");

        // 删除用户
        var result2 = await dbContext.Users.DeleteOneAsync(users[1].Id);
        Assert.AreEqual(true, result2.IsAcknowledged, "用户2，未成功删除。");

        // 删除用户
        var result3 = await dbContext.Users.DeleteOneAsync(d => d.Id == users[2].Id);
        Assert.AreEqual(true, result3.IsAcknowledged, "用户3，未成功删除。");

        // 删除用户
        var result4 = await dbContext.Users.DeleteOneAsync(Builders<User>.Filter.Eq(f => f.Id, users[3].Id));
        Assert.AreEqual(true, result4.IsAcknowledged, "用户4，未成功删除。");

        // 验证删除是否成功
        var deletedUser = await dbContext.Users.DeleteManyAsync(users);
        Assert.AreEqual(2, deletedUser.Count(a => a.DeletedCount == 1), "用户未成功删除。");
    }

    [TestMethod]
    public void TestDeleteOneSession()
    {
        var users = DataHelper.GetNewUsers();

        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            dbContext.Users.AddMany(session, users);

            // 删除用户
            var result1 = dbContext.Users.DeleteOne(session, users[0]);
            Assert.AreEqual(true, result1.IsAcknowledged, "用户1，未成功删除。");

            // 删除用户
            var result2 = dbContext.Users.DeleteOne(session, users[1].Id);
            Assert.AreEqual(true, result2.IsAcknowledged, "用户2，未成功删除。");

            // 删除用户
            var result3 = dbContext.Users.DeleteOne(session, d => d.Id == users[2].Id);
            Assert.AreEqual(true, result3.IsAcknowledged, "用户3，未成功删除。");

            // 删除用户
            var result4 = dbContext.Users.DeleteOne(session, Builders<User>.Filter.Eq(f => f.Id, users[3].Id));
            Assert.AreEqual(true, result4.IsAcknowledged, "用户4，未成功删除。");

            // 验证删除是否成功
            var deletedUser = dbContext.Users.DeleteMany(session, users);
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

            await dbContext.Users.AddManyAsync(session, users);

            // 删除用户
            var result1 = await dbContext.Users.DeleteOneAsync(session, users[0]);
            Assert.AreEqual(true, result1.IsAcknowledged, "用户1，未成功删除。");

            // 删除用户
            var result2 = await dbContext.Users.DeleteOneAsync(session, users[1].Id);
            Assert.AreEqual(true, result2.IsAcknowledged, "用户2，未成功删除。");

            // 删除用户
            var result3 = await dbContext.Users.DeleteOneAsync(session, d => d.Id == users[2].Id);
            Assert.AreEqual(true, result3.IsAcknowledged, "用户3，未成功删除。");

            // 删除用户
            var result4 = await dbContext.Users.DeleteOneAsync(session, Builders<User>.Filter.Eq(f => f.Id, users[3].Id));
            Assert.AreEqual(true, result4.IsAcknowledged, "用户4，未成功删除。");

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.DeleteManyAsync(session, users);
            Assert.AreEqual(2, deletedUser.Count(a => a.DeletedCount == 1), "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public void TestDeleteOneDynamic()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        var users = DataHelper.GetNewUsers();

        dbContext.Users.DynamicCollectionAddMany(userGroup, users);

        // 删除用户
        var result1 = dbContext.Users.DynamicCollectionDeleteOne(userGroup, users[0]);
        Assert.AreEqual(true, result1.IsAcknowledged, "用户1，未成功删除。");

        // 删除用户
        var result2 = dbContext.Users.DynamicCollectionDeleteOne(userGroup, users[1].Id);
        Assert.AreEqual(true, result2.IsAcknowledged, "用户2，未成功删除。");

        // 删除用户
        var result3 = dbContext.Users.DynamicCollectionDeleteOne(userGroup, d => d.Id == users[2].Id);
        Assert.AreEqual(true, result3.IsAcknowledged, "用户3，未成功删除。");

        // 删除用户
        var result4 = dbContext.Users.DynamicCollectionDeleteOne(userGroup, Builders<User>.Filter.Eq(f => f.Id, users[3].Id));
        Assert.AreEqual(true, result4.IsAcknowledged, "用户4，未成功删除。");

        // 验证删除是否成功
        var deletedUser = dbContext.Users.DynamicCollectionDeleteMany(userGroup, users);
        Assert.AreEqual(2, deletedUser.Count(a => a.DeletedCount == 1), "用户未成功删除。");
    }

    [TestMethod]
    public async Task TestDeleteOneDynamicAsync()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        var users = DataHelper.GetNewUsers();

        await dbContext.Users.DynamicCollectionAddManyAsync(userGroup, users);

        // 删除用户
        var result1 = await dbContext.Users.DynamicCollectionDeleteOneAsync(userGroup, users[0]);
        Assert.AreEqual(true, result1.IsAcknowledged, "用户1，未成功删除。");

        // 删除用户
        var result2 = await dbContext.Users.DynamicCollectionDeleteOneAsync(userGroup, users[1].Id);
        Assert.AreEqual(true, result2.IsAcknowledged, "用户2，未成功删除。");

        // 删除用户
        var result3 = await dbContext.Users.DynamicCollectionDeleteOneAsync(userGroup, d => d.Id == users[2].Id);
        Assert.AreEqual(true, result3.IsAcknowledged, "用户3，未成功删除。");

        // 删除用户
        var result4 = await dbContext.Users.DynamicCollectionDeleteOneAsync(userGroup, Builders<User>.Filter.Eq(f => f.Id, users[3].Id));
        Assert.AreEqual(true, result4.IsAcknowledged, "用户4，未成功删除。");

        // 验证删除是否成功
        var deletedUser = await dbContext.Users.DynamicCollectionDeleteManyAsync(userGroup, users);
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

            dbContext.Users.DynamicCollectionAddMany(session, userGroup, users);

            // 删除用户
            var result1 = dbContext.Users.DynamicCollectionDeleteOne(session, userGroup, users[0]);
            Assert.AreEqual(true, result1.IsAcknowledged, "用户1，未成功删除。");

            // 删除用户
            var result2 = dbContext.Users.DynamicCollectionDeleteOne(session, userGroup, users[1].Id);
            Assert.AreEqual(true, result2.IsAcknowledged, "用户2，未成功删除。");

            // 删除用户
            var result3 = dbContext.Users.DynamicCollectionDeleteOne(session, userGroup, d => d.Id == users[2].Id);
            Assert.AreEqual(true, result3.IsAcknowledged, "用户3，未成功删除。");

            // 删除用户
            var result4 = dbContext.Users.DynamicCollectionDeleteOne(session, userGroup, Builders<User>.Filter.Eq(f => f.Id, users[3].Id));
            Assert.AreEqual(true, result4.IsAcknowledged, "用户4，未成功删除。");

            // 验证删除是否成功
            var deletedUser = dbContext.Users.DynamicCollectionDeleteMany(session, userGroup, users);
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

            await dbContext.Users.DynamicCollectionAddManyAsync(session, userGroup, users);

            // 删除用户
            var result1 = await dbContext.Users.DynamicCollectionDeleteOneAsync(session, userGroup, users[0]);
            Assert.AreEqual(true, result1.IsAcknowledged, "用户1，未成功删除。");

            // 删除用户
            var result2 = await dbContext.Users.DynamicCollectionDeleteOneAsync(session, userGroup, users[1].Id);
            Assert.AreEqual(true, result2.IsAcknowledged, "用户2，未成功删除。");

            // 删除用户
            var result3 = await dbContext.Users.DynamicCollectionDeleteOneAsync(session, userGroup, d => d.Id == users[2].Id);
            Assert.AreEqual(true, result3.IsAcknowledged, "用户3，未成功删除。");

            // 删除用户
            var result4 = await dbContext.Users.DynamicCollectionDeleteOneAsync(session, userGroup, Builders<User>.Filter.Eq(f => f.Id, users[3].Id));
            Assert.AreEqual(true, result4.IsAcknowledged, "用户4，未成功删除。");

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.DynamicCollectionDeleteManyAsync(session, userGroup, users);
            Assert.AreEqual(2, deletedUser.Count(a => a.DeletedCount == 1), "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public void TestFindOneAndDeleteOne()
    {
        var users = DataHelper.GetNewUsers();

        dbContext.Users.AddMany(users);

        // 删除用户
        var result1 = dbContext.Users.FindOneAndDelete(users[0].Id);
        Assert.IsNotNull(result1, "用户1，未成功删除。");

        // 删除用户
        var result2 = dbContext.Users.FindOneAndDelete(d => d.Id == users[1].Id);
        Assert.IsNotNull(result2, "用户2，未成功删除。");

        // 删除用户
        var result3 = dbContext.Users.FindOneAndDelete(Builders<User>.Filter.Eq(f => f.Id, users[2].Id));
        Assert.IsNotNull(result3, "用户3，未成功删除。");

        var deletedUser = dbContext.Users.DeleteMany(users);
    }

    [TestMethod]
    public async Task TestFindOneAndDeleteOneAsync()
    {
        var users = DataHelper.GetNewUsers();

        await dbContext.Users.AddManyAsync(users);

        // 删除用户
        var result1 = await dbContext.Users.FindOneAndDeleteAsync(users[0].Id);
        Assert.IsNotNull(result1, "用户1，未成功删除。");

        // 删除用户
        var result2 = await dbContext.Users.FindOneAndDeleteAsync(d => d.Id == users[1].Id);
        Assert.IsNotNull(result2, "用户2，未成功删除。");

        // 删除用户
        var result3 = await dbContext.Users.FindOneAndDeleteAsync(Builders<User>.Filter.Eq(f => f.Id, users[2].Id));
        Assert.IsNotNull(result3, "用户3，未成功删除。");

        var deletedUser = dbContext.Users.DeleteMany(users);
    }

    [TestMethod]
    public void TestFindOneAndDeleteOneSession()
    {
        var users = DataHelper.GetNewUsers();

        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            dbContext.Users.AddMany(session, users);

            // 删除用户
            var result1 = dbContext.Users.FindOneAndDelete(session, users[0].Id);
            Assert.IsNotNull(result1, "用户1，未成功删除。");

            // 删除用户
            var result2 = dbContext.Users.FindOneAndDelete(session, d => d.Id == users[1].Id);
            Assert.IsNotNull(result2, "用户2，未成功删除。");

            // 删除用户
            var result3 = dbContext.Users.FindOneAndDelete(session, Builders<User>.Filter.Eq(f => f.Id, users[2].Id));
            Assert.IsNotNull(result3, "用户3，未成功删除。");

            var deletedUser = dbContext.Users.DeleteMany(session, users);

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

            await dbContext.Users.AddManyAsync(session, users);

            // 删除用户
            var result1 = await dbContext.Users.FindOneAndDeleteAsync(session, users[0].Id);
            Assert.IsNotNull(result1, "用户1，未成功删除。");

            // 删除用户
            var result2 = await dbContext.Users.FindOneAndDeleteAsync(session, d => d.Id == users[1].Id);
            Assert.IsNotNull(result2, "用户2，未成功删除。");

            // 删除用户
            var result3 = await dbContext.Users.FindOneAndDeleteAsync(session, Builders<User>.Filter.Eq(f => f.Id, users[2].Id));
            Assert.IsNotNull(result3, "用户3，未成功删除。");

            var deletedUser = dbContext.Users.DeleteMany(session, users);

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public void TestFindOneAndDeleteOneDynamic()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        var users = DataHelper.GetNewUsers();

        dbContext.Users.DynamicCollectionAddMany(userGroup, users);

        // 删除用户
        var result1 = dbContext.Users.DynamicCollectionFindOneAndDelete(userGroup, users[0].Id);
        Assert.IsNotNull(result1, "用户1，未成功删除。");

        // 删除用户
        var result2 = dbContext.Users.DynamicCollectionFindOneAndDelete(userGroup, d => d.Id == users[1].Id);
        Assert.IsNotNull(result2, "用户2，未成功删除。");

        // 删除用户
        var result3 = dbContext.Users.DynamicCollectionFindOneAndDelete(userGroup, Builders<User>.Filter.Eq(f => f.Id, users[2].Id));
        Assert.IsNotNull(result3, "用户3，未成功删除。");

        var deletedUser = dbContext.Users.DynamicCollectionDeleteMany(userGroup, users);
    }

    [TestMethod]
    public async Task TestFindOneAndDeleteOneDynamicAsync()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        var users = DataHelper.GetNewUsers();

        await dbContext.Users.DynamicCollectionAddManyAsync(userGroup, users);

        // 删除用户
        var result1 = await dbContext.Users.DynamicCollectionFindOneAndDeleteAsync(userGroup, users[0].Id);
        Assert.IsNotNull(result1, "用户1，未成功删除。");

        // 删除用户
        var result2 = await dbContext.Users.DynamicCollectionFindOneAndDeleteAsync(userGroup, d => d.Id == users[1].Id);
        Assert.IsNotNull(result2, "用户2，未成功删除。");

        // 删除用户
        var result3 = await dbContext.Users.DynamicCollectionFindOneAndDeleteAsync(userGroup, Builders<User>.Filter.Eq(f => f.Id, users[2].Id));
        Assert.IsNotNull(result3, "用户3，未成功删除。");

        var deletedUser = await dbContext.Users.DynamicCollectionDeleteManyAsync(userGroup, users);
    }

    [TestMethod]
    public void TestFindOneAndDeleteOneDynamicSession()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        var users = DataHelper.GetNewUsers();

        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            dbContext.Users.DynamicCollectionAddMany(session, userGroup, users);

            // 删除用户
            var result1 = dbContext.Users.DynamicCollectionFindOneAndDelete(session, userGroup, users[0].Id);
            Assert.IsNotNull(result1, "用户1，未成功删除。");

            // 删除用户
            var result2 = dbContext.Users.DynamicCollectionFindOneAndDelete(session, userGroup, d => d.Id == users[1].Id);
            Assert.IsNotNull(result2, "用户2，未成功删除。");

            // 删除用户
            var result3 = dbContext.Users.DynamicCollectionFindOneAndDelete(session, userGroup, Builders<User>.Filter.Eq(f => f.Id, users[2].Id));
            Assert.IsNotNull(result3, "用户3，未成功删除。");

            var deletedUser = dbContext.Users.DynamicCollectionDeleteMany(session, userGroup, users);

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

            await dbContext.Users.DynamicCollectionAddManyAsync(session, userGroup, users);

            // 删除用户
            var result1 = await dbContext.Users.DynamicCollectionFindOneAndDeleteAsync(session, userGroup, users[0].Id);
            Assert.IsNotNull(result1, "用户1，未成功删除。");

            // 删除用户
            var result2 = await dbContext.Users.DynamicCollectionFindOneAndDeleteAsync(session, userGroup, d => d.Id == users[1].Id);
            Assert.IsNotNull(result2, "用户2，未成功删除。");

            // 删除用户
            var result3 = await dbContext.Users.DynamicCollectionFindOneAndDeleteAsync(session, userGroup, Builders<User>.Filter.Eq(f => f.Id, users[2].Id));
            Assert.IsNotNull(result3, "用户3，未成功删除。");

            var deletedUser = await dbContext.Users.DynamicCollectionDeleteManyAsync(session, userGroup, users);

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
        dbContext.Users.AddMany(users1);
        // 验证删除是否成功
        var deletedUser1 = dbContext.Users.DeleteMany(users1);
        Assert.AreEqual(6, deletedUser1.Count(a => a.DeletedCount == 1), "用户1，未成功删除。");

        //添加用户
        dbContext.Users.AddMany(users2);
        // 验证删除是否成功
        var deletedUser2 = dbContext.Users.DeleteMany(Builders<User>.Filter.Eq(f => f.Password, "123456"));
        Assert.AreEqual(6, deletedUser2.DeletedCount, "用户2，未成功删除。");

        //添加用户
        dbContext.Users.AddMany(users3);
        // 验证删除是否成功
        var deletedUser3 = dbContext.Users.DeleteMany(d => d.Password == "123456");
        Assert.AreEqual(6, deletedUser3.DeletedCount, "用户3，未成功删除。");
    }

    [TestMethod]
    public async Task TestDeleteManyAsync()
    {
        var users1 = DataHelper.GetNewUsers();
        var users2 = DataHelper.GetNewUsers();
        var users3 = DataHelper.GetNewUsers();

        //添加用户
        await dbContext.Users.AddManyAsync(users1);
        // 验证删除是否成功
        var deletedUser1 = await dbContext.Users.DeleteManyAsync(users1);
        Assert.AreEqual(6, deletedUser1.Count(a => a.DeletedCount == 1), "用户1，未成功删除。");

        //添加用户
        await dbContext.Users.AddManyAsync(users2);
        // 验证删除是否成功
        var deletedUser2 = await dbContext.Users.DeleteManyAsync(Builders<User>.Filter.Eq(f => f.Password, "123456"));
        Assert.AreEqual(6, deletedUser2.DeletedCount, "用户2，未成功删除。");

        //添加用户
        await dbContext.Users.AddManyAsync(users3);
        // 验证删除是否成功
        var deletedUser3 = await dbContext.Users.DeleteManyAsync(d => d.Password == "123456");
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
            dbContext.Users.AddMany(session, users1);
            // 验证删除是否成功
            var deletedUser1 = dbContext.Users.DeleteMany(session, users1);
            Assert.AreEqual(6, deletedUser1.Count(a => a.DeletedCount == 1), "用户1，未成功删除。");

            //添加用户
            dbContext.Users.AddMany(session, users2);
            // 验证删除是否成功
            var deletedUser2 = dbContext.Users.DeleteMany(session, Builders<User>.Filter.Eq(f => f.Password, pwd2));
            Assert.AreEqual(6, deletedUser2.DeletedCount, "用户2，未成功删除。");

            //添加用户
            dbContext.Users.AddMany(session, users3);
            // 验证删除是否成功
            var deletedUser3 = dbContext.Users.DeleteMany(session, d => d.Password == pwd3);
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
            await dbContext.Users.AddManyAsync(session, users1);
            // 验证删除是否成功
            var deletedUser1 = await dbContext.Users.DeleteManyAsync(session, users1);
            Assert.AreEqual(6, deletedUser1.Count(a => a.DeletedCount == 1), "用户1，未成功删除。");

            //添加用户
            await dbContext.Users.AddManyAsync(session, users2);
            // 验证删除是否成功
            var deletedUser2 = await dbContext.Users.DeleteManyAsync(session, Builders<User>.Filter.Eq(f => f.Password, pwd2));
            Assert.AreEqual(6, deletedUser2.DeletedCount, "用户2，未成功删除。");

            //添加用户
            await dbContext.Users.AddManyAsync(session, users3);
            // 验证删除是否成功
            var deletedUser3 = await dbContext.Users.DeleteManyAsync(session, d => d.Password == pwd3);
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
        dbContext.Users.DynamicCollectionAddMany(userGroup, users1);
        // 验证删除是否成功
        var deletedUser1 = dbContext.Users.DynamicCollectionDeleteMany(userGroup, users1);
        Assert.AreEqual(6, deletedUser1.Count(a => a.DeletedCount == 1), "用户1，未成功删除。");

        //添加用户
        dbContext.Users.DynamicCollectionAddMany(userGroup, users2);
        // 验证删除是否成功
        var deletedUser2 = dbContext.Users.DynamicCollectionDeleteMany(userGroup, Builders<User>.Filter.Eq(f => f.Password, "123456"));
        Assert.AreEqual(6, deletedUser2.DeletedCount, "用户2，未成功删除。");

        //添加用户
        dbContext.Users.DynamicCollectionAddMany(userGroup, users3);
        // 验证删除是否成功
        var deletedUser3 = dbContext.Users.DynamicCollectionDeleteMany(userGroup, d => d.Password == "123456");
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
        await dbContext.Users.DynamicCollectionAddManyAsync(userGroup, users1);
        // 验证删除是否成功
        var deletedUser1 = await dbContext.Users.DynamicCollectionDeleteManyAsync(userGroup, users1);
        Assert.AreEqual(6, deletedUser1.Count(a => a.DeletedCount == 1), "用户1，未成功删除。");

        //添加用户
        await dbContext.Users.DynamicCollectionAddManyAsync(userGroup, users2);
        // 验证删除是否成功
        var deletedUser2 = await dbContext.Users.DynamicCollectionDeleteManyAsync(userGroup, Builders<User>.Filter.Eq(f => f.Password, "123456"));
        Assert.AreEqual(6, deletedUser2.DeletedCount, "用户2，未成功删除。");

        //添加用户
        await dbContext.Users.DynamicCollectionAddManyAsync(userGroup, users3);
        // 验证删除是否成功
        var deletedUser3 = await dbContext.Users.DynamicCollectionDeleteManyAsync(userGroup, d => d.Password == "123456");
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
            dbContext.Users.DynamicCollectionAddMany(session, userGroup, users1);
            // 验证删除是否成功
            var deletedUser1 = dbContext.Users.DynamicCollectionDeleteMany(session, userGroup, users1);
            Assert.AreEqual(6, deletedUser1.Count(a => a.DeletedCount == 1), "用户1，未成功删除。");

            //添加用户
            dbContext.Users.DynamicCollectionAddMany(session, userGroup, users2);
            // 验证删除是否成功
            var deletedUser2 = dbContext.Users.DynamicCollectionDeleteMany(session, userGroup, Builders<User>.Filter.Eq(f => f.Password, pwd2));
            Assert.AreEqual(6, deletedUser2.DeletedCount, "用户2，未成功删除。");

            //添加用户
            dbContext.Users.DynamicCollectionAddMany(session, userGroup, users3);
            // 验证删除是否成功
            var deletedUser3 = dbContext.Users.DynamicCollectionDeleteMany(session, userGroup, d => d.Password == pwd3);
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
            await dbContext.Users.DynamicCollectionAddManyAsync(session, userGroup, users1);
            // 验证删除是否成功
            var deletedUser1 = await dbContext.Users.DynamicCollectionDeleteManyAsync(session, userGroup, users1);
            Assert.AreEqual(6, deletedUser1.Count(a => a.DeletedCount == 1), "用户1，未成功删除。");

            //添加用户
            await dbContext.Users.DynamicCollectionAddManyAsync(session, userGroup, users2);
            // 验证删除是否成功
            var deletedUser2 = await dbContext.Users.DynamicCollectionDeleteManyAsync(session, userGroup, Builders<User>.Filter.Eq(f => f.Password, pwd2));
            Assert.AreEqual(6, deletedUser2.DeletedCount, "用户2，未成功删除。");

            //添加用户
            await dbContext.Users.DynamicCollectionAddManyAsync(session, userGroup, users3);
            // 验证删除是否成功
            var deletedUser3 = await dbContext.Users.DynamicCollectionDeleteManyAsync(session, userGroup, d => d.Password == pwd3);
            Assert.AreEqual(6, deletedUser3.DeletedCount, "用户3，未成功删除。");

            session.CommitTransaction();
        }
    }
}
