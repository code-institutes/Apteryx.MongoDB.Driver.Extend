using Apteryx.Mongodb.Driver.Extend;
using Apteryx.MongoDB.Driver.Extend;

namespace Apteryx.WebApi.Data;

[MongoIndex("Name:desc", Unique = false)]
[MongoIndex("Email:desc", Unique = false)]
[MongoIndex("Name:desc","Email:desc",Unique = false)]
[MongoIndex("CreateTime:asc", TtlSeconds = 30)]
public class User : BaseMongoEntity
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}
