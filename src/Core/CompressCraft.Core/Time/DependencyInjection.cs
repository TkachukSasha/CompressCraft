using CompressCraft.Core.Abstractions.Time;
using Microsoft.Extensions.DependencyInjection;

namespace CompressCraft.Core.Time;

public static class DependencyInjection
{
    public static IServiceCollection AddTime(this IServiceCollection services)
       => services.AddScoped<IUtcClock, UtcClock>();
}
