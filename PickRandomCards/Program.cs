namespace PickRandomCards;

internal class Program
{
    static void Main(string[] args)
    {
        
        CardPicker cp = new CardPicker() { name = "Hello" };
        Console.Write("Enter Number of cards to pick: ");
        string? line = Console.ReadLine();
        if (int.TryParse(line, out int numberOfCards))
        {
            string[] ret = CardPicker.PickSomeCards(numberOfCards);
            for (int i = 0; i<numberOfCards; i++) 
            Console.WriteLine(ret[i]);
        }
        else 
        { 
            Console.WriteLine($"The value \"{line}\" entered is not valid");
        }

        double[] randomDoubles = new double[20];
        foreach (var item in randomDoubles)
        {
            double value = Random.Shared.NextDouble();

        }
    }
}
