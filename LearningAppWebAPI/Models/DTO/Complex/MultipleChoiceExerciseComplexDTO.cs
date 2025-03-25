using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Models.DTO.Complex
{
    public class MultipleChoiceExerciseComplexDTO : MultipleChoiceExerciseSimpleDto
    {
        public List<OptionSimpleDto>? Options { get; set; }
    }
}
