using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using shadowbase.Data;
using shadowbase.Models;

namespace shadowbase.Pages.Bids
{
    public class IndexModel : PageModel
    {
        private readonly shadowbase.Data.ShadowbaseContext _context;

        public IndexModel(shadowbase.Data.ShadowbaseContext context)
        {
            _context = context;
        }

        public IList<Bid> Bid { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Bids != null)
            {
                Bid = await _context.Bids
                .Include(b => b.Auction)
                .Include(b => b.User).ToListAsync();
            }
        }
    }
}
