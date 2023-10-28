using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    public Task<ICollection<Post>> GetAsync(string? userName, string? titleContains, string? bodyContains);
    public Task CreateAsync(PostCreationDto postCreationDto);
   // public Task AddCommentAsync(CommentCreationDto commentCreationDto); //fosadek nem tom egszerre megmaradhatott e volna a masikkal
   //megporbaltam atnevezni AddCommentAsync1 re aztan behivni a masikba h adjon valamit de nyilvan nem adxdd
    Task<Comment> AddCommentAsync(CommentCreationDto commentCreationDto);
}