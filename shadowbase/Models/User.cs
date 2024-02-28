using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace shadowbase.Models;

public class User
{
    [Key]
    public int UserID { get; set; }

    [Required]
    [ForeignKey("UserType")]
    public int UserTypeIDFK { get; set; }
    public UserType UserType { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 3)]
    public string Username { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    [StringLength(20, MinimumLength = 6)]
    public string Password { get; set; }
  
    [Required]
    [StringLength(30, MinimumLength = 1)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(30, MinimumLength = 1)]
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
    [StringLength(50, MinimumLength = 1)]
    public string City { get; set; }

    [Required]
    [DataType(DataType.PostalCode)]
    public string PostalCode { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 1)]
    public string Country { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 1)]
    public string Company { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string PayPalEmail { get; set; }

    [Required]
    [StringLength(30, MinimumLength = 3)]
    public string LicenseID { get; set; }

    public ICollection<Auction>? Auctions { get; set; }
    public ICollection<Bid>? Bids { get; set; }
}
// TODO: Feb. 28 - Connect clients to users. Users should be able to create clients.
// Clients are the commodity that is traded on this platform, the currency is bidded % commission.
// So, Users must be able to create clients and view their own clients.
// Other users should not be able to see your clients. Their contact information is the commodity.
// Auction creation should have selection of clients created and linked to your account.
// Client selection in auction creation should hide clients linked to other users.
// Auction creation should be linked to the logged in user to determine which clients are visible/hidden.