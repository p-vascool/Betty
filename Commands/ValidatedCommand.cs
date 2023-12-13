using Betty.Commands.Contracts;
using Betty.Models;
using Betty.Models.Results;

namespace Betty.Commands
{
    public abstract class ValidatedCommand : ICommand
    {
        public abstract ICommandResult Execute();
        protected virtual ValidationResult ValidateCommand() 
            => new ValidationResult(true, "");
    }
}
