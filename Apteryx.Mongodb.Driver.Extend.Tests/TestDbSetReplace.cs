using Apteryx.Mongodb.Driver.Extend.Tests.Data;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Apteryx.Mongodb.Driver.Extend.Tests
{
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
            dbContext.Users.Add(user);

            // 验证添加是否成功
            var addedUser = dbContext.Users.FindOne(user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 替换用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            user.Name = name1;
            dbContext.Users.ReplaceOne(user.Id, user);

            // 验证替换是否成功
            var replaceedUser1 = dbContext.Users.FindOne(user.Id);
            Assert.AreEqual(replaceedUser1.Name, name1, "未成功替换用户。");


            // 替换用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            user.Name = name2;
            dbContext.Users.ReplaceOne(r => r.Id == user.Id, user);

            // 验证替换是否成功
            var replaceedUser2 = dbContext.Users.FindOne(user.Id);
            Assert.AreEqual(replaceedUser2.Name, name2, "未成功替换用户。");

            // 替换用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            user.Name = name3;
            dbContext.Users.ReplaceOne(new FilterDefinitionBuilder<User>().Eq(f => f.Id, user.Id), user);

            var replaceedUser3 = dbContext.Users.FindOne(user.Id);
            Assert.AreEqual(replaceedUser3.Name, name3, "未成功替换用户。");

            // 删除用户
            dbContext.Users.DeleteOne(user);

            // 验证删除是否成功
            var deletedUser = dbContext.Users.FindOne(user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");
        }

        [TestMethod]
        public async Task TestReplaceOneAsync()
        {
            var user = DataHelper.GetNewUser();
            await dbContext.Users.AddAsync(user);

            // 验证添加是否成功
            var addedUser = await dbContext.Users.FindOneAsync(user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");

            // 替换用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            user.Name = name1;
            await dbContext.Users.ReplaceOneAsync(user.Id, user);

            // 验证替换是否成功
            var replaceedUser1 = await dbContext.Users.FindOneAsync(user.Id);
            Assert.AreEqual(replaceedUser1.Name, name1, "未成功替换用户。");


            // 替换用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            user.Name = name2;
            await dbContext.Users.ReplaceOneAsync(r => r.Id == user.Id, user);

            // 验证替换是否成功
            var replaceedUser2 = await dbContext.Users.FindOneAsync(user.Id);
            Assert.AreEqual(replaceedUser2.Name, name2, "未成功替换用户。");

            // 替换用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            user.Name = name3;
            await dbContext.Users.ReplaceOneAsync(new FilterDefinitionBuilder<User>().Eq(f => f.Id, user.Id), user);

            var replaceedUser3 = await dbContext.Users.FindOneAsync(user.Id);
            Assert.AreEqual(replaceedUser3.Name, name3, "未成功替换用户。");

            // 删除用户
            await dbContext.Users.DeleteOneAsync(user);

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.FindOneAsync(user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");
        }

        [TestMethod]
        public void TestReplaceOneSession()
        {
            using (var session = dbContext.Client.StartSession())
            {
                session.StartTransaction();

                var user = DataHelper.GetNewUser();

                dbContext.Users.Add(session, user);

                // 验证添加是否成功
                var addedUser = dbContext.Users.FindOne(session, user.Id);
                Assert.IsNotNull(addedUser, "未成功添加用户。");


                // 替换用户1
                var name1 = $"乔峰{Guid.NewGuid().ToString()}";
                user.Name = name1;
                dbContext.Users.ReplaceOne(session, user.Id, user);

                // 验证替换是否成功
                var replaceedUser1 = dbContext.Users.FindOne(session, user.Id);
                Assert.AreEqual(replaceedUser1.Name, name1, "未成功替换用户。");


                // 替换用户2
                var name2 = $"虚竹{Guid.NewGuid().ToString()}";
                user.Name = name2;
                dbContext.Users.ReplaceOne(session, r => r.Id == user.Id, user);

                // 验证替换是否成功
                var replaceedUser2 = dbContext.Users.FindOne(session, user.Id);
                Assert.AreEqual(replaceedUser2.Name, name2, "未成功替换用户。");

                // 替换用户3
                var name3 = $"段誉{Guid.NewGuid().ToString()}";
                user.Name = name3;
                dbContext.Users.ReplaceOne(session, new FilterDefinitionBuilder<User>().Eq(f => f.Id, user.Id), user);

                var replaceedUser3 = dbContext.Users.FindOne(session, user.Id);
                Assert.AreEqual(replaceedUser3.Name, name3, "未成功替换用户。");

                // 删除用户
                dbContext.Users.DeleteOne(session, user);

                // 验证删除是否成功
                var deletedUser = dbContext.Users.FindOne(session, user.Id);
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

                await dbContext.Users.AddAsync(session, user);

                // 验证添加是否成功
                var addedUser = await dbContext.Users.FindOneAsync(session, user.Id);
                Assert.IsNotNull(addedUser, "未成功添加用户。");


                // 替换用户1
                var name1 = $"乔峰{Guid.NewGuid().ToString()}";
                user.Name = name1;
                await dbContext.Users.ReplaceOneAsync(session, user.Id, user);

                // 验证替换是否成功
                var replaceedUser1 = await dbContext.Users.FindOneAsync(session, user.Id);
                Assert.AreEqual(replaceedUser1.Name, name1, "未成功替换用户。");


                // 替换用户2
                var name2 = $"虚竹{Guid.NewGuid().ToString()}";
                user.Name = name2;
                await dbContext.Users.ReplaceOneAsync(session, r => r.Id == user.Id, user);

                // 验证替换是否成功
                var replaceedUser2 = await dbContext.Users.FindOneAsync(session, user.Id);
                Assert.AreEqual(replaceedUser2.Name, name2, "未成功替换用户。");

                // 替换用户3
                var name3 = $"段誉{Guid.NewGuid().ToString()}";
                user.Name = name3;
                await dbContext.Users.ReplaceOneAsync(session, new FilterDefinitionBuilder<User>().Eq(f => f.Id, user.Id), user);

                var replaceedUser3 = await dbContext.Users.FindOneAsync(session, user.Id);
                Assert.AreEqual(replaceedUser3.Name, name3, "未成功替换用户。");

                // 删除用户
                await dbContext.Users.DeleteOneAsync(session, user);

                // 验证删除是否成功
                var deletedUser = await dbContext.Users.FindOneAsync(session, user.Id);
                Assert.IsNull(deletedUser, "用户未成功删除。");

                session.CommitTransaction();
            }
        }

        [TestMethod]
        public void TestReplaceOneDynamic()
        {
            var user = DataHelper.GetNewUser();
            var userGroup = DataHelper.GetNewUserGroup();
            dbContext.Users.DynamicCollectionAdd(userGroup, user);

            // 验证添加是否成功
            var addedUser = dbContext.Users.DynamicCollectionFindOne(userGroup, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 替换用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            user.Name = name1;
            dbContext.Users.DynamicCollectionReplaceOne(userGroup, user.Id, user);

            // 验证替换是否成功
            var replaceedUser1 = dbContext.Users.DynamicCollectionFindOne(userGroup, user.Id);
            Assert.AreEqual(replaceedUser1.Name, name1, "未成功替换用户。");


            // 替换用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            user.Name = name2;
            dbContext.Users.DynamicCollectionReplaceOne(userGroup, r => r.Id == user.Id, user);

            // 验证替换是否成功
            var replaceedUser2 = dbContext.Users.DynamicCollectionFindOne(userGroup, user.Id);
            Assert.AreEqual(replaceedUser2.Name, name2, "未成功替换用户。");

            // 替换用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            user.Name = name3;
            dbContext.Users.DynamicCollectionReplaceOne(userGroup, new FilterDefinitionBuilder<User>().Eq(f => f.Id, user.Id), user);

            var replaceedUser3 = dbContext.Users.DynamicCollectionFindOne(userGroup, user.Id);
            Assert.AreEqual(replaceedUser3.Name, name3, "未成功替换用户。");

            // 删除用户
            dbContext.Users.DynamicCollectionDeleteOne(userGroup, user);

            // 验证删除是否成功
            var deletedUser = dbContext.Users.DynamicCollectionFindOne(userGroup, user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");
        }

        [TestMethod]
        public async Task TestReplaceOneDynamicAsync()
        {
            var user = DataHelper.GetNewUser();
            var userGroup = DataHelper.GetNewUserGroup();
            await dbContext.Users.DynamicCollectionAddAsync(userGroup, user);

            // 验证添加是否成功
            var addedUser = await dbContext.Users.DynamicCollectionFindOneAsync(userGroup, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 替换用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            user.Name = name1;
            await dbContext.Users.DynamicCollectionReplaceOneAsync(userGroup, user.Id, user);

            // 验证替换是否成功
            var replaceedUser1 = await dbContext.Users.DynamicCollectionFindOneAsync(userGroup, user.Id);
            Assert.AreEqual(replaceedUser1.Name, name1, "未成功替换用户。");


            // 替换用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            user.Name = name2;
            await dbContext.Users.DynamicCollectionReplaceOneAsync(userGroup, r => r.Id == user.Id, user);

            // 验证替换是否成功
            var replaceedUser2 = await dbContext.Users.DynamicCollectionFindOneAsync(userGroup, user.Id);
            Assert.AreEqual(replaceedUser2.Name, name2, "未成功替换用户。");

            // 替换用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            user.Name = name3;
            await dbContext.Users.DynamicCollectionReplaceOneAsync(userGroup, new FilterDefinitionBuilder<User>().Eq(f => f.Id, user.Id), user);

            var replaceedUser3 = await dbContext.Users.DynamicCollectionFindOneAsync(userGroup, user.Id);
            Assert.AreEqual(replaceedUser3.Name, name3, "未成功替换用户。");

            // 删除用户
            await dbContext.Users.DynamicCollectionDeleteOneAsync(userGroup, user);

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.DynamicCollectionFindOneAsync(userGroup, user.Id);
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

                dbContext.Users.DynamicCollectionAdd(session, userGroup, user);

                // 验证添加是否成功
                var addedUser = dbContext.Users.DynamicCollectionFindOne(session, userGroup, user.Id);
                Assert.IsNotNull(addedUser, "未成功添加用户。");


                // 替换用户1
                var name1 = $"乔峰{Guid.NewGuid().ToString()}";
                user.Name = name1;
                dbContext.Users.DynamicCollectionReplaceOne(session, userGroup, user.Id, user);

                // 验证替换是否成功
                var replaceedUser1 = dbContext.Users.DynamicCollectionFindOne(session, userGroup, user.Id);
                Assert.AreEqual(replaceedUser1.Name, name1, "未成功替换用户。");


                // 替换用户2
                var name2 = $"虚竹{Guid.NewGuid().ToString()}";
                user.Name = name2;
                dbContext.Users.DynamicCollectionReplaceOne(session, userGroup, r => r.Id == user.Id, user);

                // 验证替换是否成功
                var replaceedUser2 = dbContext.Users.DynamicCollectionFindOne(session, userGroup, user.Id);
                Assert.AreEqual(replaceedUser2.Name, name2, "未成功替换用户。");

                // 替换用户3
                var name3 = $"段誉{Guid.NewGuid().ToString()}";
                user.Name = name3;
                dbContext.Users.DynamicCollectionReplaceOne(session, userGroup, new FilterDefinitionBuilder<User>().Eq(f => f.Id, user.Id), user);

                var replaceedUser3 = dbContext.Users.DynamicCollectionFindOne(session, userGroup, user.Id);
                Assert.AreEqual(replaceedUser3.Name, name3, "未成功替换用户。");

                // 删除用户
                dbContext.Users.DynamicCollectionDeleteOne(session, userGroup, user);

                // 验证删除是否成功
                var deletedUser = dbContext.Users.DynamicCollectionFindOne(session, userGroup, user.Id);
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

                await dbContext.Users.DynamicCollectionAddAsync(session, userGroup, user);

                // 验证添加是否成功
                var addedUser = await dbContext.Users.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
                Assert.IsNotNull(addedUser, "未成功添加用户。");


                // 替换用户1
                var name1 = $"乔峰{Guid.NewGuid().ToString()}";
                user.Name = name1;
                await dbContext.Users.DynamicCollectionReplaceOneAsync(session, userGroup, user.Id, user);

                // 验证替换是否成功
                var replaceedUser1 = await dbContext.Users.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
                Assert.AreEqual(replaceedUser1.Name, name1, "未成功替换用户。");


                // 替换用户2
                var name2 = $"虚竹{Guid.NewGuid().ToString()}";
                user.Name = name2;
                await dbContext.Users.DynamicCollectionReplaceOneAsync(session, userGroup, r => r.Id == user.Id, user);

                // 验证替换是否成功
                var replaceedUser2 = await dbContext.Users.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
                Assert.AreEqual(replaceedUser2.Name, name2, "未成功替换用户。");

                // 替换用户3
                var name3 = $"段誉{Guid.NewGuid().ToString()}";
                user.Name = name3;
                await dbContext.Users.DynamicCollectionReplaceOneAsync(session, userGroup, new FilterDefinitionBuilder<User>().Eq(f => f.Id, user.Id), user);

                // 删除用户
                await dbContext.Users.DynamicCollectionDeleteOneAsync(session, userGroup, user);

                // 验证删除是否成功
                var deletedUser = await dbContext.Users.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
                Assert.IsNull(deletedUser, "用户未成功删除。");

                session.CommitTransaction();
            }
        }

        [TestMethod]
        public void TestFindOneAndReplaceOne()
        {
            var user = DataHelper.GetNewUser();
            dbContext.Users.Add(user);

            // 验证添加是否成功
            var addedUser = dbContext.Users.FindOne(user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 替换用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            user.Name = name1;
            var result1 = dbContext.Users.FindOneAndReplaceOne(user.Id, user);

            // 验证替换是否成功
            var replaceedUser1 = dbContext.Users.FindOne(user.Id);
            Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功替换用户。");


            // 替换用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            user.Name = name2;
            var result2 = dbContext.Users.FindOneAndReplaceOne(r => r.Id == user.Id, user);

            // 验证替换是否成功
            var replaceedUser2 = dbContext.Users.FindOne(user.Id);
            Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功替换用户。");

            // 替换用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            user.Name = name3;
            var result3 = dbContext.Users.FindOneAndReplaceOne(new FilterDefinitionBuilder<User>().Eq(f => f.Id, user.Id), user);

            var replaceedUser3 = dbContext.Users.FindOne(user.Id);
            Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功替换用户。");

            // 删除用户
            dbContext.Users.DeleteOne(user);

            // 验证删除是否成功
            var deletedUser = dbContext.Users.FindOne(user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");
        }

        [TestMethod]
        public async Task TestFindOneAndReplaceOneAsync()
        {
            var user = DataHelper.GetNewUser();
            await dbContext.Users.AddAsync(user);

            // 验证添加是否成功
            var addedUser = await dbContext.Users.FindOneAsync(user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");

            // 替换用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            user.Name = name1;
            var result1 = await dbContext.Users.FindOneAndReplaceOneAsync(user.Id, user);

            // 验证替换是否成功
            var replaceedUser1 = await dbContext.Users.FindOneAsync(user.Id);
            Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功替换用户。");


            // 替换用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            user.Name = name2;
            var result2 = await dbContext.Users.FindOneAndReplaceOneAsync(r => r.Id == user.Id, user);

            // 验证替换是否成功
            var replaceedUser2 = await dbContext.Users.FindOneAsync(user.Id);
            Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功替换用户。");

            // 替换用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            user.Name = name3;
            var result3 = await dbContext.Users.FindOneAndReplaceOneAsync(new FilterDefinitionBuilder<User>().Eq(f => f.Id, user.Id), user);

            var replaceedUser3 = await dbContext.Users.FindOneAsync(user.Id);
            Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功替换用户。");


            // 删除用户
            await dbContext.Users.DeleteOneAsync(user);

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.FindOneAsync(user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");
        }

        [TestMethod]
        public void TestFindOneAndReplaceOneSession()
        {
            using (var session = dbContext.Client.StartSession())
            {
                session.StartTransaction();

                var user = DataHelper.GetNewUser();

                dbContext.Users.Add(session, user);

                // 验证添加是否成功
                var addedUser = dbContext.Users.FindOne(session, user.Id);
                Assert.IsNotNull(addedUser, "未成功添加用户。");


                // 替换用户1
                var name1 = $"乔峰{Guid.NewGuid().ToString()}";
                user.Name = name1;
                var result1 = dbContext.Users.FindOneAndReplaceOne(session, user.Id, user);

                // 验证替换是否成功
                var replaceedUser1 = dbContext.Users.FindOne(session, user.Id);
                Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功替换用户。");


                // 替换用户2
                var name2 = $"虚竹{Guid.NewGuid().ToString()}";
                user.Name = name2;
                var result2 = dbContext.Users.FindOneAndReplaceOne(session, r => r.Id == user.Id, user);

                // 验证替换是否成功
                var replaceedUser2 = dbContext.Users.FindOne(session, user.Id);
                Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功替换用户。");

                // 替换用户3
                var name3 = $"段誉{Guid.NewGuid().ToString()}";
                user.Name = name3;
                var result3 = dbContext.Users.FindOneAndReplaceOne(session, new FilterDefinitionBuilder<User>().Eq(f => f.Id, user.Id), user);

                var replaceedUser3 = dbContext.Users.FindOne(session, user.Id);
                Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功替换用户。");

                // 删除用户
                dbContext.Users.DeleteOne(session, user);

                // 验证删除是否成功
                var deletedUser = dbContext.Users.FindOne(session, user.Id);
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

                await dbContext.Users.AddAsync(session, user);

                // 验证添加是否成功
                var addedUser = await dbContext.Users.FindOneAsync(session, user.Id);
                Assert.IsNotNull(addedUser, "未成功添加用户。");


                // 替换用户1
                var name1 = $"乔峰{Guid.NewGuid().ToString()}";
                user.Name = name1;
                var result1 = await dbContext.Users.FindOneAndReplaceOneAsync(session, user.Id, user);

                // 验证替换是否成功
                var replaceedUser1 = await dbContext.Users.FindOneAsync(session, user.Id);
                Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功替换用户。");


                // 替换用户2
                var name2 = $"虚竹{Guid.NewGuid().ToString()}";
                user.Name = name2;
                var result2 = await dbContext.Users.FindOneAndReplaceOneAsync(session, r => r.Id == user.Id, user);

                // 验证替换是否成功
                var replaceedUser2 = await dbContext.Users.FindOneAsync(session, user.Id);
                Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功替换用户。");

                // 替换用户3
                var name3 = $"段誉{Guid.NewGuid().ToString()}";
                user.Name = name3;
                var result3 = await dbContext.Users.FindOneAndReplaceOneAsync(session, new FilterDefinitionBuilder<User>().Eq(f => f.Id, user.Id), user);

                var replaceedUser3 = await dbContext.Users.FindOneAsync(session, user.Id);
                Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功替换用户。");

                // 删除用户
                await dbContext.Users.DeleteOneAsync(session, user);

                // 验证删除是否成功
                var deletedUser = await dbContext.Users.FindOneAsync(session, user.Id);
                Assert.IsNull(deletedUser, "用户未成功删除。");

                session.CommitTransaction();
            }
        }

        [TestMethod]
        public void TestFindOneAndReplaceOneDynamic()
        {
            var user = DataHelper.GetNewUser();
            var userGroup = DataHelper.GetNewUserGroup();
            dbContext.Users.DynamicCollectionAdd(userGroup, user);

            // 验证添加是否成功
            var addedUser = dbContext.Users.DynamicCollectionFindOne(userGroup, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 替换用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            user.Name = name1;
            var result1 = dbContext.Users.DynamicCollectionFindOneAndReplaceOne(userGroup, user.Id, user);

            // 验证替换是否成功
            var replaceedUser1 = dbContext.Users.DynamicCollectionFindOne(userGroup, user.Id);
            Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功替换用户。");


            // 替换用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            user.Name = name2;
            var result2 = dbContext.Users.DynamicCollectionFindOneAndReplaceOne(userGroup, r => r.Id == user.Id, user);

            // 验证替换是否成功
            var replaceedUser2 = dbContext.Users.DynamicCollectionFindOne(userGroup, user.Id);
            Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功替换用户。");

            // 替换用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            user.Name = name3;
            var result3 = dbContext.Users.DynamicCollectionFindOneAndReplaceOne(userGroup, new FilterDefinitionBuilder<User>().Eq(f => f.Id, user.Id), user);

            var replaceedUser3 = dbContext.Users.DynamicCollectionFindOne(userGroup, user.Id);
            Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功替换用户。");

            // 删除用户
            dbContext.Users.DynamicCollectionDeleteOne(userGroup, user);

            // 验证删除是否成功
            var deletedUser = dbContext.Users.DynamicCollectionFindOne(userGroup, user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");
        }

        [TestMethod]
        public async Task TestFindOneAndReplaceOneDynamicAsync()
        {
            var user = DataHelper.GetNewUser();
            var userGroup = DataHelper.GetNewUserGroup();
            await dbContext.Users.DynamicCollectionAddAsync(userGroup, user);

            // 验证添加是否成功
            var addedUser = await dbContext.Users.DynamicCollectionFindOneAsync(userGroup, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 替换用户1
            var name1 = $"乔峰{Guid.NewGuid().ToString()}";
            user.Name = name1;
            var result1 = await dbContext.Users.DynamicCollectionFindOneAndReplaceOneAsync(userGroup, user.Id, user);

            // 验证替换是否成功
            var replaceedUser1 = await dbContext.Users.DynamicCollectionFindOneAsync(userGroup, user.Id);
            Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功替换用户。");


            // 替换用户2
            var name2 = $"虚竹{Guid.NewGuid().ToString()}";
            user.Name = name2;
            var result2 = await dbContext.Users.DynamicCollectionFindOneAndReplaceOneAsync(userGroup, r => r.Id == user.Id, user);

            // 验证替换是否成功
            var replaceedUser2 = await dbContext.Users.DynamicCollectionFindOneAsync(userGroup, user.Id);
            Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功替换用户。");

            // 替换用户3
            var name3 = $"段誉{Guid.NewGuid().ToString()}";
            user.Name = name3;
            var result3 = await dbContext.Users.DynamicCollectionFindOneAndReplaceOneAsync(userGroup, new FilterDefinitionBuilder<User>().Eq(f => f.Id, user.Id), user);

            var replaceedUser3 = await dbContext.Users.DynamicCollectionFindOneAsync(userGroup, user.Id);
            Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功替换用户。");

            // 删除用户
            await dbContext.Users.DynamicCollectionDeleteOneAsync(userGroup, user);

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.DynamicCollectionFindOneAsync(userGroup, user.Id);
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

                dbContext.Users.DynamicCollectionAdd(session, userGroup, user);

                // 验证添加是否成功
                var addedUser = dbContext.Users.DynamicCollectionFindOne(session, userGroup, user.Id);
                Assert.IsNotNull(addedUser, "未成功添加用户。");


                // 替换用户1
                var name1 = $"乔峰{Guid.NewGuid().ToString()}";
                user.Name = name1;
                var result1 = dbContext.Users.DynamicCollectionFindOneAndReplaceOne(session, userGroup, user.Id, user);

                // 验证替换是否成功
                var replaceedUser1 = dbContext.Users.DynamicCollectionFindOne(session, userGroup, user.Id);
                Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功替换用户。");


                // 替换用户2
                var name2 = $"虚竹{Guid.NewGuid().ToString()}";
                user.Name = name2;
                var result2 = dbContext.Users.DynamicCollectionFindOneAndReplaceOne(session, userGroup, r => r.Id == user.Id, user);

                // 验证替换是否成功
                var replaceedUser2 = dbContext.Users.DynamicCollectionFindOne(session, userGroup, user.Id);
                Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功替换用户。");

                // 替换用户3
                var name3 = $"段誉{Guid.NewGuid().ToString()}";
                user.Name = name3;
                var result3 = dbContext.Users.DynamicCollectionFindOneAndReplaceOne(session, userGroup, new FilterDefinitionBuilder<User>().Eq(f => f.Id, user.Id), user);

                var replaceedUser3 = dbContext.Users.DynamicCollectionFindOne(session, userGroup, user.Id);
                Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功替换用户。");

                // 删除用户
                dbContext.Users.DynamicCollectionDeleteOne(session, userGroup, user);

                // 验证删除是否成功
                var deletedUser = dbContext.Users.DynamicCollectionFindOne(session, userGroup, user.Id);
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

                await dbContext.Users.DynamicCollectionAddAsync(session, userGroup, user);

                // 验证添加是否成功
                var addedUser = await dbContext.Users.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
                Assert.IsNotNull(addedUser, "未成功添加用户。");


                // 替换用户1
                var name1 = $"乔峰{Guid.NewGuid().ToString()}";
                user.Name = name1;
                var result1 = await dbContext.Users.DynamicCollectionFindOneAndReplaceOneAsync(session, userGroup, user.Id, user);

                // 验证替换是否成功
                var replaceedUser1 = await dbContext.Users.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
                Assert.AreNotEqual(replaceedUser1.Name, result1.Name, "未成功替换用户。");


                // 替换用户2
                var name2 = $"虚竹{Guid.NewGuid().ToString()}";
                user.Name = name2;
                var result2 = await dbContext.Users.DynamicCollectionFindOneAndReplaceOneAsync(session, userGroup, r => r.Id == user.Id, user);

                // 验证替换是否成功
                var replaceedUser2 = await dbContext.Users.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
                Assert.AreNotEqual(replaceedUser2.Name, result2.Name, "未成功替换用户。");

                // 替换用户3
                var name3 = $"段誉{Guid.NewGuid().ToString()}";
                user.Name = name3;
                var result3 = await dbContext.Users.DynamicCollectionFindOneAndReplaceOneAsync(session, userGroup, new FilterDefinitionBuilder<User>().Eq(f => f.Id, user.Id), user);

                var replaceedUser3 = await dbContext.Users.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
                Assert.AreNotEqual(replaceedUser3.Name, result3.Name, "未成功替换用户。");

                // 删除用户
                await dbContext.Users.DynamicCollectionDeleteOneAsync(session, userGroup, user);

                // 验证删除是否成功
                var deletedUser = await dbContext.Users.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
                Assert.IsNull(deletedUser, "用户未成功删除。");

                session.CommitTransaction();
            }
        }
    }
}
