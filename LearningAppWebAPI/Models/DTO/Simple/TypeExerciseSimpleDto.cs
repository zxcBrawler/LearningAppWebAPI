using System.Text.Json.Serialization;

namespace LearningAppWebAPI.Models.DTO.Simple
{
    // TODO: Complete docs
    /// <summary>
    /// The type exercise simple dto class
    /// </summary>
    public class TypeExerciseSimpleDto
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; init; }
        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("exercise_type_name")] public string? ExerciseTypeName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("exercise_type_description")] public string? ExerciseTypeDescription { get; set; }
    }
}
