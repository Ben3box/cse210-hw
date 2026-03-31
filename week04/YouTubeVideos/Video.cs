using System.Collections.Generic;

public class Video
{
    // Properties
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // in seconds

    // List of comments
    private List<Comment> _comments;

    // Constructor
    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        _comments = new List<Comment>();
    }

    // Add a comment
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Get number of comments
    public int GetCommentCount()
    {
        return _comments.Count;
    }

    // Get all comments
    public List<Comment> GetComments()
    {
        return _comments;
    }
}