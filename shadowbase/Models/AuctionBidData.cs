using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace shadowbase.Models;

public class AuctionBidData
{
    public int Id { get; set; }
    [Required]
    public int UserID { get; set; } 
    [Column(TypeName = "decimal(2, 2)")]
    [Required]
    public decimal BidAmount { get; set; }
    [DataType(DataType.Date)]
    [Required]
    public DateTime BidDate { get; set; }
    public ICollection<UserData> UserData { get; set; }
    public ICollection<AuctionData> AuctionData { get; set; }

 

}


