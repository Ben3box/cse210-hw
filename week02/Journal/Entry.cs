public class Entry
{
    public string Date;
    public string PromptText;
    public string entrytext;

    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {PromptText}");
        Console.WriteLine($"Response: {entrytext}");
       
    }
}

