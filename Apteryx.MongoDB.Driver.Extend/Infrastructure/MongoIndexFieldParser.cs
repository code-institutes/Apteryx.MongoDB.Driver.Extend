using Apteryx.Mongodb.Driver.Extend.Infrastructure;
using System;

namespace Apteryx.MongoDB.Driver.Extend;

public static class MongoIndexFieldParser
{
    public static (string field, IndexType type) Parse(string raw)
    {
        if (string.IsNullOrWhiteSpace(raw))
            throw new ArgumentException("Index field cannot be null or empty.", nameof(raw));

        var parts = raw.Split(':', StringSplitOptions.RemoveEmptyEntries);

        var field = parts[0].Trim();
        var type = IndexType.Asc;

        if (parts.Length > 1)
        {
            type = parts[1].Trim().ToLowerInvariant() switch
            {
                "asc" => IndexType.Asc,
                "desc" => IndexType.Desc,
                "hashed" => IndexType.Hashed,
                "text" => IndexType.Text,
                "2d" => IndexType.Geo2D,
                "2dsphere" => IndexType.Geo2DSphere,
                _ => IndexType.Asc
            };
        }

        return (field, type);
    }
}


