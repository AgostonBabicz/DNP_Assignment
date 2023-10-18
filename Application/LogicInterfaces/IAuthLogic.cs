using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface IAuthLogic
{
    public Task<User> CreateAsync(UserCreationDto userCreationDto);
    public Task<User?> GetAsync(UserLoginDto userLoginDto);
}