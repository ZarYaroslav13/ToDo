using ToDo.API.Wrappers.Result;
using IResult = ToDo.API.Wrappers.Result.IResult;

namespace ToDo.API.Features.Commons;

public class BaseRequestHandler
{
    protected async Task<IResult> ExecuteAsync(Func<Task<IResult>> handle)
    {
        try
        {
            return await handle();
        }
        catch (Exception e)
        {
            return Result.Fail(e.Message);
        }
    }
    
    protected async Task<Result<T>> ExecuteAsync<T>(Func<Task<Result<T>>> handle)
    {
        try
        {
            return await handle();
        }
        catch (Exception e)
        {
            return Result<T>.Fail(e.Message);
        }
    }
}