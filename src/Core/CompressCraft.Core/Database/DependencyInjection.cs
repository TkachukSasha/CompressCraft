using CompressCraft.Core.Abstractions.Database;
using Microsoft.Extensions.DependencyInjection;

namespace CompressCraft.Core.Database;

public static class DependencyInjection
{
    public static IServiceCollection AddPostgresConnections(this IServiceCollection services, string connectionString)
    {
        services.AddSingleton<IPostgresConnectionFactory>(_ =>
                new PostgresConnectionFactory(connectionString));

        return services;
    }
}
