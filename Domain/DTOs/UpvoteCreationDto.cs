using Domain.Models;

namespace Domain.DTOs;

public class UpvoteCreationDto
{
    public int Vote { get; set; }
    public Post Post { get; set; }
    public string Owner { get; set; }

    public UpvoteCreationDto(int vote, Post post,string owner)
    {
        Vote = vote;
        Post = post;
        Owner = owner;
    }
}