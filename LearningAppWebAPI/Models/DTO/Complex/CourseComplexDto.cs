using System.Text.Json.Serialization;
using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Models.DTO.Complex
{
    // TODO: Complete doc
    /// <summary>
    /// The course complex dto class
    /// </summary>
    /// <seealso cref="CourseSimpleDto"/>
    public class CourseComplexDto : CourseSimpleDto
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("lesson")] public List<LessonComplexDto>? Lesson { get; set; }
    }
}
