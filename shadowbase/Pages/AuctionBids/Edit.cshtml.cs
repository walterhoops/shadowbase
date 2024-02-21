using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using shadowbase.Data;
using shadowbase.Models;

namespace shadowbase.Pages.AuctionBids
{
    public class EditModel : PageModel
    {
        private readonly shadowbase.Data.shadowbaseContext _context;

        public EditModel(shadowbase.Data.shadowbaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AuctionBidData AuctionBidData { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AuctionBidData = await _context.AuctionBidData.FindAsync(id);

            if (AuctionBidData == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var auctionBidToUpdate = await _context.AuctionBidData.FindAsync(id);

            if (auctionBidToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<AuctionBidData>(
                auctionBidToUpdate,
                "auctionBid",
                s => s.UserID, s => s.BidAmount, s => s.BidDate))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool AuctionBidDataExists(int id)
        {
          return (_context.AuctionBidData?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
