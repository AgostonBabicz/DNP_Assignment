using System.Text.Json.Serialization;

namespace Domain.Models;

public class Post
{
    public int Id { get; set; }
    public User Owner { get; set; }
    public string Title { get; private set; }
    public string Body { get; private set; }
    public DateTime DateTime { get; private set; }
    
    public ICollection<Comment> Comments  { get; set; }
    public int UpVotes { get; set; }
    public int OwnerId { get; set; }

    public Post(int ownerId, string title, string body,DateTime dateTime)
    {
        OwnerId = ownerId;
        Title = title;
        Body = body;
        DateTime = dateTime;
        Comments = new List<Comment>();
        UpVotes = 0;
    }
    
    
}