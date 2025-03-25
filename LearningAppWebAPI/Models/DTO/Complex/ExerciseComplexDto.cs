using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Models.DTO.Complex
{
    /// <summary>
    /// The exercise complex dto class
    /// </summary>
    /// <seealso cref="ExerciseSimpleDto"/>
    public class ExerciseComplexDto : ExerciseSimpleDto
    {
        /// <summary>
        /// Gets or sets the value of the multiple choice exercise
        /// </summary>
        public MultipleChoiceExerciseComplexDto? MultipleChoiceExercise { get; set; }
        /// <summary>
        /// Gets or sets the value of the text answer exercise
        /// </summary>
        public TextAnswerExerciseSimpleDto? TextAnswerExercise { get; set; }
        /// <summary>
        /// Gets or sets the value of the true false exercise
        /// </summary>
        public TrueFalseExerciseSimpleDto? TrueFalseExercise { get; set; }
    }
}
