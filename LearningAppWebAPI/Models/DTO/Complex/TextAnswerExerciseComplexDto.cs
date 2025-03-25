using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Models.DTO.Complex
{
    /// <summary>
    /// The text answer exercise complex dto class
    /// </summary>
    /// <seealso cref="TextAnswerExerciseSimpleDto"/>
    public class TextAnswerExerciseComplexDto : TextAnswerExerciseSimpleDto
    {
        /// <summary>
        /// Gets or sets the value of the exercise
        /// </summary>
        public ExerciseSimpleDto? Exercise { get; set; }
    }
}
