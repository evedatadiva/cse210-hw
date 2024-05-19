using System;

class Program
{
    static void Main(string[] args)
    {
        
        Assignment assignment = new Assignment("Evelin Flores", "C#");
        Console.WriteLine(assignment.GetSummary());

        
        MathAssignment mathAssignment = new MathAssignment("James Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());

        
        WritingAssignment writingAssignment = new WritingAssignment("Otto Lopez", "European History", "The Causes of World War II");
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());
    }
}

