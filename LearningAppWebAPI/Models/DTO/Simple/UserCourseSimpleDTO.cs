namespace LearningAppWebAPI.Models.DTO.Simple
{
    public class UserCourseSimpleDto
    {


        public UserSimpleDto? User { get; set; }

        public CourseSimpleDto? Course { get; set; }

        //TODO: add some more params
        public bool IsFinished { get; set; } = false;

        public float Course_Progress { get; set; } = 0;
    }
}
