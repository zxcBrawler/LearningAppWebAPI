namespace LearningAppWebAPI.Models.DTO.Simple
{
    /// <summary>
    /// The type exercise simple dto class
    /// </summary>
    public class TypeExerciseSimpleDto
    {
        /// <summary>
        /// Gets or sets the value of the id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the value of the exercise type name
        /// </summary>
        public string? ExerciseTypeName { get; set; }
        /// <summary>
        /// Gets or sets the value of the exercise type description
        /// </summary>
        public string? ExerciseTypeDescription { get; set; }
    }
}
