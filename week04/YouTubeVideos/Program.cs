using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("Learn C# Basics", "Alice", 600);
        Video video2 = new Video("Object-Oriented Programming", "Bob", 900);
        Video video3 = new Video("C# Collections Explained", "Charlie", 750);

        // Add comments to video1
        video1.AddComment(new Comment("John", "Great video!"));
        video1.AddComment(new Comment("Mary", "Very helpful."));
        video1.AddComment(new Comment("Sam", "Thanks for explaining clearly."));

        // Add comments to video2
        video2.AddComment(new Comment("Anna", "I understand OOP now!"));
        video2.AddComment(new Comment("Mike", "Nice examples."));
        video2.AddComment(new Comment("Tom", "Good job!"));

        // Add comments to video3
        video3.AddComment(new Comment("Lucy", "Collections are easier now."));
        video3.AddComment(new Comment("David", "Very informative."));
        video3.AddComment(new Comment("Emma", "Loved this lesson."));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display videos and comments
        foreach (Video video in videos)
        {
            Console.WriteLine("Title: " + video.Title);
            Console.WriteLine("Author: " + video.Author);
            Console.WriteLine("Length (seconds): " + video.Length);
            Console.WriteLine("Number of Comments: " + video.GetCommentCount());

            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine(comment.Name + ": " + comment.Text);
            }

            Console.WriteLine(); // blank line between videos
        }
    }
}