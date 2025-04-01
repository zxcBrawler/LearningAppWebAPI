namespace LearningAppWebAPI.Models.DTO.Response;

public class TokenResponse
{
    public string Token { get; set; }
    public DateTime ExpiryDate { get; set; }
}