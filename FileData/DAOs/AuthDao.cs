using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;
using FileData;

namespace DefaultNamespace.DAOs;

public class AuthDao : IAuthDao
{
    private readonly FileContext context;

    public AuthDao(FileContext context)
    {
        this.context = context;
    }
    public Task<User> CreateAsync(User user)
    {
        int userId = 1;
        if (context.Users.Any())
        {
            userId = context.Users.Max(u => u.Id);
            userId++;
        }
        user.Id = userId;
        context.Users.Add(user);
        context.SaveChanges();

        return Task.FromResult(user);
    }

    public Task<User?> GetByUsernameAsync(string username)
    {
        User? existing = context.Users.FirstOrDefault(u => 
            u.Username.Equals(username,StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(existing);
    }

    public Task<User?> GetUser(string username, string password)
    {
        User? existingUser = context.Users.FirstOrDefault(u => 
            u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }
        
        return Task.FromResult(existingUser)!;
    }
}