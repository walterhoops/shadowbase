using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using shadowbase.Data;
using shadowbase.Models;

namespace shadowbase.Pages.Auctions
{
    public class DeleteModel : PageModel
    {
        private readonly shadowbase.Data.ShadowbaseContext _context;

        // Feb 29 - Added logger (Lab 6)
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(shadowbase.Data.ShadowbaseContext context,
            ILogger<DeleteModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Auction Auction { get; set; } /*= default!;*/
        public string ErrorMessage { get; set; }

        //public async Task<IActionResult> OnGetAsync(int? id)

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null /*|| _context.Auctions == null*/)
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

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = String.Format("Delete {0} failed. Try again", id);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null /*|| _context.Auctions == null*/)
            {
                return NotFound();
            }
            var auction = await _context.Auctions.FindAsync(id);

            if (auction == null)
            {
                return NotFound();
            }

            try
            {
                _context.Auctions.Remove(auction);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, ErrorMessage);

                return RedirectToAction("./Delete",
                    new { id, saveChangesError = true });
            }


            // Feb 29 - Removed below (Lab 6)

            //if (auction != null)
            //{
            //    Auction = auction;
            //    _context.Auctions.Remove(Auction);
            //    await _context.SaveChangesAsync();
            //}

            //return RedirectToPage("./Index");
        }
    }
}
