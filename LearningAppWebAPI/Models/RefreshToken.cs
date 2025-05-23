﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningAppWebAPI.Models;

/// <summary>
/// Stores users refresh token in hash
/// </summary>
[Table("refresh_token")]
[Serializable]
public class RefreshToken
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
    [Column("hashed_token")]
    public required string HashedToken { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    [Column("expiry_date")]
    public DateTime ExpiryDate { get; init; }
    
    /// <summary>
    /// 
    /// </summary>
    [Column("is_revoked")]
    [DefaultValue(false)]
    public bool IsRevoked { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    [Column("revoked_at")]
    public DateTime? RevokedAt { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [Column("user_id")]
    public long UserId { get; init; }
    
    /// <summary>
    /// 
    /// </summary>
    public User? User { get; set; }
}