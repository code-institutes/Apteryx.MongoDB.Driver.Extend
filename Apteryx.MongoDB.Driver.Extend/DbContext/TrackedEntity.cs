namespace Apteryx.Mongodb.Driver.Extend;

public enum EntityState
{
    Detached = 0,
    Unchanged = 1,
    Added = 2,
    Deleted = 3,
    Modified = 4
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

