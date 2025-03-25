namespace LearningAppWebAPI.Models.DTO.Simple
{
    public class ExerciseSimpleDto
    {
        public int Id { get; set; }
        public string? Question_Name { get; set; }
        public string? Question_Text { get; set; }

        public int XP_Reward { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public TypeExerciseSimpleDto? TypeExercise { get; set; }

    }
}
