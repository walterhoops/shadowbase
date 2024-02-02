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
        private readonly shadowbase.Data.shadowbaseContext _context;

        public IndexModel(shadowbase.Data.shadowbaseContext context)
        {
            _context = context;
        }

        public IList<AuctionData> AuctionData { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.AuctionData != null)
            {
                AuctionData = await _context.AuctionData.ToListAsync();
            }
        }
    }
}
