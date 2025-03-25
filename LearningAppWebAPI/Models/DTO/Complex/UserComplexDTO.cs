using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Models.DTO.Complex
{
    public class UserComplexDTO : UserSimpleDto
    {
        public List<UserCourseSimpleDto>? Courses { get; set; }
    }
}
