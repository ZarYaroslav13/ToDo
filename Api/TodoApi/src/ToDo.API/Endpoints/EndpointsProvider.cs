using ToDo.API.Endpoints.Authorization;
using ToDo.API.Endpoints.Users;
using ToDo.API.Extensions.Endpoints;

namespace ToDo.API.Endpoints;

public static class EndpointsProvider
{
    public static void RegisterAppEndpoints(RouteGroupBuilder endpointsBuilder)
    {
        endpointsBuilder.Register<LoginBaseEndpoint>();
        endpointsBuilder.Register<RegisterUserEndpoint>();

        endpointsBuilder.Register<GetUserInformationEndpoint>();
        endpointsBuilder.Register<UpdateUserEndpoint>();
    }
}