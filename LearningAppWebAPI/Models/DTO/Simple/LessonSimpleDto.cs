namespace LearningAppWebAPI.Models.DTO.Simple
{
    /// <summary>
    /// The lesson simple dto class
    /// </summary>
    public class LessonSimpleDto
    {
        /// <summary>
        /// Gets or sets the value of the id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the value of the lesson name
        /// </summary>
        public string? LessonName { get; set; }
        /// <summary>
        /// Gets or sets the value of the lesson description
        /// </summary>
        public string? LessonDescription { get; set; }
        /// <summary>
        /// Gets or sets the value of the created at
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the value of the uid
        /// </summary>
        public string? Uid { get; set; }

    }
}
