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
    public class DeleteModel : PageModel
    {
        private readonly shadowbase.Data.shadowbaseContext _context;

        public DeleteModel(shadowbase.Data.shadowbaseContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.AuctionBidData == null)
            {
                return NotFound();
            }
            var auctionbiddata = await _context.AuctionBidData.FindAsync(id);

            if (auctionbiddata != null)
            {
                AuctionBidData = auctionbiddata;
                _context.AuctionBidData.Remove(AuctionBidData);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
