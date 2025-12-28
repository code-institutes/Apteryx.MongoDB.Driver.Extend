using System;

namespace Apteryx.Mongodb.Driver.Extend;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class MongoIndexAttribute : Attribute
{
    public string[] Fields { get; }
    public bool Unique { get; set; }
    public bool Sparse { get; set; }
    public int TtlSeconds { get; set; } = -1;
    public string PartialFilterJson { get; set; }
    public string Name { get; set; }

    public MongoIndexAttribute(params string[] fields)
    {
        Fields = fields ?? Array.Empty<string>();
    }
}

