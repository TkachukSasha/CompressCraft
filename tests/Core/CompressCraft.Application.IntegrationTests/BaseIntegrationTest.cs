using CompressCraft.Application.Abstractions.Authentication;
using CompressCraft.Application.Abstractions.Storage;
using CompressCraft.Infrastructure.Database;
using CompressCraft.Shared.Abstractions.Dispatchers;
using Microsoft.Extensions.DependencyInjection;

namespace CompressCraft.Application.IntegrationTests;

public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>
{
    private readonly IServiceScope _serviceScope;

    protected readonly IDispatcher _dispatcher;

    protected readonly IHttpContextStorage _httpContextStorage;

    protected readonly IPasswordManager _passwordManager;

    protected readonly CompressCraftContext _dbContext;

    protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
    {
        _serviceScope = factory.Services.CreateScope();

        _dispatcher = _serviceScope.ServiceProvider.GetRequiredService<IDispatcher>();

        _dbContext = _serviceScope.ServiceProvider.GetRequiredService<CompressCraftContext>();

        _httpContextStorage = _serviceScope.ServiceProvider.GetRequiredService<IHttpContextStorage>();

        _passwordManager = _serviceScope.ServiceProvider.GetRequiredService<IPasswordManager>();
    }
}
