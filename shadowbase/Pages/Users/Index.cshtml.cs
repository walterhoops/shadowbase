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

namespace shadowbase.Pages.Users
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

        public PaginatedList<UserData> StudAuctionDataents { get; set; }
        public PaginatedList<UserData> UserData { get; private set; }

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

            IQueryable<UserData> user = from s in _context.UserData
                                          select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                user = user.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name":
                    user = user.OrderByDescending(s => s.LastName);
                    break;
                case "Email":
                    user = user.OrderBy(s => s.Email);
                    break;
                case "Email_desc":
                    user = user.OrderByDescending(s => s.Email);
                    break;
                default:
                    user = user.OrderBy(s => s.LastName);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 4);
            UserData = await PaginatedList<UserData>.CreateAsync(
                user.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
