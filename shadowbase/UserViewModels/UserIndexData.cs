
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shadowbase.Models;
using shadowbase.Models.SchoolViewModels;

namespace shadowbase.UserViewModels
{
    public class UserIndexData
    {
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Bid> Bids { get; set; }
        public IEnumerable<Auction> Auctions { get; set; }
        public IEnumerable<EnrollmentDateGroup> AuctionCount { get; set; }
        //Remove it if it doesn't work AuctionCount;
    }
}