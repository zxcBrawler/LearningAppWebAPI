using System.ComponentModel.DataAnnotations;

namespace LearningAppWebAPI.Models
{
    public class Exercise
    {

        public int Id { get; set; }
        [Required]
        public string? Question_Name { get; set; }

        [Required]
        public string? Question_Text { get; set; }

        public int XP_Reward { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        //
        public int Type_Exercise_Id { get; set; }
        public TypeExercise? TypeExercise { get; set; }

        public int Lesson_Id { get; set; }
        public Lesson? Lesson { get; set; }

        public MultipleChoiceExercise? MultipleChoiceExercise { get; set; }
        public TextAnswerExercise? TextAnswerExercise { get; set; }
        public TrueFalseExercise? TrueFalseExercise { get; set; }
    }
}
