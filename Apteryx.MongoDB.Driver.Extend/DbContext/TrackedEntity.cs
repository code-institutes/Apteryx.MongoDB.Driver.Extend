namespace Apteryx.Mongodb.Driver.Extend;

public enum EntityState
{
    Added = 1,
    Modified,
    Deleted
}

internal class TrackedEntity<T>
{
    public T Entity { get; }
    public EntityState State { get; set; }


    public TrackedEntity(T entity, EntityState state)
    {
        Entity = entity;
        State = state;
    }
}

