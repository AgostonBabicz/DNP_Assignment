using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IAuthLogic authLogic;

    public UsersController(IAuthLogic authLogic)
    {
        this.authLogic = authLogic;
    }

    [HttpPost]
    public async Task<ActionResult<User>> RegisterUserAsync(UserCreationDto userCreationDto)
    {
        try
        {
            User user = await authLogic.CreateAsync(userCreationDto);
            return Created($"/users/{user.Id}", user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
}