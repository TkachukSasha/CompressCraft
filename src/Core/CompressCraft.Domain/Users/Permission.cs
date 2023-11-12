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

    public PermissionName PermissionName { get; }

    public static Result<Permission> Init(PermissionName permissionName)
    {
        if (string.IsNullOrWhiteSpace(permissionName.Value))
            return Result.Failure<Permission>(UsersErrors.PermissionErrors.PermissionNameMustBeProvide);

        return new Permission(new PermissionId(), permissionName);
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
