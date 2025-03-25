using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Models.DTO.Complex
{
    /// <summary>
    /// The lesson complex dto class
    /// </summary>
    /// <seealso cref="LessonSimpleDto"/>
    public class LessonComplexDto : LessonSimpleDto
    {

        /// <summary>
        /// Gets or sets the value of the exercises
        /// </summary>
        public List<ExerciseComplexDto>? Exercises { get; set; }
    }
}
