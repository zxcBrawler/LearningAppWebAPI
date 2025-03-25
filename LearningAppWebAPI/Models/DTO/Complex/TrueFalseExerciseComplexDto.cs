using System.Text.Json.Serialization;
using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Models.DTO.Complex
{
    // TODO: Complete doc
    /// <summary>
    /// The true false exercise complex dto class
    /// </summary>
    /// <seealso cref="TrueFalseExerciseSimpleDto"/>
    public class TrueFalseExerciseComplexDto : TrueFalseExerciseSimpleDto
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("exercise")] public ExerciseSimpleDto? Exercise { get; set; }
    }
}
