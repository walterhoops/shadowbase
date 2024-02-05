using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shadowbase.Models;

public class AuctionData
{
	public int Id { get; set; }
	public required int UserID { get; set; }
	public required int ClientID { get; set; }
	public string? StatusID { get; set; }
	public required string Type { get; set; }
	[DataType(DataType.Date)]
	public DateTime CreationDate { get; set; }
	[DataType(DataType.Date)]
	public DateTime ExpiryDate { get; set; }
	[DataType(DataType.Currency)]
	[Column(TypeName = "decimal(18, 2)")]
	public decimal HomeBudget { get; set; }
	public int BidID { get; set; }
	[Column(TypeName = "decimal(2, 2)")]
	public decimal BidLimit { get; set; }
}
