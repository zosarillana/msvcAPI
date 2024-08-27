using System.ComponentModel.DataAnnotations;

namespace Restful_API.Model
{
    public class Isr
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string isr_name { get; set; } = string.Empty;
        [Required]
        [StringLength(255)]
        public string isr_others { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string isr_type { get; set; } = string.Empty;
        [Required]
        [StringLength(255)]
        public string description { get; set; } = string.Empty;
        [StringLength(255)]
        public string image_path { get; set; } = string.Empty;
    }
}
