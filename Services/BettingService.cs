using Betty.Models;
using Betty.Services.Contracts;

namespace Betty.Services
{
    public class BettingService : IBettingService
    {
        private readonly Random random = new Random();
        public decimal MakeBet(decimal amount)
        {
            var betConfig = BetConfiguration.GetBetConfiguration();
            decimal chance = (decimal)random.NextDouble();
            decimal calculatedChance = 0M;

            foreach (var probability in betConfig.Probabilities)
            {
                calculatedChance += probability.Percentage;

                if (chance <= calculatedChance)
                {
                    return CalculateWinAmount(amount, probability);
                }
            }

            return 0;
        }

        private decimal CalculateWinAmount(decimal amount, Probability probability)
        {
            decimal range = probability.Maximum - probability.Minimum;
            decimal winMultiplier = probability.Minimum + range * (decimal)random.NextDouble();
            return Math.Round(amount * winMultiplier, 2);
        }
    }
}
