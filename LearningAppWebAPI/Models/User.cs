using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningAppWebAPI.Models
{
    /// <summary>
    /// The user class
    /// </summary>
    [Table("user")]
    public class User
    {

        /// <summary>
        /// Gets or inits the value of the id
        /// </summary>
        [Key]
        [Column("id_user")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }

        /// <summary>
        /// Gets or sets the value of the username
        /// </summary>
        [Required]
        [MaxLength(50)]
        [Column("username")]
        public string? Username { get; set; }

        /// <summary>
        /// Gets or sets the value of the password hash
        /// </summary>
        [Required]
        [MaxLength(500)]
        [Column("password_hash")]
        public string? PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets the value of the profile picture
        /// </summary>
        [MaxLength(500)]
        [Column("profile_picture")]
        public string? ProfilePicture { get; set; }

        /// <summary>
        /// Gets or sets the value of the registration date
        /// </summary>
        [Column("registration_date")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the value of the email
        /// </summary>
        [Required]
        [MaxLength(125)]
        [Column("email")]
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the value of the role id
        /// </summary>
        [Column("role_id")]
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or sets the value of the level
        /// </summary>
        [Column("level")]
        [DefaultValue(1)]
        public int Level { get; set; }

        /// <summary>
        /// Gets or sets the value of the current xp
        /// </summary>
        [Column("current_xp")]
        [DefaultValue(0)]
        public int CurrentXp { get; set; }

        /// <summary>
        /// Gets or inits the value of the courses
        /// </summary>
        public List<Course>? Courses { get; init; }
        

        /// <summary>
        /// Gets or sets the value of the role
        /// </summary>
        public Role? Role { get; set; }

    }
}
