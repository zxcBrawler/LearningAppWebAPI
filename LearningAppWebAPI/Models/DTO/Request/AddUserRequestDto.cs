using System.Text.Json.Serialization;

namespace LearningAppWebAPI.Models.DTO.Request
{
    // TODO: Complete doc
    /// <summary>
    /// The add user request dto class
    /// </summary>
    public class AddUserRequestDto
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("username")] public string? Username { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("password")] public string? Password { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("email")] public string? Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("profile_picture")] public string? ProfilePicture { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("role_id")] public int RoleId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("level")] public int Level { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("current_xp")] public int CurrentXp { get; set; }
    }
}
