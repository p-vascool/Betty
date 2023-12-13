using Betty.Models;
using Betty.Models.Results;
using Betty.Services.Contracts;
using Betty.Shared;

namespace Betty.Commands
{
    public class WithdrawCommand : ValidatedCommand
    {
        private readonly IBalanceSerivce _balanceSerivce;
        private readonly decimal _amount;

        public WithdrawCommand(IBalanceSerivce balanceService, decimal amount)
        {
            this._balanceSerivce = balanceService;
            this._amount = amount;
        }

        public override ICommandResult Execute()
        {
            var validationResult = ValidateCommand();
            if (!validationResult.IsValid)
                return CommandResultBuilder.CreateCommandResult<WithdrawCommand>(validationResult);

            var currentBalance = _balanceSerivce.Withdraw(_amount);
            return CommandResultBuilder.CreateCommandResult<WithdrawCommand>(
                message: string.Format(validationResult.Message, currentBalance),
                isSuccesful: validationResult.IsValid);
        }

        protected override ValidationResult ValidateCommand()
        {
            if (this._amount <= 0)
                return new ValidationResult(false, Messages.NEGATIVE_NUMBER);
            if (!_balanceSerivce.CanWithdrawAmount(_amount))
                return new ValidationResult(false, Messages.INSUFFICIENT_FUNDS_WITHDRAW);
            return new ValidationResult(true, Messages.SUCCESSFUL_WITHDRAW);
        }
    }
}
