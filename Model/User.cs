using BCrypt.Net;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restful_API.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Ensure the ID is auto-incremented
        public int id { get; set; }
       
        [Required]
        [StringLength(50)]
        public string abfi_id { get; set; } = string.Empty; //make this unique

        [Required]
        [StringLength(50)]
        public string fname { get; set; } = string.Empty;

        [StringLength(50)]
        public string mname { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string lname { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string role { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string contact_num { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string email_add { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string username { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string user_password { get; set; } = string.Empty; // Store hashed password

        public DateTime date_created { get; set; }
        public DateTime date_updated { get; set; }

        public User()
        {
            date_created = DateTime.UtcNow;
            date_updated = DateTime.UtcNow;
        }

        // Hash the password using BCrypt
        public void SetPassword(string password)
        {
            user_password = BCrypt.Net.BCrypt.HashPassword(password);
        }

        // Verify the password against the hashed password
        public bool VerifyPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, user_password);
        }
    }
}
