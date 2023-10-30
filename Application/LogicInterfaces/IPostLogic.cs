using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    public Task<Post> CreateAsync(PostCreationDto postCreationDto);
    public Task<IEnumerable<Post>> GetAsync();
    public Task<Comment> AddCommentAsync(CommentCreationDto commentCreationDto);
    public Task<bool> DeletePost(int postID);
    public Task<int> AddUpvoteAsync(UpvoteCreationDto upvoteCreationDto);
}