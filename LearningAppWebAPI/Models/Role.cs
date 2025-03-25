using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningAppWebAPI.Models
{
    
    /// <summary>
    /// 
    /// </summary>
    [Table("role")]
    public class Role
    {
   
        /// <summary>
        /// Gets or inits the value of the id
        /// </summary>
        [Key]
        [Column("id_role")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }
   
        /// <summary>
        /// Gets or inits the value of the role name
        /// </summary>
        [MaxLength(50)]
        [Column("role_name")]
        public string? RoleName { get; init; }
   
        /// <summary>
        /// Gets or inits the value of the user
        /// </summary>
        public List<User>? User { get; init; }
    }
}
