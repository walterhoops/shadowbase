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
        private readonly shadowbase.Data.shadowbaseContext _context;

        public CreateModel(shadowbase.Data.shadowbaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AuctionData AuctionData { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyAuctionData = new AuctionData();

            if (await TryUpdateModelAsync<AuctionData>(
                emptyAuctionData,
                "Auction",   // Prefix for form value.
                s => s.UserID, s => s.ClientID, s => s.StatusID, s => s.Type, s => s.CreationDate, s => s.ExpiryDate, s => s.HomeBudget, s => s.BidID, s => s.BidLimit))
            {
                _context.AuctionData.Add(emptyAuctionData);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
