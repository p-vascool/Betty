using Betty.Models;
using Betty.Models.Results;
using Betty.Services.Contracts;
using Betty.Shared;

namespace Betty.Commands
{
    public class BetCommand : ValidatedCommand
    {
        private readonly IBalanceSerivce _balanceSerivce;
        private readonly decimal _bet;
        private readonly IBettingService _bettingService;

        public BetCommand(IBalanceSerivce balanceSerivce, decimal bet, IBettingService bettingService)
        {
            this._balanceSerivce = balanceSerivce;
            this._bet = bet;
            this._bettingService = bettingService;
        }

        public override ICommandResult Execute()
        {
            var validationResult = this.ValidateCommand();
            if (validationResult.IsValid)
            {
                var amountWon = _bettingService.MakeBet(_bet);
                var currentBalance = _balanceSerivce.Deposit(amountWon);
                validationResult = new ValidationResult(true, GetMessage(amountWon, currentBalance));
                return CommandResultBuilder.CreateCommandResult<BetCommand>(
                    message: string.Format(validationResult.Message, currentBalance),
                    isSuccesful: validationResult.IsValid);
            }
            return CommandResultBuilder.CreateCommandResult<BetCommand>(validationResult);
        }

        private string GetMessage(decimal amountWon, decimal balance)
            => amountWon > 0
            ? string.Format(Messages.SUCCESSFUL_BET, amountWon, balance)
            : string.Format(Messages.UNSUCCESSFUL_BET, balance);

        protected override ValidationResult ValidateCommand()
        {
            if (!_balanceSerivce.CanWithdrawAmount(_bet))
                return new ValidationResult(false, Messages.INSUFFICIENT_FUNDS_BET);
            var betConfiguration = BetConfiguration.GetBetConfiguration();
            if (!betConfiguration.IsInBettingRange(_bet))
                return new ValidationResult(false, string.Format(Messages.INVALID_BET, betConfiguration.LowestBet, betConfiguration.HighestBet));

            return base.ValidateCommand();
        }
    }
}
