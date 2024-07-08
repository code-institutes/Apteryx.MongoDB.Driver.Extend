using System;

namespace Apteryx.MongoDB.Driver.Extend
{
    public interface IEntity
    {
        string Id { get; set; }
        DateTime CreateTime { get; set; }
        DateTime UpdateTime { get; set; }
    }
}
