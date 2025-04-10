using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningAppWebAPI.Models
{
    // TODO: Complete docs
    /// <summary>
    /// The text answer exercise class
    /// </summary>
    [Table("text_answer_exercise")]
    [Serializable]
    public class TextAnswerExercise
    {
   
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [MaxLength(500)]
        [Column("expected_answer")]
        public string? ExpectedAnswer { get; init; } // data should be a list possible answers {answer1, answer2}
        
   
        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(false)]
        [Column("case_sensitive")]
        public bool CaseSensitive { get; init; }
   
        /// <summary>
        /// 
        /// </summary>
        [MaxLength(150)]
        [Column("hint")]
        public string? Hint { get; init; }

   
        /// <summary>
        /// 
        /// </summary>
        [Column("exercise_id")]
        public int ExerciseId { get; init; }
   
        /// <summary>
        /// 
        /// </summary>
        public Exercise? Exercise { get; init; }
    }
}
