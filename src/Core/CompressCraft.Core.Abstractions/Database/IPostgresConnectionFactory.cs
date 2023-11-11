using System.Data;

namespace CompressCraft.Core.Abstractions.Database;

public interface IPostgresConnectionFactory
{
    IDbConnection CreateConnection();
}

