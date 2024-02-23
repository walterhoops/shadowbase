using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using shadowbase.Data;
using shadowbase.Models;

namespace shadowbase.Pages.AuctionBids
{
    public class IndexModel : PageModel
    {
        private readonly shadowbase.Data.shadowbaseContext _context;

        public IndexModel(shadowbase.Data.shadowbaseContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<AuctionBidData> AuctionBidData { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            // using System;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            IQueryable<AuctionBidData> auctionbid = from s in _context.AuctionBidData
                                                    select s;

            switch (sortOrder)
            {
                case "amount":
                    auctionbid = auctionbid.OrderByDescending(s => s.BidAmount);
                    break;
                case "Date":
                    auctionbid = auctionbid.OrderBy(s => s.BidDate);
                    break;
                case "date_desc":
                    auctionbid = auctionbid.OrderByDescending(s => s.BidDate);
                    break;
                default:
                    auctionbid = auctionbid.OrderBy(s => s.BidAmount);
                    break;
            }

            AuctionBidData = await auctionbid.AsNoTracking().ToListAsync();
        }
    }
}
