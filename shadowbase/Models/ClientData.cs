using System.ComponentModel.DataAnnotations;

namespace shadowbase.Models;

public class ClientData
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    [DataType(DataType.EmailAddress)]
    public required string Email { get; set; }
    [DataType(DataType.PhoneNumber)]
    public required string Phone { get; set; }
}
