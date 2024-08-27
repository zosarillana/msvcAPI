using System.ComponentModel.DataAnnotations;

namespace Restful_API.DataTransferObject
{
    public class CreateIsr
    {

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string isr_name { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string isr_type { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string description { get; set; } = string.Empty;
    }
}
