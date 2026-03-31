public class Comment
{
    // Properties
    public string Name { get; set; }
    public string Text { get; set; }

    // Constructor
    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}