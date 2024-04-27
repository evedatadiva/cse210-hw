using System;

class Program
{
    static void Main(string[] args)
    {
        // Asking at the user for their grade percentage
        Console.WriteLine("Enter your grade percentage:");

        // Read user input and attempt to parse it as a double
        if (double.TryParse(Console.ReadLine(), out double gradePercentage))
        {
            char letterGrade;

            // Determine the letter grade based on the percentage
            if (gradePercentage >= 90)
            {
                letterGrade = 'A';
            }
            else if (gradePercentage >= 80)
            {
                letterGrade = 'B';
            }
            else if (gradePercentage >= 70)
            {
                letterGrade = 'C';
            }
            else if (gradePercentage >= 60)
            {
                letterGrade = 'D';
            }
            else
            {
                letterGrade = 'F';
            }

            // Print the determined letter grade
            Console.WriteLine($"Your letter grade is: {letterGrade}");

            // Check if the user passed the course (passing grade >= 70)
            if (gradePercentage >= 70)
            {
                Console.WriteLine("Congratulations! You passed the course.");
            }
            else
            {
                Console.WriteLine("You did not pass the course. Better luck next time!");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid grade percentage.");
        }
    }
}
