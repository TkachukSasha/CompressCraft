using CompressCraft.Application.Abstractions.Database;
using Microsoft.Extensions.DependencyInjection;

namespace CompressCraft.Infrastructure.Database;

public static class DependencyInjection
{
    public static IServiceCollection AddPostgresConnections(this IServiceCollection services, string connectionString)
    {
        services.AddSingleton<IPostgresConnectionFactory>(_ =>
                new PostgresConnectionFactory(connectionString));

        return services;
    }
}
