namespace Betty.Models.Results
{
    public record CommandResult(string Message, bool Success) : ICommandResult;
}