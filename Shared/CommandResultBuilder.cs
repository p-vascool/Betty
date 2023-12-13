using Betty.Commands;
using Betty.Models;
using Betty.Models.Results;

namespace Betty.Shared
{
    public static class CommandResultBuilder
    {
        public static CommandResult CreateCommandResult<TExecutingCommand>(ValidationResult validation)
        {
            Log.WriteToLog($"Executed {nameof(TExecutingCommand)} with result:{Environment.NewLine} {validation.Message}");
            return new CommandResult(validation.Message, validation.IsValid);
        }
        public static CommandResult CreateCommandResult<TExecutingCommand>(string message, bool isSuccesful)
        {
            Log.WriteToLog($"Executed {nameof(TExecutingCommand)} with result:{Environment.NewLine} {message}");
            return new CommandResult(message, isSuccesful);
        }
        public static ExitCommandResult CreateExitCommandResult()
        {
            Log.WriteToLog($"Executed {nameof(ExitCommand)}");
            return new ExitCommandResult();
        }
    }
}
