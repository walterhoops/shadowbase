using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shadowbase.Models
{
    public class AuctionStatus
    {
        // 0 = Closed, 1 = Open, 2 = Pending
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int AuctionStatusID { get; set; }

        [Required]
        public string AuctionStatusDescription { get; set; }

        public ICollection<Auction> Auctions { get; set; }
    }
}
