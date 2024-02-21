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

namespace shadowbase.Pages.Clients
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

        public PaginatedList<ClientData> StudAuctionDataents { get; set; }
        public PaginatedList<ClientData> ClientData { get; private set; }

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

            IQueryable<ClientData> client = from s in _context.ClientData
                                            select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                client = client.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name":
                    client = client.OrderByDescending(s => s.LastName);
                    break;
                case "Email":
                    client = client.OrderBy(s => s.Email);
                    break;
                case "Email_desc":
                    client = client.OrderByDescending(s => s.Email);
                    break;
                default:
                    client = client.OrderBy(s => s.LastName);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 4);
            ClientData = await PaginatedList<ClientData>.CreateAsync(
                client.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
