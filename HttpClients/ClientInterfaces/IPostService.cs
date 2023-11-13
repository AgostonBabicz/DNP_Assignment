using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    public Task<ICollection<Post>> GetAsync(string? userName, string? titleContains, string? bodyContains);
    public Task CreateAsync(PostCreationDto postCreationDto);
    public Task<Comment> AddCommentAsync(CommentCreationDto commentCreationDto);
    public Task DeletePost(int postID);
    public Task<int> AddUpvoteAsync(UpvoteCreationDto upvoteCreationDto);
}