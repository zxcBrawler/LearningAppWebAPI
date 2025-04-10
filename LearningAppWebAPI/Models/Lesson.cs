using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LearningAppWebAPI.Models
{
    // TODO: Complete docs
    /// <summary>
    /// The lesson class
    /// </summary>
    [Table("lesson")]
    [Serializable]
    public class Lesson
    {
   
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [Column("id_lesson")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }

   
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [MaxLength(200)]
        [Column("lesson_name")]
        public string? LessonName { get; set; }

   
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [MaxLength(200)]
        [Column("lesson_description")]
        public string? LessonDescription { get; set; }

   
        /// <summary>
        /// 
        /// </summary>
        [Column("created_at")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
   
        /// <summary>
        /// 
        /// </summary>
        [Column("updated_at")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; init; } = DateTime.UtcNow;

   
        /// <summary>
        /// 
        /// </summary>
        [MaxLength(50)]
        [Column("uid")]
        public string? Uid { get; init; }

   
        /// <summary>
        /// 
        /// </summary>
        [Column("course_id")]
        public long? CourseId { get; init; }
        
   
        /// <summary>
        /// 
        /// </summary>
        public required Course Course { get; init; }


        /// <summary>
        /// 
        /// </summary>
        public List<Exercise> Exercises { get; set; } = [];
    }
}
