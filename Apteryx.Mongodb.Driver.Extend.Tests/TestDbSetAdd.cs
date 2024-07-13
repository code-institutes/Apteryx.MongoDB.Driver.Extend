using Apteryx.Mongodb.Driver.Extend.Tests.Data;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;

namespace Apteryx.Mongodb.Driver.Extend.Tests
{
    [TestClass]
    public class TestDbSetAdd : TestBase
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

        public TestDbSetAdd()
        {
            this.dbContext = ServiceProvider.GetService<ApteryxDbContext>();
        }

        /// <summary>
        /// 测试添加、查询、删除（同步方法）
        /// </summary>
        [TestMethod]
        public void TestAdd()
        {
            dbContext.Users.Add(user);

            // 验证添加是否成功
            var addedUser = dbContext.Users.FindOne(user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 删除用户
            var result = dbContext.Users.DeleteOne(addedUser);

            // 验证删除是否成功
            var deletedUser = dbContext.Users.FindOne(user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");
        }

        /// <summary>
        /// 测试动态添加、查询、删除（同步方法）
        /// </summary>
        [TestMethod]
        public void TestAddDynamic()
        {
            var userGroup = DataHelper.GetNewUserGroup();

            dbContext.Users.DynamicCollectionAdd(userGroup, user);

            // 验证添加是否成功
            var addedUser = dbContext.Users.DynamicCollectionFindOne(userGroup, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 删除用户
            dbContext.Users.DynamicCollectionDeleteOne(userGroup, addedUser);

            // 验证删除是否成功
            var deletedUser = dbContext.Users.DynamicCollectionFindOne(userGroup, user.Id);
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

                dbContext.Users.Add(session, newUser);

                // 验证添加是否成功
                var addedUser = dbContext.Users.FindOne(session, newUser.Id);
                Assert.IsNotNull(addedUser, "未成功添加用户。");


                // 删除用户
                 var result = dbContext.Users.DeleteOne(session, addedUser);

                // 验证删除是否成功
                var deletedUser = dbContext.Users.FindOne(session, newUser.Id);
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

                dbContext.Users.DynamicCollectionAdd(session, userGroup, user);

                // 验证添加是否成功
                var addedUser = dbContext.Users.DynamicCollectionFindOne(session, userGroup, user.Id);
                Assert.IsNotNull(addedUser, "未成功添加用户。");


                // 删除用户
                dbContext.Users.DynamicCollectionDeleteOne(session, userGroup, addedUser);

                // 验证删除是否成功
                var deletedUser = dbContext.Users.DynamicCollectionFindOne(session, userGroup, user.Id);
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

            await dbContext.Users.AddAsync(newUser);

            // 验证添加是否成功
            var addedUser = await dbContext.Users.FindOneAsync(newUser.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");

            // 删除用户
            var result = await dbContext.Users.DeleteOneAsync(addedUser);

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.FindOneAsync(newUser.Id);
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

            await dbContext.Users.DynamicCollectionAddAsync(userGroup, user);

            // 验证添加是否成功
            var addedUser = dbContext.Users.DynamicCollectionFindOne(userGroup, user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 删除用户
            dbContext.Users.DynamicCollectionDeleteOne(userGroup, addedUser);

            // 验证删除是否成功
            var deletedUser = dbContext.Users.DynamicCollectionFindOne(userGroup, user.Id);
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

                await dbContext.Users.AddAsync(session, newUser);

                // 验证添加是否成功
                var addedUser = await dbContext.Users.FindOneAsync(session, newUser.Id);
                Assert.IsNotNull(addedUser, "未成功添加用户。");

                // 删除用户
                var result = await dbContext.Users.DeleteOneAsync(session, addedUser);

                // 验证删除是否成功
                var deletedUser = await dbContext.Users.FindOneAsync(session, newUser.Id);
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

                await dbContext.Users.DynamicCollectionAddAsync(session, userGroup, user);

                // 验证添加是否成功
                var addedUser = await dbContext.Users.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
                Assert.IsNotNull(addedUser, "未成功添加用户。");


                // 删除用户
                var result = await dbContext.Users.DynamicCollectionDeleteOneAsync(session, userGroup, addedUser);

                // 验证删除是否成功
                var deletedUser = await dbContext.Users.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
                Assert.IsNull(deletedUser, "用户未成功删除。");
            }
        }

        /// <summary>
        /// 测试批量添加、查询、删除（同步方法）
        /// </summary>
        [TestMethod]
        public void TestAddMany()
        {
            dbContext.Users.AddMany(users);

            // 验证添加是否成功
            var addedUserCount = dbContext.Users.Where(w => w.Email == "zhangfei@qq.com").CountDocuments();
            Assert.AreEqual(3, addedUserCount, "未成功添加，数量不正确");


            // 删除用户
            var result = dbContext.Users.DeleteMany(users);

            // 验证删除是否成功
            var deletedUserCount = dbContext.Users.Where(w => true).CountDocuments();
            Assert.AreEqual(0, deletedUserCount, "用户未成功删除。");
        }

        /// <summary>
        /// 测试动态批量添加、查询、删除（同步方法）
        /// </summary>
        [TestMethod]
        public void TestAddManyDynamic()
        {
            var userGroup = DataHelper.GetNewUserGroup();

            dbContext.Users.DynamicCollectionAddMany(userGroup, users);

            // 验证添加是否成功
            var addedUserCount = dbContext.Users.DynamicCollectionWhere(userGroup, w => w.Email == "zhangfei@qq.com").CountDocuments();
            Assert.AreEqual(3, addedUserCount, "未成功添加，数量不正确");


            // 删除用户
            dbContext.Users.DynamicCollectionDeleteMany(userGroup, users);

            // 验证删除是否成功
            var deletedUserCount = dbContext.Users.DynamicCollectionWhere(userGroup, w => true).CountDocuments();
            Assert.AreEqual(0, deletedUserCount, "用户未成功删除。");
        }

        /// <summary>
        /// 测试事务批量添加、查询、删除（同步方法）
        /// </summary>
        [TestMethod]
        public void AddManySession()
        {
            using (var session = dbContext.Client.StartSession())
            {
                session.StartTransaction();

                dbContext.Users.AddMany(session, users);

                // 验证添加是否成功
                var addedUserCount = dbContext.Users.Where(session, w => w.Email == "zhangfei@qq.com").CountDocuments();

                Assert.IsNotNull(addedUserCount, "未成功添加用户。");

                Assert.AreEqual(3, addedUserCount, "未成功添加，数量不正确");


                // 删除用户
                var result = dbContext.Users.DeleteMany(session, users);

                // 验证删除是否成功
                var deletedUserCount = dbContext.Users.Where(session, w => true).CountDocuments();
                Assert.AreEqual(0, deletedUserCount, "用户未成功删除。");

                session.CommitTransaction();
            }
        }

        [TestMethod]
        public void AddManyDynamicSession()
        {
            var userGroup = DataHelper.GetNewUserGroup();

            using (var session = dbContext.Client.StartSession())
            {
                session.StartTransaction();

                dbContext.Users.DynamicCollectionDeleteMany(session, userGroup, d => d.Password == "123456");

                dbContext.Users.DynamicCollectionAddMany(session, userGroup, users);

                // 验证添加是否成功
                var addedUserCount = dbContext.Users.DynamicCollectionWhere(session, userGroup, w => w.Email == "zhangfei@qq.com").CountDocuments();
                Assert.AreEqual(3, addedUserCount, "未成功添加，数量不正确");


                // 删除用户
                dbContext.Users.DynamicCollectionDeleteMany(session, userGroup, users);

                // 验证删除是否成功
                var deletedUserCount = dbContext.Users.DynamicCollectionWhere(session, userGroup, w => true).CountDocuments();
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
            await dbContext.Users.AddManyAsync(users);

            // 验证添加是否成功
            List<User> addedUser = new();
            await foreach (var user in dbContext.Users.WhereAsync(w => w.Email == "zhangfei@qq.com"))
            {
                addedUser.Add(user);
            }
            Assert.AreEqual(3, addedUser.Count, "未成功添加，数量不正确");


            // 删除用户
            var result = await dbContext.Users.DeleteManyAsync(users);

            // 验证删除是否成功
            addedUser.Clear();
            await foreach (var user in dbContext.Users.WhereAsync(w => true))
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

            await dbContext.Users.DynamicCollectionAddManyAsync(userGroup, users);

            // 验证添加是否成功
            List<User> addedUser = new();
            await foreach (var user in dbContext.Users.DynamicCollectionWhereAsync(userGroup, w => w.Email == "zhangfei@qq.com"))
            {
                addedUser.Add(user);
            }
            Assert.AreEqual(3, addedUser.Count, "未成功添加，数量不正确");


            // 删除用户
            var result = await dbContext.Users.DynamicCollectionDeleteManyAsync(userGroup, users);

            // 验证删除是否成功
            addedUser.Clear();
            await foreach (var user in dbContext.Users.DynamicCollectionWhereAsync(userGroup, w => true))
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

                await dbContext.Users.AddManyAsync(session, users);

                // 验证添加是否成功
                List<User> addedUser = new();
                await foreach (var user in dbContext.Users.WhereAsync(session, w => w.Email == "zhangfei@qq.com"))
                {
                    addedUser.Add(user);
                }
                Assert.AreEqual(3, addedUser.Count, "未成功添加，数量不正确");


                // 删除用户
                var result = await dbContext.Users.DeleteManyAsync(session, users);

                // 验证删除是否成功
                addedUser.Clear();
                await foreach (var user in dbContext.Users.WhereAsync(session, w => true))
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

                await dbContext.Users.DynamicCollectionAddManyAsync(session, userGroup, users);

                // 验证添加是否成功
                List<User> addedUser = new();
                await foreach (var user in dbContext.Users.DynamicCollectionWhereAsync(session, userGroup, w => w.Email == "zhangfei@qq.com"))
                {
                    addedUser.Add(user);
                }
                Assert.AreEqual(3, addedUser.Count, "未成功添加，数量不正确");

                // 删除用户
                var result = await dbContext.Users.DynamicCollectionDeleteManyAsync(session, userGroup, users);

                // 验证删除是否成功
                addedUser.Clear();
                await foreach (var user in dbContext.Users.DynamicCollectionWhereAsync(session, userGroup, w => true))
                {
                    addedUser.Add(user);
                }
                Assert.AreEqual(0, addedUser.Count, "用户未成功删除。");

                session.CommitTransaction();
            }
        }
    }
}
