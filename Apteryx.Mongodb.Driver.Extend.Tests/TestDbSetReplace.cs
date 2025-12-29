using MongoDB.Driver;
using Apteryx.Mongodb.Driver.Extend.Tests.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Apteryx.Mongodb.Driver.Extend.Tests;

[TestClass]
public class TestDbSetReplace : TestBase
{
    private readonly ApteryxDbContext? dbContext;

    [TestInitialize]
    public void TestInitialize()
    {
        // 确保 dbContext 不为 null
        Assert.IsNotNull(dbContext, "无法从服务提供程序获取ApteryxDbContext。"); ;
    }

    public TestDbSetReplace()
    {
        this.dbContext = ServiceProvider.GetService<ApteryxDbContext>();
    }

    [TestMethod]
    public void TestReplaceOne()
    {
        var user = DataHelper.GetNewUser();
        dbContext.Users.Commands.Insert(user);

        // 验证添加是否成功
        var addedUser = dbContext.Users.Commands.FindOne(user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 替换用户1
        var name1 = $"乔峰{Guid.NewGuid().ToString()}";
        user.Name = name1;
        dbContext.Users.Commands.ReplaceOne(user.Id, user);

        // 验证替换是否成功
        var replaceedUser1 = dbContext.Users.Commands.FindOne(user.Id);
        Assert.AreEqual(replaceedUser1.Name, name1, "未成功替换用户。");


        // 替换用户2
        var name2 = $"虚竹{Guid.NewGuid().ToString()}";
        user.Name = name2;
        dbContext.Users.Commands.ReplaceOne(r => r.Id == user.Id, user);

        // 验证替换是否成功
        var replaceedUser2 = dbContext.Users.Commands.FindOne(user.Id);
        Assert.AreEqual(replaceedUser2.Name, name2, "未成功替换用户。");

        // 替换用户3
        var name3 = $"段誉{Guid.NewGuid().ToString()}";
        user.Name = name3;
        dbContext.Users.Commands.ReplaceOne(Builders<User>.Filter.Eq(f => f.Id, user.Id), user);

        var replaceedUser3 = dbContext.Users.Commands.FindOne(user.Id);
        Assert.AreEqual(replaceedUser3.Name, name3, "未成功替换用户。");

        // 删除用户
        var result = dbContext.Users.Commands.DeleteOne(user);

        // 验证删除是否成功
        var deletedUser = dbContext.Users.Commands.FindOne(user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public async Task TestReplaceOneAsync()
    {
        var user = DataHelper.GetNewUser();
        await dbContext.Users.Commands.InsertAsync(user);

        // 验证添加是否成功
        var addedUser = await dbContext.Users.Commands.FindOneAsync(user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");

        // 替换用户1
        var name1 = $"乔峰{Guid.NewGuid().ToString()}";
        user.Name = name1;
        await dbContext.Users.Commands.ReplaceOneAsync(user.Id, user);

        // 验证替换是否成功
        var replaceedUser1 = await dbContext.Users.Commands.FindOneAsync(user.Id);
        Assert.AreEqual(replaceedUser1.Name, name1, "未成功替换用户。");


        // 替换用户2
        var name2 = $"虚竹{Guid.NewGuid().ToString()}";
        user.Name = name2;
        await dbContext.Users.Commands.ReplaceOneAsync(r => r.Id == user.Id, user);

        // 验证替换是否成功
        var replaceedUser2 = await dbContext.Users.Commands.FindOneAsync(user.Id);
        Assert.AreEqual(replaceedUser2.Name, name2, "未成功替换用户。");

        // 替换用户3
        var name3 = $"段誉{Guid.NewGuid().ToString()}";
        user.Name = name3;
        await dbContext.Users.Commands.ReplaceOneAsync(Builders<User>.Filter.Eq(f => f.Id, user.Id), user);

        var replaceedUser3 = await dbContext.Users.Commands.FindOneAsync(user.Id);
        Assert.AreEqual(replaceedUser3.Name, name3, "未成功替换用户。");

        // 删除用户
        var result = await dbContext.Users.Commands.DeleteOneAsync(user);

        // 验证删除是否成功
        var deletedUser = await dbContext.Users.Commands.FindOneAsync(user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public void TestReplaceOneSession()
    {
        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            var user = DataHelper.GetNewUser();

            dbContext.Users.Commands.Insert(session, user);

            // 验证添加是否成功
            var addedUser = dbContext.Users.Commands.FindOne(session, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 替换用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            user.Name = name1;
            dbContext.Users.Commands.ReplaceOne(session, user.Id, user);

            // 验证替换是否成功
            var replaceedUser1 = dbContext.Users.Commands.FindOne(session, user.Id);
            Assert.AreEqual(replaceedUser1.Name, name1, "未成功替换用户。");


            // 替换用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            user.Name = name2;
            dbContext.Users.Commands.ReplaceOne(session, r => r.Id == user.Id, user);

            // 验证替换是否成功
            var replaceedUser2 = dbContext.Users.Commands.FindOne(session, user.Id);
            Assert.AreEqual(replaceedUser2.Name, name2, "未成功替换用户。");

            // 替换用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            user.Name = name3;
            dbContext.Users.Commands.ReplaceOne(session, Builders<User>.Filter.Eq(f => f.Id, user.Id), user);

            var replaceedUser3 = dbContext.Users.Commands.FindOne(session, user.Id);
            Assert.AreEqual(replaceedUser3.Name, name3, "未成功替换用户。");

            // 删除用户
            var result = dbContext.Users.Commands.DeleteOne(session, user);

            // 验证删除是否成功
            var deletedUser = dbContext.Users.Commands.FindOne(session, user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public async Task TestReplaceOneSessionAsync()
    {
        using (var session = await dbContext.Client.StartSessionAsync())
        {
            session.StartTransaction();

            var user = DataHelper.GetNewUser();

            await dbContext.Users.Commands.InsertAsync(session, user);

            // 验证添加是否成功
            var addedUser = await dbContext.Users.Commands.FindOneAsync(session, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 替换用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            user.Name = name1;
            await dbContext.Users.Commands.ReplaceOneAsync(session, user.Id, user);

            // 验证替换是否成功
            var replaceedUser1 = await dbContext.Users.Commands.FindOneAsync(session, user.Id);
            Assert.AreEqual(replaceedUser1.Name, name1, "未成功替换用户。");


            // 替换用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            user.Name = name2;
            await dbContext.Users.Commands.ReplaceOneAsync(session, r => r.Id == user.Id, user);

            // 验证替换是否成功
            var replaceedUser2 = await dbContext.Users.Commands.FindOneAsync(session, user.Id);
            Assert.AreEqual(replaceedUser2.Name, name2, "未成功替换用户。");

            // 替换用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            user.Name = name3;
            await dbContext.Users.Commands.ReplaceOneAsync(session, Builders<User>.Filter.Eq(f => f.Id, user.Id), user);

            var replaceedUser3 = await dbContext.Users.Commands.FindOneAsync(session, user.Id);
            Assert.AreEqual(replaceedUser3.Name, name3, "未成功替换用户。");

            // 删除用户
            var result = await dbContext.Users.Commands.DeleteOneAsync(session, user);

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.Commands.FindOneAsync(session, user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public void TestReplaceOneDynamic()
    {
        var user = DataHelper.GetNewUser();
        var userGroup = DataHelper.GetNewUserGroup();
        dbContext.Users.Commands.DynamicCollectionInsert(userGroup, user);

        // 验证添加是否成功
        var addedUser = dbContext.Users.Commands.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 替换用户1
        var name1 = $"乔峰{Guid.NewGuid().ToString()}";
        user.Name = name1;
        dbContext.Users.Commands.DynamicCollectionReplaceOne(userGroup, user.Id, user);

        // 验证替换是否成功
        var replaceedUser1 = dbContext.Users.Commands.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.AreEqual(replaceedUser1.Name, name1, "未成功替换用户。");


        // 替换用户2
        var name2 = $"虚竹{Guid.NewGuid().ToString()}";
        user.Name = name2;
        dbContext.Users.Commands.DynamicCollectionReplaceOne(userGroup, r => r.Id == user.Id, user);

        // 验证替换是否成功
        var replaceedUser2 = dbContext.Users.Commands.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.AreEqual(replaceedUser2.Name, name2, "未成功替换用户。");

        // 替换用户3
        var name3 = $"段誉{Guid.NewGuid().ToString()}";
        user.Name = name3;
        dbContext.Users.Commands.DynamicCollectionReplaceOne(userGroup, Builders<User>.Filter.Eq(f => f.Id, user.Id), user);

        var replaceedUser3 = dbContext.Users.Commands.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.AreEqual(replaceedUser3.Name, name3, "未成功替换用户。");

        // 删除用户
        var result = dbContext.Users.Commands.DynamicCollectionDeleteOne(userGroup, user);

        // 验证删除是否成功
        var deletedUser = dbContext.Users.Commands.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public async Task TestReplaceOneDynamicAsync()
    {
        var user = DataHelper.GetNewUser();
        var userGroup = DataHelper.GetNewUserGroup();
        await dbContext.Users.Commands.DynamicCollectionInsertAsync(userGroup, user);

        // 验证添加是否成功
        var addedUser = await dbContext.Users.Commands.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 替换用户1
        var name1 = $"乔峰{Guid.NewGuid().ToString()}";
        user.Name = name1;
        await dbContext.Users.Commands.DynamicCollectionReplaceOneAsync(userGroup, user.Id, user);

        // 验证替换是否成功
        var replaceedUser1 = await dbContext.Users.Commands.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.AreEqual(replaceedUser1.Name, name1, "未成功替换用户。");


        // 替换用户2
        var name2 = $"虚竹{Guid.NewGuid().ToString()}";
        user.Name = name2;
        await dbContext.Users.Commands.DynamicCollectionReplaceOneAsync(userGroup, r => r.Id == user.Id, user);

        // 验证替换是否成功
        var replaceedUser2 = await dbContext.Users.Commands.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.AreEqual(replaceedUser2.Name, name2, "未成功替换用户。");

        // 替换用户3
        var name3 = $"段誉{Guid.NewGuid().ToString()}";
        user.Name = name3;
        await dbContext.Users.Commands.DynamicCollectionReplaceOneAsync(userGroup, Builders<User>.Filter.Eq(f => f.Id, user.Id), user);

        var replaceedUser3 = await dbContext.Users.Commands.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.AreEqual(replaceedUser3.Name, name3, "未成功替换用户。");

        // 删除用户
        var result = await dbContext.Users.Commands.DynamicCollectionDeleteOneAsync(userGroup, user);

        // 验证删除是否成功
        var deletedUser = await dbContext.Users.Commands.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public void TestReplaceOneDynamicSession()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            var user = DataHelper.GetNewUser();

            dbContext.Users.Commands.DynamicCollectionInsert(session, userGroup, user);

            // 验证添加是否成功
            var addedUser = dbContext.Users.Commands.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 替换用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            user.Name = name1;
            dbContext.Users.Commands.DynamicCollectionReplaceOne(session, userGroup, user.Id, user);

            // 验证替换是否成功
            var replaceedUser1 = dbContext.Users.Commands.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.AreEqual(replaceedUser1.Name, name1, "未成功替换用户。");


            // 替换用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            user.Name = name2;
            dbContext.Users.Commands.DynamicCollectionReplaceOne(session, userGroup, r => r.Id == user.Id, user);

            // 验证替换是否成功
            var replaceedUser2 = dbContext.Users.Commands.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.AreEqual(replaceedUser2.Name, name2, "未成功替换用户。");

            // 替换用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            user.Name = name3;
            dbContext.Users.Commands.DynamicCollectionReplaceOne(session, userGroup, Builders<User>.Filter.Eq(f => f.Id, user.Id), user);

            var replaceedUser3 = dbContext.Users.Commands.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.AreEqual(replaceedUser3.Name, name3, "未成功替换用户。");

            // 删除用户
            var result = dbContext.Users.Commands.DynamicCollectionDeleteOne(session, userGroup, user);

            // 验证删除是否成功
            var deletedUser = dbContext.Users.Commands.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public async Task TestReplaceOneDynamicSessionAsync()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        using (var session = await dbContext.Client.StartSessionAsync())
        {
            session.StartTransaction();

            var user = DataHelper.GetNewUser();

            await dbContext.Users.Commands.DynamicCollectionInsertAsync(session, userGroup, user);

            // 验证添加是否成功
            var addedUser = await dbContext.Users.Commands.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 替换用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            user.Name = name1;
            await dbContext.Users.Commands.DynamicCollectionReplaceOneAsync(session, userGroup, user.Id, user);

            // 验证替换是否成功
            var replaceedUser1 = await dbContext.Users.Commands.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.AreEqual(replaceedUser1.Name, name1, "未成功替换用户。");


            // 替换用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            user.Name = name2;
            await dbContext.Users.Commands.DynamicCollectionReplaceOneAsync(session, userGroup, r => r.Id == user.Id, user);

            // 验证替换是否成功
            var replaceedUser2 = await dbContext.Users.Commands.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.AreEqual(replaceedUser2.Name, name2, "未成功替换用户。");

            // 替换用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            user.Name = name3;
            await dbContext.Users.Commands.DynamicCollectionReplaceOneAsync(session, userGroup, Builders<User>.Filter.Eq(f => f.Id, user.Id), user);

            // 删除用户
            var result = await dbContext.Users.Commands.DynamicCollectionDeleteOneAsync(session, userGroup, user);

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.Commands.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public void TestFindOneAndReplaceOne()
    {
        var user = DataHelper.GetNewUser();
        dbContext.Users.Commands.Insert(user);

        // 验证添加是否成功
        var addedUser = dbContext.Users.Commands.FindOne(user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 替换用户1
        var name1 = $"乔峰{Guid.NewGuid().ToString()}";
        user.Name = name1;
        var result1 = dbContext.Users.Commands.FindOneAndReplaceOne(user.Id, user);

        // 验证替换是否成功
        var replaceedUser1 = dbContext.Users.Commands.FindOne(user.Id);
        Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功替换用户。");


        // 替换用户2
        var name2 = $"虚竹{Guid.NewGuid().ToString()}";
        user.Name = name2;
        var result2 = dbContext.Users.Commands.FindOneAndReplaceOne(r => r.Id == user.Id, user);

        // 验证替换是否成功
        var replaceedUser2 = dbContext.Users.Commands.FindOne(user.Id);
        Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功替换用户。");

        // 替换用户3
        var name3 = $"段誉{Guid.NewGuid().ToString()}";
        user.Name = name3;
        var result3 = dbContext.Users.Commands.FindOneAndReplaceOne(Builders<User>.Filter.Eq(f => f.Id, user.Id), user);

        var replaceedUser3 = dbContext.Users.Commands.FindOne(user.Id);
        Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功替换用户。");

        // 删除用户
        var result = dbContext.Users.Commands.DeleteOne(user);

        // 验证删除是否成功
        var deletedUser = dbContext.Users.Commands.FindOne(user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public async Task TestFindOneAndReplaceOneAsync()
    {
        var user = DataHelper.GetNewUser();
        await dbContext.Users.Commands.InsertAsync(user);

        // 验证添加是否成功
        var addedUser = await dbContext.Users.Commands.FindOneAsync(user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");

        // 替换用户1
        var name1 = $"乔峰{Guid.NewGuid().ToString()}";
        user.Name = name1;
        var result1 = await dbContext.Users.Commands.FindOneAndReplaceOneAsync(user.Id, user);

        // 验证替换是否成功
        var replaceedUser1 = await dbContext.Users.Commands.FindOneAsync(user.Id);
        Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功替换用户。");


        // 替换用户2
        var name2 = $"虚竹{Guid.NewGuid().ToString()}";
        user.Name = name2;
        var result2 = await dbContext.Users.Commands.FindOneAndReplaceOneAsync(r => r.Id == user.Id, user);

        // 验证替换是否成功
        var replaceedUser2 = await dbContext.Users.Commands.FindOneAsync(user.Id);
        Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功替换用户。");

        // 替换用户3
        var name3 = $"段誉{Guid.NewGuid().ToString()}";
        user.Name = name3;
        var result3 = await dbContext.Users.Commands.FindOneAndReplaceOneAsync(Builders<User>.Filter.Eq(f => f.Id, user.Id), user);

        var replaceedUser3 = await dbContext.Users.Commands.FindOneAsync(user.Id);
        Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功替换用户。");


        // 删除用户
        var result = await dbContext.Users.Commands.DeleteOneAsync(user);

        // 验证删除是否成功
        var deletedUser = await dbContext.Users.Commands.FindOneAsync(user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public void TestFindOneAndReplaceOneSession()
    {
        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            var user = DataHelper.GetNewUser();

            dbContext.Users.Commands.Insert(session, user);

            // 验证添加是否成功
            var addedUser = dbContext.Users.Commands.FindOne(session, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 替换用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            user.Name = name1;
            var result1 = dbContext.Users.Commands.FindOneAndReplaceOne(session, user.Id, user);

            // 验证替换是否成功
            var replaceedUser1 = dbContext.Users.Commands.FindOne(session, user.Id);
            Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功替换用户。");


            // 替换用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            user.Name = name2;
            var result2 = dbContext.Users.Commands.FindOneAndReplaceOne(session, r => r.Id == user.Id, user);

            // 验证替换是否成功
            var replaceedUser2 = dbContext.Users.Commands.FindOne(session, user.Id);
            Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功替换用户。");

            // 替换用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            user.Name = name3;
            var result3 = dbContext.Users.Commands.FindOneAndReplaceOne(session, Builders<User>.Filter.Eq(f => f.Id, user.Id), user);

            var replaceedUser3 = dbContext.Users.Commands.FindOne(session, user.Id);
            Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功替换用户。");

            // 删除用户
            var result = dbContext.Users.Commands.DeleteOne(session, user);

            // 验证删除是否成功
            var deletedUser = dbContext.Users.Commands.FindOne(session, user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public async Task TestFindOneAndReplaceOneSessionAsync()
    {
        using (var session = await dbContext.Client.StartSessionAsync())
        {
            session.StartTransaction();

            var user = DataHelper.GetNewUser();

            await dbContext.Users.Commands.InsertAsync(session, user);

            // 验证添加是否成功
            var addedUser = await dbContext.Users.Commands.FindOneAsync(session, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 替换用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            user.Name = name1;
            var result1 = await dbContext.Users.Commands.FindOneAndReplaceOneAsync(session, user.Id, user);

            // 验证替换是否成功
            var replaceedUser1 = await dbContext.Users.Commands.FindOneAsync(session, user.Id);
            Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功替换用户。");


            // 替换用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            user.Name = name2;
            var result2 = await dbContext.Users.Commands.FindOneAndReplaceOneAsync(session, r => r.Id == user.Id, user);

            // 验证替换是否成功
            var replaceedUser2 = await dbContext.Users.Commands.FindOneAsync(session, user.Id);
            Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功替换用户。");

            // 替换用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            user.Name = name3;
            var result3 = await dbContext.Users.Commands.FindOneAndReplaceOneAsync(session, Builders<User>.Filter.Eq(f => f.Id, user.Id), user);

            var replaceedUser3 = await dbContext.Users.Commands.FindOneAsync(session, user.Id);
            Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功替换用户。");

            // 删除用户
            var result = await dbContext.Users.Commands.DeleteOneAsync(session, user);

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.Commands.FindOneAsync(session, user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public void TestFindOneAndReplaceOneDynamic()
    {
        var user = DataHelper.GetNewUser();
        var userGroup = DataHelper.GetNewUserGroup();
        dbContext.Users.Commands.DynamicCollectionInsert(userGroup, user);

        // 验证添加是否成功
        var addedUser = dbContext.Users.Commands.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 替换用户1
        var name1 = $"乔峰{Guid.NewGuid().ToString()}";
        user.Name = name1;
        var result1 = dbContext.Users.Commands.DynamicCollectionFindOneAndReplaceOne(userGroup, user.Id, user);

        // 验证替换是否成功
        var replaceedUser1 = dbContext.Users.Commands.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功替换用户。");


        // 替换用户2
        var name2 = $"虚竹{Guid.NewGuid().ToString()}";
        user.Name = name2;
        var result2 = dbContext.Users.Commands.DynamicCollectionFindOneAndReplaceOne(userGroup, r => r.Id == user.Id, user);

        // 验证替换是否成功
        var replaceedUser2 = dbContext.Users.Commands.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功替换用户。");

        // 替换用户3
        var name3 = $"段誉{Guid.NewGuid().ToString()}";
        user.Name = name3;
        var result3 = dbContext.Users.Commands.DynamicCollectionFindOneAndReplaceOne(userGroup, Builders<User>.Filter.Eq(f => f.Id, user.Id), user);

        var replaceedUser3 = dbContext.Users.Commands.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功替换用户。");

        // 删除用户
        var result = dbContext.Users.Commands.DynamicCollectionDeleteOne(userGroup, user);

        // 验证删除是否成功
        var deletedUser = dbContext.Users.Commands.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public async Task TestFindOneAndReplaceOneDynamicAsync()
    {
        var user = DataHelper.GetNewUser();
        var userGroup = DataHelper.GetNewUserGroup();
        await dbContext.Users.Commands.DynamicCollectionInsertAsync(userGroup, user);

        // 验证添加是否成功
        var addedUser = await dbContext.Users.Commands.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 替换用户1
        var name1 = $"乔峰{Guid.NewGuid().ToString()}";
        user.Name = name1;
        var result1 = await dbContext.Users.Commands.DynamicCollectionFindOneAndReplaceOneAsync(userGroup, user.Id, user);

        // 验证替换是否成功
        var replaceedUser1 = await dbContext.Users.Commands.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功替换用户。");


        // 替换用户2
        var name2 = $"虚竹{Guid.NewGuid().ToString()}";
        user.Name = name2;
        var result2 = await dbContext.Users.Commands.DynamicCollectionFindOneAndReplaceOneAsync(userGroup, r => r.Id == user.Id, user);

        // 验证替换是否成功
        var replaceedUser2 = await dbContext.Users.Commands.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功替换用户。");

        // 替换用户3
        var name3 = $"段誉{Guid.NewGuid().ToString()}";
        user.Name = name3;
        var result3 = await dbContext.Users.Commands.DynamicCollectionFindOneAndReplaceOneAsync(userGroup, Builders<User>.Filter.Eq(f => f.Id, user.Id), user);

        var replaceedUser3 = await dbContext.Users.Commands.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功替换用户。");

        // 删除用户
        var result = await dbContext.Users.Commands.DynamicCollectionDeleteOneAsync(userGroup, user);

        // 验证删除是否成功
        var deletedUser = await dbContext.Users.Commands.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public void TestFindOneAndReplaceOneDynamicSession()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            var user = DataHelper.GetNewUser();

            dbContext.Users.Commands.DynamicCollectionInsert(session, userGroup, user);

            // 验证添加是否成功
            var addedUser = dbContext.Users.Commands.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 替换用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            user.Name = name1;
            var result1 = dbContext.Users.Commands.DynamicCollectionFindOneAndReplaceOne(session, userGroup, user.Id, user);

            // 验证替换是否成功
            var replaceedUser1 = dbContext.Users.Commands.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功替换用户。");


            // 替换用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            user.Name = name2;
            var result2 = dbContext.Users.Commands.DynamicCollectionFindOneAndReplaceOne(session, userGroup, r => r.Id == user.Id, user);

            // 验证替换是否成功
            var replaceedUser2 = dbContext.Users.Commands.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功替换用户。");

            // 替换用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            user.Name = name3;
            var result3 = dbContext.Users.Commands.DynamicCollectionFindOneAndReplaceOne(session, userGroup, Builders<User>.Filter.Eq(f => f.Id, user.Id), user);

            var replaceedUser3 = dbContext.Users.Commands.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功替换用户。");

            // 删除用户
            var result = dbContext.Users.Commands.DynamicCollectionDeleteOne(session, userGroup, user);

            // 验证删除是否成功
            var deletedUser = dbContext.Users.Commands.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public async Task TestFindOneAndReplaceOneDynamicSessionAsync()
    {
        var userGroup = DataHelper.GetNewUserGroup();
        using (var session = await dbContext.Client.StartSessionAsync())
        {
            session.StartTransaction();

            var user = DataHelper.GetNewUser();

            await dbContext.Users.Commands.DynamicCollectionInsertAsync(session, userGroup, user);

            // 验证添加是否成功
            var addedUser = await dbContext.Users.Commands.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 替换用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            user.Name = name1;
            var result1 = await dbContext.Users.Commands.DynamicCollectionFindOneAndReplaceOneAsync(session, userGroup, user.Id, user);

            // 验证替换是否成功
            var replaceedUser1 = await dbContext.Users.Commands.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功替换用户。");


            // 替换用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            user.Name = name2;
            var result2 = await dbContext.Users.Commands.DynamicCollectionFindOneAndReplaceOneAsync(session, userGroup, r => r.Id == user.Id, user);

            // 验证替换是否成功
            var replaceedUser2 = await dbContext.Users.Commands.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功替换用户。");

            // 替换用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            user.Name = name3;
            var result3 = await dbContext.Users.Commands.DynamicCollectionFindOneAndReplaceOneAsync(session, userGroup, Builders<User>.Filter.Eq(f => f.Id, user.Id), user);

            var replaceedUser3 = await dbContext.Users.Commands.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功替换用户。");

            // 删除用户
            var result = await dbContext.Users.Commands.DynamicCollectionDeleteOneAsync(session, userGroup, user);

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.Commands.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");

            session.CommitTransaction();
        }
    }
}
