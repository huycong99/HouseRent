using System.ComponentModel.DataAnnotations;

namespace appcuoi.Bussiness.DTOs.Request
{
    public class updateHouseDTO
    {
        
        public string? HouseName { get; set; }
        

        public string? HouseDescription { get; set; }
        
        public int? StreetId { get; set; }
    }
}
