using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shadowbase.Models;

public class Auction
{

    [Key]
	public int AuctionID { get; set; }
    
    [Required]
    [ForeignKey("User")]
    public int UserIDFK { get; set; }
    public User User { get; set; }

    [Required]
    [ForeignKey("Client")]
    public int ClientIDFK { get; set; }
    public Client Client { get; set; }

    [Required]
    [ForeignKey("AuctionStatus")]
	public int AuctionStatusIDFK { get; set; }
    public AuctionStatus AuctionStatus { get; set; }
  
    [Required]
    [ForeignKey("AuctionType")]
    public int AuctionTypeIDFK { get; set; }
    public AuctionType AuctionType { get; set; }


    [DataType(DataType.Date)]
    public DateTime CreationDate { get; set; }

	[DataType(DataType.Date)]
	public DateTime ExpiryDate { get; set; }
  
	[DataType(DataType.Currency)]
	public int HomeBudget { get; set; }

    public ICollection<Bid>? Bids { get; set; }

    //[ForeignKey("HighestBid")]
	//public int HighestBidIDFK { get; set; }
    //public Bid HighestBid { get; set; }

    [DataType(DataType.Currency)]
	[Column(TypeName = "decimal(2, 2)")]
	public decimal BidLimit { get; set; }
}