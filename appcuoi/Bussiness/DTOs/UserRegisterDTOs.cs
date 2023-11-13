using System.ComponentModel.DataAnnotations;

namespace appcuoi.Bussiness.DTOs
{
    public class UserRegisterDTOs
    {
        [Required] 
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ReInputPassword { get; set; }
        [Required]
        [EmailAddress] 
        public string Email { get; set; }
        public int? RoleId { get; set; }

    }
}
