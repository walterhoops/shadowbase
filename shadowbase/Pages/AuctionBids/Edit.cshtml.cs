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

namespace shadowbase.Pages.AuctionBids
{
    public class EditModel : PageModel
    {
        private readonly shadowbase.Data.shadowbaseContext _context;

        public EditModel(shadowbase.Data.shadowbaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AuctionBidData AuctionBidData { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AuctionBidData == null)
            {
                return NotFound();
            }

            var auctionbiddata =  await _context.AuctionBidData.FirstOrDefaultAsync(m => m.Id == id);
            if (auctionbiddata == null)
            {
                return NotFound();
            }
            AuctionBidData = auctionbiddata;
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

            _context.Attach(AuctionBidData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuctionBidDataExists(AuctionBidData.Id))
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

        private bool AuctionBidDataExists(int id)
        {
          return (_context.AuctionBidData?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
