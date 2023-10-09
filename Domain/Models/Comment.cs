namespace Domain.Models;

public class Comment
{
    public User owner;
    public Post Post;
    public DateTime CreationDateTime;

    public Comment(User owner, Post post, DateTime creationDateTime)
    {
        this.owner = owner;
        Post = post;
        CreationDateTime = creationDateTime;
    }
}