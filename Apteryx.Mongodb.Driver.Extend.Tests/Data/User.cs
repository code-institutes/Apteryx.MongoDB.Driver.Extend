namespace Apteryx.MongoDB.Driver.Extend.Tests.Data;

public class User : BaseMongoEntity
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Description { get; set; }
}
