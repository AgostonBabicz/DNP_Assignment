using Domain.Models;

namespace Application.DaoInterfaces;

public interface ICommentDao
{
    public Task<Comment> CreateAsync(Comment comment);
    public Task<IEnumerable<Comment>> GetAsync();
}