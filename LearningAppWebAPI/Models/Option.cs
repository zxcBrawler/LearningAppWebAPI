

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningAppWebAPI.Models
{
    // TODO: Complete docs
    /// <summary>
    /// The option class
    /// </summary>
    [Table("option")]
    public class Option
    {
   
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [Column("id_option")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }
   
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [MaxLength(150)]
        [Column("text")]
        public string? Text { get; init; }
   
        /// <summary>
        /// 
        /// </summary>
        [Column("multiple_choice_exercise_id")]
        public int MultipleChoiceExerciseId { get; init; }
   
        /// <summary>
        /// 
        /// </summary>
        public MultipleChoiceExercise? MultipleChoiceExercise { get; init; }
    }
}
