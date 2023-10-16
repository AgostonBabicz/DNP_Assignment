using Domain.Models;

namespace Application.DaoInterfaces;

public interface IPostDao
{
    public Task<Post> CreateAsync(Post post);
    public Task<IEnumerable<Post>> GetAsync();
}