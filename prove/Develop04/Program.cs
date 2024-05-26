using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Program
{
    static void Main()
    {
        Dictionary<string, Activity> activities = new Dictionary<string, Activity>
        {
            { "1", new BreathingActivity() },
            { "2", new ReflectionActivity() },
            { "3", new ListingActivity() }
        };

        while (true)
        {
            Console.WriteLine("\nMindfulness Program Menu:");

            Console.Write("Starting in 3 seconds :)");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(1000); 
                Console.Write(".");
            }
            Console.WriteLine();


            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an activity: ");
            string choice = Console.ReadLine();

            if (choice == "4")
                break;

            if (activities.ContainsKey(choice))
                activities[choice].Start();
            else
                Console.WriteLine("Invalid choice, please try again.");
        }
    }
}

abstract class Activity
{
    public string Name { get; set; }
    public string Description { get; set; }
    protected int Duration { get; set; }

    public Activity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void StartActivity()
    {
        Console.WriteLine($"Starting {Name} activity");
        Console.WriteLine(Description);
        Console.Write("Enter the duration of the activity in seconds: ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin in 3 seconds...");
        ShowSpinner(3);
        Console.WriteLine("You can!! :)");
    }

    public void EndActivity()
    {
        Console.WriteLine($"Well Done!! :) You've completed the {Name} activity for {Duration} seconds.");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public abstract void Start();
}

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Start()
    {
        StartActivity();
        for (int i = 0; i < Duration; i += 6)
        {
            Console.WriteLine("Breathe in...");
            ShowSpinner(3);
            Console.WriteLine("Breathe out...");
            ShowSpinner(3);
        }
        EndActivity();
    }
}

class ReflectionActivity : Activity
{
    private static readonly List<string> Prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly List<string> Questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public override void Start()
    {
        StartActivity();
        Random rand = new Random();
        string prompt = Prompts[rand.Next(Prompts.Count)];
        Console.WriteLine(prompt);
        int elapsed = 0;
        while (elapsed < Duration)
        {
            string question = Questions[rand.Next(Questions.Count)];
            Console.WriteLine(question);
            ShowSpinner(5);
            elapsed += 5;
        }
        EndActivity();
    }
}

class ListingActivity : Activity
{
    private static readonly List<string> Prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public override void Start()
    {
        StartActivity();
        Random rand = new Random();
        string prompt = Prompts[rand.Next(Prompts.Count)];
        Console.WriteLine(prompt);
        ShowSpinner(5);
        DateTime start = DateTime.Now;
        Console.WriteLine("Start listing items and press enter when done:");
        Console.ReadLine();
        TimeSpan elapsed = DateTime.Now - start;
        Console.WriteLine($"You listed items for {elapsed.TotalSeconds:F2} seconds.");
        EndActivity();
    }
}


