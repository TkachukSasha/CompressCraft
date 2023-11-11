using CompressCraft.Core.Database;
using CompressCraft.Modules.Encodings.Core.Domain;

namespace CompressCraft.Modules.Encodings.Core.Dal;

internal static class TableNames
{
    internal static string EncodingTables => GetTableName(TableTypes.EncodingTable.Name);

    internal static string EncodingTableLanguages => GetTableName(TableTypes.EncodingTableLanguage.Name);

    internal static string EncodingAlgorithms => GetTableName(TableTypes.EncodingAlgorithm.Name);

    internal static string EncodingFiles => GetTableName(TableTypes.EncodingFile.Name);

    private static string GetTableName(string tableName)
        => tableName.ConvertToSnakeCase(TableScheme.EncodingScheme);
}

internal static class TableTypes
{
    internal static Type EncodingTable => typeof(EncodingTable);

    internal static Type EncodingTableLanguage => typeof(EncodingTableLanguage);

    internal static Type EncodingAlgorithm => typeof(EncodingAlgorithm);

    internal static Type EncodingFile => typeof(EncodingFile);
}

internal static class TableScheme
{
    internal static string EncodingScheme => "encodings";
}
