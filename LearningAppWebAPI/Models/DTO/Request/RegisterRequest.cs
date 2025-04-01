namespace LearningAppWebAPI.Models.DTO.Request;

public class RegisterRequest
{
    public required string Username { get; set; }
    public required string Email { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public required string Password { get; set; }
}