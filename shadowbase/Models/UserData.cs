using System.ComponentModel.DataAnnotations;
namespace shadowbase.Models;
public class UserData
{
    public int Id { get; set; }
    [Required]
    public required string TypeID { get; set; }
    public required string Username { get; set; }
    [DataType(DataType.Password)]
    public required string Password { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    [DataType(DataType.Date)]
    public required DateTime DOB { get; set; }
    [DataType(DataType.PhoneNumber)]
    public string? Phone { get; set; }
    [DataType(DataType.EmailAddress)]
    public required string Email { get; set; }
    public required string Address { get; set; }
    public required string City { get; set; }
    [DataType(DataType.PostalCode)]
    public required string PostalCode { get; set; }
    public required string Country { get; set; }
    public required string Company { get; set; }
    [DataType(DataType.EmailAddress)]
    public required string PayPalEmail { get; set; }
}
