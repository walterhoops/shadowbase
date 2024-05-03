using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shadowbase.Models.SchoolViewModels
{
    public class UserIndexData
    {
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Bid> Bids { get; set; }
    }
}
