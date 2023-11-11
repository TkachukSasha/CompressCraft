using CompressCraft.Core.Abstractions.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace CompressCraft.Core.Storage;

public static class DependencyInjection
{
    public static IServiceCollection AddStorage(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<IHttpContextStorage, HttpContextStorage>();

        return services;
    }
}
