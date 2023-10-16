using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao userDao;

    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }

    public async Task<User> CreateAsync(UserCreationDto userCreationDto)
    {
        User? existingUser = await userDao.GetByUsernameAsync(userCreationDto.Username);
        if (existingUser != null)
        {
            throw new Exception("This username is already taken");
        }
        ValidateUser(userCreationDto);
        User expectedUser = new User
        {
            Username = userCreationDto.Username
        };
        User newUser = await userDao.CreateAsync(expectedUser);
        return newUser;

    }

    private void ValidateUser(UserCreationDto userCreationDto)
    {
        string Username = userCreationDto.Username;
        if (Username.Length<4)
        {
            throw new Exception("The username cannot be shorter than 4 characters");
        }

        if (Username.Length>20)
        {
            throw new Exception("The username cannot be longer than 20 characters");
        }
    }

    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchUserParametersDto)
    {
        return userDao.GetAsync(searchUserParametersDto);
    }
}