using System.ComponentModel.DataAnnotations;

namespace appcuoi.Data.Models
{
    public class District
    {
        [Key]
        public int DistricId { get; set; }
        [Required]
        [StringLength(50)]
        public string DistrictName { get; set; }
    }
}
