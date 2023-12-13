using Betty.Commands;
using Betty.Commands.Contracts;
using Betty.Services.Contracts;
using Betty.Shared;

namespace Betty.Services
{
    public class CommandService : ICommandService
    {
        private readonly IBalanceSerivce _balanceService;
        private readonly IBettingService _bettingService;

        public CommandService(IBalanceSerivce balanceService, IBettingService bettingService)
        {
            _balanceService = balanceService;
            _bettingService = bettingService;
        }
        public ICommand GetCommand(string input) => input.GetCommand() switch
        {
            Command.Bet => new BetCommand(_balanceService, input.GetAmount(), _bettingService),
            Command.Withdraw => new WithdrawCommand(_balanceService, input.GetAmount()),
            Command.Deposit => new DepositCommand(_balanceService, input.GetAmount()),
            Command.Exit => new ExitCommand(),
            Command.None => new UnknownActionCommand(),
            _ => throw new NotImplementedException(),
        };
    }
}
