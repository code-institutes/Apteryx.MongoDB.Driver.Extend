using MongoDB.Bson.Serialization.Attributes;
using System;
using MongoDB.Bson;

namespace Apteryx.MongoDB.Driver.Extend
{
    public abstract class BaseMongoEntity : IEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 更新时间
        /// </summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime UpdateTime { get; set; } = DateTime.Now;
    }
}
