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
        dbContext.Users.Immediate.Insert(user);

        // 验证添加是否成功
        var addedUser = dbContext.Users.Immediate.FindOne(user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 替换用户1
        var name1 = $"乔峰{Guid.NewGuid().ToString()}";
        user.Name = name1;
        dbContext.Users.Immediate.ReplaceOne(user.Id, user);

        // 验证替换是否成功
        var replaceedUser1 = dbContext.Users.Immediate.FindOne(user.Id);
        Assert.AreEqual(replaceedUser1.Name, name1, "未成功替换用户。");


        // 替换用户2
        var name2 = $"虚竹{Guid.NewGuid().ToString()}";
        user.Name = name2;
        dbContext.Users.Immediate.ReplaceOne(r => r.Id == user.Id, user);

        // 验证替换是否成功
        var replaceedUser2 = dbContext.Users.Immediate.FindOne(user.Id);
        Assert.AreEqual(replaceedUser2.Name, name2, "未成功替换用户。");

        // 替换用户3
        var name3 = $"段誉{Guid.NewGuid().ToString()}";
        user.Name = name3;
        dbContext.Users.Immediate.ReplaceOne(Builders<User>.Filter.Eq(f => f.Id, user.Id), user);

        var replaceedUser3 = dbContext.Users.Immediate.FindOne(user.Id);
        Assert.AreEqual(replaceedUser3.Name, name3, "未成功替换用户。");

        // 删除用户
        var result = dbContext.Users.Immediate.DeleteOne(user);

        // 验证删除是否成功
        var deletedUser = dbContext.Users.Immediate.FindOne(user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public async Task TestReplaceOneAsync()
    {
        var user = DataHelper.GetNewUser();
        await dbContext.Users.Immediate.InsertAsync(user);

        // 验证添加是否成功
        var addedUser = await dbContext.Users.Immediate.FindOneAsync(user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");

        // 替换用户1
        var name1 = $"乔峰{Guid.NewGuid().ToString()}";
        user.Name = name1;
        await dbContext.Users.Immediate.ReplaceOneAsync(user.Id, user);

        // 验证替换是否成功
        var replaceedUser1 = await dbContext.Users.Immediate.FindOneAsync(user.Id);
        Assert.AreEqual(replaceedUser1.Name, name1, "未成功替换用户。");


        // 替换用户2
        var name2 = $"虚竹{Guid.NewGuid().ToString()}";
        user.Name = name2;
        await dbContext.Users.Immediate.ReplaceOneAsync(r => r.Id == user.Id, user);

        // 验证替换是否成功
        var replaceedUser2 = await dbContext.Users.Immediate.FindOneAsync(user.Id);
        Assert.AreEqual(replaceedUser2.Name, name2, "未成功替换用户。");

        // 替换用户3
        var name3 = $"段誉{Guid.NewGuid().ToString()}";
        user.Name = name3;
        await dbContext.Users.Immediate.ReplaceOneAsync(Builders<User>.Filter.Eq(f => f.Id, user.Id), user);

        var replaceedUser3 = await dbContext.Users.Immediate.FindOneAsync(user.Id);
        Assert.AreEqual(replaceedUser3.Name, name3, "未成功替换用户。");

        // 删除用户
        var result = await dbContext.Users.Immediate.DeleteOneAsync(user);

        // 验证删除是否成功
        var deletedUser = await dbContext.Users.Immediate.FindOneAsync(user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public void TestReplaceOneSession()
    {
        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            var user = DataHelper.GetNewUser();

            dbContext.Users.Immediate.Insert(session, user);

            // 验证添加是否成功
            var addedUser = dbContext.Users.Immediate.FindOne(session, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 替换用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            user.Name = name1;
            dbContext.Users.Immediate.ReplaceOne(session, user.Id, user);

            // 验证替换是否成功
            var replaceedUser1 = dbContext.Users.Immediate.FindOne(session, user.Id);
            Assert.AreEqual(replaceedUser1.Name, name1, "未成功替换用户。");


            // 替换用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            user.Name = name2;
            dbContext.Users.Immediate.ReplaceOne(session, r => r.Id == user.Id, user);

            // 验证替换是否成功
            var replaceedUser2 = dbContext.Users.Immediate.FindOne(session, user.Id);
            Assert.AreEqual(replaceedUser2.Name, name2, "未成功替换用户。");

            // 替换用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            user.Name = name3;
            dbContext.Users.Immediate.ReplaceOne(session, Builders<User>.Filter.Eq(f => f.Id, user.Id), user);

            var replaceedUser3 = dbContext.Users.Immediate.FindOne(session, user.Id);
            Assert.AreEqual(replaceedUser3.Name, name3, "未成功替换用户。");

            // 删除用户
            var result = dbContext.Users.Immediate.DeleteOne(session, user);

            // 验证删除是否成功
            var deletedUser = dbContext.Users.Immediate.FindOne(session, user.Id);
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

            await dbContext.Users.Immediate.InsertAsync(session, user);

            // 验证添加是否成功
            var addedUser = await dbContext.Users.Immediate.FindOneAsync(session, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 替换用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            user.Name = name1;
            await dbContext.Users.Immediate.ReplaceOneAsync(session, user.Id, user);

            // 验证替换是否成功
            var replaceedUser1 = await dbContext.Users.Immediate.FindOneAsync(session, user.Id);
            Assert.AreEqual(replaceedUser1.Name, name1, "未成功替换用户。");


            // 替换用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            user.Name = name2;
            await dbContext.Users.Immediate.ReplaceOneAsync(session, r => r.Id == user.Id, user);

            // 验证替换是否成功
            var replaceedUser2 = await dbContext.Users.Immediate.FindOneAsync(session, user.Id);
            Assert.AreEqual(replaceedUser2.Name, name2, "未成功替换用户。");

            // 替换用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            user.Name = name3;
            await dbContext.Users.Immediate.ReplaceOneAsync(session, Builders<User>.Filter.Eq(f => f.Id, user.Id), user);

            var replaceedUser3 = await dbContext.Users.Immediate.FindOneAsync(session, user.Id);
            Assert.AreEqual(replaceedUser3.Name, name3, "未成功替换用户。");

            // 删除用户
            var result = await dbContext.Users.Immediate.DeleteOneAsync(session, user);

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.Immediate.FindOneAsync(session, user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public void TestReplaceOneDynamic()
    {
        var user = DataHelper.GetNewUser();
        var userGroup = DataHelper.GetNewUserGroup();
        dbContext.Users.Immediate.DynamicCollectionInsert(userGroup, user);

        // 验证添加是否成功
        var addedUser = dbContext.Users.Immediate.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 替换用户1
        var name1 = $"乔峰{Guid.NewGuid().ToString()}";
        user.Name = name1;
        dbContext.Users.Immediate.DynamicCollectionReplaceOne(userGroup, user.Id, user);

        // 验证替换是否成功
        var replaceedUser1 = dbContext.Users.Immediate.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.AreEqual(replaceedUser1.Name, name1, "未成功替换用户。");


        // 替换用户2
        var name2 = $"虚竹{Guid.NewGuid().ToString()}";
        user.Name = name2;
        dbContext.Users.Immediate.DynamicCollectionReplaceOne(userGroup, r => r.Id == user.Id, user);

        // 验证替换是否成功
        var replaceedUser2 = dbContext.Users.Immediate.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.AreEqual(replaceedUser2.Name, name2, "未成功替换用户。");

        // 替换用户3
        var name3 = $"段誉{Guid.NewGuid().ToString()}";
        user.Name = name3;
        dbContext.Users.Immediate.DynamicCollectionReplaceOne(userGroup, Builders<User>.Filter.Eq(f => f.Id, user.Id), user);

        var replaceedUser3 = dbContext.Users.Immediate.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.AreEqual(replaceedUser3.Name, name3, "未成功替换用户。");

        // 删除用户
        var result = dbContext.Users.Immediate.DynamicCollectionDeleteOne(userGroup, user);

        // 验证删除是否成功
        var deletedUser = dbContext.Users.Immediate.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public async Task TestReplaceOneDynamicAsync()
    {
        var user = DataHelper.GetNewUser();
        var userGroup = DataHelper.GetNewUserGroup();
        await dbContext.Users.Immediate.DynamicCollectionInsertAsync(userGroup, user);

        // 验证添加是否成功
        var addedUser = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 替换用户1
        var name1 = $"乔峰{Guid.NewGuid().ToString()}";
        user.Name = name1;
        await dbContext.Users.Immediate.DynamicCollectionReplaceOneAsync(userGroup, user.Id, user);

        // 验证替换是否成功
        var replaceedUser1 = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.AreEqual(replaceedUser1.Name, name1, "未成功替换用户。");


        // 替换用户2
        var name2 = $"虚竹{Guid.NewGuid().ToString()}";
        user.Name = name2;
        await dbContext.Users.Immediate.DynamicCollectionReplaceOneAsync(userGroup, r => r.Id == user.Id, user);

        // 验证替换是否成功
        var replaceedUser2 = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.AreEqual(replaceedUser2.Name, name2, "未成功替换用户。");

        // 替换用户3
        var name3 = $"段誉{Guid.NewGuid().ToString()}";
        user.Name = name3;
        await dbContext.Users.Immediate.DynamicCollectionReplaceOneAsync(userGroup, Builders<User>.Filter.Eq(f => f.Id, user.Id), user);

        var replaceedUser3 = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.AreEqual(replaceedUser3.Name, name3, "未成功替换用户。");

        // 删除用户
        var result = await dbContext.Users.Immediate.DynamicCollectionDeleteOneAsync(userGroup, user);

        // 验证删除是否成功
        var deletedUser = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(userGroup, user.Id);
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

            dbContext.Users.Immediate.DynamicCollectionInsert(session, userGroup, user);

            // 验证添加是否成功
            var addedUser = dbContext.Users.Immediate.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 替换用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            user.Name = name1;
            dbContext.Users.Immediate.DynamicCollectionReplaceOne(session, userGroup, user.Id, user);

            // 验证替换是否成功
            var replaceedUser1 = dbContext.Users.Immediate.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.AreEqual(replaceedUser1.Name, name1, "未成功替换用户。");


            // 替换用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            user.Name = name2;
            dbContext.Users.Immediate.DynamicCollectionReplaceOne(session, userGroup, r => r.Id == user.Id, user);

            // 验证替换是否成功
            var replaceedUser2 = dbContext.Users.Immediate.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.AreEqual(replaceedUser2.Name, name2, "未成功替换用户。");

            // 替换用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            user.Name = name3;
            dbContext.Users.Immediate.DynamicCollectionReplaceOne(session, userGroup, Builders<User>.Filter.Eq(f => f.Id, user.Id), user);

            var replaceedUser3 = dbContext.Users.Immediate.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.AreEqual(replaceedUser3.Name, name3, "未成功替换用户。");

            // 删除用户
            var result = dbContext.Users.Immediate.DynamicCollectionDeleteOne(session, userGroup, user);

            // 验证删除是否成功
            var deletedUser = dbContext.Users.Immediate.DynamicCollectionFindOne(session, userGroup, user.Id);
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

            await dbContext.Users.Immediate.DynamicCollectionInsertAsync(session, userGroup, user);

            // 验证添加是否成功
            var addedUser = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 替换用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            user.Name = name1;
            await dbContext.Users.Immediate.DynamicCollectionReplaceOneAsync(session, userGroup, user.Id, user);

            // 验证替换是否成功
            var replaceedUser1 = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.AreEqual(replaceedUser1.Name, name1, "未成功替换用户。");


            // 替换用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            user.Name = name2;
            await dbContext.Users.Immediate.DynamicCollectionReplaceOneAsync(session, userGroup, r => r.Id == user.Id, user);

            // 验证替换是否成功
            var replaceedUser2 = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.AreEqual(replaceedUser2.Name, name2, "未成功替换用户。");

            // 替换用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            user.Name = name3;
            await dbContext.Users.Immediate.DynamicCollectionReplaceOneAsync(session, userGroup, Builders<User>.Filter.Eq(f => f.Id, user.Id), user);

            // 删除用户
            var result = await dbContext.Users.Immediate.DynamicCollectionDeleteOneAsync(session, userGroup, user);

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public void TestFindOneAndReplaceOne()
    {
        var user = DataHelper.GetNewUser();
        dbContext.Users.Immediate.Insert(user);

        // 验证添加是否成功
        var addedUser = dbContext.Users.Immediate.FindOne(user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 替换用户1
        var name1 = $"乔峰{Guid.NewGuid().ToString()}";
        user.Name = name1;
        var result1 = dbContext.Users.Immediate.FindOneAndReplaceOne(user.Id, user);

        // 验证替换是否成功
        var replaceedUser1 = dbContext.Users.Immediate.FindOne(user.Id);
        Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功替换用户。");


        // 替换用户2
        var name2 = $"虚竹{Guid.NewGuid().ToString()}";
        user.Name = name2;
        var result2 = dbContext.Users.Immediate.FindOneAndReplaceOne(r => r.Id == user.Id, user);

        // 验证替换是否成功
        var replaceedUser2 = dbContext.Users.Immediate.FindOne(user.Id);
        Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功替换用户。");

        // 替换用户3
        var name3 = $"段誉{Guid.NewGuid().ToString()}";
        user.Name = name3;
        var result3 = dbContext.Users.Immediate.FindOneAndReplaceOne(Builders<User>.Filter.Eq(f => f.Id, user.Id), user);

        var replaceedUser3 = dbContext.Users.Immediate.FindOne(user.Id);
        Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功替换用户。");

        // 删除用户
        var result = dbContext.Users.Immediate.DeleteOne(user);

        // 验证删除是否成功
        var deletedUser = dbContext.Users.Immediate.FindOne(user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public async Task TestFindOneAndReplaceOneAsync()
    {
        var user = DataHelper.GetNewUser();
        await dbContext.Users.Immediate.InsertAsync(user);

        // 验证添加是否成功
        var addedUser = await dbContext.Users.Immediate.FindOneAsync(user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");

        // 替换用户1
        var name1 = $"乔峰{Guid.NewGuid().ToString()}";
        user.Name = name1;
        var result1 = await dbContext.Users.Immediate.FindOneAndReplaceOneAsync(user.Id, user);

        // 验证替换是否成功
        var replaceedUser1 = await dbContext.Users.Immediate.FindOneAsync(user.Id);
        Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功替换用户。");


        // 替换用户2
        var name2 = $"虚竹{Guid.NewGuid().ToString()}";
        user.Name = name2;
        var result2 = await dbContext.Users.Immediate.FindOneAndReplaceOneAsync(r => r.Id == user.Id, user);

        // 验证替换是否成功
        var replaceedUser2 = await dbContext.Users.Immediate.FindOneAsync(user.Id);
        Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功替换用户。");

        // 替换用户3
        var name3 = $"段誉{Guid.NewGuid().ToString()}";
        user.Name = name3;
        var result3 = await dbContext.Users.Immediate.FindOneAndReplaceOneAsync(Builders<User>.Filter.Eq(f => f.Id, user.Id), user);

        var replaceedUser3 = await dbContext.Users.Immediate.FindOneAsync(user.Id);
        Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功替换用户。");


        // 删除用户
        var result = await dbContext.Users.Immediate.DeleteOneAsync(user);

        // 验证删除是否成功
        var deletedUser = await dbContext.Users.Immediate.FindOneAsync(user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public void TestFindOneAndReplaceOneSession()
    {
        using (var session = dbContext.Client.StartSession())
        {
            session.StartTransaction();

            var user = DataHelper.GetNewUser();

            dbContext.Users.Immediate.Insert(session, user);

            // 验证添加是否成功
            var addedUser = dbContext.Users.Immediate.FindOne(session, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 替换用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            user.Name = name1;
            var result1 = dbContext.Users.Immediate.FindOneAndReplaceOne(session, user.Id, user);

            // 验证替换是否成功
            var replaceedUser1 = dbContext.Users.Immediate.FindOne(session, user.Id);
            Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功替换用户。");


            // 替换用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            user.Name = name2;
            var result2 = dbContext.Users.Immediate.FindOneAndReplaceOne(session, r => r.Id == user.Id, user);

            // 验证替换是否成功
            var replaceedUser2 = dbContext.Users.Immediate.FindOne(session, user.Id);
            Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功替换用户。");

            // 替换用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            user.Name = name3;
            var result3 = dbContext.Users.Immediate.FindOneAndReplaceOne(session, Builders<User>.Filter.Eq(f => f.Id, user.Id), user);

            var replaceedUser3 = dbContext.Users.Immediate.FindOne(session, user.Id);
            Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功替换用户。");

            // 删除用户
            var result = dbContext.Users.Immediate.DeleteOne(session, user);

            // 验证删除是否成功
            var deletedUser = dbContext.Users.Immediate.FindOne(session, user.Id);
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

            await dbContext.Users.Immediate.InsertAsync(session, user);

            // 验证添加是否成功
            var addedUser = await dbContext.Users.Immediate.FindOneAsync(session, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 替换用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            user.Name = name1;
            var result1 = await dbContext.Users.Immediate.FindOneAndReplaceOneAsync(session, user.Id, user);

            // 验证替换是否成功
            var replaceedUser1 = await dbContext.Users.Immediate.FindOneAsync(session, user.Id);
            Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功替换用户。");


            // 替换用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            user.Name = name2;
            var result2 = await dbContext.Users.Immediate.FindOneAndReplaceOneAsync(session, r => r.Id == user.Id, user);

            // 验证替换是否成功
            var replaceedUser2 = await dbContext.Users.Immediate.FindOneAsync(session, user.Id);
            Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功替换用户。");

            // 替换用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            user.Name = name3;
            var result3 = await dbContext.Users.Immediate.FindOneAndReplaceOneAsync(session, Builders<User>.Filter.Eq(f => f.Id, user.Id), user);

            var replaceedUser3 = await dbContext.Users.Immediate.FindOneAsync(session, user.Id);
            Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功替换用户。");

            // 删除用户
            var result = await dbContext.Users.Immediate.DeleteOneAsync(session, user);

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.Immediate.FindOneAsync(session, user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");

            session.CommitTransaction();
        }
    }

    [TestMethod]
    public void TestFindOneAndReplaceOneDynamic()
    {
        var user = DataHelper.GetNewUser();
        var userGroup = DataHelper.GetNewUserGroup();
        dbContext.Users.Immediate.DynamicCollectionInsert(userGroup, user);

        // 验证添加是否成功
        var addedUser = dbContext.Users.Immediate.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 替换用户1
        var name1 = $"乔峰{Guid.NewGuid().ToString()}";
        user.Name = name1;
        var result1 = dbContext.Users.Immediate.DynamicCollectionFindOneAndReplaceOne(userGroup, user.Id, user);

        // 验证替换是否成功
        var replaceedUser1 = dbContext.Users.Immediate.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功替换用户。");


        // 替换用户2
        var name2 = $"虚竹{Guid.NewGuid().ToString()}";
        user.Name = name2;
        var result2 = dbContext.Users.Immediate.DynamicCollectionFindOneAndReplaceOne(userGroup, r => r.Id == user.Id, user);

        // 验证替换是否成功
        var replaceedUser2 = dbContext.Users.Immediate.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功替换用户。");

        // 替换用户3
        var name3 = $"段誉{Guid.NewGuid().ToString()}";
        user.Name = name3;
        var result3 = dbContext.Users.Immediate.DynamicCollectionFindOneAndReplaceOne(userGroup, Builders<User>.Filter.Eq(f => f.Id, user.Id), user);

        var replaceedUser3 = dbContext.Users.Immediate.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功替换用户。");

        // 删除用户
        var result = dbContext.Users.Immediate.DynamicCollectionDeleteOne(userGroup, user);

        // 验证删除是否成功
        var deletedUser = dbContext.Users.Immediate.DynamicCollectionFindOne(userGroup, user.Id);
        Assert.IsNull(deletedUser, "用户未成功删除。");
    }

    [TestMethod]
    public async Task TestFindOneAndReplaceOneDynamicAsync()
    {
        var user = DataHelper.GetNewUser();
        var userGroup = DataHelper.GetNewUserGroup();
        await dbContext.Users.Immediate.DynamicCollectionInsertAsync(userGroup, user);

        // 验证添加是否成功
        var addedUser = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.IsNotNull(addedUser, "未成功添加用户。");


        // 替换用户1
        var name1 = $"乔峰{Guid.NewGuid().ToString()}";
        user.Name = name1;
        var result1 = await dbContext.Users.Immediate.DynamicCollectionFindOneAndReplaceOneAsync(userGroup, user.Id, user);

        // 验证替换是否成功
        var replaceedUser1 = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功替换用户。");


        // 替换用户2
        var name2 = $"虚竹{Guid.NewGuid().ToString()}";
        user.Name = name2;
        var result2 = await dbContext.Users.Immediate.DynamicCollectionFindOneAndReplaceOneAsync(userGroup, r => r.Id == user.Id, user);

        // 验证替换是否成功
        var replaceedUser2 = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功替换用户。");

        // 替换用户3
        var name3 = $"段誉{Guid.NewGuid().ToString()}";
        user.Name = name3;
        var result3 = await dbContext.Users.Immediate.DynamicCollectionFindOneAndReplaceOneAsync(userGroup, Builders<User>.Filter.Eq(f => f.Id, user.Id), user);

        var replaceedUser3 = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(userGroup, user.Id);
        Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功替换用户。");

        // 删除用户
        var result = await dbContext.Users.Immediate.DynamicCollectionDeleteOneAsync(userGroup, user);

        // 验证删除是否成功
        var deletedUser = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(userGroup, user.Id);
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

            dbContext.Users.Immediate.DynamicCollectionInsert(session, userGroup, user);

            // 验证添加是否成功
            var addedUser = dbContext.Users.Immediate.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 替换用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            user.Name = name1;
            var result1 = dbContext.Users.Immediate.DynamicCollectionFindOneAndReplaceOne(session, userGroup, user.Id, user);

            // 验证替换是否成功
            var replaceedUser1 = dbContext.Users.Immediate.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功替换用户。");


            // 替换用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            user.Name = name2;
            var result2 = dbContext.Users.Immediate.DynamicCollectionFindOneAndReplaceOne(session, userGroup, r => r.Id == user.Id, user);

            // 验证替换是否成功
            var replaceedUser2 = dbContext.Users.Immediate.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功替换用户。");

            // 替换用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            user.Name = name3;
            var result3 = dbContext.Users.Immediate.DynamicCollectionFindOneAndReplaceOne(session, userGroup, Builders<User>.Filter.Eq(f => f.Id, user.Id), user);

            var replaceedUser3 = dbContext.Users.Immediate.DynamicCollectionFindOne(session, userGroup, user.Id);
            Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功替换用户。");

            // 删除用户
            var result = dbContext.Users.Immediate.DynamicCollectionDeleteOne(session, userGroup, user);

            // 验证删除是否成功
            var deletedUser = dbContext.Users.Immediate.DynamicCollectionFindOne(session, userGroup, user.Id);
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

            await dbContext.Users.Immediate.DynamicCollectionInsertAsync(session, userGroup, user);

            // 验证添加是否成功
            var addedUser = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 替换用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            user.Name = name1;
            var result1 = await dbContext.Users.Immediate.DynamicCollectionFindOneAndReplaceOneAsync(session, userGroup, user.Id, user);

            // 验证替换是否成功
            var replaceedUser1 = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功替换用户。");


            // 替换用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            user.Name = name2;
            var result2 = await dbContext.Users.Immediate.DynamicCollectionFindOneAndReplaceOneAsync(session, userGroup, r => r.Id == user.Id, user);

            // 验证替换是否成功
            var replaceedUser2 = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功替换用户。");

            // 替换用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            user.Name = name3;
            var result3 = await dbContext.Users.Immediate.DynamicCollectionFindOneAndReplaceOneAsync(session, userGroup, Builders<User>.Filter.Eq(f => f.Id, user.Id), user);

            var replaceedUser3 = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功替换用户。");

            // 删除用户
            var result = await dbContext.Users.Immediate.DynamicCollectionDeleteOneAsync(session, userGroup, user);

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.Immediate.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");

            session.CommitTransaction();
        }
    }
}
