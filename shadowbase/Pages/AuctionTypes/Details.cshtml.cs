using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using shadowbase.Data;
using shadowbase.Models;

namespace shadowbase.Pages.AuctionTypes
{
    public class DetailsModel : PageModel
    {
        private readonly shadowbase.Data.ShadowbaseContext _context;

        public DetailsModel(shadowbase.Data.ShadowbaseContext context)
        {
            _context = context;
        }

      public AuctionType AuctionType { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AuctionTypes == null)
            {
                return NotFound();
            }

            var auctiontype = await _context.AuctionTypes.FirstOrDefaultAsync(m => m.AuctionTypeID == id);
            if (auctiontype == null)
            {
                return NotFound();
            }
            else 
            {
                AuctionType = auctiontype;
            }
            return Page();
        }
    }
}
