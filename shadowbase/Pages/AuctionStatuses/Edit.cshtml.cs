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

namespace shadowbase.Pages.AuctionStatuses
{
    public class EditModel : PageModel
    {
        private readonly shadowbase.Data.ShadowbaseContext _context;

        public EditModel(shadowbase.Data.ShadowbaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AuctionStatus AuctionStatus { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AuctionStatuses == null)
            {
                return NotFound();
            }

            var auctionstatus =  await _context.AuctionStatuses.FirstOrDefaultAsync(m => m.AuctionStatusID == id);
            if (auctionstatus == null)
            {
                return NotFound();
            }
            AuctionStatus = auctionstatus;
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

            _context.Attach(AuctionStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuctionStatusExists(AuctionStatus.AuctionStatusID))
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

        private bool AuctionStatusExists(int id)
        {
          return (_context.AuctionStatuses?.Any(e => e.AuctionStatusID == id)).GetValueOrDefault();
        }
    }
}
