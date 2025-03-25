using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Models.DTO.Complex
{
    public class TrueFalseExerciseComplexDTO : TrueFalseExerciseSimpleDto
    {
        public ExerciseSimpleDto? Exercise { get; set; }
    }
}
