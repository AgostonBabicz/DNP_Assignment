using System.Text.Json.Serialization;

namespace Domain.Models;

public class Post
{
    public int Id { get; set; }
    public User Owner { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public DateTime DateTime { get; set; }
    
    public List<Comment> Comments  { get; set; }

    public Post(User owner, string title, string body,DateTime dateTime)
    {
        Owner = owner;
        Title = title;
        Body = body;
        DateTime = dateTime;
        Comments = new List<Comment>();
    }

    public override string ToString()
    {
        string commentsInfo = string.Join("\n", Comments.Select(comment => comment.ToString()));
        return $"Post Id: {Id}\n" +
               $"Title: {Title}\n" +
               $"Body: {Body}\n" +
               $"Owner: {Owner.Username}\n" +
               $"Comments:\n{commentsInfo}";
    }
}