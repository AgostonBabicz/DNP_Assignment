namespace Domain.Models;

public class User
{
    public string Username { get; set; }
    private string password;
    public string Email { get; set; }

    public User(string password, string username)
    {
        this.password = password;
        Username = username;
    }
    
}