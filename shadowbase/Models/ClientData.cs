using System.ComponentModel.DataAnnotations;

namespace shadowbase.Models;

using System.ComponentModel.DataAnnotations;

public class ClientData
{
    public int Id { get; set; }

    [Required(ErrorMessage = "First Name is required")]
    [StringLength(int.MaxValue)] // nvarchar(max) equivalent
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last Name is required")]
    [StringLength(int.MaxValue)] // nvarchar(max) equivalent
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    [StringLength(int.MaxValue)] // nvarchar(max) equivalent
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Phone number is required")]
    [Phone(ErrorMessage = "Invalid Phone Number")]
    [StringLength(int.MaxValue)] // nvarchar(max) equivalent
    [Display(Name = "Phone")]
    public string Phone { get; set; }
}


