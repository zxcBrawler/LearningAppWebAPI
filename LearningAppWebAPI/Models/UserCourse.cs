
namespace LearningAppWebAPI.Models
{
    public class UserCourse
    {
        public int UserId { get; set; }
        public User? User { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }

        //TODO: add some more params
        public bool IsFinished { get; set; } = false;

        public float Course_Progress { get; set; } = 0;
    }
}
