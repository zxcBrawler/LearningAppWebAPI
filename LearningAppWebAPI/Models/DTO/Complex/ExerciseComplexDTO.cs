using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Models.DTO.Complex
{
    public class ExerciseComplexDTO : ExerciseSimpleDto
    {
        public MultipleChoiceExerciseComplexDTO? MultipleChoiceExercise { get; set; }
        public TextAnswerExerciseSimpleDto? TextAnswerExercise { get; set; }
        public TrueFalseExerciseSimpleDto? TrueFalseExercise { get; set; }
    }
}
