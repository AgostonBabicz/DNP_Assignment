namespace Domain.Models;

public class Comment
{
    public User Owner { get; set; }
    public DateTime CreationDateTime { get; set; }
    public String CommentBody { get; set; }

    public Comment(User owner, DateTime creationDateTime,String commentBody)
    {
        Owner = owner;
        CreationDateTime = creationDateTime;
        CommentBody = commentBody;
    }
}