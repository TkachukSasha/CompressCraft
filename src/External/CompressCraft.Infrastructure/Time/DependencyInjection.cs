using CompressCraft.Application.Abstractions.Time;
using Microsoft.Extensions.DependencyInjection;

namespace CompressCraft.Infrastructure.Time;

public static class DependencyInjection
{
    public static IServiceCollection AddTime(this IServiceCollection services)
       => services.AddScoped<IUtcClock, UtcClock>();
}
