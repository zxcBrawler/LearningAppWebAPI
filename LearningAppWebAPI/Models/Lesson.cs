using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LearningAppWebAPI.Models
{

    /// <summary>
    /// The lesson class
    /// </summary>
    [Table("lesson")]
    public class Lesson
    {
   
        /// <summary>
        /// Gets or inits the value of the id
        /// </summary>
        [Key]
        [Column("id_lesson")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }

   
        /// <summary>
        /// Gets or sets the value of the lesson name
        /// </summary>
        [Required]
        [MaxLength(200)]
        [Column("lesson_name")]
        public string? LessonName { get; set; }

   
        /// <summary>
        /// Gets or sets the value of the lesson description
        /// </summary>
        [Required]
        [MaxLength(200)]
        [Column("lesson_description")]
        public string? LessonDescription { get; set; }

   
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
        /// Gets or inits the value of the uid
        /// </summary>
        [MaxLength(50)]
        [Column("uid")]
        public string? Uid { get; init; }

   
        /// <summary>
        /// Gets or inits the value of the course id
        /// </summary>
        [Column("course_id")]
        public int? CourseId { get; init; }
        
   
        /// <summary>
        /// Gets or inits the value of the course
        /// </summary>
        public Course? Course { get; init; }

   
        /// <summary>
        /// Gets or inits the value of the exercises
        /// </summary>
        public List<Exercise>? Exercises { get; init; }
    }
}
