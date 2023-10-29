using Domain.Models;

namespace Domain.DTOs;

public class AddVoteDto
{
    public string User { get; }
    public Post Post  { get; }
    public int Vote { get; }

    public AddVoteDto(string user, Post post, int vote)
    {
        User = user;
        Post = post;
        Vote = vote;
    }
}