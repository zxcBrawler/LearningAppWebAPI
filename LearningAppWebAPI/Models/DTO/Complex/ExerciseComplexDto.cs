using System.Text.Json.Serialization;
using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Models.DTO.Complex
{
    // TODO: Complete doc
    /// <summary>
    /// The exercise complex dto class
    /// </summary>
    /// <seealso cref="ExerciseSimpleDto"/>
    public class ExerciseComplexDto : ExerciseSimpleDto
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("multiple_choice_exercise")] public MultipleChoiceExerciseComplexDto? MultipleChoiceExercise { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("text_answer_exercise")] public TextAnswerExerciseSimpleDto? TextAnswerExercise { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("true_false_exercise")] public TrueFalseExerciseSimpleDto? TrueFalseExercise { get; set; }
    }
}
