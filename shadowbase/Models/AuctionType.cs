using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shadowbase.Models
{
    public class AuctionType
    {
        // 0 = Real Estate, 1 = Mortgage, 2 = Home Insurance
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int AuctionTypeID { get; set; }

        [Required,
            StringLength(50)]
        public string AuctionTypeDescription { get; set; }

        public ICollection<Auction> Auctions { get; set; }
    }
}
