using System.ComponentModel.DataAnnotations.Schema;
using CompressCraft.Domain.Abstractions.Errors;
using CompressCraft.Domain.Abstractions.Kernel;
using CompressCraft.Domain.Users.ValueObjects;

namespace CompressCraft.Domain.Users;

public sealed class Permission : Entity<PermissionId>
{
    private Permission(
        PermissionId id,
        PermissionName permissionName
    ) : base(id)
    {
        PermissionName = permissionName;
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Permission()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }

    [Column("permission_name")]
    public PermissionName PermissionName { get; }

    public static Result<Permission> Init(string permissionName)
    {
        if (string.IsNullOrWhiteSpace(permissionName))
            return Result.Failure<Permission>(UsersErrors.PermissionErrors.PermissionNameMustBeProvide);

        return new Permission(new PermissionId(), new PermissionName(permissionName));
    }
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
