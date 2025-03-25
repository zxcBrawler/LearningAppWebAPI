using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Models.DTO.Complex
{
    /// <summary>
    /// The option complex dto class
    /// </summary>
    /// <seealso cref="OptionSimpleDto"/>
    public class OptionComplexDto : OptionSimpleDto
    {
        /// <summary>
        /// The multiple choice exercise simple dto
        /// </summary>
        public MultipleChoiceExerciseSimpleDto? MultipleChoiceExerciseSimpleDto;
    }
}
