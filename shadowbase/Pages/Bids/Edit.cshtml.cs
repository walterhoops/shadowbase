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

namespace shadowbase.Pages.Bids
{
    public class EditModel : PageModel
    {
        private readonly shadowbase.Data.ShadowbaseContext _context;

        public EditModel(shadowbase.Data.ShadowbaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bid Bid { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Bids == null)
            {
                return NotFound();
            }

            var bid =  await _context.Bids.FirstOrDefaultAsync(m => m.BidID == id);
            if (bid == null)
            {
                return NotFound();
            }
            Bid = bid;
           ViewData["AuctionIDFK"] = new SelectList(_context.Auctions, "AuctionID", "AuctionID");
           ViewData["UserIDFK"] = new SelectList(_context.Users, "UserID", "Address");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Bid).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BidExists(Bid.BidID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BidExists(int id)
        {
          return (_context.Bids?.Any(e => e.BidID == id)).GetValueOrDefault();
        }
    }
}
