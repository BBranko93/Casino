using System;

namespace Casino
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            double odds = 0.75;
            Guy thePlayer = new Guy() { Cash = 100, Name = "The player" };

            Console.WriteLine("Welcome to the Casino. The odds are " + odds);

            // While loop will run until player runs out of money.
            while (thePlayer.Cash > 0)
            {
                // Call WriteMyInfo method from Guy class
                thePlayer.WriteMyInfo();
                Console.Write("How much do you want to bet: ");

                // Store the player input into howMuch
                string howMuch = Console.ReadLine();

                // When a Main method executes this return statment it ends the program,
                // because console apps stop when Main method ends.
                if (howMuch == "") return;

                if (int.TryParse(howMuch, out int amount))
                {
                    /* If it parses, the player gives the amount to an int variable called pot.
                      It gets multiplied by two, because it's a double-or-nothing bet.*/
                    int pot = thePlayer.GiveCash(amount) * 2;
                    if (pot > 0)
                    {
                        if (random.NextDouble() > odds)
                        {
                            int winnings = pot;
                            Console.WriteLine("You win " + winnings);
                            thePlayer.ReceiveCash(winnings);
                        }
                        else
                        {
                            Console.WriteLine("Bad Luck, you lose.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }
            Console.WriteLine("The house always wins!!");
        }
    }
}
