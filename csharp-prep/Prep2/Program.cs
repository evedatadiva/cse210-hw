using System;

class Program
{
    static void Main(string[] args)
    {
        
        Console.WriteLine("Enter your grade percentage: ");

        
        if (double.TryParse(Console.ReadLine(), out double gradePercentage))
        {
            char letterGrade;

            
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
            Console.WriteLine("Your letter grade is: " + letterGrade);

            // Check if the user passed the course
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
