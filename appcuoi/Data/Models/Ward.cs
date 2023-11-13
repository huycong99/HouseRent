using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appcuoi.Data.Models
{
    public class Ward
    {
        [Key]
        public int WardId { get; set; }
        [Required]
        [StringLength(50)]
        public string WardName { get; set; }
        public int DistrictId { get; set; }
        [ForeignKey("DistrictId")]
        public District District { get; set; }


    }
}
