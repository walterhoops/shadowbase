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

        //SearchString bind property
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        //AuctionType select from list
        public SelectList? Types { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? AuctionType { get; set; }

        //AuctionStatus select from list
        public SelectList? Statuses { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? AuctionStatus { get; set; }


        public async Task OnGetAsync()
        {
            // Use LINQ to get list of auction types.
            // Query the database for all auction types
            IQueryable<string> auctionTypeQuery = from at in _context.AuctionTypes
                                            orderby at.AuctionTypeDescription
                                            select at.AuctionTypeDescription;
            // Query the database for all auction statuses
            IQueryable<string> auctionStatusQuery = from ast in _context.AuctionStatuses
                                            orderby ast.AuctionStatusDescription
                                            select ast.AuctionStatusDescription;
            // Auctions query
            var auctions = from a in _context.Auctions
                           select a;
            // Filter by auction type
            if (!string.IsNullOrEmpty(AuctionType))
            {
                auctions = auctions.Where(a => a.AuctionType.AuctionTypeDescription == AuctionType);
            }
            // Filter by auction status
            if (!string.IsNullOrEmpty(AuctionStatus))
            {
                auctions = auctions.Where(b => b.AuctionStatus.AuctionStatusDescription == AuctionStatus);
            }
            // Filter by search string = auction ID
            if (!string.IsNullOrEmpty(SearchString))
            {
                int auctionID;
                if (int.TryParse(SearchString, out auctionID))
                {
                    auctions = auctions.Where(a => a.AuctionID == auctionID);
                }
            }
            // Set the select list dropdowns for auction types and statuses
            Types = new SelectList(await auctionTypeQuery.Distinct().ToListAsync());
            Statuses = new SelectList(await auctionStatusQuery.Distinct().ToListAsync());
 
            Auction = await auctions
                .Include(a => a.AuctionStatus)
                .Include(a => a.AuctionType)
                .Include(a => a.Client)
                .Include(a => a.User)
                .ToListAsync();
        }
    }
}
