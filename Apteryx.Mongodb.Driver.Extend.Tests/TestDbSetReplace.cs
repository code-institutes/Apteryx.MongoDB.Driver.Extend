using Apteryx.Mongodb.Driver.Extend.Tests.Data;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;

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
        public void TestReplace()
        {
            var user = DataHelper.GetNewUser();
            dbContext.Users.Add(user);

            // 验证添加是否成功
            var addedUser = dbContext.Users.FindOne(user.Id);
            Assert.IsNotNull(addedUser, "未成功添加用户。");


            // 替换用户
            user.Name = "乔峰";
            dbContext.Users.WhereReplaceOne(user.Id, user);

            // 验证添加是否成功
            var replaceedUser = dbContext.Users.FindOne(user.Id);
            Assert.AreEqual(replaceedUser.Name, "乔峰", "未成功替换用户。");

            // 删除用户
            dbContext.Users.DeleteOne(user);

            // 验证删除是否成功
            var deletedUser = dbContext.Users.FindOne(user.Id);
            Assert.IsNull(deletedUser, "用户未成功删除。");
        }

        [TestMethod]
        public void TestReplaceSession()
        {
            using (var session = dbContext.Client.StartSession())
            {
                session.StartTransaction();

                var user = DataHelper.GetNewUser();
                dbContext.Users.Add(session, user);

                // 验证添加是否成功
                var addedUser = dbContext.Users.FindOne(session, user.Id);
                Assert.IsNotNull(addedUser, "未成功添加用户。");


                // 替换用户
                user.Name = "乔峰";
                dbContext.Users.WhereReplaceOne(session, user.Id, user);

                // 验证添加是否成功
                var replaceedUser = dbContext.Users.FindOne(session, user.Id);
                Assert.AreEqual(replaceedUser.Name, "乔峰", "未成功替换用户。");

                // 删除用户
                dbContext.Users.DeleteOne(session, user);

                // 验证删除是否成功
                var deletedUser = dbContext.Users.FindOne(session, user.Id);
                Assert.IsNull(deletedUser, "用户未成功删除。");

                session.CommitTransaction();
            }
        }
    }
}
