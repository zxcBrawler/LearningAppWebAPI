namespace LearningAppWebAPI.Models.DTO.Simple
{
    public class LessonSimpleDto
    {
        public int Id { get; set; }
        public string? Lesson_Name { get; set; }
        public string? Lesson_Description { get; set; }
        public DateTime? Created_At { get; set; }

        public string? UID { get; set; }

    }
}
