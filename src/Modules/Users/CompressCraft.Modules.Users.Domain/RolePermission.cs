namespace CompressCraft.Modules.Users.Domain;

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

    public string RoleId { get; set; }

    public int PermissionId { get; set; }

    public static RolePermission Init(
        string roleId,
        int permissionId
    ) => new RolePermission(roleId, permissionId);
}
