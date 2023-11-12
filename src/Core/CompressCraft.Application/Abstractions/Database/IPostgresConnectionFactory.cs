using System.Data;

namespace CompressCraft.Application.Abstractions.Database;

public interface IPostgresConnectionFactory
{
    IDbConnection CreateConnection();
}

