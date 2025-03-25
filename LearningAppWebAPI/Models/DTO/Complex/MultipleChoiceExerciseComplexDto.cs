using System.Text.Json.Serialization;
using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Models.DTO.Complex
{
    // TODO: Complete doc
    /// <summary>
    /// The multiple choice exercise complex dto class
    /// </summary>
    /// <seealso cref="MultipleChoiceExerciseSimpleDto"/>
    public class MultipleChoiceExerciseComplexDto : MultipleChoiceExerciseSimpleDto
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("options")]  public List<OptionSimpleDto>? Options { get; set; }
    }
}
