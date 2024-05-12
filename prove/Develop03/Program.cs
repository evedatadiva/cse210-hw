using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

public class Word
{
    public string Text { get; private set; }
    public bool IsHidden { get; set; }
    public bool IsGuessed { get; set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
        IsGuessed = false;
    }

    public override string ToString()
    {
        if (IsGuessed)
            return Text;
        else
            return IsHidden ? "_ _ _" : Text;
    }
}


public class Scripture
{
    private List<Word> words;

    public string Reference { get; private set; }

    public Scripture(string reference, string text)
    {
        Reference = reference;
        words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void Display()
    {
        Console.WriteLine($"{Reference}:");
        foreach (var word in words)
        {
            Console.Write(word + " ");
        }
        Console.WriteLine();
    }

    public bool HideRandomWord()
    {
        var visibleWords = words.Where(word => !word.IsHidden).ToList();
        if (visibleWords.Count == 0)
            return false;

        var random = new Random();
        int index = random.Next(visibleWords.Count);
        visibleWords[index].IsHidden = true;
        return true;
    }

    public bool AllWordsHidden()
    {
        return words.All(word => word.IsHidden);
    }

    public bool GuessWords()
    {
        int attempts = 3;
        bool allGuessed = false;

        while (attempts > 0)
        {
            Console.WriteLine($"You have {attempts} attempts remaining.");
            Console.WriteLine("You have 30 seconds to guess the missing words.");
            Console.WriteLine("Type your guesses separated by spaces:");

            string input = Console.ReadLine();
            string[] guesses = input.Split(' ');

            foreach (var guess in guesses)
            {
                bool correctGuess = false;
                foreach (var word in words)
                {
                    if (word.IsHidden && !word.IsGuessed && word.Text.ToLower() == guess.ToLower())
                    {
                        word.IsGuessed = true;
                        correctGuess = true;
                        break;
                    }
                }

                if (!correctGuess)
                {
                    Console.WriteLine($"'{guess}' is incorrect.");
                    attempts--;
                }
            }

            if (AllWordsGuessed())
            {
                allGuessed = true;
                break;
            }
        }

        return allGuessed;
    }

    private bool AllWordsGuessed()
    {
        return words.All(word => !word.IsHidden || word.IsGuessed);
    }

    public string GetGuessedText()
    {
        
        return string.Join(" ", words.Select(word => word.IsGuessed ? word.Text : "___"));
    }
}

public class Program
{
    private static void Main()
    {
        
        var scripture = new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life");

        
        Thread.Sleep(3000);

        
        scripture.Display();

        
        while (true)
        {
            Console.WriteLine("Press Enter to continue or type 'quit' to exit...");
            string input = Console.ReadLine().Trim();

            if (input.ToLower() == "quit")
                break;

            
            if (!scripture.HideRandomWord())
            {
                Console.WriteLine("All words are hidden. Memorization complete!");
                break;
            }

            
            Console.Clear();
            scripture.Display();

            
            Console.WriteLine("Are you ready to guess the missing words? (yes/no)");
            string readyInput = Console.ReadLine().Trim().ToLower();

            if (readyInput == "yes")
            {
                
                bool allGuessed = scripture.GuessWords();

                if (allGuessed)
                {
                    Console.WriteLine("You did it!! Congratulations!");

                    string guessedText = scripture.GetGuessedText();

                
                    Console.WriteLine("Do you want to save your guessed scripture? (yes/no)");
                    string saveInput = Console.ReadLine().Trim().ToLower();

                    if (saveInput == "yes")
                    {
                        
                        Console.WriteLine("Enter a file name to save your guessed scripture:");
                        string fileName = Console.ReadLine().Trim();

                        
                        try
                        {
                            File.WriteAllText(fileName + ".txt", guessedText);
                            Console.WriteLine("Scripture saved successfully!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error saving file: {ex.Message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Scripture not saved.");
                    }

                    break;
                }
                else
                {
                    Console.WriteLine("Out of attempts. Better luck next time!");
                    break;
                }
            }
            else
            {
                
                Console.Clear();
                scripture.Display();
            }
        }
    }
}
