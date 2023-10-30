using System.Threading.Tasks;
using Domain.DTOs;
using Domain.Models;

namespace Application.DaoInterfaces;

public interface IAuthDao
{
    public Task<User> CreateAsync(User user);
    public Task<User?> GetByUsernameAsync(string username);
    public Task<User?> GetUser(string username, string password);
}