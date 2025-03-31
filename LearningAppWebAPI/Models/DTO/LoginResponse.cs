using System.Text.Json.Serialization;

namespace LearningAppWebAPI.Models.DTO;

/// <summary>
/// 
/// </summary>
public class LoginResponse
{
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("access_token")]
    public string? Token { get; set; }  
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("refresh_token")]
    public string? RefreshToken { get; set; } 
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("expiry_date")]
    public DateTime ExpiryDate { get; set; }
}