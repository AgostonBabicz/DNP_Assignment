using Domain.Models;

namespace Domain.DTOs;

public class CommentCreationDto
{
    public string User { get; }
    public DateTime CreationTime { get; }
    public Post Post { get; }
    public string CommentBody { get; }

    public CommentCreationDto(string user, DateTime creationTime, Post post, string commentBody)
    {
        User = user;
        CreationTime = creationTime;
        Post = post;
        CommentBody = commentBody;
    }
}