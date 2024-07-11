using Apteryx.Mongodb.Driver.Extend.Tests.Data;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;

namespace Apteryx.Mongodb.Driver.Extend.Tests
{
    [TestClass]
    public class TestDbSetAdd : TestBase
    {
        private readonly ApteryxDbContext? dbContext;

        private List<User> newUsers = DataHelper.GetNewUsers();

        private User user = DataHelper.GetNewUser();

        [TestInitialize]
        public void TestInitialize()
        {
            // ȷ�� dbContext ��Ϊ null
            Assert.IsNotNull(dbContext, "�޷��ӷ����ṩ�����ȡApteryxDbContext��"); ;
        }

        public TestDbSetAdd()
        {
            this.dbContext = ServiceProvider.GetService<ApteryxDbContext>();
        }

        /// <summary>
        /// ������ӡ���ѯ��ɾ����ͬ��������
        /// </summary>
        [TestMethod]
        public void TestAdd()
        {
            dbContext.Users.Add(user);

            // ��֤����Ƿ�ɹ�
            var addedUser = dbContext.Users.FindOne(user.Id);
            Assert.IsNotNull(addedUser, "δ�ɹ�����û���");


            // ɾ���û�
            dbContext.Users.DeleteOne(addedUser);

            // ��֤ɾ���Ƿ�ɹ�
            var deletedUser = dbContext.Users.FindOne(user.Id);
            Assert.IsNull(deletedUser, "�û�δ�ɹ�ɾ����");
        }

        /// <summary>
        /// ���Զ�̬��ӡ���ѯ��ɾ����ͬ��������
        /// </summary>
        [TestMethod]
        public void TestAddDynamic()
        {
            var userGroup = DataHelper.GetNewUserGroup();

            dbContext.Users.DynamicCollectionAdd(userGroup, user);

            // ��֤����Ƿ�ɹ�
            var addedUser = dbContext.Users.DynamicCollectionFindOne(userGroup, user.Id);
            Assert.IsNotNull(addedUser, "δ�ɹ�����û���");


            // ɾ���û�
            dbContext.Users.DynamicCollectionDeleteOne(userGroup, addedUser);

            // ��֤ɾ���Ƿ�ɹ�
            var deletedUser = dbContext.Users.DynamicCollectionFindOne(userGroup, user.Id);
            Assert.IsNull(deletedUser, "�û�δ�ɹ�ɾ����");
        }

        /// <summary>
        /// ����������ӡ���ѯ��ɾ����ͬ��������
        /// </summary>
        [TestMethod]
        public void TestAddSession()
        {
            // ����һ���µ� User ʵ��
            var newUser = new User { Id = ObjectId.GenerateNewId().ToString(), Name = "Test User" };

            using (var session = dbContext.Client.StartSession())
            {
                session.StartTransaction();

                dbContext.Users.Add(session, newUser);

                // ��֤����Ƿ�ɹ�
                var addedUser = dbContext.Users.FindOne(session, newUser.Id);
                Assert.IsNotNull(addedUser, "δ�ɹ�����û���");


                // ɾ���û�
                dbContext.Users.DeleteOne(session, addedUser);

                // ��֤ɾ���Ƿ�ɹ�
                var deletedUser = dbContext.Users.FindOne(session, newUser.Id);
                Assert.IsNull(deletedUser, "�û�δ�ɹ�ɾ����");

                session.CommitTransaction();
            }
        }

        /// <summary>
        /// ��������̬��ӡ���ѯ��ɾ����ͬ��������
        /// </summary>
        [TestMethod]
        public void TestAddDynamicSession()
        {
            using (var session = dbContext.Client.StartSession())
            {
                session.StartTransaction();

                var userGroup = DataHelper.GetNewUserGroup();

                dbContext.Users.DynamicCollectionAdd(session, userGroup, user);

                // ��֤����Ƿ�ɹ�
                var addedUser = dbContext.Users.DynamicCollectionFindOne(session, userGroup, user.Id);
                Assert.IsNotNull(addedUser, "δ�ɹ�����û���");


                // ɾ���û�
                dbContext.Users.DynamicCollectionDeleteOne(session, userGroup, addedUser);

                // ��֤ɾ���Ƿ�ɹ�
                var deletedUser = dbContext.Users.DynamicCollectionFindOne(session, userGroup, user.Id);
                Assert.IsNull(deletedUser, "�û�δ�ɹ�ɾ����");
            }
        }

        /// <summary>
        /// ������ӡ���ѯ��ɾ�����첽������
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task TestAddAsync()
        {
            // ����һ���µ� User ʵ��
            var newUser = new User { Id = ObjectId.GenerateNewId().ToString(), Name = "Test User" };

            await dbContext.Users.AddAsync(newUser);

            // ��֤����Ƿ�ɹ�
            var addedUser = await dbContext.Users.FindOneAsync(newUser.Id);
            Assert.IsNotNull(addedUser, "δ�ɹ�����û���");

            // ɾ���û�
            await dbContext.Users.DeleteOneAsync(addedUser);

            // ��֤ɾ���Ƿ�ɹ�
            var deletedUser = await dbContext.Users.FindOneAsync(newUser.Id);
            Assert.IsNull(deletedUser, "�û�δ�ɹ�ɾ����");
        }

        /// <summary>
        /// ���Զ�̬��ӡ���ѯ��ɾ�����첽������
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task TestAddDynamicAsync()
        {
            var userGroup = DataHelper.GetNewUserGroup();

            await dbContext.Users.DynamicCollectionAddAsync(userGroup, user);

            // ��֤����Ƿ�ɹ�
            var addedUser = dbContext.Users.DynamicCollectionFindOne(userGroup, user.Id);
            Assert.IsNotNull(addedUser, "δ�ɹ�����û���");


            // ɾ���û�
            dbContext.Users.DynamicCollectionDeleteOne(userGroup, addedUser);

            // ��֤ɾ���Ƿ�ɹ�
            var deletedUser = dbContext.Users.DynamicCollectionFindOne(userGroup, user.Id);
            Assert.IsNull(deletedUser, "�û�δ�ɹ�ɾ����");
        }

        /// <summary>
        /// ����������ӡ���ѯ��ɾ�����첽������
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task TestAddSessionAsync()
        {
            // ����һ���µ� User ʵ��
            var newUser = new User { Id = ObjectId.GenerateNewId().ToString(), Name = "Test User" };

            using (var session = await dbContext.Client.StartSessionAsync())
            {
                session.StartTransaction();

                await dbContext.Users.AddAsync(session, newUser);

                // ��֤����Ƿ�ɹ�
                var addedUser = await dbContext.Users.FindOneAsync(session, newUser.Id);
                Assert.IsNotNull(addedUser, "δ�ɹ�����û���");

                // ɾ���û�
                await dbContext.Users.DeleteOneAsync(session, addedUser);

                // ��֤ɾ���Ƿ�ɹ�
                var deletedUser = await dbContext.Users.FindOneAsync(session, newUser.Id);
                Assert.IsNull(deletedUser, "�û�δ�ɹ�ɾ����");

                session.CommitTransaction();
            }
        }

        /// <summary>
        /// ��������̬��ӡ���ѯ��ɾ�����첽������
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

                // ��֤����Ƿ�ɹ�
                var addedUser = await dbContext.Users.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
                Assert.IsNotNull(addedUser, "δ�ɹ�����û���");


                // ɾ���û�
                await dbContext.Users.DynamicCollectionDeleteOneAsync(session, userGroup, addedUser);

                // ��֤ɾ���Ƿ�ɹ�
                var deletedUser = await dbContext.Users.DynamicCollectionFindOneAsync(session, userGroup, user.Id);
                Assert.IsNull(deletedUser, "�û�δ�ɹ�ɾ����");
            }
        }

        /// <summary>
        /// ����������ӡ���ѯ��ɾ����ͬ��������
        /// </summary>
        [TestMethod]
        public void TestAddMany()
        {
            dbContext.Users.DeleteMany(d => d.Email == "zhangfei@qq.com");

            dbContext.Users.AddMany(newUsers);

            // ��֤����Ƿ�ɹ�
            var addedUser = dbContext.Users.Where(w => w.Email == "zhangfei@qq.com").CountDocuments();

            Assert.IsNotNull(addedUser, "δ�ɹ�����û���");

            Assert.AreEqual(addedUser, 3, "δ�ɹ���ӣ���������ȷ");


            // ɾ���û�
            dbContext.Users.DeleteMany(newUsers);

            // ��֤ɾ���Ƿ�ɹ�
            var deletedUser = dbContext.Users.Where(w => w.Email == "zhangfei@qq.com").CountDocuments();
            Assert.AreEqual(deletedUser, 0, "�û�δ�ɹ�ɾ����");
        }

        /// <summary>
        /// ���Զ�̬������ӡ���ѯ��ɾ����ͬ��������
        /// </summary>
        [TestMethod]
        public void TestAddManyDynamic()
        {
            var userGroup = DataHelper.GetNewUserGroup();

            dbContext.Users.DynamicCollectionDeleteMany(userGroup, d => d.Email == "zhangfei@qq.com");

            dbContext.Users.DynamicCollectionAddMany(userGroup, newUsers);

            // ��֤����Ƿ�ɹ�
            var addedUser = dbContext.Users.DynamicCollectionWhere(userGroup, w => w.Email == "zhangfei@qq.com").CountDocuments();

            Assert.IsNotNull(addedUser, "δ�ɹ�����û���");

            Assert.AreEqual(addedUser, 3, "δ�ɹ���ӣ���������ȷ");


            // ɾ���û�
            dbContext.Users.DynamicCollectionDeleteMany(userGroup, newUsers);

            // ��֤ɾ���Ƿ�ɹ�
            var deletedUser = dbContext.Users.DynamicCollectionWhere(userGroup, w => w.Email == "zhangfei@qq.com").CountDocuments();
            Assert.AreEqual(deletedUser, 0, "�û�δ�ɹ�ɾ����");
        }

        /// <summary>
        /// ��������������ӡ���ѯ��ɾ����ͬ��������
        /// </summary>
        [TestMethod]
        public void AddManySession()
        {
            using (var session = dbContext.Client.StartSession())
            {
                session.StartTransaction();

                dbContext.Users.DeleteMany(session, d => d.Email == "zhangfei@qq.com");

                dbContext.Users.AddMany(session, newUsers);

                // ��֤����Ƿ�ɹ�
                var addedUser = dbContext.Users.Where(session, w => w.Email == "zhangfei@qq.com").CountDocuments();

                Assert.IsNotNull(addedUser, "δ�ɹ�����û���");

                Assert.AreEqual(addedUser, 3, "δ�ɹ���ӣ���������ȷ");


                // ɾ���û�
                dbContext.Users.DeleteMany(session, newUsers);

                // ��֤ɾ���Ƿ�ɹ�
                var deletedUser = dbContext.Users.Where(session, w => w.Email == "zhangfei@qq.com").CountDocuments();
                Assert.AreEqual(deletedUser, 0, "�û�δ�ɹ�ɾ����");

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

                dbContext.Users.DynamicCollectionDeleteMany(session, userGroup, d => d.Email == "zhangfei@qq.com");

                dbContext.Users.DynamicCollectionAddMany(session, userGroup, newUsers);

                // ��֤����Ƿ�ɹ�
                var addedUser = dbContext.Users.DynamicCollectionWhere(session, userGroup, w => w.Email == "zhangfei@qq.com").CountDocuments();

                Assert.IsNotNull(addedUser, "δ�ɹ�����û���");

                Assert.AreEqual(addedUser, 3, "δ�ɹ���ӣ���������ȷ");


                // ɾ���û�
                dbContext.Users.DynamicCollectionDeleteMany(session, userGroup, newUsers);

                // ��֤ɾ���Ƿ�ɹ�
                var deletedUser = dbContext.Users.DynamicCollectionWhere(session, userGroup, w => w.Email == "zhangfei@qq.com").CountDocuments();
                Assert.AreEqual(deletedUser, 0, "�û�δ�ɹ�ɾ����");

                session.CommitTransaction();
            }
        }

        /// <summary>
        /// ����������ӡ���ѯ��ɾ�����첽������
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task TestAddManyAsync()
        {
            await dbContext.Users.DeleteManyAsync(d => d.Email == "zhangfei@qq.com");

            await dbContext.Users.AddManyAsync(newUsers);

            // ��֤����Ƿ�ɹ�
            List<User> addedUser = new();
            await foreach (var user in dbContext.Users.WhereAsync(w => w.Email == "zhangfei@qq.com"))
            {
                addedUser.Add(user);
            }
            Assert.IsNotNull(addedUser, "δ�ɹ�����û���");

            Assert.AreEqual(addedUser.Count, 3, "δ�ɹ���ӣ���������ȷ");


            // ɾ���û�
            await dbContext.Users.DeleteManyAsync(newUsers);

            // ��֤ɾ���Ƿ�ɹ�
            addedUser.Clear();
            await foreach (var user in dbContext.Users.WhereAsync(w => w.Email == "zhangfei@qq.com"))
            {
                addedUser.Add(user);
            }
            Assert.AreEqual(addedUser.Count, 0, "�û�δ�ɹ�ɾ����");
        }

        /// <summary>
        /// ���Զ�̬������ӡ���ѯ��ɾ�����첽������
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task TestAddManyDynamicAsync()
        {
            var userGroup = DataHelper.GetNewUserGroup();

            await dbContext.Users.DynamicCollectionDeleteManyAsync(userGroup, d => d.Email == "zhangfei@qq.com");

            await dbContext.Users.DynamicCollectionAddManyAsync(userGroup, newUsers);

            // ��֤����Ƿ�ɹ�
            List<User> addedUser = new();
            await foreach (var user in dbContext.Users.DynamicCollectionWhereAsync(userGroup, w => w.Email == "zhangfei@qq.com"))
            {
                addedUser.Add(user);
            }
            Assert.IsNotNull(addedUser, "δ�ɹ�����û���");

            Assert.AreEqual(addedUser.Count, 3, "δ�ɹ���ӣ���������ȷ");


            // ɾ���û�
            await dbContext.Users.DynamicCollectionDeleteManyAsync(userGroup, newUsers);

            // ��֤ɾ���Ƿ�ɹ�
            addedUser.Clear();
            await foreach (var user in dbContext.Users.DynamicCollectionWhereAsync(userGroup, w => w.Email == "zhangfei@qq.com"))
            {
                addedUser.Add(user);
            }
            Assert.AreEqual(addedUser.Count, 0, "�û�δ�ɹ�ɾ����");
        }

        /// <summary>
        /// ��������������ӡ���ѯ��ɾ�����첽������
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task TestAddManySessionAsync()
        {
            using (var session = await dbContext.Client.StartSessionAsync())
            {
                session.StartTransaction();

                await dbContext.Users.DeleteManyAsync(session, d => d.Email == "zhangfei@qq.com");

                await dbContext.Users.AddManyAsync(session, newUsers);

                // ��֤����Ƿ�ɹ�
                List<User> addedUser = new();
                await foreach (var user in dbContext.Users.WhereAsync(session, w => w.Email == "zhangfei@qq.com"))
                {
                    addedUser.Add(user);
                }
                Assert.IsNotNull(addedUser, "δ�ɹ�����û���");

                Assert.AreEqual(addedUser.Count, 3, "δ�ɹ���ӣ���������ȷ");


                // ɾ���û�
                await dbContext.Users.DeleteManyAsync(session, newUsers);

                // ��֤ɾ���Ƿ�ɹ�
                addedUser.Clear();
                await foreach (var user in dbContext.Users.WhereAsync(session, w => w.Email == "zhangfei@qq.com"))
                {
                    addedUser.Add(user);
                }
                Assert.AreEqual(addedUser.Count, 0, "�û�δ�ɹ�ɾ����");

                session.CommitTransaction();
            }
        }

        /// <summary>
        /// ��������̬������ӡ���ѯ��ɾ�����첽������
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task TestAddManyDynamicSessionAsync()
        {
            var userGroup = DataHelper.GetNewUserGroup();

            using (var session = await dbContext.Client.StartSessionAsync())
            {
                session.StartTransaction();

                await dbContext.Users.DynamicCollectionDeleteManyAsync(session, userGroup, d => d.Email == "zhangfei@qq.com");

                await dbContext.Users.DynamicCollectionAddManyAsync(session, userGroup, newUsers);

                // ��֤����Ƿ�ɹ�
                List<User> addedUser = new();
                await foreach (var user in dbContext.Users.DynamicCollectionWhereAsync(session, userGroup, w => w.Email == "zhangfei@qq.com"))
                {
                    addedUser.Add(user);
                }
                Assert.IsNotNull(addedUser, "δ�ɹ�����û���");

                Assert.AreEqual(addedUser.Count, 3, "δ�ɹ���ӣ���������ȷ");

                // ɾ���û�
                await dbContext.Users.DynamicCollectionDeleteManyAsync(session, userGroup, newUsers);

                // ��֤ɾ���Ƿ�ɹ�
                addedUser.Clear();
                await foreach (var user in dbContext.Users.DynamicCollectionWhereAsync(session, userGroup, w => w.Email == "zhangfei@qq.com"))
                {
                    addedUser.Add(user);
                }
                Assert.AreEqual(addedUser.Count, 0, "�û�δ�ɹ�ɾ����");

                session.CommitTransaction();
            }
        }
    }
}
