namespace Betty.Models
{
    public sealed class BetConfiguration
    {
        private BetConfiguration()
            : this(1m, 10m, Probability.GetProbabilities())
        {
        }
        private BetConfiguration(decimal lowestBet, decimal highestBet, IList<Probability> probabilities)
        {
            LowestBet = lowestBet;
            HighestBet = highestBet;
            Probabilities = probabilities;
        }

        public decimal LowestBet { get; init; }
        public decimal HighestBet { get; init; }
        public IList<Probability> Probabilities { get; init; }

        public static BetConfiguration GetBetConfiguration()
            => new BetConfiguration();
    }
}
