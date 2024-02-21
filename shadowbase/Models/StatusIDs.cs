using System.ComponentModel.DataAnnotations;
namespace shadowbase.Models;

public class StatusIDs
{
    public int Id { get; set; }
    [Required]
    public int StatusID { get; set; }
    [DataType(DataType.Text)]
    public string? StatusDescription { get; set; }
    public ICollection<AuctionData> AuctionData { get; set; }
}
