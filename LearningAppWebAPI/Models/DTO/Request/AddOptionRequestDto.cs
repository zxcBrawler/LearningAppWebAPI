using System.Text.Json.Serialization;

namespace LearningAppWebAPI.Models.DTO.Request;

// TODO: Complete doc
/// <summary>
/// The add option dto class
/// </summary>
public class AddOptionRequestDto
{

    /// <summary>
    /// 
    /// </summary>
    public string? Text { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("multiple_choice_exercise_id")] public int MultipleChoiceExerciseId { get; set; }
}