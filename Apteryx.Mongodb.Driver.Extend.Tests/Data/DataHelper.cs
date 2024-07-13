using MongoDB.Bson;

namespace Apteryx.Mongodb.Driver.Extend.Tests.Data
{
    public static class DataHelper
    {
        public static List<User> GetNewUsers(string? pwd = null) => new List<User>()
        {
            new User()
            {
                Name = "张飞",
                Email = "zhangfei@qq.com",
                Password = pwd ?? "123456",
                Id = ObjectId.GenerateNewId().ToString(),
            },
            new User()
            {
                Name = "关羽",
                Email = "zhangfei@qq.com",
                Password = pwd ?? "123456",
                Id = ObjectId.GenerateNewId().ToString(),
            },
            new User()
            {
                Name = "张无忌",
                Email = "zhangfei@qq.com",
                Password = pwd ?? "123456",
                Id = ObjectId.GenerateNewId().ToString(),
            },
            new User()
            {
                Name = "乔峰",
                Email = "qiaofeng@qq.com",
                Password = pwd ?? "123456",
                Id = ObjectId.GenerateNewId().ToString(),
            },
            new User()
            {
                Name = "虚竹",
                Email = "qiaofeng@qq.com",
                Password = pwd ?? "123456",
                Id = ObjectId.GenerateNewId().ToString(),
            },
            new User()
            {
                Name = "段誉",
                Email = "qiaofeng@qq.com",
                Password = pwd ?? "123456",
                Id = ObjectId.GenerateNewId().ToString(),
            }
        };

        public static User GetNewUser(string name = null) => new User { Id = ObjectId.GenerateNewId().ToString(), Name = name ?? "Test User" };

        public static UserGroup GetNewUserGroup(string name = null) => new UserGroup() { Id = ObjectId.GenerateNewId().ToString(), Name = name ?? "Test UserGroup" };
    }
}
