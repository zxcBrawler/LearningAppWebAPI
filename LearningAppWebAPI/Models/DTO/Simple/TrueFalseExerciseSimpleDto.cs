using System.Text.Json.Serialization;

namespace LearningAppWebAPI.Models.DTO.Simple
{
    // TODO: Complete docs
    /// <summary>
    /// The true false exercise simple dto class
    /// </summary>
    public class TrueFalseExerciseSimpleDto
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("answer_value")] public bool AnswerValue { get; set; }
    }
}
