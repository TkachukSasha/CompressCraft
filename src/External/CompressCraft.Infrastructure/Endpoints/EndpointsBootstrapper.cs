using System.Reflection;
using Microsoft.AspNetCore.Builder;

namespace CompressCraft.Infrastructure.Endpoints;

public static class EndpointsBootstrapper
{
    public static void UseEndpoints<TMarker>(this IApplicationBuilder app)
        => UseEndpoints(app, typeof(TMarker).Assembly);

    public static void UseEndpoints(this IApplicationBuilder app, Assembly assembly)
    {
        var endpointTypes = GetEndpointDefinitionsFromAssembly(assembly);

        foreach (var endpointType in endpointTypes)
        {
            endpointType.GetMethod(nameof(IEndpointDefinition.ConfigureEndpoints))!
                .Invoke(null, new object[] { app });
        }
    }

    private static IEnumerable<TypeInfo> GetEndpointDefinitionsFromAssembly(Assembly assembly)
    {
        return assembly
            .DefinedTypes
            .Where(x => x is
            {
                IsAbstract: false,
                IsInterface: false
            }

            && typeof(IEndpointDefinition).IsAssignableFrom(x));
    }
}
