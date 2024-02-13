using System.ComponentModel.DataAnnotations;
namespace shadowbase.Models;

public class StatusIDs
{
    public int Id { get; set; }
    public required string StatusID { get; set; }
    [DataType(DataType.Text)]
    public string? StatusDescription { get; set; }
}
