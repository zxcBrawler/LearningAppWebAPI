namespace LearningAppWebAPI.Models.DTO.Request;

public class RegisterRequest
{
    public string? Username { get; set; }
    public string? ProfilePicture { get; set; }
    public string? Email { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string? Password { get; set; }
}