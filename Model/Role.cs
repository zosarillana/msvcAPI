using System.ComponentModel.DataAnnotations;

namespace Restful_API.Model
{
    public class Role
    {
        [Key]
        public int id { get; set; }
       
        [Required]
        [StringLength(50)]
        public string role { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string role_description { get; set; } = string.Empty;
    }
}