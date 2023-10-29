using Domain.Models;

namespace Domain.DTOs;

public class PostCreationDto
{
    public string OwnerUsername { get; }
    public string Title { get; }
    public string Body { get; }
    public int UpVotes { get; }

    public PostCreationDto(string? ownerUsername, string title, string body, int upVotes)
    {
        OwnerUsername = ownerUsername;
        Title = title;
        Body = body;
        UpVotes = upVotes;
    }
}