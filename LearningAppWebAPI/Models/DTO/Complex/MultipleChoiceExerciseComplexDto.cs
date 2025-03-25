using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Models.DTO.Complex
{
    /// <summary>
    /// The multiple choice exercise complex dto class
    /// </summary>
    /// <seealso cref="MultipleChoiceExerciseSimpleDto"/>
    public class MultipleChoiceExerciseComplexDto : MultipleChoiceExerciseSimpleDto
    {
        /// <summary>
        /// Gets or sets the value of the options
        /// </summary>
        public List<OptionSimpleDto>? Options { get; set; }
    }
}
