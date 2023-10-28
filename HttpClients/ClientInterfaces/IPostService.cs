using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    public Task<ICollection<Post>> GetAsync(string? userName, string? titleContains, string? bodyContains);
    public Task CreateAsync(PostCreationDto postCreationDto);
    public Task AddCommentAsync(CommentCreationDto commentCreationDto);
}