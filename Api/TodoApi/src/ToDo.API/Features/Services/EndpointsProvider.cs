using ToDo.API.Features.Commons;

namespace ToDo.API.Features.Services;

public static class EndpointsProvider
{
    public static void RegisterAppEndpoints(RouteGroupBuilder endpointsBuilder)
    {
        var endpointInterface = typeof(IEndpoint);

        var endpointTypes = endpointInterface.Assembly
            .GetExportedTypes()
            .Where(t => endpointInterface.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract);

        foreach (var type in endpointTypes)
        {
            if (Activator.CreateInstance(type) is IEndpoint endpointInstance)
            {
                endpointInstance.Register(endpointsBuilder);
            }
        }
    }
}