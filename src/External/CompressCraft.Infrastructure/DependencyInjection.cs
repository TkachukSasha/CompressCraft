using CompressCraft.Infrastructure.Authentication;
using CompressCraft.Infrastructure.Database;
using CompressCraft.Infrastructure.Database.Initializers;
using CompressCraft.Infrastructure.Database.Services;
using CompressCraft.Infrastructure.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompressCraft.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddStorage();

        services.AddPostgresDatabase<CompressCraftContext>();

        services.AddInitializers();

        services.AddPostgresConnections(configuration.GetConnectionString("postgres_connection") ?? string.Empty);

        services.AddServices();

        services.AddAuth(configuration);

        return services;
    }

    private static IServiceCollection AddInitializers(this IServiceCollection services)
        => services.AddInitializer<EncodingAlgorithmInitializer>()
                .AddInitializer<EncodingTableLanguageInitializer>()
                .AddInitializer<RoleInitializer>()
                .AddInitializer<PermissionInitializer>()
                .AddInitializer<RolePermissionInitializer>();
}
