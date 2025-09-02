using ToDo.API.Features.Commons;

namespace ToDo.API.Extensions.Endpoints;

public static class RouteGroupBuilderExtenstion
{
    public static IEndpointRouteBuilder Register<T>(this IEndpointRouteBuilder endpointsBuilder)
        where T : IEndpoint, new()
    {
        var endpointsProvider = new T();
        
        endpointsProvider.Register(endpointsBuilder);
        
        return endpointsBuilder;
    }
}