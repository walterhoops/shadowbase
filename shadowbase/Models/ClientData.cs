using System.ComponentModel.DataAnnotations;

namespace shadowbase.Models;

public class ClientData
{
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [DataType(DataType.EmailAddress)]
    [Required]
    public string Email { get; set; }
    [DataType(DataType.PhoneNumber)]
    [Required]
    public string Phone { get; set; }
    public ICollection<AuctionData> AuctionData { get; set; }
}
