using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Models.DTO.Complex
{
    /// <summary>
    /// The course complex dto class
    /// </summary>
    /// <seealso cref="CourseSimpleDto"/>
    public class CourseComplexDto : CourseSimpleDto
    {
        /// <summary>
        /// Gets or sets the value of the lesson
        /// </summary>
        public List<LessonComplexDto>? Lesson { get; set; }
    }
}
