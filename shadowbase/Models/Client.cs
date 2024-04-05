using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace shadowbase.Models;
public class Client
{

    [Key]
    public int ClientID { get; set; }

    [StringLength(50, MinimumLength = 1, ErrorMessage = "First name cannot be longer than 50 characters.")]
    [Required]
    [Column("First Name")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [StringLength(50, MinimumLength = 1)]
    [Required]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.PhoneNumber)]
    public string Phone { get; set; }
    public string FullName
    {
        get
        {
            return LastName + ", " + FirstName;
        }
    }

    public ICollection<Auction> Auctions { get; set; }
}
// TODO: Feb. 28 - Connect clients to users. Users should be able to create clients.
// Clients are the commodity that is traded on this platform, the currency is bidded % commission.
// So, Users must be able to create clients and view their own clients.
// Other users should not be able to see your clients. Their contact information is the commodity.
// Auction creation should have selection of clients created and linked to your account.
// Client selection in auction creation should hide clients linked to other users.
// Auction creation should be linked to the logged in user to determine which clients are visible/hidden.