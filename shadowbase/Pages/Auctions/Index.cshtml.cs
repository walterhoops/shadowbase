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
    public class IndexModel : PageModel
    {
        private readonly shadowbase.Data.ShadowbaseContext _context;

        public IndexModel(shadowbase.Data.ShadowbaseContext context)
        {
            _context = context;
        }

        public IList<Auction> Auction { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Types { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? AuctionType { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of auction types.
            IQueryable<string> auctionTypeQuery = from at in _context.AuctionTypes
                                            orderby at.AuctionTypeDescription
                                            select at.AuctionTypeDescription;

            var auctions = from a in _context.Auctions
                           select a;

            if (!string.IsNullOrEmpty(AuctionType))
            {
                auctions = auctions.Where(a => a.AuctionType.AuctionTypeDescription == AuctionType);
            }

            if (!string.IsNullOrEmpty(SearchString))
            {
                int auctionID;
                if (int.TryParse(SearchString, out auctionID))
                {
                    auctions = auctions.Where(a => a.AuctionID == auctionID);
                }
            }

            Types = new SelectList(await auctionTypeQuery.Distinct().ToListAsync());
            Auction = await auctions
                .Include(a => a.AuctionStatus)
                .Include(a => a.AuctionType)
                .Include(a => a.Client)
                .Include(a => a.User)
                .ToListAsync();
        }
    }
}
