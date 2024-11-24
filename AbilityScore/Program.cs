using AbilityScore;
AbilityScoreCalculator calculator = new AbilityScoreCalculator();

while (true)
{
    calculator.RollResult = ReadInt(calculator.RollResult, "Starting 4d6 roll");
    calculator.DivideBy = ReadDouble(calculator.DivideBy, "Divide by");
    calculator.AddAmount = ReadInt(calculator.AddAmount, "Add amount");
    calculator.Minimum = ReadInt(calculator.Minimum, "Minimum");
    calculator.CalculateAbilityScore();
    Console.WriteLine("Calculated ability score: " + calculator.Score);
    Console.WriteLine("Press Q to quit, any other key to continue");
    char keyChar = Console.ReadKey(true).KeyChar;
    if ((keyChar == 'Q') || (keyChar == 'q')) return;
}

static int ReadInt(int defaultValue, string prompt)
{
    Console.WriteLine($"{prompt} [" + defaultValue + "]" );
    if(int.TryParse(prompt, out int result))
        return result;
    else
        return defaultValue;
}

static double ReadDouble(double defaultValue, string prompt)
{
    Console.WriteLine($"{prompt} [" + defaultValue + "]");
    if (double.TryParse(prompt, out double result))
        return result;
    else
        return defaultValue;
}