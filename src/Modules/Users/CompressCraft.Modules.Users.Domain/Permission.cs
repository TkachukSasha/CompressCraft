using CompressCraft.Core.Abstractions.Abstractions.Kernel;
using CompressCraft.Modules.Users.Domain.ValueObjects;

namespace CompressCraft.Modules.Users.Domain;

public sealed class Permission : Entity<PermissionId>
{
    private Permission(
        PermissionId id,
        PermissionName permissionName
    ) : base(id)
    {
        PermissionName = permissionName;
    }

    public PermissionName PermissionName { get; }

    public static Permission Init(PermissionName permissionName)
        => new Permission(new PermissionId(), permissionName);
}

public sealed class PermissionId : TypeId
{
    public PermissionId()
        : this(ShortGuid.GenerateShortGuid()) { }

    public PermissionId(string value) : base(value) { }

    public static implicit operator PermissionId(string id) => new(id);

    public static implicit operator string(PermissionId id) => id.Value;

    public override string ToString() => Value.ToString();
}
