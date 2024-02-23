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
    public class DeleteModel : PageModel
    {
        private readonly shadowbase.Data.ShadowbaseContext _context;

        public DeleteModel(shadowbase.Data.ShadowbaseContext context)
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

            var bid = await _context.Bids.FirstOrDefaultAsync(m => m.BidID == id);

            if (bid == null)
            {
                return NotFound();
            }
            else 
            {
                Bid = bid;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Bids == null)
            {
                return NotFound();
            }
            var bid = await _context.Bids.FindAsync(id);

            if (bid != null)
            {
                Bid = bid;
                _context.Bids.Remove(Bid);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
