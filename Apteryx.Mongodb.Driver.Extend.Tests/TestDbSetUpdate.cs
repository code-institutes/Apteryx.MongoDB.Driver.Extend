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
        dbContext.Users.Add(user);

        // 验证添加是否成功
        var addedUser = dbContext.Users.FindOne(user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 更新用户1
        var name1 = $"乔峰{Guid.NewGuid().ToString()}";
        dbContext.Users.UpdateOne(user.Id, Builders<User>.Update.Set(u => u.Name, name1));

        // 验证更新是否成功
        var updatedUser1 = dbContext.Users.FindOne(user.Id);
        Assert.AreEqual(updatedUser1.Name, name1, "未成功更新用户。");

        // 更新用户2
        var name2 = $"虚竹{Guid.NewGuid().ToString()}";
        dbContext.Users.UpdateOne(r => r.Id == user.Id, Builders<User>.Update.Set(u => u.Name, name2));

        // 验证更新是否成功
        var updatedUser2 = dbContext.Users.FindOne(user.Id);
        Assert.AreEqual(updatedUser2.Name, name2, "未成功更新用户。");

        // 更新用户3
        var name3 = $"段誉{Guid.NewGuid().ToString()}";
        dbContext.Users.UpdateOne(Builders<User>.Filter.Eq(f => f.Id, user.Id), Builders<User>.Update.Set(u => u.Name, name3));

        var updatedUser3 = dbContext.Users.FindOne(user.Id);
        Assert.AreEqual(updatedUser3.Name, name3, "未成功更新用户。");


        // 删除用户
        var result = dbContext.Users.DeleteOne(user);

        // 验证删除是否成功
        var deletedUser = dbContext.Users.FindOne(user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public async Task TestUpdateOneAsync()
    {
        var user = DataHelper.GetNewUser();
        await dbContext.Users.AddAsync(user);

        // 验证添加是否成功
        var addedUser = await dbContext.Users.FindOneAsync(user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 更新用户1
        var name1 = $"乔峰{Guid.NewGuid().ToString()}";
        await dbContext.Users.UpdateOneAsync(user.Id, Builders<User>.Update.Set(u => u.Name, name1));

        // 验证更新是否成功
        var updatedUser1 = dbContext.Users.FindOne(user.Id);
        Assert.AreEqual(updatedUser1.Name, name1, "未成功更新用户。");

        // 更新用户2
        var name2 = $"虚竹{Guid.NewGuid().ToString()}";
        await dbContext.Users.UpdateOneAsync(r => r.Id == user.Id, Builders<User>.Update.Set(u => u.Name, name2));

        // 验证更新是否成功
        var updatedUser2 = dbContext.Users.FindOne(user.Id);
        Assert.AreEqual(updatedUser2.Name, name2, "未成功更新用户。");

        // 更新用户3
        var name3 = $"段誉{Guid.NewGuid().ToString()}";
        await dbContext.Users.UpdateOneAsync(Builders<User>.Filter.Eq(f => f.Id, user.Id), Builders<User>.Update.Set(u => u.Name, name3));

        var updatedUser3 = dbContext.Users.FindOne(user.Id);
        Assert.AreEqual(updatedUser3.Name, name3, "未成功更新用户。");


        // 删除用户
        var result = await dbContext.Users.DeleteOneAsync(user);

        // 验证删除是否成功
        var deletedUser = await dbContext.Users.FindOneAsync(user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public void TestUpdateOneSession()
    {
        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            var user = DataHelper.GetNewUser();

            dbContext.Users.Add(session, user);

            // 验证添加是否成功
            var addedUser = dbContext.Users.FindOne(session, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 更新用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            dbContext.Users.UpdateOne(session, user.Id, Builders<User>.Update.Set(u => u.Name, name1));

            // 验证更新是否成功
            var updatedUser1 = dbContext.Users.FindOne(session, user.Id);
            Assert.AreEqual(updatedUser1.Name, name1, "未成功更新用户。");

            // 更新用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            dbContext.Users.UpdateOne(session, r => r.Id == user.Id, Builders<User>.Update.Set(u => u.Name, name2));

            // 验证更新是否成功
            var updatedUser2 = dbContext.Users.FindOne(session, user.Id);
            Assert.AreEqual(updatedUser2.Name, name2, "未成功更新用户。");

            // 更新用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            dbContext.Users.UpdateOne(session, Builders<User>.Filter.Eq(f => f.Id, user.Id), Builders<User>.Update.Set(u => u.Name, name3));

            var updatedUser3 = dbContext.Users.FindOne(session, user.Id);
            Assert.AreEqual(updatedUser3.Name, name3, "未成功更新用户。");


            // 删除用户
            var result = dbContext.Users.DeleteOne(session, user);

            // 验证删除是否成功
            var deletedUser = dbContext.Users.FindOne(session, user.Id);
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

            await dbContext.Users.AddAsync(session, user);

            // 验证添加是否成功
            var addedUser = await dbContext.Users.FindOneAsync(session, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 更新用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            await dbContext.Users.UpdateOneAsync(session, user.Id, Builders<User>.Update.Set(u => u.Name, name1));

            // 验证更新是否成功
            var updatedUser1 = await dbContext.Users.FindOneAsync(session, user.Id);
            Assert.AreEqual(updatedUser1.Name, name1, "未成功更新用户。");

            // 更新用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            await dbContext.Users.UpdateOneAsync(session, r => r.Id == user.Id, Builders<User>.Update.Set(u => u.Name, name2));

            // 验证更新是否成功
            var updatedUser2 = await dbContext.Users.FindOneAsync(session, user.Id);
            Assert.AreEqual(updatedUser2.Name, name2, "未成功更新用户。");

            // 更新用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            await dbContext.Users.UpdateOneAsync(session, Builders<User>.Filter.Eq(f => f.Id, user.Id), Builders<User>.Update.Set(u => u.Name, name3));

            var updatedUser3 = await dbContext.Users.FindOneAsync(session, user.Id);
            Assert.AreEqual(updatedUser3.Name, name3, "未成功更新用户。");


            // 删除用户
            var result = await dbContext.Users.DeleteOneAsync(session, user);

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.FindOneAsync(session, user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public void TestUpdateOneDynamic()
    {
        var user = DataHelper.GetNewUser();
        var userGroup = DataHelper.GetNewUserGroup();
        dbContext.Users.DynamicCollectionAdd(userGroup, user);

        // 验证添加是否成功
        var addedUser = dbContext.Users.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 更新用户1
        var name1 = $"乔峰{Guid.NewGuid().ToString()}";
        dbContext.Users.DynamicCollectionUpdateOne(userGroup, user.Id, Builders<User>.Update.Set(u => u.Name, name1));

        // 验证更新是否成功
        var updatedUser1 = dbContext.Users.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.AreEqual(updatedUser1.Name, name1, "未成功更新用户。");

        // 更新用户2
        var name2 = $"虚竹{Guid.NewGuid().ToString()}";
        dbContext.Users.DynamicCollectionUpdateOne(userGroup, r => r.Id == user.Id, Builders<User>.Update.Set(u => u.Name, name2));

        // 验证更新是否成功
        var updatedUser2 = dbContext.Users.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.AreEqual(updatedUser2.Name, name2, "未成功更新用户。");

        // 更新用户3
        var name3 = $"段誉{Guid.NewGuid().ToString()}";
        dbContext.Users.DynamicCollectionUpdateOne(userGroup, Builders<User>.Filter.Eq(f => f.Id, user.Id), Builders<User>.Update.Set(u => u.Name, name3));

        var updatedUser3 = dbContext.Users.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.AreEqual(updatedUser3.Name, name3, "未成功更新用户。");


        // 删除用户
        var result = dbContext.Users.DynamicCollectionDeleteOne(userGroup, user);

        // 验证删除是否成功
        var deletedUser = dbContext.Users.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public async Task TestUpdateOneDynamicAsync()
    {
        var user = DataHelper.GetNewUser();
        var userGroup = DataHelper.GetNewUserGroup();
        await dbContext.Users.DynamicCollectionAddAsync(userGroup, user);

        // 验证添加是否成功
        var addedUser = await dbContext.Users.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 更新用户1
        var name1 = $"乔峰{Guid.NewGuid().ToString()}";
        await dbContext.Users.DynamicCollectionUpdateOneAsync(userGroup, user.Id, Builders<User>.Update.Set(u => u.Name, name1));

        // 验证更新是否成功
        var updatedUser1 = await dbContext.Users.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.AreEqual(updatedUser1.Name, name1, "未成功更新用户。");

        // 更新用户2
        var name2 = $"虚竹{Guid.NewGuid().ToString()}";
        await dbContext.Users.DynamicCollectionUpdateOneAsync(userGroup, r => r.Id == user.Id, Builders<User>.Update.Set(u => u.Name, name2));

        // 验证更新是否成功
        var updatedUser2 = await dbContext.Users.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.AreEqual(updatedUser2.Name, name2, "未成功更新用户。");

        // 更新用户3
        var name3 = $"段誉{Guid.NewGuid().ToString()}";
        await dbContext.Users.DynamicCollectionUpdateOneAsync(userGroup, Builders<User>.Filter.Eq(f => f.Id, user.Id), Builders<User>.Update.Set(u => u.Name, name3));

        var updatedUser3 = await dbContext.Users.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.AreEqual(updatedUser3.Name, name3, "未成功更新用户。");


        // 删除用户
        var result = await dbContext.Users.DynamicCollectionDeleteOneAsync(userGroup, user);

        // 验证删除是否成功
        var deletedUser = await dbContext.Users.DynamicCollectionFindOneAsync(userGroup, user.Id);
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

            dbContext.Users.DynamicCollectionAdd(session, userGroup, user);

            // 验证添加是否成功
            var addedUser = dbContext.Users.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 更新用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            dbContext.Users.DynamicCollectionUpdateOne(session, userGroup, user.Id, Builders<User>.Update.Set(u => u.Name, name1));

            // 验证更新是否成功
            var updatedUser1 = dbContext.Users.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.AreEqual(updatedUser1.Name, name1, "未成功更新用户。");

            // 更新用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            dbContext.Users.DynamicCollectionUpdateOne(session, userGroup, r => r.Id == user.Id, Builders<User>.Update.Set(u => u.Name, name2));

            // 验证更新是否成功
            var updatedUser2 = dbContext.Users.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.AreEqual(updatedUser2.Name, name2, "未成功更新用户。");

            // 更新用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            dbContext.Users.DynamicCollectionUpdateOne(session, userGroup, Builders<User>.Filter.Eq(f => f.Id, user.Id), Builders<User>.Update.Set(u => u.Name, name3));

            var updatedUser3 = dbContext.Users.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.AreEqual(updatedUser3.Name, name3, "未成功更新用户。");


            // 删除用户
            var result = dbContext.Users.DynamicCollectionDeleteOne(session, userGroup, user);

            // 验证删除是否成功
            var deletedUser = dbContext.Users.DynamicCollectionFindOne(session, userGroup, user.Id);
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

            await dbContext.Users.DynamicCollectionAddAsync(session, userGroup, user);

            // 验证添加是否成功
            var addedUser = await dbContext.Users.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 更新用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            await dbContext.Users.DynamicCollectionUpdateOneAsync(session, userGroup, user.Id, Builders<User>.Update.Set(u => u.Name, name1));

            // 验证更新是否成功
            var updatedUser1 = await dbContext.Users.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.AreEqual(updatedUser1.Name, name1, "未成功更新用户。");

            // 更新用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            await dbContext.Users.DynamicCollectionUpdateOneAsync(session, userGroup, r => r.Id == user.Id, Builders<User>.Update.Set(u => u.Name, name2));

            // 验证更新是否成功
            var updatedUser2 = await dbContext.Users.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.AreEqual(updatedUser2.Name, name2, "未成功更新用户。");

            // 更新用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            await dbContext.Users.DynamicCollectionUpdateOneAsync(session, userGroup, Builders<User>.Filter.Eq(f => f.Id, user.Id), Builders<User>.Update.Set(u => u.Name, name3));

            var updatedUser3 = await dbContext.Users.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.AreEqual(updatedUser3.Name, name3, "未成功更新用户。");


            // 删除用户
            var result = await dbContext.Users.DynamicCollectionDeleteOneAsync(session, userGroup, user);

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public void TestFindOneAndUpdateOne()
    {
        var user = DataHelper.GetNewUser();
        dbContext.Users.Add(user);

        // 验证添加是否成功
        var addedUser = dbContext.Users.FindOne(user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 更新用户1
        var name1 = $"乔峰{Guid.NewGuid().ToString()}";
        var result1 = dbContext.Users.FindOneAndUpdateOne(user.Id, Builders<User>.Update.Set(u => u.Name, name1));

        // 验证更新是否成功
        var updatedUser1 = dbContext.Users.FindOne(user.Id);
        Assert.AreNotEqual(updatedUser1.Name, result1.Name, "未成功更新用户。");


        // 更新用户2
        var name2 = $"虚竹{Guid.NewGuid().ToString()}";
        var result2 = dbContext.Users.FindOneAndUpdateOne(r => r.Id == user.Id, Builders<User>.Update.Set(u => u.Name, name2));

        // 验证更新是否成功
        var updatedUser2 = dbContext.Users.FindOne(user.Id);
        Assert.AreNotEqual(updatedUser2.Name, result2.Name, "未成功更新用户。");

        // 更新用户3
        var name3 = $"段誉{Guid.NewGuid().ToString()}";
        var result3 = dbContext.Users.FindOneAndUpdateOne(Builders<User>.Filter.Eq(f => f.Id, user.Id), Builders<User>.Update.Set(u => u.Name, name3));

        var updatedUser3 = dbContext.Users.FindOne(user.Id);
        Assert.AreNotEqual(updatedUser3.Name, result3.Name, "未成功更新用户。");

        // 删除用户
        var result = dbContext.Users.DeleteOne(user);

        // 验证删除是否成功
        var deletedUser = dbContext.Users.FindOne(user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public async Task TestFindOneAndUpdateOneAsync()
    {
        var user = DataHelper.GetNewUser();
        await dbContext.Users.AddAsync(user);

        // 验证添加是否成功
        var addedUser = await dbContext.Users.FindOneAsync(user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");

        // 更新用户1
        var name1 = $"乔峰{Guid.NewGuid().ToString()}";
        var result1 = await dbContext.Users.FindOneAndUpdateOneAsync(user.Id, Builders<User>.Update.Set(u => u.Name, name1));

        // 验证更新是否成功
        var replaceedUser1 = await dbContext.Users.FindOneAsync(user.Id);
        Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功更新用户。");


        // 更新用户2
        var name2 = $"虚竹{Guid.NewGuid().ToString()}";
        var result2 = await dbContext.Users.FindOneAndUpdateOneAsync(r => r.Id == user.Id, Builders<User>.Update.Set(u => u.Name, name2));

        // 验证更新是否成功
        var replaceedUser2 = await dbContext.Users.FindOneAsync(user.Id);
        Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功更新用户。");

        // 更新用户3
        var name3 = $"段誉{Guid.NewGuid().ToString()}";
        var result3 = await dbContext.Users.FindOneAndUpdateOneAsync(Builders<User>.Filter.Eq(f => f.Id, user.Id), Builders<User>.Update.Set(u => u.Name, name3));

        var replaceedUser3 = await dbContext.Users.FindOneAsync(user.Id);
        Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功更新用户。");


        // 删除用户
        var result = await dbContext.Users.DeleteOneAsync(user);

        // 验证删除是否成功
        var deletedUser = await dbContext.Users.FindOneAsync(user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public void TestFindOneAndUpdateOneSession()
    {
        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            var user = DataHelper.GetNewUser();

            dbContext.Users.Add(session, user);

            // 验证添加是否成功
            var addedUser = dbContext.Users.FindOne(session, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 更新用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            var result1 = dbContext.Users.FindOneAndUpdateOne(session, user.Id, Builders<User>.Update.Set(u => u.Name, name1));

            // 验证更新是否成功
            var replaceedUser1 = dbContext.Users.FindOne(session, user.Id);
            Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功更新用户。");


            // 更新用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            var result2 = dbContext.Users.FindOneAndUpdateOne(session, r => r.Id == user.Id, Builders<User>.Update.Set(u => u.Name, name2));

            // 验证更新是否成功
            var replaceedUser2 = dbContext.Users.FindOne(session, user.Id);
            Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功更新用户。");

            // 更新用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            var result3 = dbContext.Users.FindOneAndUpdateOne(session, Builders<User>.Filter.Eq(f => f.Id, user.Id), Builders<User>.Update.Set(u => u.Name, name3));

            var replaceedUser3 = dbContext.Users.FindOne(session, user.Id);
            Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功更新用户。");

            // 删除用户
            var result = dbContext.Users.DeleteOne(session, user);

            // 验证删除是否成功
            var deletedUser = dbContext.Users.FindOne(session, user.Id);
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

            await dbContext.Users.AddAsync(session, user);

            // 验证添加是否成功
            var addedUser = await dbContext.Users.FindOneAsync(session, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 更新用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            var result1 = await dbContext.Users.FindOneAndUpdateOneAsync(session, user.Id, Builders<User>.Update.Set(u => u.Name, name1));

            // 验证更新是否成功
            var replaceedUser1 = await dbContext.Users.FindOneAsync(session, user.Id);
            Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功更新用户。");


            // 更新用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            var result2 = await dbContext.Users.FindOneAndUpdateOneAsync(session, r => r.Id == user.Id, Builders<User>.Update.Set(u => u.Name, name2));

            // 验证更新是否成功
            var replaceedUser2 = await dbContext.Users.FindOneAsync(session, user.Id);
            Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功更新用户。");

            // 更新用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            var result3 = await dbContext.Users.FindOneAndUpdateOneAsync(session, Builders<User>.Filter.Eq(f => f.Id, user.Id), Builders<User>.Update.Set(u => u.Name, name3));

            var replaceedUser3 = await dbContext.Users.FindOneAsync(session, user.Id);
            Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功更新用户。");

            // 删除用户
            var result = await dbContext.Users.DeleteOneAsync(session, user);

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.FindOneAsync(session, user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public void TestFindOneAndUpdateOneDynamic()
    {
        var user = DataHelper.GetNewUser();
        var userGroup = DataHelper.GetNewUserGroup();
        dbContext.Users.DynamicCollectionAdd(userGroup, user);

        // 验证添加是否成功
        var addedUser = dbContext.Users.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 更新用户1
        var name1 = $"乔峰{Guid.NewGuid().ToString()}";
        var result1 = dbContext.Users.DynamicCollectionFindOneAndUpdateOne(userGroup, user.Id, Builders<User>.Update.Set(u => u.Name, name1));

        // 验证更新是否成功
        var replaceedUser1 = dbContext.Users.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功更新用户。");


        // 更新用户2
        var name2 = $"虚竹{Guid.NewGuid().ToString()}";
        var result2 = dbContext.Users.DynamicCollectionFindOneAndUpdateOne(userGroup, r => r.Id == user.Id, Builders<User>.Update.Set(u => u.Name, name2));

        // 验证更新是否成功
        var replaceedUser2 = dbContext.Users.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功更新用户。");

        // 更新用户3
        var name3 = $"段誉{Guid.NewGuid().ToString()}";
        var result3 = dbContext.Users.DynamicCollectionFindOneAndUpdateOne(userGroup, Builders<User>.Filter.Eq(f => f.Id, user.Id), Builders<User>.Update.Set(u => u.Name, name3));

        var replaceedUser3 = dbContext.Users.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功更新用户。");

        // 删除用户
        var result = dbContext.Users.DynamicCollectionDeleteOne(userGroup, user);

        // 验证删除是否成功
        var deletedUser = dbContext.Users.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public async Task TestFindOneAndUpdateOneDynamicAsync()
    {
        var user = DataHelper.GetNewUser();
        var userGroup = DataHelper.GetNewUserGroup();
        await dbContext.Users.DynamicCollectionAddAsync(userGroup, user);

        // 验证添加是否成功
        var addedUser = await dbContext.Users.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 更新用户1
        var name1 = $"乔峰{Guid.NewGuid().ToString()}";
        var result1 = await dbContext.Users.DynamicCollectionFindOneAndUpdateOneAsync(userGroup, user.Id, Builders<User>.Update.Set(u => u.Name, name1));

        // 验证更新是否成功
        var replaceedUser1 = await dbContext.Users.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功更新用户。");


        // 更新用户2
        var name2 = $"虚竹{Guid.NewGuid().ToString()}";
        var result2 = await dbContext.Users.DynamicCollectionFindOneAndUpdateOneAsync(userGroup, r => r.Id == user.Id, Builders<User>.Update.Set(u => u.Name, name2));

        // 验证更新是否成功
        var replaceedUser2 = await dbContext.Users.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功更新用户。");

        // 更新用户3
        var name3 = $"段誉{Guid.NewGuid().ToString()}";
        var result3 = await dbContext.Users.DynamicCollectionFindOneAndUpdateOneAsync(userGroup, Builders<User>.Filter.Eq(f => f.Id, user.Id), Builders<User>.Update.Set(u => u.Name, name3));

        var replaceedUser3 = await dbContext.Users.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功更新用户。");

        // 删除用户
        var result = await dbContext.Users.DynamicCollectionDeleteOneAsync(userGroup, user);

        // 验证删除是否成功
        var deletedUser = await dbContext.Users.DynamicCollectionFindOneAsync(userGroup, user.Id);
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

            dbContext.Users.DynamicCollectionAdd(session, userGroup, user);

            // 验证添加是否成功
            var addedUser = dbContext.Users.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 更新用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            var result1 = dbContext.Users.DynamicCollectionFindOneAndUpdateOne(session, userGroup, user.Id, Builders<User>.Update.Set(u => u.Name, name1));

            // 验证更新是否成功
            var replaceedUser1 = dbContext.Users.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功更新用户。");


            // 更新用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            var result2 = dbContext.Users.DynamicCollectionFindOneAndUpdateOne(session, userGroup, r => r.Id == user.Id, Builders<User>.Update.Set(u => u.Name, name2));

            // 验证更新是否成功
            var replaceedUser2 = dbContext.Users.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功更新用户。");

            // 更新用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            var result3 = dbContext.Users.DynamicCollectionFindOneAndUpdateOne(session, userGroup, Builders<User>.Filter.Eq(f => f.Id, user.Id), Builders<User>.Update.Set(u => u.Name, name3));

            var replaceedUser3 = dbContext.Users.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功更新用户。");

            // 删除用户
            var result = dbContext.Users.DynamicCollectionDeleteOne(session, userGroup, user);

            // 验证删除是否成功
            var deletedUser = dbContext.Users.DynamicCollectionFindOne(session, userGroup, user.Id);
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

            await dbContext.Users.DynamicCollectionAddAsync(session, userGroup, user);

            // 验证添加是否成功
            var addedUser = await dbContext.Users.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 更新用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            user.Name = name1;
            var result1 = await dbContext.Users.DynamicCollectionFindOneAndUpdateOneAsync(session, userGroup, user.Id, Builders<User>.Update.Set(u => u.Name, name1));

            // 验证更新是否成功
            var replaceedUser1 = await dbContext.Users.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功更新用户。");


            // 更新用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            user.Name = name2;
            var result2 = await dbContext.Users.DynamicCollectionFindOneAndUpdateOneAsync(session, userGroup, r => r.Id == user.Id, Builders<User>.Update.Set(u => u.Name, name2));

            // 验证更新是否成功
            var replaceedUser2 = await dbContext.Users.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功更新用户。");

            // 更新用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            user.Name = name3;
            var result3 = await dbContext.Users.DynamicCollectionFindOneAndUpdateOneAsync(session, userGroup, Builders<User>.Filter.Eq(f => f.Id, user.Id), Builders<User>.Update.Set(u => u.Name, name3));

            var replaceedUser3 = await dbContext.Users.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功更新用户。");

            // 删除用户
            var result = await dbContext.Users.DynamicCollectionDeleteOneAsync(session, userGroup, user);

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public void TestUpdateMany()
    {
        var users = DataHelper.GetNewUsers();

        dbContext.Users.AddMany(users);

        // 验证添加是否成功
        var addedUserCount = dbContext.Users.Find(w => w.Email == "zhangfei@qq.com").CountDocuments();
        Assert.AreEqual(3, addedUserCount, "未成功添加，数量不正确");

        //验证更新是否成功
        var result1 = dbContext.Users.UpdateMany(u => u.Email == "zhangfei@qq.com", Builders<User>.Update.Set(s => s.Description, Guid.NewGuid().ToString()));
        Assert.AreEqual(3, result1.ModifiedCount, "未成功更新，数量不正确");

        //验证更新是否成功
        var result2 = dbContext.Users.UpdateMany(Builders<User>.Filter.Eq(f => f.Email, "zhangfei@qq.com"), Builders<User>.Update.Set(s => s.Description, Guid.NewGuid().ToString()));
        Assert.AreEqual(3, result2.ModifiedCount, "未成功更新，数量不正确");

        // 删除用户
        var result = dbContext.Users.DeleteMany(users);

        // 验证删除是否成功
        var deletedUserCount = dbContext.Users.Find(w => true).CountDocuments();
        Assert.AreEqual(0, deletedUserCount, "用户未成功删除。");
    }

    [TestMethod]
    public async Task TestUpdateManyAsync()
    {
        var users = DataHelper.GetNewUsers();
        await dbContext.Users.AddManyAsync(users);

        // 验证添加是否成功
        List<User> addedUser = new();
        await foreach (var user in dbContext.Users.FindAsync(w => w.Email == "zhangfei@qq.com"))
        {
            addedUser.Add(user);
        }
        Assert.AreEqual(3, addedUser.Count, "未成功添加，数量不正确");

        //验证更新是否成功
        var result1 = await dbContext.Users.UpdateManyAsync(u => u.Email == "zhangfei@qq.com", Builders<User>.Update.Set(s => s.Description, Guid.NewGuid().ToString()));
        Assert.AreEqual(3, result1.ModifiedCount, "未成功更新，数量不正确");

        //验证更新是否成功
        var result2 = await dbContext.Users.UpdateManyAsync(Builders<User>.Filter.Eq(f => f.Email, "zhangfei@qq.com"), Builders<User>.Update.Set(s => s.Description, Guid.NewGuid().ToString()));
        Assert.AreEqual(3, result2.ModifiedCount, "未成功更新，数量不正确");

        // 删除用户
        var result = await dbContext.Users.DeleteManyAsync(users);

        // 验证删除是否成功
        var deletedUserCount = dbContext.Users.Find(w => true).CountDocuments();
        Assert.AreEqual(0, deletedUserCount, "用户未成功删除。");
    }

    [TestMethod]
    public void TestUpdateManySession()
    {
        var users = DataHelper.GetNewUsers();

        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            dbContext.Users.AddMany(session, users);

            // 验证添加是否成功
            var addedUserCount = dbContext.Users.Find(session, w => w.Email == "zhangfei@qq.com").CountDocuments();
            Assert.AreEqual(3, addedUserCount, "未成功添加，数量不正确");

            //验证更新是否成功
            var result1 = dbContext.Users.UpdateMany(session, u => u.Email == "zhangfei@qq.com", Builders<User>.Update.Set(s => s.Description, Guid.NewGuid().ToString()));
            Assert.AreEqual(3, result1.ModifiedCount, "未成功更新，数量不正确");

            //验证更新是否成功
            var result2 = dbContext.Users.UpdateMany(session, Builders<User>.Filter.Eq(f => f.Email, "zhangfei@qq.com"), Builders<User>.Update.Set(s => s.Description, Guid.NewGuid().ToString()));
            Assert.AreEqual(3, result2.ModifiedCount, "未成功更新，数量不正确");

            // 删除用户
            var result = dbContext.Users.DeleteMany(session, users);

            // 验证删除是否成功
            var deletedUserCount = dbContext.Users.Find(session, w => true).CountDocuments();
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
            await dbContext.Users.AddManyAsync(session, users);

            // 验证添加是否成功
            List<User> addedUser = new();
            await foreach (var user in dbContext.Users.FindAsync(session, w => w.Email == "zhangfei@qq.com"))
            {
                addedUser.Add(user);
            }
            Assert.AreEqual(3, addedUser.Count, "未成功添加，数量不正确");

            //验证更新是否成功
            var result1 = await dbContext.Users.UpdateManyAsync(session, u => u.Email == "zhangfei@qq.com", Builders<User>.Update.Set(s => s.Description, Guid.NewGuid().ToString()));
            Assert.AreEqual(3, result1.ModifiedCount, "未成功更新，数量不正确");

            //验证更新是否成功
            var result2 = await dbContext.Users.UpdateManyAsync(session, Builders<User>.Filter.Eq(f => f.Email, "zhangfei@qq.com"), Builders<User>.Update.Set(s => s.Description, Guid.NewGuid().ToString()));
            Assert.AreEqual(3, result2.ModifiedCount, "未成功更新，数量不正确");

            // 删除用户
            var result = await dbContext.Users.DeleteManyAsync(session, users);

            // 验证删除是否成功
            var deletedUserCount = dbContext.Users.Find(session, w => true).CountDocuments();
            Assert.AreEqual(0, deletedUserCount, "用户未成功删除。");

            await session.CommitTransactionAsync();
        }
    }

    [TestMethod]
    public void TestUpdateManyDynamic()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        var users = DataHelper.GetNewUsers();

        dbContext.Users.DynamicCollectionAddMany(userGroup, users);

        // 验证添加是否成功
        var addedUserCount = dbContext.Users.DynamicCollectionFind(userGroup, w => w.Email == "zhangfei@qq.com").CountDocuments();
        Assert.AreEqual(3, addedUserCount, "未成功添加，数量不正确");

        //验证更新是否成功
        var result1 = dbContext.Users.DynamicCollectionUpdateMany(userGroup, u => u.Email == "zhangfei@qq.com", Builders<User>.Update.Set(s => s.Description, Guid.NewGuid().ToString()));
        Assert.AreEqual(3, result1.ModifiedCount, "未成功更新，数量不正确");

        //验证更新是否成功
        var result2 = dbContext.Users.DynamicCollectionUpdateMany(userGroup, Builders<User>.Filter.Eq(f => f.Email, "zhangfei@qq.com"), Builders<User>.Update.Set(s => s.Description, Guid.NewGuid().ToString()));
        Assert.AreEqual(3, result2.ModifiedCount, "未成功更新，数量不正确");

        // 删除用户
        var result = dbContext.Users.DynamicCollectionDeleteMany(userGroup, users);

        // 验证删除是否成功
        var deletedUserCount = dbContext.Users.DynamicCollectionFind(userGroup, w => true).CountDocuments();
        Assert.AreEqual(0, deletedUserCount, "用户未成功删除。");
    }

    [TestMethod]
    public async Task TestUpdateManyDynamicAsync()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        var users = DataHelper.GetNewUsers();

        await dbContext.Users.DynamicCollectionAddManyAsync(userGroup, users);

        // 验证添加是否成功
        List<User> addedUser = new();
        await foreach (var user in dbContext.Users.DynamicCollectionFindAsync(userGroup, w => w.Email == "zhangfei@qq.com"))
        {
            addedUser.Add(user);
        }
        Assert.AreEqual(3, addedUser.Count, "未成功添加，数量不正确");

        //验证更新是否成功
        var result1 = await dbContext.Users.DynamicCollectionUpdateManyAsync(userGroup, u => u.Email == "zhangfei@qq.com", Builders<User>.Update.Set(s => s.Description, Guid.NewGuid().ToString()));
        Assert.AreEqual(3, result1.ModifiedCount, "未成功更新，数量不正确");

        //验证更新是否成功
        var result2 = await dbContext.Users.DynamicCollectionUpdateManyAsync(userGroup, Builders<User>.Filter.Eq(f => f.Email, "zhangfei@qq.com"), Builders<User>.Update.Set(s => s.Description, Guid.NewGuid().ToString()));
        Assert.AreEqual(3, result2.ModifiedCount, "未成功更新，数量不正确");

        // 删除用户
        var result = await dbContext.Users.DynamicCollectionDeleteManyAsync(userGroup, users);

        // 验证删除是否成功
        var deletedUserCount = dbContext.Users.DynamicCollectionFind(userGroup, w => true).CountDocuments();
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

            dbContext.Users.DynamicCollectionAddMany(session, userGroup, users);

            // 验证添加是否成功
            var addedUserCount = dbContext.Users.DynamicCollectionFind(session, userGroup, w => w.Email == "zhangfei@qq.com").CountDocuments();
            Assert.AreEqual(3, addedUserCount, "未成功添加，数量不正确");

            //验证更新是否成功
            var result1 = dbContext.Users.DynamicCollectionUpdateMany(session, userGroup, u => u.Email == "zhangfei@qq.com", Builders<User>.Update.Set(s => s.Description, Guid.NewGuid().ToString()));
            Assert.AreEqual(3, result1.ModifiedCount, "未成功更新，数量不正确");

            //验证更新是否成功
            var result2 = dbContext.Users.DynamicCollectionUpdateMany(session, userGroup, Builders<User>.Filter.Eq(f => f.Email, "zhangfei@qq.com"), Builders<User>.Update.Set(s => s.Description, Guid.NewGuid().ToString()));
            Assert.AreEqual(3, result2.ModifiedCount, "未成功更新，数量不正确");

            // 删除用户
            var result = dbContext.Users.DynamicCollectionDeleteMany(session, userGroup, users);

            // 验证删除是否成功
            var deletedUserCount = dbContext.Users.DynamicCollectionFind(session, userGroup, w => true).CountDocuments();
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
            await dbContext.Users.DynamicCollectionAddManyAsync(session, userGroup, users);

            // 验证添加是否成功
            List<User> addedUser = new();
            await foreach (var user in dbContext.Users.DynamicCollectionFindAsync(session, userGroup, w => w.Email == "zhangfei@qq.com"))
            {
                addedUser.Add(user);
            }
            Assert.AreEqual(3, addedUser.Count, "未成功添加，数量不正确");

            //验证更新是否成功
            var result1 = await dbContext.Users.DynamicCollectionUpdateManyAsync(session, userGroup, u => u.Email == "zhangfei@qq.com", Builders<User>.Update.Set(s => s.Description, Guid.NewGuid().ToString()));
            Assert.AreEqual(3, result1.ModifiedCount, "未成功更新，数量不正确");

            //验证更新是否成功
            var result2 = await dbContext.Users.DynamicCollectionUpdateManyAsync(session, userGroup, Builders<User>.Filter.Eq(f => f.Email, "zhangfei@qq.com"), Builders<User>.Update.Set(s => s.Description, Guid.NewGuid().ToString()));
            Assert.AreEqual(3, result2.ModifiedCount, "未成功更新，数量不正确");

            // 删除用户
            var result = await dbContext.Users.DynamicCollectionDeleteManyAsync(session, userGroup, users);

            // 验证删除是否成功
            var deletedUserCount = dbContext.Users.DynamicCollectionFind(session, userGroup, w => true).CountDocuments();
            Assert.AreEqual(0, deletedUserCount, "用户未成功删除。");
        }
    }
}
