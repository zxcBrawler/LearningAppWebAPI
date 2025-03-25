using System.ComponentModel.DataAnnotations;

namespace LearningAppWebAPI.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        [MinLength(5)]
        public string? Course_Name { get; set; }

        [Required]
        public string? Course_Description { get; set; }
        [Required]
        [MinLength(2)]
        public string? Course_Language_Level { get; set; }
        public string? Image_URL { get; set; }

        public bool Is_Archived { get; set; }
        public DateTime Created_At { get; set; } = DateTime.Now;
        public DateTime Updated_At { get; set; } = DateTime.UtcNow;
        public List<Lesson>? Lesson { get; set; }
        public List<User>? Users { get; set; }

    }
}
