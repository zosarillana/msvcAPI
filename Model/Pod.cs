using System.ComponentModel.DataAnnotations;

namespace Restful_API.Model
{
    public class Pod
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string pod_name { get; set; } = string.Empty;
        [Required]
        [StringLength(255)]
        public string pod_others { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string pod_type { get; set; } = string.Empty;
        [Required]
        [StringLength(255)]
        public string description { get; set; } = string.Empty;
        [StringLength(255)]
        public string image_path { get; set; } = string.Empty;
    }
}
