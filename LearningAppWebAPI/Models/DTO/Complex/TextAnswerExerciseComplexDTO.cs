using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Models.DTO.Complex
{
    public class TextAnswerExerciseComplexDTO : TextAnswerExerciseSimpleDto
    {
        public ExerciseSimpleDto? Exercise { get; set; }
    }
}
