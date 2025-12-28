using System;
using System.Collections.Generic;
using System.Text;

namespace Apteryx.Mongodb.Driver.Extend.Infrastructure;

public enum IndexType
{
    Asc,
    Desc,
    Hashed,
    Text,
    Geo2D,
    Geo2DSphere
}
