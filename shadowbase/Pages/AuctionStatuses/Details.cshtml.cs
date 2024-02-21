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
    public class DetailsModel : PageModel
    {
        private readonly shadowbase.Data.shadowbaseContext _context;

        public DetailsModel(shadowbase.Data.shadowbaseContext context)
        {
            _context = context;
        }

      public StatusIDs StatusIDs { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.StatusIDs == null)
            {
                return NotFound();
            }

            StatusIDs = await _context.StatusIDs
        .Include(s => s.AuctionData)
        
        .AsNoTracking()
        .FirstOrDefaultAsync(m => m.Id == id);
            if (StatusIDs == null)
            {
                return NotFound();
            }
            
            return Page();
        }
    }
}
