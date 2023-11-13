using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appcuoi.Data.Models
{
    [Table("Users")]
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        
        [StringLength(50)]
        public string ActiveStatus { get; set; }
        [Required]
        
        public DateTime Createdate { get; set; }
        
        public int? RoleId { get; set; }
        [ForeignKey("RoleId")]
        public UserRoles Roles { get; set; }
    }
}
