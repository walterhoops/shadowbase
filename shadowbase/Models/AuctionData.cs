using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shadowbase.Models;

public class AuctionData
{
    public int Id { get; set; }
    public int UserID { get; set; }
    public int ClientID { get; set; }
    public string StatusID { get; set; }
    public string Type { get; set; }

    [Display(Name = "Created")]
    [DataType(DataType.Date)]
    public DateTime CreationDate { get; set; }

    [Display(Name = "Expired")]
    [DataType(DataType.Date)]
    public DateTime ExpiryDate { get; set; }

    [Display(Name = "Home Budget")]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(2, 2)")] 
    public decimal HomeBudget { get; set; }

    public int BidID { get; set; }

    [Display(Name = "Bid Limit")]
    [Column(TypeName = "decimal(2, 2)")]
    public decimal BidLimit { get; set; }

    [Display(Name = "Commission")]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(2, 2)")]
    public decimal Commission { get; set; }
}



