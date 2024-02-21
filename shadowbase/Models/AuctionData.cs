﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shadowbase.Models;

public class AuctionData
{
	public int Id { get; set; }
    [Required]
    public int UserID { get; set; }
    [Required]
    public int ClientID { get; set; }
	public string? StatusID { get; set; }
    [Required]
    public string Type { get; set; }
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

    public ICollection<UserData> UserData { get; set; }
    public ICollection<AuctionBidData> AuctionBidData { get; set; }
    public ICollection<StatusIDs> StatusIDs { get; set; }
    public ICollection<ClientData> ClientData { get; set; }
}
