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

        public IList<AuctionBidData> AuctionBidData { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.AuctionBidData != null)
            {
                AuctionBidData = await _context.AuctionBidData.ToListAsync();
            }
        }
    }
}
