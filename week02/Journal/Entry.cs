using System;

public class Entry
{
    public string Date;
    public string PromptText;
    public string EntryText;
    public Person Author;
    
    public string Mood; 

    public void Display()
    {
        Console.WriteLine($"Date: {Date} - Author: {Author.fistname} {Author.lastname}");
        Console.WriteLine($"Mood: {Mood}"); 
        Console.WriteLine($"{EntryText}");
        Console.WriteLine("------------------------------------------");
    }
}