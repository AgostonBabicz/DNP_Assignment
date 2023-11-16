using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.DaoInterfaces;

public interface IPostDao
{
    public Task<Post> CreateAsync(Post post);
    public Task<IEnumerable<Post>> GetAsync();
    public Task<IEnumerable<Comment>> GetCommentsForPost(int postId);

    public Task<Comment> AddCommentAsync(Comment comment, Post post);
    public Task<int> AddUpvoteAsync(int vote, Post post);
    public Task<bool> DeletePost(int postId);
}