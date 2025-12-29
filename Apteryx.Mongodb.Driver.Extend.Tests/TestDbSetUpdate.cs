using MongoDB.Driver;
using Apteryx.Mongodb.Driver.Extend.Tests.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Apteryx.Mongodb.Driver.Extend.Tests;

[TestClass]
public class TestDbSetUpdate : TestBase
{
    private readonly ApteryxDbContext? dbContext;

    [TestInitialize]
    public void TestInitialize()
    {
        // 确保 dbContext 不为 null
        Assert.IsNotNull(dbContext, "无法从服务提供程序获取ApteryxDbContext。"); ;
    }

    public TestDbSetUpdate()
    {
        this.dbContext = ServiceProvider.GetService<ApteryxDbContext>();
    }

    [TestMethod]
    public void TestUpdateOne()
    {
        var user = DataHelper.GetNewUser();
        dbContext.Users.Immediate.Insert(user);

        // 验证添加是否成功
        var addedUser = dbContext.Users.Immediate.FindOne(user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 更新用户1
        var name1 = $"乔峰{Guid.NewGuid().ToString()}";
        dbContext.Users.Immediate.UpdateOne(user.Id, Builders<User>.Update.Set(u => u.Name, name1));

        // 验证更新是否成功
        var updatedUser1 = dbContext.Users.Immediate.FindOne(user.Id);
        Assert.AreEqual(updatedUser1.Name, name1, "未成功更新用户。");

        // 更新用户2
        var name2 = $"虚竹{Guid.NewGuid().ToString()}";
        dbContext.Users.Immediate.UpdateOne(r => r.Id == user.Id, Builders<User>.Update.Set(u => u.Name, name2));

        // 验证更新是否成功
        var updatedUser2 = dbContext.Users.Immediate.FindOne(user.Id);
        Assert.AreEqual(updatedUser2.Name, name2, "未成功更新用户。");

        // 更新用户3
        var name3 = $"段誉{Guid.NewGuid().ToString()}";
        dbContext.Users.Immediate.UpdateOne(Builders<User>.Filter.Eq(f => f.Id, user.Id), Builders<User>.Update.Set(u => u.Name, name3));

        var updatedUser3 = dbContext.Users.Immediate.FindOne(user.Id);
        Assert.AreEqual(updatedUser3.Name, name3, "未成功更新用户。");


        // 删除用户
        var result = dbContext.Users.Immediate.DeleteOne(user);

        // 验证删除是否成功
        var deletedUser = dbContext.Users.Immediate.FindOne(user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public async Task TestUpdateOneAsync()
    {
        var user = DataHelper.GetNewUser();
        await dbContext.Users.Immediate.InsertAsync(user);

        // 验证添加是否成功
        var addedUser = await dbContext.Users.Immediate.FindOneAsync(user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 更新用户1
        var name1 = $"乔峰{Guid.NewGuid().ToString()}";
        await dbContext.Users.Immediate.UpdateOneAsync(user.Id, Builders<User>.Update.Set(u => u.Name, name1));

        // 验证更新是否成功
        var updatedUser1 = dbContext.Users.Immediate.FindOne(user.Id);
        Assert.AreEqual(updatedUser1.Name, name1, "未成功更新用户。");

        // 更新用户2
        var name2 = $"虚竹{Guid.NewGuid().ToString()}";
        await dbContext.Users.Immediate.UpdateOneAsync(r => r.Id == user.Id, Builders<User>.Update.Set(u => u.Name, name2));

        // 验证更新是否成功
        var updatedUser2 = dbContext.Users.Immediate.FindOne(user.Id);
        Assert.AreEqual(updatedUser2.Name, name2, "未成功更新用户。");

        // 更新用户3
        var name3 = $"段誉{Guid.NewGuid().ToString()}";
        await dbContext.Users.Immediate.UpdateOneAsync(Builders<User>.Filter.Eq(f => f.Id, user.Id), Builders<User>.Update.Set(u => u.Name, name3));

        var updatedUser3 = dbContext.Users.Immediate.FindOne(user.Id);
        Assert.AreEqual(updatedUser3.Name, name3, "未成功更新用户。");


        // 删除用户
        var result = await dbContext.Users.Immediate.DeleteOneAsync(user);

        // 验证删除是否成功
        var deletedUser = await dbContext.Users.Immediate.FindOneAsync(user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public void TestUpdateOneSession()
    {
        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            var user = DataHelper.GetNewUser();

            dbContext.Users.Immediate.Insert(session, user);

            // 验证添加是否成功
            var addedUser = dbContext.Users.Immediate.FindOne(session, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 更新用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            dbContext.Users.Immediate.UpdateOne(session, user.Id, Builders<User>.Update.Set(u => u.Name, name1));

            // 验证更新是否成功
            var updatedUser1 = dbContext.Users.Immediate.FindOne(session, user.Id);
            Assert.AreEqual(updatedUser1.Name, name1, "未成功更新用户。");

            // 更新用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            dbContext.Users.Immediate.UpdateOne(session, r => r.Id == user.Id, Builders<User>.Update.Set(u => u.Name, name2));

            // 验证更新是否成功
            var updatedUser2 = dbContext.Users.Immediate.FindOne(session, user.Id);
            Assert.AreEqual(updatedUser2.Name, name2, "未成功更新用户。");

            // 更新用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            dbContext.Users.Immediate.UpdateOne(session, Builders<User>.Filter.Eq(f => f.Id, user.Id), Builders<User>.Update.Set(u => u.Name, name3));

            var updatedUser3 = dbContext.Users.Immediate.FindOne(session, user.Id);
            Assert.AreEqual(updatedUser3.Name, name3, "未成功更新用户。");


            // 删除用户
            var result = dbContext.Users.Immediate.DeleteOne(session, user);

            // 验证删除是否成功
            var deletedUser = dbContext.Users.Immediate.FindOne(session, user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public async Task TestUpdateOneSessionAsync()
    {
        using (var session = await dbContext.Client.StartSessionAsync())
        {
            session.StartTransaction();

            var user = DataHelper.GetNewUser();

            await dbContext.Users.Immediate.InsertAsync(session, user);

            // 验证添加是否成功
            var addedUser = await dbContext.Users.Immediate.FindOneAsync(session, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 更新用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            await dbContext.Users.Immediate.UpdateOneAsync(session, user.Id, Builders<User>.Update.Set(u => u.Name, name1));

            // 验证更新是否成功
            var updatedUser1 = await dbContext.Users.Immediate.FindOneAsync(session, user.Id);
            Assert.AreEqual(updatedUser1.Name, name1, "未成功更新用户。");

            // 更新用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            await dbContext.Users.Immediate.UpdateOneAsync(session, r => r.Id == user.Id, Builders<User>.Update.Set(u => u.Name, name2));

            // 验证更新是否成功
            var updatedUser2 = await dbContext.Users.Immediate.FindOneAsync(session, user.Id);
            Assert.AreEqual(updatedUser2.Name, name2, "未成功更新用户。");

            // 更新用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            await dbContext.Users.Immediate.UpdateOneAsync(session, Builders<User>.Filter.Eq(f => f.Id, user.Id), Builders<User>.Update.Set(u => u.Name, name3));

            var updatedUser3 = await dbContext.Users.Immediate.FindOneAsync(session, user.Id);
            Assert.AreEqual(updatedUser3.Name, name3, "未成功更新用户。");


            // 删除用户
            var result = await dbContext.Users.Immediate.DeleteOneAsync(session, user);

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.Immediate.FindOneAsync(session, user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public void TestUpdateOneDynamic()
    {
        var user = DataHelper.GetNewUser();
        var userGroup = DataHelper.GetNewUserGroup();
        dbContext.Users.Immediate.DynamicCollectionInsert(userGroup, user);

        // 验证添加是否成功
        var addedUser = dbContext.Users.Immediate.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 更新用户1
        var name1 = $"乔峰{Guid.NewGuid().ToString()}";
        dbContext.Users.Immediate.DynamicCollectionUpdateOne(userGroup, user.Id, Builders<User>.Update.Set(u => u.Name, name1));

        // 验证更新是否成功
        var updatedUser1 = dbContext.Users.Immediate.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.AreEqual(updatedUser1.Name, name1, "未成功更新用户。");

        // 更新用户2
        var name2 = $"虚竹{Guid.NewGuid().ToString()}";
        dbContext.Users.Immediate.DynamicCollectionUpdateOne(userGroup, r => r.Id == user.Id, Builders<User>.Update.Set(u => u.Name, name2));

        // 验证更新是否成功
        var updatedUser2 = dbContext.Users.Immediate.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.AreEqual(updatedUser2.Name, name2, "未成功更新用户。");

        // 更新用户3
        var name3 = $"段誉{Guid.NewGuid().ToString()}";
        dbContext.Users.Immediate.DynamicCollectionUpdateOne(userGroup, Builders<User>.Filter.Eq(f => f.Id, user.Id), Builders<User>.Update.Set(u => u.Name, name3));

        var updatedUser3 = dbContext.Users.Immediate.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.AreEqual(updatedUser3.Name, name3, "未成功更新用户。");


        // 删除用户
        var result = dbContext.Users.Immediate.DynamicCollectionDeleteOne(userGroup, user);

        // 验证删除是否成功
        var deletedUser = dbContext.Users.Immediate.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public async Task TestUpdateOneDynamicAsync()
    {
        var user = DataHelper.GetNewUser();
        var userGroup = DataHelper.GetNewUserGroup();
        await dbContext.Users.Immediate.DynamicCollectionInsertAsync(userGroup, user);

        // 验证添加是否成功
        var addedUser = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 更新用户1
        var name1 = $"乔峰{Guid.NewGuid().ToString()}";
        await dbContext.Users.Immediate.DynamicCollectionUpdateOneAsync(userGroup, user.Id, Builders<User>.Update.Set(u => u.Name, name1));

        // 验证更新是否成功
        var updatedUser1 = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.AreEqual(updatedUser1.Name, name1, "未成功更新用户。");

        // 更新用户2
        var name2 = $"虚竹{Guid.NewGuid().ToString()}";
        await dbContext.Users.Immediate.DynamicCollectionUpdateOneAsync(userGroup, r => r.Id == user.Id, Builders<User>.Update.Set(u => u.Name, name2));

        // 验证更新是否成功
        var updatedUser2 = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.AreEqual(updatedUser2.Name, name2, "未成功更新用户。");

        // 更新用户3
        var name3 = $"段誉{Guid.NewGuid().ToString()}";
        await dbContext.Users.Immediate.DynamicCollectionUpdateOneAsync(userGroup, Builders<User>.Filter.Eq(f => f.Id, user.Id), Builders<User>.Update.Set(u => u.Name, name3));

        var updatedUser3 = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.AreEqual(updatedUser3.Name, name3, "未成功更新用户。");


        // 删除用户
        var result = await dbContext.Users.Immediate.DynamicCollectionDeleteOneAsync(userGroup, user);

        // 验证删除是否成功
        var deletedUser = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public void TestUpdateOneDynamicSession()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            var user = DataHelper.GetNewUser();

            dbContext.Users.Immediate.DynamicCollectionInsert(session, userGroup, user);

            // 验证添加是否成功
            var addedUser = dbContext.Users.Immediate.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 更新用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            dbContext.Users.Immediate.DynamicCollectionUpdateOne(session, userGroup, user.Id, Builders<User>.Update.Set(u => u.Name, name1));

            // 验证更新是否成功
            var updatedUser1 = dbContext.Users.Immediate.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.AreEqual(updatedUser1.Name, name1, "未成功更新用户。");

            // 更新用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            dbContext.Users.Immediate.DynamicCollectionUpdateOne(session, userGroup, r => r.Id == user.Id, Builders<User>.Update.Set(u => u.Name, name2));

            // 验证更新是否成功
            var updatedUser2 = dbContext.Users.Immediate.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.AreEqual(updatedUser2.Name, name2, "未成功更新用户。");

            // 更新用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            dbContext.Users.Immediate.DynamicCollectionUpdateOne(session, userGroup, Builders<User>.Filter.Eq(f => f.Id, user.Id), Builders<User>.Update.Set(u => u.Name, name3));

            var updatedUser3 = dbContext.Users.Immediate.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.AreEqual(updatedUser3.Name, name3, "未成功更新用户。");


            // 删除用户
            var result = dbContext.Users.Immediate.DynamicCollectionDeleteOne(session, userGroup, user);

            // 验证删除是否成功
            var deletedUser = dbContext.Users.Immediate.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public async Task TestUpdateOneDynamicSessionAsync()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        using (var session = await dbContext.Client.StartSessionAsync())
        {
            session.StartTransaction();

            var user = DataHelper.GetNewUser();

            await dbContext.Users.Immediate.DynamicCollectionInsertAsync(session, userGroup, user);

            // 验证添加是否成功
            var addedUser = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 更新用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            await dbContext.Users.Immediate.DynamicCollectionUpdateOneAsync(session, userGroup, user.Id, Builders<User>.Update.Set(u => u.Name, name1));

            // 验证更新是否成功
            var updatedUser1 = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.AreEqual(updatedUser1.Name, name1, "未成功更新用户。");

            // 更新用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            await dbContext.Users.Immediate.DynamicCollectionUpdateOneAsync(session, userGroup, r => r.Id == user.Id, Builders<User>.Update.Set(u => u.Name, name2));

            // 验证更新是否成功
            var updatedUser2 = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.AreEqual(updatedUser2.Name, name2, "未成功更新用户。");

            // 更新用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            await dbContext.Users.Immediate.DynamicCollectionUpdateOneAsync(session, userGroup, Builders<User>.Filter.Eq(f => f.Id, user.Id), Builders<User>.Update.Set(u => u.Name, name3));

            var updatedUser3 = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.AreEqual(updatedUser3.Name, name3, "未成功更新用户。");


            // 删除用户
            var result = await dbContext.Users.Immediate.DynamicCollectionDeleteOneAsync(session, userGroup, user);

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public void TestFindOneAndUpdateOne()
    {
        var user = DataHelper.GetNewUser();
        dbContext.Users.Immediate.Insert(user);

        // 验证添加是否成功
        var addedUser = dbContext.Users.Immediate.FindOne(user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 更新用户1
        var name1 = $"乔峰{Guid.NewGuid().ToString()}";
        var result1 = dbContext.Users.Immediate.FindOneAndUpdateOne(user.Id, Builders<User>.Update.Set(u => u.Name, name1));

        // 验证更新是否成功
        var updatedUser1 = dbContext.Users.Immediate.FindOne(user.Id);
        Assert.AreNotEqual(updatedUser1.Name, result1.Name, "未成功更新用户。");


        // 更新用户2
        var name2 = $"虚竹{Guid.NewGuid().ToString()}";
        var result2 = dbContext.Users.Immediate.FindOneAndUpdateOne(r => r.Id == user.Id, Builders<User>.Update.Set(u => u.Name, name2));

        // 验证更新是否成功
        var updatedUser2 = dbContext.Users.Immediate.FindOne(user.Id);
        Assert.AreNotEqual(updatedUser2.Name, result2.Name, "未成功更新用户。");

        // 更新用户3
        var name3 = $"段誉{Guid.NewGuid().ToString()}";
        var result3 = dbContext.Users.Immediate.FindOneAndUpdateOne(Builders<User>.Filter.Eq(f => f.Id, user.Id), Builders<User>.Update.Set(u => u.Name, name3));

        var updatedUser3 = dbContext.Users.Immediate.FindOne(user.Id);
        Assert.AreNotEqual(updatedUser3.Name, result3.Name, "未成功更新用户。");

        // 删除用户
        var result = dbContext.Users.Immediate.DeleteOne(user);

        // 验证删除是否成功
        var deletedUser = dbContext.Users.Immediate.FindOne(user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public async Task TestFindOneAndUpdateOneAsync()
    {
        var user = DataHelper.GetNewUser();
        await dbContext.Users.Immediate.InsertAsync(user);

        // 验证添加是否成功
        var addedUser = await dbContext.Users.Immediate.FindOneAsync(user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");

        // 更新用户1
        var name1 = $"乔峰{Guid.NewGuid().ToString()}";
        var result1 = await dbContext.Users.Immediate.FindOneAndUpdateOneAsync(user.Id, Builders<User>.Update.Set(u => u.Name, name1));

        // 验证更新是否成功
        var replaceedUser1 = await dbContext.Users.Immediate.FindOneAsync(user.Id);
        Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功更新用户。");


        // 更新用户2
        var name2 = $"虚竹{Guid.NewGuid().ToString()}";
        var result2 = await dbContext.Users.Immediate.FindOneAndUpdateOneAsync(r => r.Id == user.Id, Builders<User>.Update.Set(u => u.Name, name2));

        // 验证更新是否成功
        var replaceedUser2 = await dbContext.Users.Immediate.FindOneAsync(user.Id);
        Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功更新用户。");

        // 更新用户3
        var name3 = $"段誉{Guid.NewGuid().ToString()}";
        var result3 = await dbContext.Users.Immediate.FindOneAndUpdateOneAsync(Builders<User>.Filter.Eq(f => f.Id, user.Id), Builders<User>.Update.Set(u => u.Name, name3));

        var replaceedUser3 = await dbContext.Users.Immediate.FindOneAsync(user.Id);
        Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功更新用户。");


        // 删除用户
        var result = await dbContext.Users.Immediate.DeleteOneAsync(user);

        // 验证删除是否成功
        var deletedUser = await dbContext.Users.Immediate.FindOneAsync(user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public void TestFindOneAndUpdateOneSession()
    {
        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            var user = DataHelper.GetNewUser();

            dbContext.Users.Immediate.Insert(session, user);

            // 验证添加是否成功
            var addedUser = dbContext.Users.Immediate.FindOne(session, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 更新用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            var result1 = dbContext.Users.Immediate.FindOneAndUpdateOne(session, user.Id, Builders<User>.Update.Set(u => u.Name, name1));

            // 验证更新是否成功
            var replaceedUser1 = dbContext.Users.Immediate.FindOne(session, user.Id);
            Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功更新用户。");


            // 更新用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            var result2 = dbContext.Users.Immediate.FindOneAndUpdateOne(session, r => r.Id == user.Id, Builders<User>.Update.Set(u => u.Name, name2));

            // 验证更新是否成功
            var replaceedUser2 = dbContext.Users.Immediate.FindOne(session, user.Id);
            Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功更新用户。");

            // 更新用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            var result3 = dbContext.Users.Immediate.FindOneAndUpdateOne(session, Builders<User>.Filter.Eq(f => f.Id, user.Id), Builders<User>.Update.Set(u => u.Name, name3));

            var replaceedUser3 = dbContext.Users.Immediate.FindOne(session, user.Id);
            Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功更新用户。");

            // 删除用户
            var result = dbContext.Users.Immediate.DeleteOne(session, user);

            // 验证删除是否成功
            var deletedUser = dbContext.Users.Immediate.FindOne(session, user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public async Task TestFindOneAndUpdateOneSessionAsync()
    {
        using (var session = await dbContext.Client.StartSessionAsync())
        {
            session.StartTransaction();

            var user = DataHelper.GetNewUser();

            await dbContext.Users.Immediate.InsertAsync(session, user);

            // 验证添加是否成功
            var addedUser = await dbContext.Users.Immediate.FindOneAsync(session, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 更新用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            var result1 = await dbContext.Users.Immediate.FindOneAndUpdateOneAsync(session, user.Id, Builders<User>.Update.Set(u => u.Name, name1));

            // 验证更新是否成功
            var replaceedUser1 = await dbContext.Users.Immediate.FindOneAsync(session, user.Id);
            Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功更新用户。");


            // 更新用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            var result2 = await dbContext.Users.Immediate.FindOneAndUpdateOneAsync(session, r => r.Id == user.Id, Builders<User>.Update.Set(u => u.Name, name2));

            // 验证更新是否成功
            var replaceedUser2 = await dbContext.Users.Immediate.FindOneAsync(session, user.Id);
            Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功更新用户。");

            // 更新用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            var result3 = await dbContext.Users.Immediate.FindOneAndUpdateOneAsync(session, Builders<User>.Filter.Eq(f => f.Id, user.Id), Builders<User>.Update.Set(u => u.Name, name3));

            var replaceedUser3 = await dbContext.Users.Immediate.FindOneAsync(session, user.Id);
            Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功更新用户。");

            // 删除用户
            var result = await dbContext.Users.Immediate.DeleteOneAsync(session, user);

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.Immediate.FindOneAsync(session, user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public void TestFindOneAndUpdateOneDynamic()
    {
        var user = DataHelper.GetNewUser();
        var userGroup = DataHelper.GetNewUserGroup();
        dbContext.Users.Immediate.DynamicCollectionInsert(userGroup, user);

        // 验证添加是否成功
        var addedUser = dbContext.Users.Immediate.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 更新用户1
        var name1 = $"乔峰{Guid.NewGuid().ToString()}";
        var result1 = dbContext.Users.Immediate.DynamicCollectionFindOneAndUpdateOne(userGroup, user.Id, Builders<User>.Update.Set(u => u.Name, name1));

        // 验证更新是否成功
        var replaceedUser1 = dbContext.Users.Immediate.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功更新用户。");


        // 更新用户2
        var name2 = $"虚竹{Guid.NewGuid().ToString()}";
        var result2 = dbContext.Users.Immediate.DynamicCollectionFindOneAndUpdateOne(userGroup, r => r.Id == user.Id, Builders<User>.Update.Set(u => u.Name, name2));

        // 验证更新是否成功
        var replaceedUser2 = dbContext.Users.Immediate.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功更新用户。");

        // 更新用户3
        var name3 = $"段誉{Guid.NewGuid().ToString()}";
        var result3 = dbContext.Users.Immediate.DynamicCollectionFindOneAndUpdateOne(userGroup, Builders<User>.Filter.Eq(f => f.Id, user.Id), Builders<User>.Update.Set(u => u.Name, name3));

        var replaceedUser3 = dbContext.Users.Immediate.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功更新用户。");

        // 删除用户
        var result = dbContext.Users.Immediate.DynamicCollectionDeleteOne(userGroup, user);

        // 验证删除是否成功
        var deletedUser = dbContext.Users.Immediate.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public async Task TestFindOneAndUpdateOneDynamicAsync()
    {
        var user = DataHelper.GetNewUser();
        var userGroup = DataHelper.GetNewUserGroup();
        await dbContext.Users.Immediate.DynamicCollectionInsertAsync(userGroup, user);

        // 验证添加是否成功
        var addedUser = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 更新用户1
        var name1 = $"乔峰{Guid.NewGuid().ToString()}";
        var result1 = await dbContext.Users.Immediate.DynamicCollectionFindOneAndUpdateOneAsync(userGroup, user.Id, Builders<User>.Update.Set(u => u.Name, name1));

        // 验证更新是否成功
        var replaceedUser1 = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功更新用户。");


        // 更新用户2
        var name2 = $"虚竹{Guid.NewGuid().ToString()}";
        var result2 = await dbContext.Users.Immediate.DynamicCollectionFindOneAndUpdateOneAsync(userGroup, r => r.Id == user.Id, Builders<User>.Update.Set(u => u.Name, name2));

        // 验证更新是否成功
        var replaceedUser2 = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功更新用户。");

        // 更新用户3
        var name3 = $"段誉{Guid.NewGuid().ToString()}";
        var result3 = await dbContext.Users.Immediate.DynamicCollectionFindOneAndUpdateOneAsync(userGroup, Builders<User>.Filter.Eq(f => f.Id, user.Id), Builders<User>.Update.Set(u => u.Name, name3));

        var replaceedUser3 = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功更新用户。");

        // 删除用户
        var result = await dbContext.Users.Immediate.DynamicCollectionDeleteOneAsync(userGroup, user);

        // 验证删除是否成功
        var deletedUser = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public void TestFindOneAndUpdateOneDynamicSession()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            var user = DataHelper.GetNewUser();

            dbContext.Users.Immediate.DynamicCollectionInsert(session, userGroup, user);

            // 验证添加是否成功
            var addedUser = dbContext.Users.Immediate.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 更新用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            var result1 = dbContext.Users.Immediate.DynamicCollectionFindOneAndUpdateOne(session, userGroup, user.Id, Builders<User>.Update.Set(u => u.Name, name1));

            // 验证更新是否成功
            var replaceedUser1 = dbContext.Users.Immediate.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功更新用户。");


            // 更新用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            var result2 = dbContext.Users.Immediate.DynamicCollectionFindOneAndUpdateOne(session, userGroup, r => r.Id == user.Id, Builders<User>.Update.Set(u => u.Name, name2));

            // 验证更新是否成功
            var replaceedUser2 = dbContext.Users.Immediate.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功更新用户。");

            // 更新用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            var result3 = dbContext.Users.Immediate.DynamicCollectionFindOneAndUpdateOne(session, userGroup, Builders<User>.Filter.Eq(f => f.Id, user.Id), Builders<User>.Update.Set(u => u.Name, name3));

            var replaceedUser3 = dbContext.Users.Immediate.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功更新用户。");

            // 删除用户
            var result = dbContext.Users.Immediate.DynamicCollectionDeleteOne(session, userGroup, user);

            // 验证删除是否成功
            var deletedUser = dbContext.Users.Immediate.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public async Task TestFindOneAndUpdateOneDynamicSessionAsync()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        using (var session = await dbContext.Client.StartSessionAsync())
        {
            session.StartTransaction();

            var user = DataHelper.GetNewUser();

            await dbContext.Users.Immediate.DynamicCollectionInsertAsync(session, userGroup, user);

            // 验证添加是否成功
            var addedUser = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 更新用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            user.Name = name1;
            var result1 = await dbContext.Users.Immediate.DynamicCollectionFindOneAndUpdateOneAsync(session, userGroup, user.Id, Builders<User>.Update.Set(u => u.Name, name1));

            // 验证更新是否成功
            var replaceedUser1 = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功更新用户。");


            // 更新用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            user.Name = name2;
            var result2 = await dbContext.Users.Immediate.DynamicCollectionFindOneAndUpdateOneAsync(session, userGroup, r => r.Id == user.Id, Builders<User>.Update.Set(u => u.Name, name2));

            // 验证更新是否成功
            var replaceedUser2 = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功更新用户。");

            // 更新用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            user.Name = name3;
            var result3 = await dbContext.Users.Immediate.DynamicCollectionFindOneAndUpdateOneAsync(session, userGroup, Builders<User>.Filter.Eq(f => f.Id, user.Id), Builders<User>.Update.Set(u => u.Name, name3));

            var replaceedUser3 = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功更新用户。");

            // 删除用户
            var result = await dbContext.Users.Immediate.DynamicCollectionDeleteOneAsync(session, userGroup, user);

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public void TestUpdateMany()
    {
        var users = DataHelper.GetNewUsers();

        dbContext.Users.Immediate.InsertMany(users);

        // 验证添加是否成功
        var addedUserCount = dbContext.Users.Immediate.Find(w => w.Email == "zhangfei@qq.com").CountDocuments();
        Assert.AreEqual(3, addedUserCount, "未成功添加，数量不正确");

        //验证更新是否成功
        var result1 = dbContext.Users.Immediate.UpdateMany(u => u.Email == "zhangfei@qq.com", Builders<User>.Update.Set(s => s.Description, Guid.NewGuid().ToString()));
        Assert.AreEqual(3, result1.ModifiedCount, "未成功更新，数量不正确");

        //验证更新是否成功
        var result2 = dbContext.Users.Immediate.UpdateMany(Builders<User>.Filter.Eq(f => f.Email, "zhangfei@qq.com"), Builders<User>.Update.Set(s => s.Description, Guid.NewGuid().ToString()));
        Assert.AreEqual(3, result2.ModifiedCount, "未成功更新，数量不正确");

        // 删除用户
        var result = dbContext.Users.Immediate.DeleteMany(users);

        // 验证删除是否成功
        var deletedUserCount = dbContext.Users.Immediate.Find(w => true).CountDocuments();
        Assert.AreEqual(0, deletedUserCount, "用户未成功删除。");
    }

    [TestMethod]
    public async Task TestUpdateManyAsync()
    {
        var users = DataHelper.GetNewUsers();
        await dbContext.Users.Immediate.InsertManyAsync(users);

        // 验证添加是否成功
        List<User> addedUser = new();
        await foreach (var user in dbContext.Users.Immediate.FindAsync(w => w.Email == "zhangfei@qq.com"))
        {
            addedUser.Add(user);
        }
        Assert.AreEqual(3, addedUser.Count, "未成功添加，数量不正确");

        //验证更新是否成功
        var result1 = await dbContext.Users.Immediate.UpdateManyAsync(u => u.Email == "zhangfei@qq.com", Builders<User>.Update.Set(s => s.Description, Guid.NewGuid().ToString()));
        Assert.AreEqual(3, result1.ModifiedCount, "未成功更新，数量不正确");

        //验证更新是否成功
        var result2 = await dbContext.Users.Immediate.UpdateManyAsync(Builders<User>.Filter.Eq(f => f.Email, "zhangfei@qq.com"), Builders<User>.Update.Set(s => s.Description, Guid.NewGuid().ToString()));
        Assert.AreEqual(3, result2.ModifiedCount, "未成功更新，数量不正确");

        // 删除用户
        var result = await dbContext.Users.Immediate.DeleteManyAsync(users);

        // 验证删除是否成功
        var deletedUserCount = dbContext.Users.Immediate.Find(w => true).CountDocuments();
        Assert.AreEqual(0, deletedUserCount, "用户未成功删除。");
    }

    [TestMethod]
    public void TestUpdateManySession()
    {
        var users = DataHelper.GetNewUsers();

        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            dbContext.Users.Immediate.InsertMany(session, users);

            // 验证添加是否成功
            var addedUserCount = dbContext.Users.Immediate.Find(session, w => w.Email == "zhangfei@qq.com").CountDocuments();
            Assert.AreEqual(3, addedUserCount, "未成功添加，数量不正确");

            //验证更新是否成功
            var result1 = dbContext.Users.Immediate.UpdateMany(session, u => u.Email == "zhangfei@qq.com", Builders<User>.Update.Set(s => s.Description, Guid.NewGuid().ToString()));
            Assert.AreEqual(3, result1.ModifiedCount, "未成功更新，数量不正确");

            //验证更新是否成功
            var result2 = dbContext.Users.Immediate.UpdateMany(session, Builders<User>.Filter.Eq(f => f.Email, "zhangfei@qq.com"), Builders<User>.Update.Set(s => s.Description, Guid.NewGuid().ToString()));
            Assert.AreEqual(3, result2.ModifiedCount, "未成功更新，数量不正确");

            // 删除用户
            var result = dbContext.Users.Immediate.DeleteMany(session, users);

            // 验证删除是否成功
            var deletedUserCount = dbContext.Users.Immediate.Find(session, w => true).CountDocuments();
            Assert.AreEqual(0, deletedUserCount, "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public async Task TestUpdateManySessionAsync()
    {
        var users = DataHelper.GetNewUsers();

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

            //验证更新是否成功
            var result1 = await dbContext.Users.Immediate.UpdateManyAsync(session, u => u.Email == "zhangfei@qq.com", Builders<User>.Update.Set(s => s.Description, Guid.NewGuid().ToString()));
            Assert.AreEqual(3, result1.ModifiedCount, "未成功更新，数量不正确");

            //验证更新是否成功
            var result2 = await dbContext.Users.Immediate.UpdateManyAsync(session, Builders<User>.Filter.Eq(f => f.Email, "zhangfei@qq.com"), Builders<User>.Update.Set(s => s.Description, Guid.NewGuid().ToString()));
            Assert.AreEqual(3, result2.ModifiedCount, "未成功更新，数量不正确");

            // 删除用户
            var result = await dbContext.Users.Immediate.DeleteManyAsync(session, users);

            // 验证删除是否成功
            var deletedUserCount = dbContext.Users.Immediate.Find(session, w => true).CountDocuments();
            Assert.AreEqual(0, deletedUserCount, "用户未成功删除。");

            await session.CommitTransactionAsync();
        }
    }

    [TestMethod]
    public void TestUpdateManyDynamic()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        var users = DataHelper.GetNewUsers();

        dbContext.Users.Immediate.DynamicCollectionInsertMany(userGroup, users);

        // 验证添加是否成功
        var addedUserCount = dbContext.Users.Immediate.DynamicCollectionFind(userGroup, w => w.Email == "zhangfei@qq.com").CountDocuments();
        Assert.AreEqual(3, addedUserCount, "未成功添加，数量不正确");

        //验证更新是否成功
        var result1 = dbContext.Users.Immediate.DynamicCollectionUpdateMany(userGroup, u => u.Email == "zhangfei@qq.com", Builders<User>.Update.Set(s => s.Description, Guid.NewGuid().ToString()));
        Assert.AreEqual(3, result1.ModifiedCount, "未成功更新，数量不正确");

        //验证更新是否成功
        var result2 = dbContext.Users.Immediate.DynamicCollectionUpdateMany(userGroup, Builders<User>.Filter.Eq(f => f.Email, "zhangfei@qq.com"), Builders<User>.Update.Set(s => s.Description, Guid.NewGuid().ToString()));
        Assert.AreEqual(3, result2.ModifiedCount, "未成功更新，数量不正确");

        // 删除用户
        var result = dbContext.Users.Immediate.DynamicCollectionDeleteMany(userGroup, users);

        // 验证删除是否成功
        var deletedUserCount = dbContext.Users.Immediate.DynamicCollectionFind(userGroup, w => true).CountDocuments();
        Assert.AreEqual(0, deletedUserCount, "用户未成功删除。");
    }

    [TestMethod]
    public async Task TestUpdateManyDynamicAsync()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        var users = DataHelper.GetNewUsers();

        await dbContext.Users.Immediate.DynamicCollectionInsertManyAsync(userGroup, users);

        // 验证添加是否成功
        List<User> addedUser = new();
        await foreach (var user in dbContext.Users.Immediate.DynamicCollectionFindAsync(userGroup, w => w.Email == "zhangfei@qq.com"))
        {
            addedUser.Add(user);
        }
        Assert.AreEqual(3, addedUser.Count, "未成功添加，数量不正确");

        //验证更新是否成功
        var result1 = await dbContext.Users.Immediate.DynamicCollectionUpdateManyAsync(userGroup, u => u.Email == "zhangfei@qq.com", Builders<User>.Update.Set(s => s.Description, Guid.NewGuid().ToString()));
        Assert.AreEqual(3, result1.ModifiedCount, "未成功更新，数量不正确");

        //验证更新是否成功
        var result2 = await dbContext.Users.Immediate.DynamicCollectionUpdateManyAsync(userGroup, Builders<User>.Filter.Eq(f => f.Email, "zhangfei@qq.com"), Builders<User>.Update.Set(s => s.Description, Guid.NewGuid().ToString()));
        Assert.AreEqual(3, result2.ModifiedCount, "未成功更新，数量不正确");

        // 删除用户
        var result = await dbContext.Users.Immediate.DynamicCollectionDeleteManyAsync(userGroup, users);

        // 验证删除是否成功
        var deletedUserCount = dbContext.Users.Immediate.DynamicCollectionFind(userGroup, w => true).CountDocuments();
        Assert.AreEqual(0, deletedUserCount, "用户未成功删除。");
    }

    [TestMethod]
    public void TestUpdateManyDynamicSession()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        var users = DataHelper.GetNewUsers();

        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            dbContext.Users.Immediate.DynamicCollectionInsertMany(session, userGroup, users);

            // 验证添加是否成功
            var addedUserCount = dbContext.Users.Immediate.DynamicCollectionFind(session, userGroup, w => w.Email == "zhangfei@qq.com").CountDocuments();
            Assert.AreEqual(3, addedUserCount, "未成功添加，数量不正确");

            //验证更新是否成功
            var result1 = dbContext.Users.Immediate.DynamicCollectionUpdateMany(session, userGroup, u => u.Email == "zhangfei@qq.com", Builders<User>.Update.Set(s => s.Description, Guid.NewGuid().ToString()));
            Assert.AreEqual(3, result1.ModifiedCount, "未成功更新，数量不正确");

            //验证更新是否成功
            var result2 = dbContext.Users.Immediate.DynamicCollectionUpdateMany(session, userGroup, Builders<User>.Filter.Eq(f => f.Email, "zhangfei@qq.com"), Builders<User>.Update.Set(s => s.Description, Guid.NewGuid().ToString()));
            Assert.AreEqual(3, result2.ModifiedCount, "未成功更新，数量不正确");

            // 删除用户
            var result = dbContext.Users.Immediate.DynamicCollectionDeleteMany(session, userGroup, users);

            // 验证删除是否成功
            var deletedUserCount = dbContext.Users.Immediate.DynamicCollectionFind(session, userGroup, w => true).CountDocuments();
            Assert.AreEqual(0, deletedUserCount, "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public async Task TestUpdateManyDynamicSessionAsync()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        var users = DataHelper.GetNewUsers();

        using (var session = await dbContext.Client.StartSessionAsync())
        {
            await dbContext.Users.Immediate.DynamicCollectionInsertManyAsync(session, userGroup, users);

            // 验证添加是否成功
            List<User> addedUser = new();
            await foreach (var user in dbContext.Users.Immediate.DynamicCollectionFindAsync(session, userGroup, w => w.Email == "zhangfei@qq.com"))
            {
                addedUser.Add(user);
            }
            Assert.AreEqual(3, addedUser.Count, "未成功添加，数量不正确");

            //验证更新是否成功
            var result1 = await dbContext.Users.Immediate.DynamicCollectionUpdateManyAsync(session, userGroup, u => u.Email == "zhangfei@qq.com", Builders<User>.Update.Set(s => s.Description, Guid.NewGuid().ToString()));
            Assert.AreEqual(3, result1.ModifiedCount, "未成功更新，数量不正确");

            //验证更新是否成功
            var result2 = await dbContext.Users.Immediate.DynamicCollectionUpdateManyAsync(session, userGroup, Builders<User>.Filter.Eq(f => f.Email, "zhangfei@qq.com"), Builders<User>.Update.Set(s => s.Description, Guid.NewGuid().ToString()));
            Assert.AreEqual(3, result2.ModifiedCount, "未成功更新，数量不正确");

            // 删除用户
            var result = await dbContext.Users.Immediate.DynamicCollectionDeleteManyAsync(session, userGroup, users);

            // 验证删除是否成功
            var deletedUserCount = dbContext.Users.Immediate.DynamicCollectionFind(session, userGroup, w => true).CountDocuments();
            Assert.AreEqual(0, deletedUserCount, "用户未成功删除。");
        }
    }
}
