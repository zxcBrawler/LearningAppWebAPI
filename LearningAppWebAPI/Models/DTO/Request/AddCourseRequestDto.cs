namespace LearningAppWebAPI.Models.DTO.Request
{
    /// <summary>
    /// The add course request dto class
    /// </summary>
    public class AddCourseRequestDto
    {
        /// <summary>
        /// Gets or sets the value of the course name
        /// </summary>
        public string? CourseName { get; set; }
        /// <summary>
        /// Gets or sets the value of the course description
        /// </summary>
        public string? CourseDescription { get; set; }
        /// <summary>
        /// Gets or sets the value of the course language level
        /// </summary>
        public string? CourseLanguageLevel { get; set; }
    }
}
