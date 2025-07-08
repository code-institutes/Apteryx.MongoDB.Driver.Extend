using Apteryx.MongoDB.Driver.Extend;

namespace Apteryx.WebApi.Data;
public class User : BaseMongoEntity
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}
