using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shadowbase.Models
{
  public class Bid
  {
    [Key]
    public int BidID { get; set; }

    [Required]
    [ForeignKey("Auction")]
    public int AuctionIDFK { get; set; }
    public Auction Auction { get; set; }

    [ForeignKey("User")]
    public int? UserIDFK { get; set; } 
    public User? User { get; set; }

    [Required]
    [Column(TypeName = "decimal(2, 2)")]
    public decimal BidAmount { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime BidDate { get; set; }

  }
}