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
        private readonly shadowbase.Data.ShadowbaseContext _context;

        public DetailsModel(shadowbase.Data.ShadowbaseContext context)
        {
            _context = context;
        }

      public AuctionStatus AuctionStatus { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AuctionStatuses == null)
            {
                return NotFound();
            }

            var auctionstatus = await _context.AuctionStatuses.FirstOrDefaultAsync(m => m.AuctionStatusID == id);
            if (auctionstatus == null)
            {
                return NotFound();
            }
            else 
            {
                AuctionStatus = auctionstatus;
            }
            return Page();
        }
    }
}
