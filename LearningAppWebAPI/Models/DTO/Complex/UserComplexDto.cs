using System.Text.Json.Serialization;
using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Models.DTO.Complex
{
    // TODO: Complete doc
    /// <summary>
    /// The user complex dto class
    /// </summary>
    /// <seealso cref="UserSimpleDto"/>
    public class UserComplexDto : UserSimpleDto
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("courses")] public List<UserCourseSimpleDto>? Courses { get; set; }
    }
}
