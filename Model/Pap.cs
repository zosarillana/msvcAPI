using System.ComponentModel.DataAnnotations;

namespace Restful_API.Model
{
    public class Pap
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string pap_name { get; set; } = string.Empty;
        [StringLength(255)]
        public string? pap_others { get; set; } = string.Empty;        
        [Required]
        [StringLength(255)]
        public string description { get; set; } = string.Empty;
        [StringLength(255)]
        public string image_path { get; set; } = string.Empty;
        public DateTime date_created { get; set; }
        public DateTime date_updated { get; set; }
        public Pap()
        {
            date_created = DateTime.UtcNow;
            date_updated = DateTime.UtcNow;
        }
    }
}
