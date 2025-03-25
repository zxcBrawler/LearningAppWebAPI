using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Models.DTO.Complex
{
    /// <summary>
    /// The true false exercise complex dto class
    /// </summary>
    /// <seealso cref="TrueFalseExerciseSimpleDto"/>
    public class TrueFalseExerciseComplexDto : TrueFalseExerciseSimpleDto
    {
        /// <summary>
        /// Gets or sets the value of the exercise
        /// </summary>
        public ExerciseSimpleDto? Exercise { get; set; }
    }
}
