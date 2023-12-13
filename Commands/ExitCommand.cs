using Betty.Commands.Contracts;
using Betty.Models.Results;
using Betty.Shared;

namespace Betty.Commands
{
    public class ExitCommand : ICommand
    {
        public ICommandResult Execute()
            => CommandResultBuilder.CreateExitCommandResult();
    }
}
