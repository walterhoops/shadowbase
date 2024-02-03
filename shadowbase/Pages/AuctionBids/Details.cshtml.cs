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
    public class DetailsModel : PageModel
    {
        private readonly shadowbase.Data.shadowbaseContext _context;

        public DetailsModel(shadowbase.Data.shadowbaseContext context)
        {
            _context = context;
        }

      public AuctionBidData AuctionBidData { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AuctionBidData == null)
            {
                return NotFound();
            }

            var auctionbiddata = await _context.AuctionBidData.FirstOrDefaultAsync(m => m.Id == id);
            if (auctionbiddata == null)
            {
                return NotFound();
            }
            else 
            {
                AuctionBidData = auctionbiddata;
            }
            return Page();
        }
    }
}
