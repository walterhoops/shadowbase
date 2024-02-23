using System.ComponentModel.DataAnnotations;
namespace shadowbase.Models;

public class StatusIDs
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Status ID is required")]
    [RegularExpression(@"^[A-Z]{3}\d{3}$", ErrorMessage = "Status ID must be open, closed, or pending")]
    [Display(Name = "Status ID")]
    public string StatusID { get; set; }
    [Display(Name = "Status Description")]
    [DataType(DataType.Text)]
    public string? StatusDescription { get; set; }
    public ICollection<AuctionData> AuctionData { get; set; }
}