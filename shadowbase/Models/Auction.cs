using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shadowbase.Models;

public class Auction
{

    [Key]
	public int AuctionID { get; set; }
    
    [Required]
    [ForeignKey("User")]
    [Display(Name = "User ID")]
    public int UserIDFK { get; set; }
    public User User { get; set; }

    [Required]
    [ForeignKey("Client")]
    [Display(Name = "Client ID")]
    public int ClientIDFK { get; set; }
    public Client Client { get; set; }

    [Required]
    [ForeignKey("AuctionStatus")]
    [Display(Name = "Status")]
	public int AuctionStatusIDFK { get; set; }
    public AuctionStatus AuctionStatus { get; set; }
  
    [Required]
    [ForeignKey("AuctionType")]
    [Display(Name = "Listing Type")]
    public int AuctionTypeIDFK { get; set; }
    public AuctionType AuctionType { get; set; }


    [DataType(DataType.Date)]
    [Display(Name = "Creation Date")]
    public DateTime CreationDate { get; set; }

	[DataType(DataType.Date)]
    [Display(Name = "Expiry Date")]
	public DateTime ExpiryDate { get; set; }
  
	[DataType(DataType.Currency)]
    [Display(Name = "Home Budget")]
	public int HomeBudget { get; set; }

    public ICollection<Bid>? Bids { get; set; }

    //[ForeignKey("HighestBid")]
	//public int HighestBidIDFK { get; set; }
    //public Bid HighestBid { get; set; }


	[Column(TypeName = "decimal(3, 2)")]
	public decimal BidLimit { get; set; }
}