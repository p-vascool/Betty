using Betty.Commands.Contracts;
using Betty.Models;
using Betty.Models.Results;
using Betty.Services.Contracts;
using Betty.Shared;

namespace Betty.Commands
{
    public class DepositCommand : ValidatedCommand
    {
        private readonly IBalanceSerivce _balanceSerivce;
        private decimal _amount;

        public DepositCommand(IBalanceSerivce balanceSerivce, decimal amount)
        {
            this._balanceSerivce = balanceSerivce;
            this._amount = amount;
        }
        public override ICommandResult Execute()
        {
            var validation = ValidateCommand();
            if (validation.IsValid)
            {
                var balance = this._balanceSerivce.Deposit(this._amount);
                return CommandResultBuilder.CreateCommandResult<DepositCommand>(
                   message: string.Format(validation.Message, this._amount, balance), 
                   isSuccesful: validation.IsValid);
            }
            return CommandResultBuilder.CreateCommandResult<DepositCommand>(validation);

        }

        protected override ValidationResult ValidateCommand()
            => this._amount > 0
                ? new ValidationResult(true, Messages.SUCCESSFUL_DEPOSIT)
                : new ValidationResult(false, Messages.NEGATIVE_NUMBER);
    }
}
