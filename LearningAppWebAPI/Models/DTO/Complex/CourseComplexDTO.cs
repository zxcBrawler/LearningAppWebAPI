using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Models.DTO.Complex
{
    public class CourseComplexDto : CourseSimpleDto
    {
        public List<LessonComplexDTO>? Lesson { get; set; }
    }
}
