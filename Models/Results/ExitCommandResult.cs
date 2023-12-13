using Betty.Shared;

namespace Betty.Models.Results
{
    public record ExitCommandResult : CommandResult
    {
        public ExitCommandResult()
            : base(Messages.EXIT_MESSAGE, true)
        {
        }
    }
}