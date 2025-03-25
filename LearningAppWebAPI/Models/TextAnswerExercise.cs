using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningAppWebAPI.Models
{

    /// <summary>
    /// The text answer exercise class
    /// </summary>
    [Table("text_answer_exercise")]
    public class TextAnswerExercise
    {
   
        /// <summary>
        /// Gets or inits the value of the expected answer
        /// </summary>
        [Required]
        [MaxLength(500)]
        [Column("expected_answer")]
        public string? ExpectedAnswer { get; init; } // data should be a list possible answers {answer1, answer2}
        
   
        /// <summary>
        /// Gets or inits the value of the case sensitive
        /// </summary>
        [DefaultValue(false)]
        [Column("case_sensitive")]
        public bool CaseSensitive { get; init; }
   
        /// <summary>
        /// Gets or inits the value of the hint
        /// </summary>
        [MaxLength(150)]
        [Column("hint")]
        public string? Hint { get; init; }

   
        /// <summary>
        /// Gets or inits the value of the exercise id
        /// </summary>
        [Column("exercise_id")]
        public int ExerciseId { get; init; }
   
        /// <summary>
        /// Gets or inits the value of the exercise
        /// </summary>
        public Exercise? Exercise { get; init; }
    }
}
