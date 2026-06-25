using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Apteryx.MongoDB.Driver.Extend;

public abstract class BaseMongoEntity : IEntity
{
    /// <summary>
    /// ID
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    /// <summary>
    /// 创建时间（UTC）
    /// </summary>
    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    public DateTime CreateTime { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// 更新时间（UTC）
    /// </summary>
    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    public DateTime UpdateTime { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// 时间戳
    /// </summary>
    public long TimeStamp => (new DateTimeOffset(CreateTime)).ToUnixTimeMilliseconds();
}

