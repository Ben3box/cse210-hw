using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        
        List<string> menuOptions = new List<string> { "Write", "Display", "Load", "Save", "Quit" };
        string userChoice = "";

        Console.WriteLine("Welcome to the Journal Program!");

        while (userChoice != "5")
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            
            int optionNumber = 1;
            foreach (string option in menuOptions)
            {
                Console.WriteLine($"{optionNumber}. {option}");
                optionNumber++;
            }

            Console.Write("What would you like to do? ");
            userChoice = Console.ReadLine();

            if (userChoice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine($"\nPrompt: {prompt}");
                Console.Write("> ");
                string response = Console.ReadLine();

                Console.Write("How are you feeling today (1-10)? ");
                string mood = Console.ReadLine();

                Entry newEntry = new Entry();
                newEntry.Date = DateTime.Now.ToShortDateString();
                newEntry.PromptText = prompt;
                newEntry.EntryText = response;
                newEntry.Mood = mood; 

                theJournal.AddEntry(newEntry);
            }
            else if (userChoice == "2")
            {

                Console.WriteLine("\n--- Journal Entries ---");
                foreach (Entry entry in theJournal.Entries)
                {
                    entry.Display();
                }
            }
            else if (userChoice == "3")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                theJournal.LoadFromFile(filename);
            }
            else if (userChoice == "4")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                theJournal.SaveToFile(filename);
            }
            else if (userChoice == "5")
            {
                Console.WriteLine("Thank you for journaling. Goodbye!");
            }
        }
    }
}