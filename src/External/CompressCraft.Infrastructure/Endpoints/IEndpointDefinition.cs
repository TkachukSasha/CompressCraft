using Microsoft.AspNetCore.Routing;

namespace CompressCraft.Infrastructure.Endpoints;

public interface IEndpointDefinition
{
    public static abstract void ConfigureEndpoints(IEndpointRouteBuilder app);
}
