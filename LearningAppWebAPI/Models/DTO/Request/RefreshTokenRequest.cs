namespace LearningAppWebAPI.Models.DTO.Request;

public class RefreshTokenRequest
{
    public required string RefreshToken { get; set; }
    public required string OldAccessToken { get; set; }
}