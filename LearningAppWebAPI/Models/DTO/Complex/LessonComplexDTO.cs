using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Models.DTO.Complex
{
    public class LessonComplexDTO : LessonSimpleDto
    {

        public List<ExerciseComplexDTO>? Exercises { get; set; }
    }
}
