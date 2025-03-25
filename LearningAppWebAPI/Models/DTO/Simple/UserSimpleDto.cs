namespace LearningAppWebAPI.Models.DTO.Simple
{
    /// <summary>
    /// The user simple dto class
    /// </summary>
    public class UserSimpleDto
    {
        /// <summary>
        /// Gets or sets the value of the id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the value of the username
        /// </summary>
        public string? Username { get; set; }
        /// <summary>
        /// Gets or sets the value of the profile picture
        /// </summary>
        public string? ProfilePicture { get; set; }
        /// <summary>
        /// Gets or sets the value of the registration date
        /// </summary>
        public DateTime RegistrationDate { get; set; }
        /// <summary>
        /// Gets or sets the value of the email
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Gets or sets the value of the role
        /// </summary>
        public RoleSimpleDto? Role { get; set; }

        /// <summary>
        /// Gets or sets the value of the level
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// Gets or sets the value of the current xp
        /// </summary>
        public int CurrentXp { get; set; }
    }
}
