using CompressCraft.Domain.Encodings;
using CompressCraft.Domain.Users;

namespace CompressCraft.Infrastructure.Database.Utils;

internal static class TableNames
{
    internal static string EncodingTables => GetTableName(TableTypes.EncodingTable.Name, TableSchemes.EncodingScheme);

    internal static string EncodingTableLanguages => GetTableName(TableTypes.EncodingTableLanguage.Name, TableSchemes.EncodingScheme);

    internal static string EncodingAlgorithms => GetTableName(TableTypes.EncodingAlgorithm.Name, TableSchemes.EncodingScheme);

    internal static string EncodingFiles => GetTableName(TableTypes.EncodingFile.Name, TableSchemes.EncodingScheme);

    internal static string Users => GetTableName(TableTypes.User.Name, TableSchemes.UserScheme);

    internal static string Roles => GetTableName(TableTypes.Role.Name, TableSchemes.UserScheme);

    internal static string Permissions => GetTableName(TableTypes.Permission.Name, TableSchemes.UserScheme);

    internal static string RolePermissions => GetTableName(TableTypes.RolePermission.Name, TableSchemes.UserScheme);

    internal static string UserRoles => GetTableName(TableTypes.UserRole.Name, TableSchemes.UserScheme);

    private static string GetTableName(string tableName, string schemeName)
        => tableName.ConvertToSnakeCase(schemeName);
}

internal static class TableTypes
{
    internal static Type EncodingTable => typeof(EncodingTable);

    internal static Type EncodingTableLanguage => typeof(EncodingTableLanguage);

    internal static Type EncodingAlgorithm => typeof(EncodingAlgorithm);

    internal static Type EncodingFile => typeof(EncodingFile);

    internal static Type User => typeof(User);

    internal static Type Role => typeof(Role);

    internal static Type Permission => typeof(Permission);

    internal static Type RolePermission => typeof(RolePermission);

    internal static Type UserRole => typeof(UserRole);
}

internal static class TableSchemes
{
    internal static string EncodingScheme => "encodings";

    internal static string UserScheme => "users";
}
