using CompressCraft.Core.Database;
using CompressCraft.Modules.Users.Domain;

namespace CompressCraft.Modules.Users.Infrastructure.Dal;

internal static class TableNames
{
    internal static string Users => GetTableName(TableTypes.User.Name);

    internal static string Roles => GetTableName(TableTypes.Role.Name);

    internal static string Permissions => GetTableName(TableTypes.Permission.Name);

    internal static string RolePermissions => GetTableName(TableTypes.RolePermission.Name);

    private static string GetTableName(string tableName)
        => tableName.ConvertToSnakeCase(TableScheme.UserScheme);
}

internal static class TableTypes
{
    internal static Type User => typeof(User);

    internal static Type Role => typeof(Role);

    internal static Type Permission => typeof(Permission);

    internal static Type RolePermission => typeof(RolePermission);
}

internal static class TableScheme
{
    internal static string UserScheme => "users";
}
