using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using shadowbase.Data;
using shadowbase.Models;

namespace shadowbase.Pages.Auctions
{
    public class IndexModel : PageModel
    {
        private readonly shadowbase.Data.shadowbaseContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(shadowbase.Data.shadowbaseContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<AuctionData> StudAuctionDataents { get; set; }
        public PaginatedList<AuctionData> AuctionData { get; private set; }
        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
           

            CurrentFilter = searchString;

            IQueryable<AuctionData> auction = from s in _context.AuctionData
                                                 select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                auction = auction.Where(s => s.Type.Contains(searchString)
                                       || s.StatusID.Contains(searchString));
            }


            switch (sortOrder)
            {
                case "type":
                    auction = auction.OrderByDescending(s => s.Type);
                    break;
                case "Date":
                    auction = auction.OrderBy(s => s.CreationDate);
                    break;
                case "date_desc":
                    auction = auction.OrderByDescending(s => s.CreationDate);
                    break;
                default:
                    auction = auction.OrderBy(s => s.Type);
                    break;
            }

                var pageSize = Configuration.GetValue("PageSize", 4);
                AuctionData = await PaginatedList<AuctionData>.CreateAsync(
                    auction.AsNoTracking(), pageIndex ?? 1, pageSize);
            }
    }
}
