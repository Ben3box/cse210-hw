using System;
public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
{
    using (StreamWriter output = new StreamWriter(file))
    {
        foreach (Entry entry in _entries)
        {
            output.WriteLine($"{entry.Date}|{entry.PromptText}|{entry.entrytext}");
        }
    }
}

    public void LoadFromFile(string file)
{
    string[] lines = File.ReadAllLines(file);

    foreach (string line in lines)
    {
        string[] parts = line.Split("|");

        Entry entry = new Entry();
        entry.Date = parts[0];
        entry.PromptText = parts[1];
        entry.entrytext = parts[2];

        _entries.Add(entry);
    }
}
}