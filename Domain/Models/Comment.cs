namespace Domain.Models;

public class Comment
{
    public String Owner { get; set; }
    public DateTime CreationDateTime { get; set; }
    public String CommentBody { get; set; }

    public Comment(String owner, DateTime creationDateTime,String commentBody)
    {
        Owner = owner;
        CreationDateTime = creationDateTime;
        CommentBody = commentBody;
    }

    public override string ToString()
    {
        return $"Owner: {Owner} " + $"Body: {CommentBody}";
    }
}