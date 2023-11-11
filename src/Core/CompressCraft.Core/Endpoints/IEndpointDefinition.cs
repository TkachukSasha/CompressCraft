using Microsoft.AspNetCore.Routing;

namespace CompressCraft.Core.Endpoints;

public interface IEndpointDefinition
{
    public static abstract void ConfigureEndpoints(IEndpointRouteBuilder app);
}
