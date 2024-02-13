using System.ComponentModel.DataAnnotations;

namespace shadowbase.Models;

public class ClientData
{
    public int Id { get; set; }
    [Display(Name = "First Name")]
    public required string FirstName { get; set; }
    [Display(Name = "Last Name")]
    public required string LastName { get; set; }
    [DataType(DataType.EmailAddress)]
    public required string Email { get; set; }
    [DataType(DataType.PhoneNumber)]
    public required string Phone { get; set; }
}
