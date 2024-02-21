using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using shadowbase.Data;
using shadowbase.Models;

namespace shadowbase.Pages.Clients
{
    public class DetailsModel : PageModel
    {
        private readonly shadowbase.Data.shadowbaseContext _context;

        public DetailsModel(shadowbase.Data.shadowbaseContext context)
        {
            _context = context;
        }

      public ClientData ClientData { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ClientData == null)
            {
                return NotFound();
            }

            ClientData = await _context.ClientData
        .Include(c => c.AuctionData)
        
        .AsNoTracking()
        .FirstOrDefaultAsync(m => m.Id == id);
            if (ClientData == null)
            {
                return NotFound();
            }
            
            return Page();
        }
    }
}
