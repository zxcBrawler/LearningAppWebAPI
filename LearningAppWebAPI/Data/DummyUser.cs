namespace LearningAppWebAPI.Data;

public class DummyUser
{
    public int Id { get; set; } = 1;
    public string Username { get; set; } = "testuser";
    public string Email { get; set; } = "test@example.com";
    public string Role { get; set; } = "User";
}