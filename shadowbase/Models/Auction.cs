using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace shadowbase.Models;

public class Auction
{
    [Key,
        Display(Name = "Number")]
	public int AuctionID { get; set; }
    
    [ForeignKey("User"),
        Display(Name = "User ID")]
    public int UserIDFK { get; set; }
    public User User { get; set; }

    [ForeignKey("Client"),
        Display(Name = "Client ID")]
    public int ClientIDFK { get; set; }
    public Client Client { get; set; }

    [ForeignKey("AuctionStatus")]
	public int AuctionStatusIDFK { get; set; }
    [Display(Name = "Status")]
    public AuctionStatus AuctionStatus { get; set; }
  
    [ForeignKey("AuctionType")]
    public int AuctionTypeIDFK { get; set; }
    [Display(Name = "Listing Type")]
    public AuctionType AuctionType { get; set; }


    [DataType(DataType.Date),
        Display(Name = "Creation Date")]
    public DateTime CreationDate { get; set; }

	[DataType(DataType.Date),
        Display(Name = "Expiry Date")]
	public DateTime ExpiryDate { get; set; }

    [Range(0, 5000000)]
    [DataType(DataType.Currency),
        Display(Name = "Home Budget")]
	public int HomeBudget { get; set; }

    public ICollection<Bid>? Bids { get; set; }
    public Department Department { get; set; }
    
    public ICollection<Instructor> Instructors { get; set; }

    //[ForeignKey("HighestBid")]
    //public int HighestBidIDFK { get; set; }
    //public Bid HighestBid { get; set; }

    [Range(0,1),
        Column(TypeName = "decimal(3, 2)"),
        Display(Name = "Bid Limit %")]
	public decimal BidLimit { get; set; }
}
// TODO: Feb. 28 - Connect clients to users. Users should be able to create clients.
// Clients are the commodity that is traded on this platform, the currency is bidded % commission.
// So, Users must be able to create clients and view their own clients.
// Other users should not be able to see your clients. Their contact information is the commodity.
// Auction creation should have selection of clients created and linked to your account.
// Client selection in auction creation should hide clients linked to other users.
// Auction creation should be linked to the logged in user to determine which clients are visible/hidden.