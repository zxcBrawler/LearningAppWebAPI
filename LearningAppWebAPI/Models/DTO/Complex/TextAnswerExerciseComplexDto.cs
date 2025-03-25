using System.Text.Json.Serialization;
using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Models.DTO.Complex
{
    // TODO: Complete doc
    /// <summary>
    /// The text answer exercise complex dto class
    /// </summary>
    /// <seealso cref="TextAnswerExerciseSimpleDto"/>
    public class TextAnswerExerciseComplexDto : TextAnswerExerciseSimpleDto
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("exercise")] public ExerciseSimpleDto? Exercise { get; set; }
    }
}
