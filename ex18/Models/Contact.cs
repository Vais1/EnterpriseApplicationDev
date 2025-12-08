using System.ComponentModel.DataAnnotations;

namespace ex18.Models;

public class Contact
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "First Name")]
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Last Name")]
    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [Display(Name = "Email Address")]
    [StringLength(100)]
    public string Email { get; set; } = string.Empty;

    [Phone]
    [Display(Name = "Phone Number")]
    [StringLength(20)]
    public string? PhoneNumber { get; set; }

    [Display(Name = "Address")]
    [StringLength(200)]
    public string? Address { get; set; }

    [Display(Name = "City")]
    [StringLength(50)]
    public string? City { get; set; }

    [Display(Name = "State")]
    [StringLength(50)]
    public string? State { get; set; }

    [Display(Name = "Zip Code")]
    [StringLength(10)]
    public string? ZipCode { get; set; }

    [Display(Name = "Notes")]
    [StringLength(500)]
    public string? Notes { get; set; }

    [Display(Name = "Created Date")]
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    [Display(Name = "User ID")]
    public string? UserId { get; set; }
}

