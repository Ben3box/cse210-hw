using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = LoadScriptures("scriptures.txt");

        int difficulty = ChooseDifficulty();
        Random rand = new Random();

        List<Scripture> filtered = new List<Scripture>();

        // EASY → single verse
        if (difficulty == 2)
        {
            filtered = scriptures.Where(s => !s.IsRange()).ToList();
        }
        // MEDIUM → pick one verse from a range
        else if (difficulty == 4)
        {
            var ranges = scriptures.Where(s => s.IsRange()).ToList();

            foreach (var s in ranges)
            {
                int verse = rand.Next(
                    s.GetReference().GetStartVerse(),
                    s.GetReference().GetEndVerse() + 1);

                filtered.Add(new Scripture(
                    new Reference(
                        s.GetReference().GetBook(),
                        s.GetReference().GetChapter(),
                        verse),
                    s.GetOriginalText()
                ));
            }
        }
        // HARD → full range
        else
        {
            filtered = scriptures.Where(s => s.IsRange()).ToList();
        }

        if (filtered.Count == 0)
            filtered = scriptures;

        Scripture scripture = filtered[rand.Next(filtered.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine($"\nProgress: {scripture.GetHiddenPercentage()}% hidden");

            if (scripture.IsCompletelyHidden())
                break;

            Console.WriteLine("\nPress ENTER to continue or type 'quit':");
            string input = Console.ReadLine();

            if (string.Equals(input, "quit", StringComparison.OrdinalIgnoreCase))
                break;

            scripture.HideRandomWords(difficulty);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words hidden. Program ended.");
    }

    static int ChooseDifficulty()
    {
        while (true)
        {
            Console.WriteLine("Select difficulty: easy / medium / hard");
            string choice = Console.ReadLine();

            if (string.Equals(choice, "easy", StringComparison.OrdinalIgnoreCase))
                return 2;

            if (string.Equals(choice, "medium", StringComparison.OrdinalIgnoreCase))
                return 4;

            if (string.Equals(choice, "hard", StringComparison.OrdinalIgnoreCase))
                return 6;

            Console.WriteLine("Invalid choice. Try again.\n");
        }
    }

    static List<Scripture> LoadScriptures(string file)
    {
        List<Scripture> list = new List<Scripture>();

        if (!File.Exists(file))
        {
            list.Add(new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son"));

            return list;
        }

        foreach (string line in File.ReadAllLines(file))
        {
            string[] parts = line.Split('|');

            if (parts.Length < 4)
                continue;

            string book = parts[0];

            if (!int.TryParse(parts[1], out int chapter))
                continue;

            if (parts[2].Contains('-'))
            {
                string[] verses = parts[2].Split('-');

                if (verses.Length != 2 ||
                    !int.TryParse(verses[0], out int start) ||
                    !int.TryParse(verses[1], out int end))
                    continue;

                list.Add(new Scripture(
                    new Reference(book, chapter, start, end),
                    parts[3]));
            }
            else
            {
                if (!int.TryParse(parts[2], out int verse))
                    continue;

                list.Add(new Scripture(
                    new Reference(book, chapter, verse),
                    parts[3]));
            }
        }

        return list;
    }
}