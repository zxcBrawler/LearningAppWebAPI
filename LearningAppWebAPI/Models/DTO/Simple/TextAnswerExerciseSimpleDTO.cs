namespace LearningAppWebAPI.Models.DTO.Simple
{
    public class TextAnswerExerciseSimpleDto
    {
        public string? Expected_Answer { get; set; }
        public bool Case_Sensitive { get; set; }
        public string? Hint { get; set; }
    }
}
