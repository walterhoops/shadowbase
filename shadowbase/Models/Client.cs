using System.ComponentModel.DataAnnotations;
namespace shadowbase.Models;
public class Client
{

    [Key]
    public int ClientID { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.PhoneNumber)]
    public string Phone { get; set; }

    public ICollection<Auction> Auctions { get; set; }
}