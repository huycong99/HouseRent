using System.ComponentModel.DataAnnotations;

namespace appcuoi.Bussiness.DTOs.Request
{
    public class AdminApproveDTO
    {
        [Required]
        public string ActiveStatus { get; set; }
    }
}
