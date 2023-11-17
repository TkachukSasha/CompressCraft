using CompressCraft.Domain.Users.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CompressCraft.Infrastructure.Database.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
        => services.AddScoped<IPermissionService, PermissionService>();
}
