using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using shadowbase.Data;
using shadowbase.Models;

namespace shadowbase.Pages.Auctions
{
    public class DeleteModel : PageModel
    {
        private readonly shadowbase.Data.shadowbaseContext _context;

        public DeleteModel(shadowbase.Data.shadowbaseContext context)
        {
            _context = context;
        }

        [BindProperty]
      public AuctionData AuctionData { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AuctionData == null)
            {
                return NotFound();
            }

            var auctiondata = await _context.AuctionData.FirstOrDefaultAsync(m => m.Id == id);

            if (auctiondata == null)
            {
                return NotFound();
            }
            else 
            {
                AuctionData = auctiondata;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.AuctionData == null)
            {
                return NotFound();
            }
            var auctiondata = await _context.AuctionData.FindAsync(id);

            if (auctiondata != null)
            {
                AuctionData = auctiondata;
                _context.AuctionData.Remove(AuctionData);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
