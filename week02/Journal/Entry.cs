using System;

public class Entry
{
    public string Date;
    public string PromptText;
    public string EntryText;
    
    // This line fixes the error in image_9b7889.png
    public string Mood; 

    public void Display()
    {
        Console.WriteLine($"Date: {Date} - Prompt: {PromptText}");
        // Adding this line shows the mood when you display the journal
        Console.WriteLine($"Mood: {Mood}"); 
        Console.WriteLine($"{EntryText}");
        Console.WriteLine("------------------------------------------");
    }
}