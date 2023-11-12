using System.Data;
using CompressCraft.Application.Abstractions.Database;
using Npgsql;

namespace CompressCraft.Infrastructure.Database;

public sealed class PostgresConnectionFactory : IPostgresConnectionFactory
{
    private readonly string _connectionString;

    public PostgresConnectionFactory(string connectionString)
        => _connectionString = connectionString;

    public IDbConnection CreateConnection()
    {
        var connection = new NpgsqlConnection(_connectionString);

        connection.Open();

        return connection;
    }
}
