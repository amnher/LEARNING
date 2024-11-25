namespace AbilityScore
{
    /// <summary>
    /// A calculator for determining ability scores.
    /// </summary>
    internal class AbilityScoreCalculator
    {
        /// <summary>
        /// Gets or sets the result of the 4d6 roll.
        /// </summary>
        public int RollResult = 14;

        /// <summary>
        /// Gets or sets the divisor for the roll result.
        /// </summary>
        public double DivideBy = 1.75;

        /// <summary>
        /// Gets or sets the amount to add to the result.
        /// </summary>
        public int AddAmount = 2;

        /// <summary>
        /// Gets or sets the minimum possible score.
        /// </summary>
        public int Minimum = 3;

        /// <summary>
        /// Gets the calculated ability score.
        /// </summary>
        public int Score;

        /// <summary>
        /// Calculates the ability score based on the provided roll result, divisor, add amount, and minimum.
        /// </summary>
        public void CalculateAbilityScore()
        {
            // Divide the roll result by the DivideBy field
            double divided = RollResult / DivideBy;

            // Add AddAmount to the result and round down
            int added = AddAmount + (int)divided;

            // If the result is too small, use Minimum
            Score = added < Minimum ? Minimum : added;
        }
    }
}
