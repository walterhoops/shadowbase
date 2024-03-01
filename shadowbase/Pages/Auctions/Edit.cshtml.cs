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

namespace shadowbase.Pages.Auctions
{
    public class EditModel : PageModel
    {
        private readonly shadowbase.Data.ShadowbaseContext _context;

        public EditModel(shadowbase.Data.ShadowbaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Auction Auction { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null /*|| _context.Auctions == null*/)
            {
                return NotFound();
            }

            //var auction =  await _context.Auctions.FirstOrDefaultAsync(m => m.AuctionID == id);

            Auction = await _context.Auctions.FindAsync(id);

            if (Auction == null)
            {
                return NotFound();
            }


           Auction = Auction;
           ViewData["AuctionStatusIDFK"] = new SelectList(_context.AuctionStatuses, "AuctionStatusID", "AuctionStatusDescription");
           ViewData["AuctionTypeIDFK"] = new SelectList(_context.AuctionTypes, "AuctionTypeID", "AuctionTypeDescription");
           ViewData["ClientIDFK"] = new SelectList(_context.Clients, "ClientID", "Email");
           ViewData["UserIDFK"] = new SelectList(_context.Users, "UserID", "Username");
           
           return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            // Below removed Feb 29 - See Lab 6 (Overposting) for details

            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //_context.Attach(Auction).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!AuctionExists(Auction.AuctionID))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return RedirectToPage("./Index");

            // Below added Feb 29 - See Lab 6 (Overposting) for details

            var auctionToUpdate = await _context.Auctions.FindAsync(id);

            if(auctionToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Auction>(
                auctionToUpdate,
                "auction",
                a => a.AuctionTypeIDFK,
                a => a.AuctionStatusIDFK,
                a => a.UserIDFK,
                a => a.ClientIDFK,
                a => a.CreationDate,
                a => a.ExpiryDate,
                a => a.HomeBudget,
                a => a.BidLimit))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool AuctionExists(int id)
        {
          return (_context.Auctions?.Any(e => e.AuctionID == id)).GetValueOrDefault();
        }
    }
}
