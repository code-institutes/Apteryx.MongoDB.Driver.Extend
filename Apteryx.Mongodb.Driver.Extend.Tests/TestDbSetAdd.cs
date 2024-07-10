using Apteryx.Mongodb.Driver.Extend.Tests.Data;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using System.Xml.Linq;

namespace Apteryx.Mongodb.Driver.Extend.Tests
{
    [TestClass]
    public class TestDbSetAdd : TestBase
    {
        private readonly ApteryxDbContext? dbContext;
        private List<User> newUsers = new List<User>()
            {
                new User()
        {
            Name = "张飞",
                    Email = "zhangfei@qq.com",
                    Id = ObjectId.GenerateNewId().ToString(),
                    },
                new User()
        {
            Name = "关羽",
                    Email = "zhangfei@qq.com",
                    Id = ObjectId.GenerateNewId().ToString(),
                },
                new User()
        {
            Name = "张无忌",
                    Email = "zhangfei@qq.com",
                    Id = ObjectId.GenerateNewId().ToString(),
                }
    };

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
            // 创建一个新的 User 实例
            var newUser = new User { Id = ObjectId.GenerateNewId().ToString(), Name = "Test User" };

            dbContext.Users.Add(newUser);

            // 验证添加是否成功
            var addedUser = dbContext.Users.FindOne(newUser.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 删除用户
            dbContext.Users.DeleteOne(addedUser);

            // 验证删除是否成功
            var deletedUser = dbContext.Users.FindOne(newUser.Id);
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
                dbContext.Users.DeleteOne(session, addedUser);

                // 验证删除是否成功
                var deletedUser = dbContext.Users.FindOne(session, newUser.Id);
                Assert.IsNull(deletedUser, "用户未成功删除。");

                session.CommitTransaction();
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
            await dbContext.Users.DeleteOneAsync(addedUser);

            // 验证删除是否成功
            var deletedUser = await dbContext.Users.FindOneAsync(newUser.Id);
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
                await dbContext.Users.DeleteOneAsync(session, addedUser);

                // 验证删除是否成功
                var deletedUser = await dbContext.Users.FindOneAsync(session, newUser.Id);
                Assert.IsNull(deletedUser, "用户未成功删除。");

                session.CommitTransaction();
            }
        }

        /// <summary>
        /// 测试批量添加、查询、删除（同步方法）
        /// </summary>
        [TestMethod]
        public void TestAddMany()
        {
            dbContext.Users.DeleteMany(d => d.Email == "zhangfei@qq.com");

            dbContext.Users.AddMany(newUsers);

            // 验证添加是否成功
            var addedUser = dbContext.Users.Where(w => w.Email == "zhangfei@qq.com").CountDocuments();

            Assert.IsNotNull(addedUser, "未成功添加用户。");

            Assert.AreEqual(addedUser, 3, "未成功添加，数量不正确");


            // 删除用户
            dbContext.Users.DeleteMany(newUsers);

            // 验证删除是否成功
            var deletedUser = dbContext.Users.Where(w => w.Email == "zhangfei@qq.com").CountDocuments();
            Assert.AreEqual(deletedUser, 0, "用户未成功删除。");
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

                dbContext.Users.DeleteMany(session, d => d.Email == "zhangfei@qq.com");

                dbContext.Users.AddMany(session, newUsers);

                // 验证添加是否成功
                var addedUser = dbContext.Users.Where(session, w => w.Email == "zhangfei@qq.com").CountDocuments();

                Assert.IsNotNull(addedUser, "未成功添加用户。");

                Assert.AreEqual(addedUser, 3, "未成功添加，数量不正确");


                // 删除用户
                dbContext.Users.DeleteMany(session, newUsers);

                // 验证删除是否成功
                var deletedUser = dbContext.Users.Where(session, w => w.Email == "zhangfei@qq.com").CountDocuments();
                Assert.AreEqual(deletedUser, 0, "用户未成功删除。");

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
            await dbContext.Users.DeleteManyAsync(d => d.Email == "zhangfei@qq.com");

            await dbContext.Users.AddManyAsync(newUsers);

            // 验证添加是否成功
            List<User> addedUser = new();
            await foreach (var user in dbContext.Users.WhereAsync(w => w.Email == "zhangfei@qq.com"))
            {
                addedUser.Add(user);
            }
            Assert.IsNotNull(addedUser, "未成功添加用户。");

            Assert.AreEqual(addedUser.Count, 3, "未成功添加，数量不正确");


            // 删除用户
            await dbContext.Users.DeleteManyAsync(newUsers);

            // 验证删除是否成功
            addedUser.Clear();
            await foreach (var user in dbContext.Users.WhereAsync(w => w.Email == "zhangfei@qq.com"))
            {
                addedUser.Add(user);
            }
            Assert.AreEqual(addedUser.Count, 0, "用户未成功删除。");
        }

        /// <summary>
        /// 测试事务批量添加、查询、删除（异步方法）
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task TestAddManySession()
        {
            using (var session = await dbContext.Client.StartSessionAsync())
            {
                session.StartTransaction();

                await dbContext.Users.DeleteManyAsync(session, d => d.Email == "zhangfei@qq.com");

                await dbContext.Users.AddManyAsync(session, newUsers);

                // 验证添加是否成功
                List<User> addedUser = new();
                await foreach (var user in dbContext.Users.WhereAsync(session, w => w.Email == "zhangfei@qq.com"))
                {
                    addedUser.Add(user);
                }
                Assert.IsNotNull(addedUser, "未成功添加用户。");

                Assert.AreEqual(addedUser.Count, 3, "未成功添加，数量不正确");


                // 删除用户
                await dbContext.Users.DeleteManyAsync(session, newUsers);

                // 验证删除是否成功
                addedUser.Clear();
                await foreach (var user in dbContext.Users.WhereAsync(session, w => w.Email == "zhangfei@qq.com"))
                {
                    addedUser.Add(user);
                }
                Assert.AreEqual(addedUser.Count, 0, "用户未成功删除。");

                session.CommitTransaction();
            }
        }
    }
}
