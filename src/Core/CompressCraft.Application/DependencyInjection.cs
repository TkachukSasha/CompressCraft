using CompressCraft.Shared.Commands;
using CompressCraft.Shared.Dispatchers;
using CompressCraft.Shared.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace CompressCraft.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddCommands();
        services.AddQueries();
        services.AddDispatchers();

        return services;
    }
}
