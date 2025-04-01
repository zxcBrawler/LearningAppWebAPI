namespace LearningAppWebAPI.Models.DTO.Request;

/// <summary>
/// 
/// </summary>
public class LoginRequest
{
    /// <summary>
    /// 
    /// </summary>
    public required string Email { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public required string Password { get; set; }
}