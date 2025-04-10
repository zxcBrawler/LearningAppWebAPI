using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LearningAppWebAPI.Models.Enum;

namespace LearningAppWebAPI.Models;

/// <summary>
/// 
/// </summary>
[Table("word")]
[Serializable]
public class Word
{
    /// <summary>
    /// 
    /// </summary>
    [Key]
    [Column("id_word")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }
    
    /// <summary>
    /// 
    /// </summary>
    [Required]
    [MaxLength(200)]
    [Column("word_value")]
    public string? WordValue { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [Required]
    [MaxLength(500)]
    [Column("word_definition")]
    public string? WordDefinition { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [Required]
    [MaxLength(100)]
    [Column("word_pronunciation")]
    public string? WordPronunciation { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [Required]
    [MaxLength(1000)]
    [Column("usage_examples")]
    public string? UsageExamples { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [Required]
    [Column("part_of_speech")]
    public List<PartOfSpeechEnum> PartOfSpeech { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [Required]
    [MaxLength(5)]
    [Column("language_level")]
    public string? LanguageLevel { get; set; }
    
    
    public List<Dictionary> Dictionaries { get; set; }
    
}