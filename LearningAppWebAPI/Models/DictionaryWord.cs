using System.ComponentModel.DataAnnotations.Schema;

namespace LearningAppWebAPI.Models;

/// <summary>
/// 
/// </summary>
[Table("dictionary_words")]
public class DictionaryWord
{
    
    /// <summary>
    /// 
    /// </summary>
    [Column("dictionary_id")]
    public int DictionaryId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [Column("word_id")]
    public int WordId { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public Word? Word { get; init; }
    /// <summary>
    /// 
    /// </summary>
    public Dictionary? Dictionary { get; init; }
}