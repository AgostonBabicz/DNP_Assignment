using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    public Task<Post> CreateAsync(PostCreationDto postCreationDto);
    public Task<IEnumerable<Post>> GetAsync();
}