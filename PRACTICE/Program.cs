namespace PRACTICE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int daysUntilExpiration = random.Next(12);
            int discountPercentage = 0;

            // Your code goes here
            Console.WriteLine(daysUntilExpiration);
            Console.WriteLine(discountPercentage);
            if (daysUntilExpiration <= 10)
            {
                if (daysUntilExpiration == 0)
                {
                    System.Console.WriteLine("Your subscription is expired.");
                }
                else if (daysUntilExpiration == 1)
                {
                    System.Console.WriteLine("Your subscription expires within a day!\nRenew now and save 20%!");
                }
                else if (daysUntilExpiration <= 5)
                {
                    System.Console.WriteLine($"Your subscription expires in {daysUntilExpiration} days.\r\nRenew now and save 10%!");
                }
                else 
                {
                    System.Console.WriteLine("Your subscription will expire soon. Renew now!");
                }
            }
        }
    }
}
