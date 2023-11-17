using CompressCraft.Infrastructure.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Testcontainers.PostgreSql;

namespace CompressCraft.Application.IntegrationTests;

public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
#pragma warning disable CA2213 // Disposable fields should be disposed
    private readonly PostgreSqlContainer _postgreSqlContainer = new PostgreSqlBuilder()
#pragma warning restore CA2213 // Disposable fields should be disposed
        .Build();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            var descriptor = services
                .SingleOrDefault(s => s.ServiceType == typeof(DbContextOptions<CompressCraftContext>));

            if (descriptor is not null)
                services.Remove(descriptor);

            services.AddDbContext<CompressCraftContext>(options =>
            {
                options.UseNpgsql(_postgreSqlContainer.GetConnectionString());
            });
        });
    }

    public async Task InitializeAsync() => await _postgreSqlContainer.StartAsync();
    Task IAsyncLifetime.DisposeAsync() => _postgreSqlContainer.StopAsync();
}
