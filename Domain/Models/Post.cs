namespace Domain.Models;

public class Post
{
    public User Owner;
    public string Title { get; set; }
    public string Body { get; set; }

    public Post(User owner, string title)
    {
        Owner = owner;
        Title = title;
    }
}