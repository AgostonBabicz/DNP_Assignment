namespace Domain.Models;

public class Comment
{
    //ID for me to be able to create async idk about jsonignore ig ill find out
    public int ID { get; set; }
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