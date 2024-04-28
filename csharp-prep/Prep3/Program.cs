using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int magicNumber = random.Next(1, 20);

        Console.WriteLine("Welcome to Guess My Number Game!!!");
        Console.WriteLine("I have picked a magic number between 1 and 20.");
        Console.WriteLine("I hope you enjoy it!!!"); 
        
        int guess = 0;

        while (true)
        {
            Console.Write("What is your guess?: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out guess))
            {
                if (guess == magicNumber)
                {
                    Console.WriteLine("You guessed it!");
                    break; 
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("Lower");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}
