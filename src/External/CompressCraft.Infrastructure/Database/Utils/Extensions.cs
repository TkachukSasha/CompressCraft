using System.Text;

namespace CompressCraft.Infrastructure.Database.Utils;

public static class Extensions
{
    public static string ConvertToSnakeCase(this string tableName, string schemeName)
    {
        if (string.IsNullOrWhiteSpace(tableName))
            return tableName;

        StringBuilder result = new StringBuilder();

        result.Append(char.ToLower(tableName[0]));

        for (int i = 1; i < tableName.Length; i++)
        {
            if (char.IsUpper(tableName[i]))
            {
                result.Append('_');
                result.Append(char.ToLower(tableName[i]));
            }

            result.Append(tableName[i]);
        }

        result.Append('s');

        return $"{schemeName}_{result}";
    }
}
