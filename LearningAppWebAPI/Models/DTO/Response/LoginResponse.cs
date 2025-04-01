using System.Text.Json.Serialization;

namespace LearningAppWebAPI.Models.DTO.Response;

/// <summary>
/// 
/// </summary>
public class LoginResponse
{
    
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }
    [JsonPropertyName("access_token_expiry_date")]
    public DateTime AccessTokenExpiryDate { get; set; }
    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; }
    [JsonPropertyName("refresh_token_expiry_date")]
    public DateTime RefreshTokenExpiryDate { get; set; }
}