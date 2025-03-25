using System.ComponentModel.DataAnnotations;


namespace LearningAppWebAPI.Models
{
    public class Lesson
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Lesson_Name { get; set; }

        [Required]
        public string? Lesson_Description { get; set; }

        public DateTime? Created_At { get; set; } = DateTime.UtcNow;
        public DateTime? Updated_At { get; set; } = DateTime.UtcNow;

        public string? UID { get; set; }

        public int? Course_Id { get; set; }
        public Course? Course { get; set; }

        public List<Exercise>? Exercises { get; set; }
    }
}
