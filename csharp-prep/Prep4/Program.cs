using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        // Ask the user to enter a list of numbers
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int number))
            {
                if (number == 0)
                {
                    break; // Exit the loop if 0 is entered
                }
                numbers.Add(number); // Add the number to the list
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        int sum = numbers.Sum();

        double average = numbers.Count > 0 ? (double)sum / numbers.Count : 0;

        int maxNumber = numbers.Max();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {maxNumber}");

        int smallestPositive = numbers.Where(n => n > 0).DefaultIfEmpty(0).Min();
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (var num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}
