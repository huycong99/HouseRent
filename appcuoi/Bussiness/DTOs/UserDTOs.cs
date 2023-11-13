using System.ComponentModel.DataAnnotations;

namespace appcuoi.Bussiness.DTOs
{
    public class UserDTOs
    {
        
        public int UserId { get; set; }
        
        public string Username { get; set; }
        public DateTime Createdate { get; set; }
        public string Email { get; set; }
        public string ActiveStatus { get; set; }
        public string RoleName { get; set; }
    }
}
