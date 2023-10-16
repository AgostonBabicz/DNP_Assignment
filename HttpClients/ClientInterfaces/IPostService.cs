using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    Task<ICollection<Post>> GetAsync(string? userName, string? titleContains, string? bodyContains);
}