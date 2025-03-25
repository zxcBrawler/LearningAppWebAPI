namespace LearningAppWebAPI.Models.DTO.Request;

/// <summary>
/// The add option dto class
/// </summary>
public class AddOptionDto
{

    /// <summary>
    /// Gets or sets the value of the text
    /// </summary>
    public string? Text { get; set; }
    /// <summary>
    /// Gets or sets the value of the multiple choice exercise id
    /// </summary>
    public int MultipleChoiceExerciseId { get; set; }
}