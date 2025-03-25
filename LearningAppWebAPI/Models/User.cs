using System.ComponentModel.DataAnnotations;

namespace LearningAppWebAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password_Hash { get; set; }
        public string? Profile_Picture { get; set; }
        public DateTime Registration_Date { get; set; } = DateTime.UtcNow;
        [Required]
        public string? Email { get; set; }
        public int Role_Id { get; set; }
        public Role? Role { get; set; }
        public int Level { get; set; } = 1;
        public int Current_XP { get; set; } = 0;
        public List<Course>? Courses { get; set; }

    }
}
