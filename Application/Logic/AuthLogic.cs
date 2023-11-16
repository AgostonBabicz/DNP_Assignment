using System;
using System.Linq;
using System.Threading.Tasks;
using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class AuthLogic : IAuthLogic
{
    private readonly IAuthDao authDao;

    public AuthLogic(IAuthDao authDao)
    {
        this.authDao = authDao;
    }

    public async Task<User> CreateAsync(UserCreationDto userCreationDto)
    {
        User? existingUser = await authDao.GetByUsernameAsync(userCreationDto.Username);
        if (existingUser != null)
        {
            throw new Exception("This username is already taken");
        }
        ValidateUser(userCreationDto);
        User expectedUser = new User
        {
            Username = userCreationDto.Username,
            Password = userCreationDto.Password,
            Role = "admin"
        };
        User newUser = await authDao.CreateAsync(expectedUser);
        return newUser;

    }

    private void ValidateUser(UserCreationDto userCreationDto)
    {
        string Username = userCreationDto.Username;
        string Password = userCreationDto.Password;
        if (Username.Length<4)
        {
            throw new Exception("The username cannot be shorter than 4 characters");
        }

        if (Username.Length>20)
        {
            throw new Exception("The username cannot be longer than 20 characters");
        }

        if (Password.Length<8)
        {
            throw new Exception("The password should be at least 8 characters");
        }

        if (!Password.Any(char.IsUpper))
        {
            throw new Exception("The password should contain at least 1 uppercase character");
        }

        if (Password.Length==0)
        {
            throw new Exception("The password cannot be null");
        }

        if (Username.Length==0)
        {
            throw new Exception("The username cannot be null");
        }
    }

    public async Task<User?> GetAsync(UserLoginDto userLoginDto)
    {
        User? user = await authDao.GetUser(userLoginDto.Username, userLoginDto.Password);
        return user;
    }
}