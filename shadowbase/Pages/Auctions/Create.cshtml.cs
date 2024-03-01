using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using shadowbase.Data;
using shadowbase.Models;

namespace shadowbase.Pages.Auctions
{
    public class CreateModel : PageModel
    {
        private readonly shadowbase.Data.ShadowbaseContext _context;

        public CreateModel(shadowbase.Data.ShadowbaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AuctionStatusIDFK"] = new SelectList(_context.AuctionStatuses, "AuctionStatusID", "AuctionStatusDescription");
        ViewData["AuctionTypeIDFK"] = new SelectList(_context.AuctionTypes, "AuctionTypeID", "AuctionTypeDescription");
        ViewData["ClientIDFK"] = new SelectList(_context.Clients, "ClientID", "FirstName");
        ViewData["UserIDFK"] = new SelectList(_context.Users, "UserID", "Username");
            return Page();
        }

        [BindProperty]
        public Auction Auction { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            // Added Feb 29 - See Lab 6 (Overposting) for details

            var emptyAuction = new Auction();

            if (await TryUpdateModelAsync<Auction>(
                emptyAuction,
                "Auction",
                a => a.AuctionTypeIDFK,
                a => a.AuctionStatusIDFK,
                a => a.ClientIDFK,
                a => a.UserIDFK,
                a => a.CreationDate,
                a => a.ExpiryDate,
                a => a.HomeBudget,
                a => a.BidLimit))
            {
                _context.Auctions.Add(emptyAuction);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Removed Feb 29 - See Lab 6 (Overposting) for details

            //if (!ModelState.IsValid || _context.Auctions == null || Auction == null)
            //  {
            //      return Page();
            //  }

            //_context.Auctions.Add(Auction);
            //await _context.SaveChangesAsync();

            return Page();
        }
    }
}
