namespace Betty.Models
{
    public class Probability(decimal Percentage, decimal MinMultiplier, decimal MaxMultiplier)
    {
        public decimal Percentage { get; } = Percentage;
        public decimal Minimum { get; } = MinMultiplier;
        public decimal Maximum { get; } = MaxMultiplier;

        public static IList<Probability> GetProbabilities()
                => new List<Probability>
                {
                    new (0.5m,0,0),
                    new (0.4m,0.01m,2),
                    new (0.1m,2,10)
                };
    }
}
