using Domain.Models;

namespace Domain.DTOs;

public class UpvoteCreationDto
{
    public int Vote { get; }
    public Post Post { get; }
    public string Owner { get; }

    public UpvoteCreationDto(int vote, Post post,string owner)
    {
        Vote = vote;
        Post = post;
        Owner = owner;
    }
}