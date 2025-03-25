namespace LearningAppWebAPI.Models.DTO.Simple
{
    public class CourseSimpleDto
    {
        public int Id { get; set; }

        public string? Course_Name { get; set; }

        public string? Course_Description { get; set; }

        public string? Course_Language_Level { get; set; }
        public bool Is_Archived { get; set; }
        public string? Image_URL { get; set; }
        public DateTime Created_At { get; set; } = DateTime.UtcNow;

    }
}
