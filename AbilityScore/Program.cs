using AbilityScore;

/// <summary>
/// Main entry point of the console application.
/// </summary>
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

/// <summary>
/// Reads an integer from the console with a default value.
/// </summary>
/// <param name="defaultValue">The default value to use if input is invalid.</param>
/// <param name="prompt">The prompt message to display.</param>
/// <returns>The integer read from the console.</returns>
static int ReadInt(int defaultValue, string prompt)
{
    Console.Write($"{prompt} [" + defaultValue + "]: ");
    string? val = Console.ReadLine();
    if (int.TryParse(val, out int result))
    {
        Console.WriteLine($"   using value {result}");
        return result;
    }
    else
    {
        Console.WriteLine($"   using default value {defaultValue}");
        return defaultValue;
    }
}

/// <summary>
/// Reads a double from the console with a default value.
/// </summary>
/// <param name="defaultValue">The default value to use if input is invalid.</param>
/// <param name="prompt">The prompt message to display.</param>
/// <returns>The double read from the console.</returns>
static double ReadDouble(double defaultValue, string prompt)
{
    Console.Write($"{prompt} [" + defaultValue + "]: ");
    string? val = Console.ReadLine();
    if (double.TryParse(val, out double result))
    {
        Console.WriteLine($"   using value {result}");
        return result;
    }
    else
    {
        Console.WriteLine($"   using default value {defaultValue}");
        return defaultValue;
    }
}
