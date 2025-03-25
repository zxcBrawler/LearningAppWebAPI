using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Models.DTO.Complex
{
    /// <summary>
    /// The user complex dto class
    /// </summary>
    /// <seealso cref="UserSimpleDto"/>
    public class UserComplexDto : UserSimpleDto
    {
        /// <summary>
        /// Gets or sets the value of the courses
        /// </summary>
        public List<UserCourseSimpleDto>? Courses { get; set; }
    }
}
