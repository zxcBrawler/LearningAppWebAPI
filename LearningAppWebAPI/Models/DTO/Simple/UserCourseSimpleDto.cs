using System.Text.Json.Serialization;

namespace LearningAppWebAPI.Models.DTO.Simple
{
   
    /// <summary>
    /// The user course simple dto class
    /// </summary>
    public class UserCourseSimpleDto
    {
        
        /// <summary>
        /// Gets or sets the value of the user
        /// </summary>
        [JsonPropertyName("user")] public UserSimpleDto? User { get; set; }

        
        /// <summary>
        /// Gets or sets the value of the course
        /// </summary>
        [JsonPropertyName("course")] public CourseSimpleDto? Course { get; set; }

        
        /// <summary>
        /// Gets or sets the value of the is finished
        /// </summary>
        [JsonPropertyName("is_finished")] public bool IsFinished { get; set; } = false;

       
        /// <summary>
        /// Gets or sets the value of the course progress
        /// </summary>
        [JsonPropertyName("course_progress")] public float CourseProgress { get; set; } = 0;
    }
}
