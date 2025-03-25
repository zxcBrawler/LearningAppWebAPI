

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningAppWebAPI.Models
{

    /// <summary>
    /// The option class
    /// </summary>
    [Table("option")]
    public class Option
    {
   
        /// <summary>
        /// Gets or inits the value of the id
        /// </summary>
        [Key]
        [Column("id_option")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }
   
        /// <summary>
        /// Gets or inits the value of the text
        /// </summary>
        [Required]
        [MaxLength(150)]
        [Column("text")]
        public string? Text { get; init; }
   
        /// <summary>
        /// Gets or inits the value of the multiple choice exercise id
        /// </summary>
        [Column("multiple_choice_exercise_id")]
        public int MultipleChoiceExerciseId { get; init; }
   
        /// <summary>
        /// Gets or inits the value of the multiple choice exercise
        /// </summary>
        public MultipleChoiceExercise? MultipleChoiceExercise { get; init; }
    }
}
