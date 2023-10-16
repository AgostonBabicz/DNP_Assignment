namespace Domain.Models;

public class Comment
{
    public User Owner;
    public Post Post;
    public DateTime CreationDateTime;

    public Comment(User owner, Post post, DateTime creationDateTime)
    {
        Owner = owner;
        Post = post;
        CreationDateTime = creationDateTime;
    }
}