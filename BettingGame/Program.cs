<<<<<<< HEAD
﻿using Guys;

while (true)
{

}
=======
﻿//From Book
using Guys;
double odds = .75;
Random random = new Random();
Guy player = new Guy() { Cash = 100, Name = "The player" };
Console.WriteLine("Welcome to the casino. The odds are " + odds);
while (player.Cash > 0)
{
    player.WriteMyInfo();
    Console.Write("How much do you want to bet: ");
    string? howMuch = Console.ReadLine();
    if (int.TryParse(howMuch, out int amount))
    {
        int pot = player.GiveCash(amount) * 2;
        if (pot > 0)
        {
            if (Random.Shared.NextDouble() > odds)
            {
                int winnings = pot;
                Console.WriteLine("You win " + winnings);
                player.ReceiveCash(winnings);
            }
            else
            {
                Console.WriteLine("Bad luck, you lose.");
            }
        }
    }
    else
    {
        Console.WriteLine("Please enter a valid number.");
    }
}
Console.WriteLine("The house always wins.");

//My logic - JR
//using Guys;

//Guy player = new Guy() {Name = "player", Cash = 100 };

//Console.WriteLine("Welcome to the casino. The odds are 0.75");
//player.WriteMyInfo();
//while (true)
//{
//    Console.Write("How much do you want to bet: ");
//    string? bet = Console.ReadLine();
//    if (bet == "") return;
//    if(int.TryParse(bet, out int amount)) 
//    {

//        int pot = player.GiveCash(amount);
//        if (pot > 0) 
//        {
//            pot *= 2;
//            double odds = Random.Shared.NextDouble();
//            if (odds > 0.75) 
//            {
//                Console.WriteLine("You win " + pot);
//                player.ReceiveCash(pot);
//                player.WriteMyInfo();
//            }
//            else
//            {
//                Console.WriteLine("Bad luck, you loose.");
//                player.WriteMyInfo();
//                if(player.Cash ==0)
//                {
//                    Console.WriteLine("The house always wins.");
//                    break;
//                }
//            }
//        }
//        else
//        {

//        }
//    } 
//    else 
//    { 
//        Console.WriteLine("Please enter an amount (or a blank line to exit)."); 
//    }
//}


>>>>>>> 83d35da0106dba4126a6521caa174d14d35df78f
