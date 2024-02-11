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
        private readonly shadowbase.Data.shadowbaseContext _context;

        public IndexModel(shadowbase.Data.shadowbaseContext context)
        {
            _context = context;
        }

        public IList<AuctionData> AuctionData { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Status { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? AuctionStatus { get; set; }


        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> statusQuery = from m in _context.AuctionData
                                            orderby m.StatusID
                                            select m.StatusID;

            var auctions = from m in _context.AuctionData
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                auctions = auctions.Where(s => s.StatusID.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(AuctionStatus))
            {
                auctions = auctions.Where(x => x.StatusID == AuctionStatus);
            }
            Status = new SelectList(await statusQuery.Distinct().ToListAsync());
            AuctionData = await auctions.ToListAsync();
        }


    }
}
