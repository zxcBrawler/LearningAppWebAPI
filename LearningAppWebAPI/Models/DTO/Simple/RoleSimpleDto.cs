using System.Text.Json.Serialization;

namespace LearningAppWebAPI.Models.DTO.Simple
{
    // TODO: Complete docs
    /// <summary>
    /// The role simple dto class
    /// </summary>
    public class RoleSimpleDto
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; init; }
        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("role_name")] public string? RoleName { get; init; }
    }
}
