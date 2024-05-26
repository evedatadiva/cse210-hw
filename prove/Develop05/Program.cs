using System;
using System.Threading;
using System.IO;
using System.Collections.Generic;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            GoalManager manager = new GoalManager();
            string filePath = "goals.txt";

            
            if (File.Exists(filePath) && new FileInfo(filePath).Length > 0)
            {
                manager.LoadGoals(filePath);
            }
            else
            {
                Console.WriteLine("No goals found or the file is empty. Starting with an empty goal list.");
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Eternal Quest Program");
                Console.WriteLine("---------------------");
                Console.WriteLine($"Score: {manager.GetScore()}\n");
                
                if (manager.GetScore() != 0)
                {
                    Console.Write("Loading ");
                    Spinner(3);
                }
                Console.WriteLine("...");
                Console.WriteLine("1. Create new goal");
                Console.WriteLine("2. Record event");
                Console.WriteLine("3. Display goals");
                Console.WriteLine("4. Save and Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateGoal(manager);
                        break;
                    case "2":
                        RecordEvent(manager);
                        Console.WriteLine("Congratulations!!! you get it!! :)");
                        break;
                    case "3":
                        manager.DisplayGoals();
                        Console.WriteLine("Press any key to return to the menu...");
                        Console.ReadKey();
                        break;
                    case "4":
                        manager.SaveGoals(filePath);
                        return;
                    default:
                        Console.WriteLine("Invalid option. Press any key to return to the menu...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void Spinner(int seconds)
        {
            for (int i = 0; i < seconds; i++)
            {
                Console.Write(".");
                Thread.Sleep(500);
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                Console.Write(" ");
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            }
        }

        static void CreateGoal(GoalManager manager)
        {
            Console.Clear();
            Console.WriteLine("Create New Goal");
            Console.WriteLine("---------------");
            Console.Write("Please enter your goal description: ");
            string description = Console.ReadLine();
            Console.Write("Enter points: ");
            int points = int.Parse(Console.ReadLine());

            Console.WriteLine("Choose goal type:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            string typeChoice = Console.ReadLine();

            Goal goal = null;

            switch (typeChoice)
            {
                case "1":
                    goal = new SimpleGoal(description, points);
                    break;
                case "2":
                    goal = new EternalGoal(description, points);
                    break;
                case "3":
                    Console.Write("Enter target count: ");
                    int targetCount = int.Parse(Console.ReadLine());
                    Console.Write("Enter bonus points: ");
                    int bonusPoints = int.Parse(Console.ReadLine());
                    goal = new ChecklistGoal(description, points, targetCount, bonusPoints);
                    break;
                default:
                    Console.WriteLine("Invalid goal type. Press any key to return to the menu...");
                    Console.ReadKey();
                    return;
            }

            manager.AddGoal(goal);
        }

        static void RecordEvent(GoalManager manager)
        {
            Console.Clear();
            Console.WriteLine("Record Event");
            Console.WriteLine("------------");
            manager.DisplayGoals();
            Console.Write("Enter the number of the goal to record: ");
            int goalIndex = int.Parse(Console.ReadLine()) - 1;
            manager.RecordEvent(goalIndex);
        }
    }
}
