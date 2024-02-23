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

namespace shadowbase.Pages.AuctionTypes
{
    public class EditModel : PageModel
    {
        private readonly shadowbase.Data.ShadowbaseContext _context;

        public EditModel(shadowbase.Data.ShadowbaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AuctionType AuctionType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AuctionTypes == null)
            {
                return NotFound();
            }

            var auctiontype =  await _context.AuctionTypes.FirstOrDefaultAsync(m => m.AuctionTypeID == id);
            if (auctiontype == null)
            {
                return NotFound();
            }
            AuctionType = auctiontype;
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

            _context.Attach(AuctionType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuctionTypeExists(AuctionType.AuctionTypeID))
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

        private bool AuctionTypeExists(int id)
        {
          return (_context.AuctionTypes?.Any(e => e.AuctionTypeID == id)).GetValueOrDefault();
        }
    }
}
