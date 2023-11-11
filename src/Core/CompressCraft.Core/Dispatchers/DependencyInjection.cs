using CompressCraft.Core.Abstractions.Dispatchers;
using Microsoft.Extensions.DependencyInjection;

namespace CompressCraft.Core.Dispatchers;

public static class DependencyInjection
{
    public static IServiceCollection AddDispatchers(this IServiceCollection services)
        => services.AddSingleton<IDispatcher, Dispatcher>();
}
