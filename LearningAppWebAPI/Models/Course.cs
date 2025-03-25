using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningAppWebAPI.Models
{
   
    /// <summary>
    /// The course class
    /// </summary>
    [Table("course")]
    public class Course
    {
       
        /// <summary>
        /// Gets or sets the value of the id
        /// </summary>
        [Key]
        [Column("id_course")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        /// <summary>
        /// Gets or sets the value of the course name
        /// </summary>
        [Required]
        [MaxLength(150)]
        [MinLength(5)]
        [Column("course_name")]
         public string? CourseName { get; set; }

        
        /// <summary>
        /// Gets or sets the value of the course description
        /// </summary>
        [Required]
        [MaxLength(500)]
        [Column("course_description")]
        public string? CourseDescription { get; set; }
        
        /// <summary>
        /// Gets or sets the value of the course language level
        /// </summary>
        [Required]
        [MinLength(2)]
        [MaxLength(5)]
        [Column("course_language_level")]
        public string? CourseLanguageLevel { get; set; }
        
        
        
        /// <summary>
        /// Gets or sets the value of the image url
        /// </summary>
        [MaxLength(500)]
        [Column("image_url")]
        public string? ImageUrl { get; set; }

        
        /// <summary>
        /// Gets or sets the value of the is archived
        /// </summary>
        [Column("is_archived")]
        [DefaultValue(false)]
        public bool IsArchived { get; set; }
       
        /// <summary>
        /// Gets or sets the value of the created at
        /// </summary>
        [Column("created_at")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        /// <summary>
        /// Gets or sets the value of the updated at
        /// </summary>
        [Column("updated_at")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        
        /// <summary>
        /// Gets or inits the value of the lesson
        /// </summary>
        public List<Lesson>? Lesson { get; init; }
        
        /// <summary>
        /// Gets or inits the value of the users
        /// </summary>
        public List<User>? Users { get; init; }

    }
}
