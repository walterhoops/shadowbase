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
    public class DeleteModel : PageModel
    {
        private readonly shadowbase.Data.ShadowbaseContext _context;

        public DeleteModel(shadowbase.Data.ShadowbaseContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Auction Auction { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Auctions == null)
            {
                return NotFound();
            }

            var auction = await _context.Auctions.FirstOrDefaultAsync(m => m.AuctionID == id);

            if (auction == null)
            {
                return NotFound();
            }
            else 
            {
                Auction = auction;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Auctions == null)
            {
                return NotFound();
            }
            var auction = await _context.Auctions.FindAsync(id);

            if (auction != null)
            {
                Auction = auction;
                _context.Auctions.Remove(Auction);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
