namespace CompressCraft.Core.Abstractions.Abstractions.Kernel;

public abstract class Entity<TEntityId>
    where TEntityId : TypeId
{
    protected Entity(TEntityId id)
    {
        Id = id;
        CreatedOn = DateTime.UtcNow;
        IsDeleted = false;
    }

    public TEntityId Id { get; }

    public DateTime? CreatedOn { get; set; }

    public bool IsDeleted { get; }
}
