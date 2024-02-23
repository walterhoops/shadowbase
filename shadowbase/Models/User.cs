using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace shadowbase.Models;

public class User
{
    public int UserID { get; set; }

    [Required]

    [ForeignKey("UserType")]
    public int UserTypeIDFK { get; set; }

    public UserType UserType { get; set; }

    [Required]
    public string Username { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
  
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime DOB { get; set; }

    [Required]
    [DataType(DataType.PhoneNumber)]
    public string Phone { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    public string City { get; set; }

    [Required]
    [DataType(DataType.PostalCode)]
    public string PostalCode { get; set; }

    [Required]
    public string Country { get; set; }

    [Required]
    public string Company { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string PayPalEmail { get; set; }

    [Required]
    public string LicenseID { get; set; }

    public ICollection<Auction>? Auctions { get; set; }
    public ICollection<Bid>? Bids { get; set; }
}