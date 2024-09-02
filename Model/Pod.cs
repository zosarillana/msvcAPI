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

        [StringLength(255)]
        public string? pod_others { get; set; } // Nullable

        [Required]
        [StringLength(50)]
        public string pod_type { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string description { get; set; } = string.Empty;

        [StringLength(255)]
        public string? image_path { get; set; } // Nullable

        public DateTime date_created { get; set; }
        public DateTime date_updated { get; set; }

        public Pod()
        {
            date_created = DateTime.UtcNow;
            date_updated = DateTime.UtcNow;
        }
    }
}
