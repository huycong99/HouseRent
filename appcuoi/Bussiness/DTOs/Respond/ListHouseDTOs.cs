using appcuoi.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace appcuoi.Bussiness.DTOs.Respond
{
    public class ListHouseDTOs
    {
        public int HouseId { get; set; }
        
        public string HouseName { get; set; }
        public string Landlord {  get; set; }
        
        public string HouseDescription { get; set; }

        public string District {  get; set; }
        public string Ward {  get; set; }
        public string Street { get; set; }

    }
}
