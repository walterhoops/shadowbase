using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using shadowbase.Data;
using shadowbase.Models;

namespace shadowbase.Pages.AuctionStatuses
{
    public class DeleteModel : PageModel
    {
        private readonly shadowbase.Data.shadowbaseContext _context;

        public DeleteModel(shadowbase.Data.shadowbaseContext context)
        {
            _context = context;
        }

        [BindProperty]
      public StatusIDs StatusIDs { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.StatusIDs == null)
            {
                return NotFound();
            }

            var statusids = await _context.StatusIDs.FirstOrDefaultAsync(m => m.Id == id);

            if (statusids == null)
            {
                return NotFound();
            }
            else 
            {
                StatusIDs = statusids;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.StatusIDs == null)
            {
                return NotFound();
            }
            var statusids = await _context.StatusIDs.FindAsync(id);

            if (statusids != null)
            {
                StatusIDs = statusids;
                _context.StatusIDs.Remove(StatusIDs);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
