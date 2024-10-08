﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Restful_API.Model;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }

    [Required]
    [StringLength(50)]
    public string abfi_id { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string fname { get; set; } = string.Empty;

    [StringLength(50)]
    public string? mname { get; set; } // Make this nullable

    [Required]
    [StringLength(50)]
    public string lname { get; set; } = string.Empty;

    [ForeignKey("Role")]
    [Required]
    [StringLength(50)]
    public int role_id { get; set; }

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
    public string user_password { get; set; } = string.Empty;

    public DateTime date_created { get; set; }
    public DateTime date_updated { get; set; }

    public Role Role { get; set; }

    public User()
    {
        date_created = DateTime.UtcNow;
        date_updated = DateTime.UtcNow;
    }

    public void SetPassword(string password)
    {
        user_password = BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool VerifyPassword(string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, user_password);
    }

   
}
