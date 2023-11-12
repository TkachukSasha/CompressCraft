using CompressCraft.Application.Abstractions.Dispatchers;
using Microsoft.Extensions.DependencyInjection;

namespace CompressCraft.Infrastructure.Dispatchers;

public static class DependencyInjection
{
    public static IServiceCollection AddDispatchers(this IServiceCollection services)
        => services.AddSingleton<IDispatcher, Dispatcher>();
}
