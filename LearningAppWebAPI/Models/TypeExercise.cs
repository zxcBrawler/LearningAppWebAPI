using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningAppWebAPI.Models
{
    // TODO: Complete docs
    /// <summary>
    /// The type exercise class
    /// </summary>
    [Table("type_exercise")]
    public class TypeExercise
    {
   
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [Column("id_type_exercise")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }

   
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [MaxLength(50)]
        [Column("exercise_type_name")]
        public string? ExerciseTypeName { get; init; }

   
        /// <summary>
        /// 
        /// </summary>
        [MaxLength(50)]
        [Column("exercise_type_description")]
        public string? ExerciseTypeDescription { get; init; }

   
        /// <summary>
        /// 
        /// </summary>
        public List<Exercise>? Exercises { get; init; }
    }
}
