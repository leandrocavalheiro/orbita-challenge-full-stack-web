namespace GrupoA.Academic.Application.Abstractions.Models;

public class CommandResult<TResponse>
{
    private static CommandResult<TResponse> DefaultFailed = new CommandResult<TResponse>(false);

    public bool IsSuccess { get; set; }
    public TResponse Result { get; set; }

    public CommandResult(bool isSuccess = false)
    {
        IsSuccess = isSuccess;
    }

    public CommandResult(bool isSuccess, TResponse result)
    {
        IsSuccess = isSuccess;
        Result = result;
    }

    public void Deconstruct(out bool isSuccess, out TResponse result)
    {
        isSuccess = IsSuccess;
        result = Result;
    }

    public static CommandResult<TResponse> CreateFailedResult()
    {
        return DefaultFailed;
    }

    public static CommandResult<TResponse> CreateSuccessResult(TResponse body)
    {
        return new CommandResult<TResponse>(true, body);
    }
}