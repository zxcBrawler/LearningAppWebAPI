namespace LearningAppWebAPI.Models.DTO.Request
{
    public class AddUserRequestDTO
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Profile_Picture { get; set; }
        public int Role_Id { get; set; }
        public int Level { get; set; }
        public int Current_XP { get; set; }
    }
}
