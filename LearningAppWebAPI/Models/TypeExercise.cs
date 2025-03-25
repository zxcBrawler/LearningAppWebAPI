using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningAppWebAPI.Models
{
  
    /// <summary>
    /// The type exercise class
    /// </summary>
    [Table("type_exercise")]
    public class TypeExercise
    {
   
        /// <summary>
        /// Gets or sets the value of the id
        /// </summary>
        [Key]
        [Column("id_type_exercise")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

   
        /// <summary>
        /// Gets or sets the value of the exercise type name
        /// </summary>
        [Required]
        [MaxLength(50)]
        [Column("exercise_type_name")]
        public string? ExerciseTypeName { get; set; }

   
        /// <summary>
        /// Gets or sets the value of the exercise type description
        /// </summary>
        [MaxLength(50)]
        [Column("exercise_type_description")]
        public string? ExerciseTypeDescription { get; set; }

   
        /// <summary>
        /// Gets or inits the value of the exercises
        /// </summary>
        public List<Exercise>? Exercises { get; init; }
    }
}
