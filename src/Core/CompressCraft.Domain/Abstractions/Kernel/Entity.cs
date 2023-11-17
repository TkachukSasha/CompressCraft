using System.ComponentModel.DataAnnotations.Schema;

namespace CompressCraft.Domain.Abstractions.Kernel;

public abstract class Entity<TEntityId>
    where TEntityId : TypeId
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected Entity()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }

    protected Entity(TEntityId id)
    {
        Id = id;
        CreatedOn = DateTime.UtcNow;
        IsDeleted = false;
    }

    [Column("id")]
    public TEntityId Id { get; }

    [Column("created_on")]
    public DateTime? CreatedOn { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; }
}
