
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningAppWebAPI.Models
{

    // TODO: Complete docs
    /// <summary>
    /// The user course class
    /// </summary>
    [Table("user_course")]
    public class UserCourse
    {

        /// <summary>
        /// 
        /// </summary>
        [Column("user_id")]
        public long UserId { get; init; }
       

        /// <summary>
        ///
        /// </summary>
        [Column("course_id")]
        public long CourseId { get; init; }
        

        /// <summary>
        /// 
        /// </summary>
        [Column("is_finished")]
        [DefaultValue(false)]
        public bool IsFinished { get; init; }


        /// <summary>
        /// 
        /// </summary>
        [Column("course_progress")]
        [DefaultValue(0)]
        public float CourseProgress { get; init; }
        

        /// <summary>
        /// 
        /// </summary>
        public Course? Course { get; init; }
        

        /// <summary>
        /// 
        /// </summary>
        public User? User { get; init; }
    }
}
