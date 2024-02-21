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

namespace shadowbase.Pages.Auctions
{
    public class EditModel : PageModel
    {
        private readonly shadowbase.Data.shadowbaseContext _context;

        public EditModel(shadowbase.Data.shadowbaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AuctionData AuctionData { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AuctionData = await _context.AuctionData.FindAsync(id);

            if (AuctionData == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var auctionToUpdate = await _context.AuctionData.FindAsync(id);

            if (auctionToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<AuctionData>(
                auctionToUpdate,
                "auction",
                s => s.UserID, s => s.ClientID, s => s.StatusID, s => s.Type, s => s.CreationDate, s => s.ExpiryDate, s => s.HomeBudget, s => s.BidID, s => s.BidLimit))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool AuctionDataExists(int id)
        {
          return (_context.AuctionData?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
