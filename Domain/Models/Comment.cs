using System.Text.Json.Serialization;

namespace Domain.Models;

public class Comment
{
    public int Id { get; set; }
    public User Owner { get; set; }
    public DateTime CreationDateTime { get; private set; }
    public string CommentBody { get; private set; }
    public int OwnerId { get; set; }
    public int PostId { get; set; }
    [JsonIgnore]
    public Post Post { get; set; }

    public Comment(int ownerId, DateTime creationDateTime, string commentBody)
    {
        OwnerId = ownerId;
        CreationDateTime = creationDateTime;
        CommentBody = commentBody;
    }
}