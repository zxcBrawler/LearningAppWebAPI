using System.ComponentModel.DataAnnotations;

namespace LearningAppWebAPI.Models
{
    public class TypeExercise
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? ExerciseTypeName { get; set; }

        public string? ExerciseTypeDescription { get; set; }

        public List<Exercise>? Exercises { get; set; }
    }
}
