namespace LearningAppWebAPI.Models.DTO.Request
{
    /// <summary>
    /// The add user request dto class
    /// </summary>
    public class AddUserRequestDto
    {
        /// <summary>
        /// Gets or sets the value of the username
        /// </summary>
        public string? Username { get; set; }
        /// <summary>
        /// Gets or sets the value of the password
        /// </summary>
        public string? Password { get; set; }
        /// <summary>
        /// Gets or sets the value of the email
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Gets or sets the value of the profile picture
        /// </summary>
        public string? ProfilePicture { get; set; }
        /// <summary>
        /// Gets or sets the value of the role id
        /// </summary>
        public int RoleId { get; set; }
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
