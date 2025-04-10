using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningAppWebAPI.Models;

/// <summary>
/// 
/// </summary>
[Table("dictionary")]
[Serializable]
public class Dictionary
{
    /// <summary>
    /// 
    /// </summary>
    [Key]
    [Column("id_dictionary")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }
    
    /// <summary>
    /// 
    /// </summary>
    [Required]
    [MaxLength(150)]
    [MinLength(5)]
    [Column("dictionary_name")]
    public string? DictionaryName { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    [MaxLength(500)]
    [Column("image_url")]
    public string? ImageUrl { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    [Column("user_id")]
    public long? UserId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public List<Word>? Words { get; set; }
  
   
    /// <summary>
    /// 
    /// </summary>
    public User? User { get; init; }
}