using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace LearningAppWebAPI.Models
{
    // TODO: Complete docs
    /// <summary>
    /// The user class
    /// </summary>
    [Table("user")]
    public class User
    {
        /// <summary>
        ///
        /// </summary>
        [Key]
        [Column("id_user")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [MaxLength(50)]
        [Column("username")]
        public string? Username { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [MaxLength(500)]
        [Column("password_hash")]
        public string? PasswordHash { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MaxLength(500)]
        [Column("profile_picture")]
        public string? ProfilePicture { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("registration_date")]
        public DateTime RegistrationDate { get; init; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [MaxLength(125)]
        [Column("email")]
        public string? Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("role_id")]
        public int RoleId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("level")]
        [DefaultValue(1)]
        public int Level { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("current_xp")]
        [DefaultValue(0)]
        public int CurrentXp { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [Column("current_streak")]
        [DefaultValue(0)]
        public int CurrentStreak { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Course>? Courses { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Dictionary>? Dictionaries { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ICollection<RefreshToken> RefreshTokens { get; init; } = [];
        /// <summary>
        /// 
        /// </summary>
        public Role? Role { get; set; }

    }
}
