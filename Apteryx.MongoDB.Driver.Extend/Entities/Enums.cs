namespace Apteryx.Mongodb.Driver.Extend.Entities;

/// <summary>
/// 实体在上下文中的跟踪状态（用于 SaveChanges()）
/// </summary>
public enum EntityState
{
    /// <summary>
    /// 已从上下文分离，不受跟踪。
    /// 通常表示：实体是新创建的，或手动 Detach 过。
    /// SaveChanges() 不会处理它。
    /// </summary>
    Detached,

    /// <summary>
    /// 未发生变化（默认状态）。
    /// 通常表示：从数据库查询出来后，没有被修改。
    /// SaveChanges() 不会对其执行任何操作。
    /// </summary>
    Unchanged,

    /// <summary>
    /// 新增状态。
    /// 表示：实体是通过 Add() 添加的。
    /// SaveChanges() 会对其执行 InsertOne。
    /// </summary>
    Added,

    /// <summary>
    /// 已修改状态。
    /// 表示：实体的属性被修改过，或通过 Update() 标记为修改。
    /// SaveChanges() 会对其执行 ReplaceOne 或 UpdateOne。
    /// </summary>
    Modified,

    /// <summary>
    /// 已删除状态。
    /// 表示：实体通过 Remove() 标记为删除。
    /// SaveChanges() 会对其执行 DeleteOne（或软删除）。
    /// </summary>
    Deleted
}