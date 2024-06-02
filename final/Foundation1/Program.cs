using System;
using System.Collections.Generic;
class Comment
{
    public string CommenterName { get; private set; }
    public string Text { get; private set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}
class Video
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int Length { get; private set; }
    private List<Comment> Comments { get; set; } = new List<Comment>();

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);

    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    // tricky
    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, Length: {Length} seconds");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");
        foreach (var comment in Comments)
        {
            Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var videos = new List<Video>
        {
            new Video("Video 1 first", "Author´video number 1", 300),
            new Video("Video 2 second", "Author´video number 2", 420),
            new Video("Video 3 third", "Author´video number 3", 180)
        };

        videos[0].AddComment(new Comment("User number 1", "Great!"));
        videos[0].AddComment(new Comment("User number 2", "Thanks for the video."));
        videos[0].AddComment(new Comment("User number 3", "Very helpful."));
        videos[1].AddComment(new Comment("User number 4", "Nice!."));
        videos[1].AddComment(new Comment("User number 5", "Very good!!."));
        videos[1].AddComment(new Comment("User number 6", "Well explained."));
        videos[2].AddComment(new Comment("User number 7", "Awesome!!."));
        videos[2].AddComment(new Comment("User number 8", "Keep it up!"));
        videos[2].AddComment(new Comment("User number 9", "Loved it."));

        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
            Console.WriteLine();
        }
    }
}
