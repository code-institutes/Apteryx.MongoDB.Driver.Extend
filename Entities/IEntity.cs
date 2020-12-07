using System;
using MongoDB.Bson;

namespace Apteryx.MongoDB.Driver.Extend.Entities
{
    public interface IEntity
    {
        string Id { get; set; }
        DateTime CreateTime { get; set; }
        DateTime UpdateTime { get; set; }
    }
}
