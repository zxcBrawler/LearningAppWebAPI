
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningAppWebAPI.Models
{

    /// <summary>
    /// The user course class
    /// </summary>
    [Table("user_course")]
    public class UserCourse
    {

        /// <summary>
        /// Gets or inits the value of the user id
        /// </summary>
        [Column("user_id")]
        public int UserId { get; init; }
       

        /// <summary>
        /// Gets or inits the value of the course id
        /// </summary>
        [Column("course_id")]
        public int CourseId { get; init; }
        

        /// <summary>
        /// Gets or inits the value of the is finished
        /// </summary>
        [Column("is_finished")]
        [DefaultValue(false)]
        public bool IsFinished { get; init; }


        /// <summary>
        /// Gets or inits the value of the course progress
        /// </summary>
        [Column("course_progress")]
        [DefaultValue(0)]
        public float CourseProgress { get; init; }
        

        /// <summary>
        /// Gets or inits the value of the course
        /// </summary>
        public Course? Course { get; init; }
        

        /// <summary>
        /// Gets or inits the value of the user
        /// </summary>
        public User? User { get; init; }
    }
}
