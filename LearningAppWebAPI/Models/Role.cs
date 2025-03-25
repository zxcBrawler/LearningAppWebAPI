using System.ComponentModel.DataAnnotations;

namespace LearningAppWebAPI.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string? Role_Name { get; set; }
        public List<User>? User { get; set; }
    }
}
