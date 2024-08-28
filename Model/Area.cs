using System.ComponentModel.DataAnnotations;

namespace Restful_API.Model
{
    public class Area
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string area { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string description { get; set; } = string.Empty;
        public DateTime date_created { get; set; }
        public DateTime date_updated { get; set; }
        public Area()
        {
            date_created = DateTime.UtcNow;
            date_updated = DateTime.UtcNow;
        }

    }
}
