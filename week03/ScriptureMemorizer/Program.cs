using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

/*
==========================================
EXCEEDING REQUIREMENTS REPORT
==========================================

This program goes beyond the core requirements in the following ways:

1. Scripture Library:
   - Instead of a single scripture, the program supports multiple scriptures.
   - Scriptures are stored in a list and one is selected randomly.

2. File Loading:
   - Scriptures are loaded from an external file called "scriptures.txt".
   - This allows easy expansion without changing the code.

3. Random Selection:
   - Each time the program runs, a random scripture is chosen.

4. Difficulty Levels:
   - User selects Easy, Medium, or Hard.
   - Difficulty controls how many words are hidden each round.

5. Smart Hiding:
   - Only words that are NOT already hidden are selected.
   - Prevents wasting turns on already hidden words.

6. Progress Indicator:
   - Displays percentage of words hidden to track progress.

These enhancements improve usability and help users memorize scriptures more effectively.
==========================================
*/
//// so let's see how are those we told over in comment in the code  in order to see if what we said it is reality. 

// WORD CLASS
public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide() => _isHidden = true;

    public bool IsHidden() => _isHidden;

    public string GetDisplayText()
    {
        return _isHidden ? new string('_', _text.Length) : _text;
    }
}

// REFERENCE CLASS
public class Reference
{
    private string _book;
    private int _chapter;
    private int _verseStart;
    private int _verseEnd;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verse;
        _verseEnd = verse;
    }

    public Reference(string book, int chapter, int verseStart, int verseEnd)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verseStart;
        _verseEnd = verseEnd;
    }

    public string GetDisplayText()
    {
        return _verseStart == _verseEnd
            ? $"{_book} {_chapter}:{_verseStart}"
            : $"{_book} {_chapter}:{_verseStart}-{_verseEnd}";
    }
}

// SCRIPTURE CLASS
public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ')
                     .Select(w => new Word(w))
                     .ToList();
    }

    public void HideRandomWords(int count)
    {
        var visibleWords = _words.Where(w => !w.IsHidden()).ToList();

        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    public int GetHiddenPercentage()
    {
        int hidden = _words.Count(w => w.IsHidden());
        return (hidden * 100) / _words.Count;
    }

    public string GetDisplayText()
    {
        string text = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()} - {text}";
    }
}

// MAIN PROGRAM
class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = LoadScriptures("scriptures.txt");

        Random rand = new Random();
        Scripture scripture = scriptures[rand.Next(scriptures.Count)];

        int difficulty = ChooseDifficulty();

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine($"\nProgress: {scripture.GetHiddenPercentage()}% hidden");

            if (scripture.IsCompletelyHidden())
                break;

            Console.WriteLine("\nPress ENTER to continue or type 'quit':");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(difficulty);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words hidden. Program ended.");
    }

    static int ChooseDifficulty()
    {
        Console.WriteLine("Select difficulty: easy / medium / hard");
        string choice = Console.ReadLine().ToLower();

        return choice switch
        {
            "easy" => 2,
            "medium" => 4,
            "hard" => 6,
            _ => 3
        };
    }

    static List<Scripture> LoadScriptures(string file)
    {
        List<Scripture> list = new List<Scripture>();

        if (!File.Exists(file))
        {
            // fallback if file missing
            list.Add(new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son"));

            return list;
        }

        foreach (string line in File.ReadAllLines(file))
        {
            string[] parts = line.Split('|');

            string book = parts[0];
            int chapter = int.Parse(parts[1]);

            if (parts[2].Contains('-'))
            {
                string[] verses = parts[2].Split('-');
                int start = int.Parse(verses[0]);
                int end = int.Parse(verses[1]);

                list.Add(new Scripture(
                    new Reference(book, chapter, start, end),
                    parts[3]));
            }
            else
            {
                int verse = int.Parse(parts[2]);

                list.Add(new Scripture(
                    new Reference(book, chapter, verse),
                    parts[3]));
            }
        }

        return list;
    }
}