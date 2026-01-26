namespace Apteryx.MongoDB.Driver.Extend.Tests.Data;

public class UserGroup:BaseMongoEntity
{
    public string? Name { get; set; }
    public string? Desc { get; set; }
    public long Count { get; set; }
}
