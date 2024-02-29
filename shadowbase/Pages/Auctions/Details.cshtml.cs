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
    public class DetailsModel : PageModel
    {
        private readonly shadowbase.Data.ShadowbaseContext _context;

        public DetailsModel(shadowbase.Data.ShadowbaseContext context)
        {
            _context = context;
        }

      public Auction Auction { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Auctions == null)
            {
                return NotFound();
            }


            //var auction = await _context.Auctions.FirstOrDefaultAsync(m => m.AuctionID == id);

            Auction = await _context.Auctions
                .Include(a => a.AuctionStatus)
                .Include(a => a.AuctionType)
                .Include(a => a.Client)
                .Include(a => a.User)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.AuctionID == id);


            if (Auction == null)
            {
                return NotFound();
            }

            //else 
            //{
            //    Auction = auction;
            //}
            return Page();
        }
    }
}
