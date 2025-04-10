using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningAppWebAPI.Models
{
    /// <summary>
    /// The course class
    /// </summary>
    [Table("course")]
    [Serializable]
    public class Course
    {
        /// <summary>
        /// The id of course
        /// </summary>
        [Key]
        [Column("id_course")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; init; }
        
        /// <summary>
        /// Course title
        /// </summary>
        [Required]
        [MaxLength(150)]
        [MinLength(5)]
        [Column("course_name")]
         public string? CourseName { get; set; }
        
        /// <summary>
        /// Course description
        /// </summary>
        [Required]
        [MaxLength(500)]
        [Column("course_description")]
        public string? CourseDescription { get; set; }
        
        /// <summary>
        /// Target language level of the course, ranges from A1 to C1+
        /// </summary>
        [Required]
        [MinLength(2)]
        [MaxLength(5)]
        [Column("course_language_level")]
        public string? CourseLanguageLevel { get; set; }
        
        /// <summary>
        /// Course Image
        /// </summary>
        [MaxLength(500)]
        [Column("image_url")]
        public string? ImageUrl { get; init; }

        
        /// <summary>
        /// Defines if course is archived
        /// </summary>
        [Column("is_archived")]
        [DefaultValue(false)]
        public bool IsArchived { get; init; }
       
        /// <summary>
        /// The time of course creation
        /// </summary>
        [Column("created_at")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
        
        /// <summary>
        /// Last time the course was updated
        /// </summary>
        [Column("updated_at")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; init; } = DateTime.UtcNow;

        /// <summary>
        /// Lessons of the course
        /// </summary>
        public List<Lesson> Lesson { get; set; } = [];

        /// <summary>
        /// Users that have enrolled to the course
        /// </summary>
        public List<User> Users { get; init; } = [];
    }
}
