namespace Domain.Models;

public class Comment
{
    public int Id { get; set; }
    public User Owner { get; set; }
    public DateTime CreationDateTime { get; private set; }
    public String CommentBody { get; private set; }
    public int OwnerId { get; set; }

    public Comment(int ownerId ,DateTime creationDateTime,String commentBody)
    {
        OwnerId = ownerId;
        CreationDateTime = creationDateTime;
        CommentBody = commentBody;
    }
}