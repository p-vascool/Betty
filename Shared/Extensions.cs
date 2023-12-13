using Betty.Commands;
using Betty.Commands.Contracts;
using Betty.Models;
using Betty.Models.Results;

namespace Betty.Shared
{
    public static class Extensions
    {
        public static Command GetCommand(this string command)
            => Enum.TryParse<Command>(value: command.ToLower().Split(' ')[0], ignoreCase: true, result: out var commandResult)
                ? commandResult
                : Command.None;
        public static decimal GetAmount(this string command)
        {
            var commandArray = command.Split(" ");
            if (commandArray.Length > 1)
                return Convert.ToDecimal(command[1]);

            return Convert.ToDecimal("0");
        }

        public static bool IsExitCommand(this ICommandResult command)
            => command is ExitCommandResult;

        public static bool IsInBettingRange(this BetConfiguration configuration, decimal amount)
            => configuration.LowestBet <= amount && amount <= configuration.HighestBet;
    }
}
