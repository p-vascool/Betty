using Betty.Models.Results;
using Betty.Shared;

namespace Betty.Services.Contracts
{
    public interface IClient
    {
        string GetUserInput();
        void ReturnResult(ICommandResult result);
    }
}