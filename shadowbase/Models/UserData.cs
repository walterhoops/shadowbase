using System.ComponentModel.DataAnnotations;
namespace shadowbase.Models;
public class UserData
{
    public int Id { get; set; }
    [Required]
    public string TypeID { get; set; }
    [Required]
    public string Username { get; set; }
    [DataType(DataType.Password)]
    [Required]
    public string Password { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [DataType(DataType.Date)]
    [Required]
    public DateTime DOB { get; set; }
    [DataType(DataType.PhoneNumber)]
    public string? Phone { get; set; }
    [DataType(DataType.EmailAddress)]
    [Required]
    public string Email { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public string City { get; set; }
    [DataType(DataType.PostalCode)]
    [Required]
    public string PostalCode { get; set; }
    [Required]
    public string Country { get; set; }
    [Required]
    public string Company { get; set; }
    [DataType(DataType.EmailAddress)]
    [Required]
    public string PayPalEmail { get; set; }

    public UserTypes UserTypes { get; set; }
    public ICollection<LicenseData> LicenseData { get; set; }
    public ICollection<AuctionData> AuctionData { get; set; }
    public ICollection<AuctionBidData> AuctionBidData { get; set; }
}
