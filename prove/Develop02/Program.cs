using System;
using System.Collections.Generic;
using System.IO;

public class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public Entry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }
}

public class Journal
{
    private List<Entry> entries;

    public Journal()
    {
        entries = new List<Entry>();
    }

    public void AddEntry(string prompt, string response, string date)
    {
        Entry newEntry = new Entry(prompt, response, date);
        entries.Add(newEntry);
    }

    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}");
            Console.WriteLine();
        }
    }

    public void SaveToFile(string fileName)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var entry in entries)
                {
                    writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
                }
            }
            Console.WriteLine("Journal saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }

    public void LoadFromFile(string fileName)
    {
        entries.Clear();

        try
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        string date = parts[0];
                        string prompt = parts[1];
                        string response = parts[2];
                        entries.Add(new Entry(prompt, response, date));
                    }
                }
            }
            Console.WriteLine("Journal loaded successfully.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }
}

public class Program
{
    private const string OptionWriteEntry = "1";
    private const string OptionDisplayJournal = "2";
    private const string OptionSaveJournal = "3";
    private const string OptionLoadJournal = "4";
    private const string OptionExit = "5";

    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");

            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case OptionWriteEntry:
                    Console.WriteLine("Select a prompt:");
                    Console.WriteLine("1. Who was the most interesting person I interacted with today?");
                    Console.WriteLine("2. What was the best part of my day?");
                    Console.WriteLine("3. How did I see the hand of the Lord in my life today?");
                    Console.WriteLine("4. What was the strongest emotion I felt today?");
                    Console.WriteLine("5. If I had one thing I could do over today, what would it be?");
                    
                    Console.Write("Enter the prompt number: ");
                    if (int.TryParse(Console.ReadLine(), out int promptIndex) && promptIndex >= 1 && promptIndex <= 5)
                    {
                        string[] prompts = {
                            "Who was the most interesting person I interacted with today?",
                            "What was the best part of my day?",
                            "How did I see the hand of the Lord in my life today?",
                            "What was the strongest emotion I felt today?",
                            "If I had one thing I could do over today, what would it be?"
                        };

                        string selectedPrompt = prompts[promptIndex - 1];
                        Console.WriteLine($"{selectedPrompt}");

                        Console.Write("Enter your response: ");
                        string response = Console.ReadLine();

                        journal.AddEntry(selectedPrompt, response, DateTime.Now.ToString("yyyy-MM-dd"));
                        Console.WriteLine("Entry added successfully!.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid prompt number. Please try again!.");
                    }
                    break;

                case OptionDisplayJournal:
                    Console.WriteLine("Journal Entries:");
                    journal.DisplayEntries();
                    break;

                case OptionSaveJournal:
                    Console.Write("Enter filename to save: ");
                    string saveFileName = Console.ReadLine();
                    journal.SaveToFile(saveFileName);
                    break;

                case OptionLoadJournal:
                    Console.Write("Enter filename to load: ");
                    string loadFileName = Console.ReadLine();
                    journal.LoadFromFile(loadFileName);
                    break;

                case OptionExit:
                    exit = true;
                    Console.WriteLine("Exiting program.");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine();  
        }
    }
}
