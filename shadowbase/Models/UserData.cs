using System.ComponentModel.DataAnnotations;
namespace shadowbase.Models;

public class UserData
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Type ID is required")]
    [Display(Name = "Type ID")]
    public string TypeID { get; set; }
  
    [Required(ErrorMessage = "Username is required")]
    public string Username { get; set; }
    
    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    [Required]
    public string Password { get; set; }
  
    [Required(ErrorMessage = "First Name is required")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }
  
    [Required(ErrorMessage = "Last Name is required")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }
  
    [Required(ErrorMessage = "Date of Birth is required")]
    [Display(Name = "Date of Birth")]
    [DataType(DataType.Date)]
    public DateTime DOB { get; set; }
    
    [Required(ErrorMessage = "Phone number is required")]
    [Phone(ErrorMessage = "Invalid Phone Number")]
    [StringLength(int.MaxValue)] // nvarchar(max) equivalent
    [Display(Name = "Phone")]
    [DataType(DataType.PhoneNumber)]
    public string Phone { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
  
    [Required(ErrorMessage = "Address is required")]
    public string Address { get; set; }
  
    [Required(ErrorMessage = "City is required")]
    public string City { get; set; }
  
    [Required(ErrorMessage = "Postal Code is required")]
    [DataType(DataType.PostalCode)]
    public string PostalCode { get; set; }
  
     [Required(ErrorMessage = "Country is required")]
    public string Country { get; set; }
  
    [Required(ErrorMessage = "Company is required")]
    public string Company { get; set; }
  
    [Required(ErrorMessage = "PayPal Email is required")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "PayPal Email")]
    public string PayPalEmail { get; set; }

    public UserTypes UserTypes { get; set; }
    public ICollection<LicenseData> LicenseData { get; set; }
    public ICollection<AuctionData> AuctionData { get; set; }
    public ICollection<AuctionBidData> AuctionBidData { get; set; }
}