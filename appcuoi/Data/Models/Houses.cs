using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appcuoi.Data.Models
{
    public class Houses
    {
        [Key]
        public int HouseId { get; set; }
        [Required]
        [StringLength(50)]
        public string HouseName { get; set;}
        [Required]
        [StringLength(50)]
        public string HouseDescription { get; set; }
       
        public int? StreetId { get; set; }
        [ForeignKey("StreetId")]
        public Street Street { get; set; }
        [Required]

        public DateTime Createdate { get; set; } = DateTime.Now;
        public int? UserId { get; set; }
        
        [ForeignKey("UserId")]
        public Users User { get; set; }
       

      


    }
}
