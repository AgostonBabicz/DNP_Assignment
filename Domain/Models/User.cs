namespace Domain.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    private string password;
    public string Email { get; set; }
}