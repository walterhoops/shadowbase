using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shadowbase.Models
{
    public class AuctionBidData
    {
        public int Id { get; set; }
        public int UserID { get; set; }

        [Column(TypeName = "decimal(2, 2)")] 
        public decimal BidAmount { get; set; }

        [DataType(DataType.Date)]
        public DateTime BidDate { get; set; }
    }
}

