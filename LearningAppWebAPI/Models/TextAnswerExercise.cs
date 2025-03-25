using System.ComponentModel.DataAnnotations;

namespace LearningAppWebAPI.Models
{
    public class TextAnswerExercise
    {
        [Required]
        public string? Expected_Answer { get; set; }
        public bool Case_Sensitive { get; set; } = false;
        public string? Hint { get; set; }

        public int Exercise_Id { get; set; }
        public Exercise? Exercise { get; set; }
    }
}
