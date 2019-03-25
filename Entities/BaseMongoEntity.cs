using MongoDB.Bson.Serialization.Attributes;
using System;
using MongoDB.Bson;

namespace Apteryx.MongoDB.Driver.Extend.Entities
{
    public abstract class BaseMongoEntity : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreateTime { get; set; } = DateTime.Now;

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime UpdateTime { get; set; } = DateTime.Now;
    }
}
