using System.Text.Json.Serialization;

namespace LearningAppWebAPI.Models.DTO.Simple
{
    // TODO: Complete docs
    /// <summary>
    /// The multiple choice exercise simple dto class
    /// </summary>
    public class MultipleChoiceExerciseSimpleDto
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("correct_answer_index")] public int CorrectAnswerIndex { get; set; }

    }
}
