namespace LearningAppWebAPI.Models.DTO.Simple;

/// <summary>
/// The exercise simple dto class
/// </summary>
public class ExerciseSimpleDto
{
    /// <summary>
    /// Gets or sets the value of the id
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Gets or sets the value of the question name
    /// </summary>
    public string? QuestionName { get; set; }
    /// <summary>
    /// Gets or sets the value of the question text
    /// </summary>
    public string? QuestionText { get; set; }
    /// <summary>
    /// Gets or sets the value of the xp reward
    /// </summary>
    public int XpReward { get; set; }
    /// <summary>
    /// Gets or sets the value of the created at
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    /// <summary>
    /// Gets or sets the value of the type exercise
    /// </summary>
    public TypeExerciseSimpleDto? TypeExercise { get; set; }
}