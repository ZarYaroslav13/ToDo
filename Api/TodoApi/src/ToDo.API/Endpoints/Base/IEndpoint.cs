namespace ToDo.API.Endpoints.Base;

public interface IEndpoint
{
    void Register(IEndpointRouteBuilder builder);
}