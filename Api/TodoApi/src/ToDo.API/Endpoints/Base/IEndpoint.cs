using ToDo.API.Endpoints.Base;

namespace ToDo.API.Endpoints;

public interface IEndpoint
{
    void Register(IEndpointRouteBuilder builder);
}