using System.ComponentModel.DataAnnotations.Schema;

namespace LearningAppWebAPI.Models;

[Table("refresh_token")]
public class RefreshToken
{
    /// <summary>
    /// 
    /// </summary>
    [Column("hashed_token")]
    public string? HashedToken { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    [Column("expiry_date")]
    public DateTime ExpiryDate { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    [Column("user_id")]
    public int UserId { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public User? User { get; set; }
}