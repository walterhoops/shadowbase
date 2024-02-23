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
        private readonly shadowbase.Data.shadowbaseContext _context;

        public EditModel(shadowbase.Data.shadowbaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StatusIDs StatusIDs { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StatusIDs = await _context.StatusIDs.FindAsync(id);

            if (StatusIDs == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var StatusIDsToUpdate = await _context.StatusIDs.FindAsync(id);

            if (StatusIDsToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<StatusIDs>(
                StatusIDsToUpdate,
                "status",
                s => s.StatusID, s => s.StatusDescription))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool StatusIDsExists(int id)
        {
          return (_context.StatusIDs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
