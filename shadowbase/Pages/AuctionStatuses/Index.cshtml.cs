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

namespace shadowbase.Pages.AuctionStatuses
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

        public PaginatedList<StatusIDs> StudAuctionDataents { get; set; }
        public PaginatedList<StatusIDs> StatusIDs { get; private set; }
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

            IQueryable<StatusIDs> status = from s in _context.StatusIDs
                                            select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                status = status.Where(s => s.StatusDescription.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "status":
                    status = status.OrderByDescending(s => s.StatusID);
                    break;
                case "Description":
                    status = status.OrderBy(s => s.StatusDescription);
                    break;
                case "Description_desc":
                    status = status.OrderByDescending(s => s.StatusDescription);
                    break;
                default:
                    status = status.OrderBy(s => s.StatusID);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 4);
            StatusIDs = await PaginatedList<StatusIDs>.CreateAsync(
                status.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
