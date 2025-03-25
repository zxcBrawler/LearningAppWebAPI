using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningAppWebAPI.Models
{
    // TODO: Complete docs
    /// <summary>
    /// 
    /// </summary>
    [Table("role")]
    public class Role
    {
   
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [Column("id_role")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }
   
        /// <summary>
        /// 
        /// </summary>
        [MaxLength(50)]
        [Column("role_name")]
        public string? RoleName { get; init; }
   
        /// <summary>
        /// 
        /// </summary>
        public List<User>? User { get; init; }
    }
}
