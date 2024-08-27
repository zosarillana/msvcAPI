using System.ComponentModel.DataAnnotations;

namespace Restful_API.DataTransferObject
{
    public class UpdateUserDto
    {
        public string abfi_id { get; set; }
        public string fname { get; set; }
        public string mname { get; set; }
        public string lname { get; set; }
        public string role { get; set; }
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Contact number must be exactly 11 digits.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Contact number must contain only digits.")]
        public string contact_num { get; set; }
        [EmailAddress(ErrorMessage = "Email address must be a valid email address.")]
        public string email_add { get; set; }
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Username must be at least 8 characters long.")]
        public string username { get; set; }

        public string user_password { get; set; } // Use this for password

    }
}
