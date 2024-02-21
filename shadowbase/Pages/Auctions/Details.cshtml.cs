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
    public class DetailsModel : PageModel
    {
        private readonly shadowbase.Data.shadowbaseContext _context;

        public DetailsModel(shadowbase.Data.shadowbaseContext context)
        {
            _context = context;
        }

      public AuctionData AuctionData { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AuctionData == null)
            {
                return NotFound();
            }

            AuctionData = await _context.AuctionData
        .Include(a => a.UserData)
        .ThenInclude(u => u.AuctionBidData)
        .Include(a => a.StatusIDs)
        .Include(a => a.ClientData)
        .AsNoTracking()
        .FirstOrDefaultAsync(m => m.Id == id);
            if (AuctionData == null)
            {
                return NotFound();
            }
            
            return Page();
        }
    }
}
