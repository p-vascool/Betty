using Betty.Commands.Contracts;
using Betty.Models.Results;
using Betty.Shared;

namespace Betty.Commands
{
    public class UnknownActionCommand : ICommand
    {
        public ICommandResult Execute()
           => CommandResultBuilder.CreateCommandResult<UnknownActionCommand>(message: "Unknown action. Try again!", isSuccesful: false);
    }
}
