using System.ComponentModel.DataAnnotations;

namespace Restful_API.Model
{
    public class Role
    {
        [Key]
        public int id { get; set; }
       
        [Required]
        [StringLength(50)]
        public int role_id { get; set; } 

        [Required]
        [StringLength(255)]
        public string role_description { get; set; } = string.Empty;
        public DateTime date_created { get; set; }
        public DateTime date_updated { get; set; }
        public Role()
        {
            date_created = DateTime.UtcNow;
            date_updated = DateTime.UtcNow;
        }
    }
}