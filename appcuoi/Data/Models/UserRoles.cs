using System.ComponentModel.DataAnnotations;

namespace appcuoi.Data.Models
{
    public class UserRoles
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        [StringLength(100)]
        public string RoleName { get; set; }
    }
}
