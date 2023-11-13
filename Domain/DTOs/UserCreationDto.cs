namespace Domain.DTOs;

public class UserCreationDto
{
    public string Username {get;}
    public string Password {get;}
    public string Role { get; set; }

    public UserCreationDto(string username,string password, string role)
    {
        Username = username;
        Password = password;
        Role = role;
    }
}