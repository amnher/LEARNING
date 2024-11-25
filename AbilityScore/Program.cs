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
    Console.Write($"{prompt} [" + defaultValue + "]: " );
    string? val = Console.ReadLine();
    if(int.TryParse(val, out int result))
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