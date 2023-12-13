using Betty.Commands.Contracts;

namespace Betty.Services.Contracts
{
    public interface ICommandService
    {
        ICommand GetCommand(string input);
    }
}