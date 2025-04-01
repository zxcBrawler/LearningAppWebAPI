using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningAppWebAPI.Models;

/// <summary>
/// 
/// </summary>
[Table("blacklisted_access_token")]
public class BlacklistedAccessToken
{
    /// <summary>
    /// 
    /// </summary>
    [Key]
    [Column("id_token")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }
    
    /// <summary>
    /// 
    /// </summary>
    [MaxLength(450)]
    [Column("jti")]
    public required string Jti { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [Column("expiry_date")]
    public DateTime ExpiryDate { get; set; }
}