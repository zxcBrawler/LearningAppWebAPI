namespace LearningAppWebAPI.Models.DTO.Simple
{
    /// <summary>
    /// 
    /// </summary>
    public class CourseSimpleDto
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? CourseName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? CourseDescription { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? CourseLanguageLevel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsArchived { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? ImageUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
