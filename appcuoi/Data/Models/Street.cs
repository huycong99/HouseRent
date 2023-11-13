using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appcuoi.Data.Models
{
    public class Street
    {
        [Key]
        public int StreetId { get; set; }
        [Required]
        [StringLength(50)]
        public string StreetName { get; set; }
        public int WardId { get; set; }
        [ForeignKey("WardId")]
        public Ward Ward { get; set; }  
    }
}
