using System.Text.Json.Serialization;
using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Models.DTO.Complex
{
    // TODO: Complete doc
    /// <summary>
    /// The option complex dto class
    /// </summary>
    /// <seealso cref="OptionSimpleDto"/>
    public class OptionComplexDto : OptionSimpleDto
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("multiple_choice_exercise")] public MultipleChoiceExerciseSimpleDto? MultipleChoiceExerciseSimpleDto;
    }
}
