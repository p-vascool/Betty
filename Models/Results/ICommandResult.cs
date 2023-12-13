namespace Betty.Models.Results
{
    public interface ICommandResult
    {
        string Message { get; }
        bool Success { get; }
    }

}
