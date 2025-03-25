using System.Text.Json.Serialization;

namespace LearningAppWebAPI.Models.DTO.Request
{
    // TODO: Complete doc
    /// <summary>
    /// The add course request dto class
    /// </summary>
    public class AddCourseRequestDto
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("course_name")] public string? CourseName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("course_description")] public string? CourseDescription { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("course_language_level")] public string? CourseLanguageLevel { get; set; }
    }
}
