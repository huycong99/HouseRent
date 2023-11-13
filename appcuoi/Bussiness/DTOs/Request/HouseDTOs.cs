using System.ComponentModel.DataAnnotations;

namespace appcuoi.Bussiness.DTOs.Request
{
    public class HouseDTOs
    {
        [Required]
        public string HouseName { get; set; }
        [Required]
        
        public string HouseDescription { get; set; }
        [Required]
        public int StreetId { get; set; }
    }
}
