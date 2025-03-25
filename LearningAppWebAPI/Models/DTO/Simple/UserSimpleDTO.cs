namespace LearningAppWebAPI.Models.DTO.Simple
{
    public class UserSimpleDto
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Profile_Picture { get; set; }
        public DateTime Registration_Date { get; set; } = DateTime.UtcNow;
        public string? Email { get; set; }
        public RoleSimpleDto? Role { get; set; }

        public int Level { get; set; } = 1;
        public int Current_XP { get; set; } = 0;
    }
}
