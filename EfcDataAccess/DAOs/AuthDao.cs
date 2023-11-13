using Application.DaoInterfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class AuthDao : IAuthDao
{
    private readonly ForumContext context;

    public AuthDao(ForumContext context)
    {
        this.context = context;
    }

    public async Task<User> CreateAsync(User user)
    {
        EntityEntry<User> newUser = await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return newUser.Entity;
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        User? existing = await context.Users.FirstOrDefaultAsync(
            u => u.Username.ToLower().Equals(username.ToLower())
        );
        return existing;
    }

    public async Task<User?> GetUser(string username, string password)
    {
        
        User? existing = await context.Users.FirstOrDefaultAsync(
            u => u.Username.ToLower().Equals(username.ToLower())
        );
        Console.WriteLine("DAO: "+existing.Username);
        if (existing == null)
        {
            throw new Exception("User not found");
        }

        if (!existing.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return existing;
    }

    
    
}