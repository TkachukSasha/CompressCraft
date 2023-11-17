using CompressCraft.Application.Abstractions.Database;
using CompressCraft.Domain.Users;
using CompressCraft.Infrastructure.Database.Initializers;
using CompressCraft.Infrastructure.Database.Options;
using CompressCraft.Infrastructure.Database.Repositories;
using CompressCraft.Infrastructure.Database.Utils;
using CompressCraft.Shared.Abstractions.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CompressCraft.Infrastructure.Database;

public static class DependencyInjection
{
    public static IServiceCollection AddPostgresDatabase<TContext>(this IServiceCollection services)
       where TContext : DbContext
    {
        services.ConfigureOptions<PostgresOptionsSetup>();

        services.AddDbContext<TContext>((serviceProvider, dbContextOptionsBuilder) =>
        {
            var databaseOptions = serviceProvider.GetService<IOptions<PostgresOptions>>()!.Value;

            if (databaseOptions is not null)
                dbContextOptionsBuilder.UseNpgsql(databaseOptions.PostgresConnection);
        });

        services.AddHostedService<DatabaseInitializer<TContext>>();
        services.AddHostedService<DataInitializer>();

        services.AddUnitOfWork<CompressCraftUnitOfWork>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserRoleRepository, UserRoleRepository>();

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        return services;
    }

    public static IServiceCollection AddUnitOfWork<T>(this IServiceCollection services) where T : class, IUnitOfWork
    {
        services.AddScoped<IUnitOfWork, T>();
        services.AddScoped<T>();

        return services;
    }

    public static IServiceCollection AddInitializer<T>(this IServiceCollection services) where T : class, IDataInitializer
         => services.AddTransient<IDataInitializer, T>();

    public static IServiceCollection AddPostgresConnections(this IServiceCollection services, string connectionString)
    {
        services.AddSingleton<IPostgresConnectionFactory>(_ =>
                new PostgresConnectionFactory(connectionString));

        return services;
    }
}
