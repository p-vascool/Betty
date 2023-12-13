using Betty.Models.Results;

namespace Betty.Commands.Contracts
{
    public interface ICommand
    {
        ICommandResult Execute();

    }
}
