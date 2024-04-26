using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using shadowbase.Data;
using shadowbase.Models;
using shadowbase.UserViewModels;

namespace shadowbase.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly shadowbase.Data.ShadowbaseContext _context;

        public IndexModel(shadowbase.Data.ShadowbaseContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; } = default!;
        public UserIndexData UserData { get; set; }
        public int UserID { get;set; }
        public int BidID { get;set; }

        public async Task OnGetAsync(int? id, int? bidID)
        {
            UserData = new UserIndexData();
            UserData.Users = await _context.Users
                .Include(i => i.Auctions)
                .Include(i => i.Bids)
                    .ThenInclude(c =>c.BidAmount)
                .OrderBy(i => i.Username)
                .AsNoTracking()
                .ToListAsync();

            if (id != null)
            {
                UserID = id.Value;
                User user = UserData.Users
                    .Where(i => i.UserID == id.Value).Single();
                UserData.Bids = user.Bids;
            }

            if (bidID != null)
            {
                BidID = bidID.Value;
                IEnumerable<Bid> Bids = await _context.Bids
                    .Where(x => x.BidID == BidID)
                    .Include(i => i.Auction)
                    .ToListAsync();
                UserData.Bids = Bids;
            }

            if (_context.Users != null)
            {
                User = await _context.Users
                .Include(u => u.UserType).ToListAsync();
            }
        }
    }
}
