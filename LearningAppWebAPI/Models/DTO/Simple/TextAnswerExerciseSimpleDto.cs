namespace LearningAppWebAPI.Models.DTO.Simple
{
    /// <summary>
    /// The text answer exercise simple dto class
    /// </summary>
    public class TextAnswerExerciseSimpleDto
    {
        /// <summary>
        /// Gets or sets the value of the expected answer
        /// </summary>
        public string? ExpectedAnswer { get; set; }
        /// <summary>
        /// Gets or sets the value of the case sensitive
        /// </summary>
        public bool CaseSensitive { get; set; }
        /// <summary>
        /// Gets or sets the value of the hint
        /// </summary>
        public string? Hint { get; set; }
    }
}
