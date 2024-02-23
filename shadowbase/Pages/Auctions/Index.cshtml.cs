using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using shadowbase.Data;
using shadowbase.Models;

namespace shadowbase.Pages.Auctions
{
    public class IndexModel : PageModel
    {
        private readonly shadowbase.Data.ShadowbaseContext _context;

        public IndexModel(shadowbase.Data.ShadowbaseContext context)
        {
            _context = context;
        }

        public IList<Auction> Auction { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Auctions != null)
            {
                Auction = await _context.Auctions
                .Include(a => a.AuctionStatus)
                .Include(a => a.AuctionType)
                .Include(a => a.Client)
                .Include(a => a.User).ToListAsync();
            }
        }
    }
}
