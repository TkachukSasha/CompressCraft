using System.ComponentModel.DataAnnotations.Schema;

namespace CompressCraft.Domain.Users;

public sealed class RolePermission
{
    private RolePermission(
        string roleId,
        int permissionId
        )
    {
        RoleId = roleId;
        PermissionId = permissionId;
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private RolePermission()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }

    [Column("role_id")]
    public string RoleId { get; }

    [Column("permission_id")]
    public int PermissionId { get; }

    public static RolePermission Init(
        string roleId,
        int permissionId
    ) => new RolePermission(roleId, permissionId);
}
