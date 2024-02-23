using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using shadowbase.Data;
using shadowbase.Models;

namespace shadowbase.Pages.Bids
{
    public class CreateModel : PageModel
    {
        private readonly shadowbase.Data.ShadowbaseContext _context;

        public CreateModel(shadowbase.Data.ShadowbaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AuctionIDFK"] = new SelectList(_context.Auctions, "AuctionID", "AuctionID");
        ViewData["UserIDFK"] = new SelectList(_context.Users, "UserID", "Address");
            return Page();
        }

        [BindProperty]
        public Bid Bid { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Bids == null || Bid == null)
            {
                return Page();
            }

            _context.Bids.Add(Bid);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
