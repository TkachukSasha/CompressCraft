using System.Reflection;
using CompressCraft.Shared.Abstractions.Attributes;
using CompressCraft.Shared.Abstractions.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace CompressCraft.Shared.Queries;

public static class DependencyInjection
{
    public static IServiceCollection AddQueries(this IServiceCollection services)
    {
        var assemblies = Assembly.GetCallingAssembly();

        services.AddSingleton<IQueryDispatcher, QueryDispatcher>();

        services.Scan(s => s.FromAssemblies(assemblies)
            .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>))
                .WithoutAttribute<DecoratorAttribute>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}
