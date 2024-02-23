using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using shadowbase.Data;
using shadowbase.Models;

namespace shadowbase.Pages.UserLicenses
{
    public class IndexModel : PageModel
    {
        private readonly shadowbase.Data.shadowbaseContext _context;

        public IndexModel(shadowbase.Data.shadowbaseContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<LicenseData> StudAuctionDataents { get; set; }
        public List<LicenseData> LicenseData { get; private set; }

        public async Task OnGetAsync(string sortOrder)
        {
            // using System;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            IQueryable<LicenseData> license = from s in _context.LicenseData
                                             select s;

            switch (sortOrder)
            {
                case "user":
                    license = license.OrderByDescending(s => s.UserID);
                    break;
                
                default:
                    license = license.OrderBy(s => s.UserID);
                    break;
            }

            LicenseData = await license.AsNoTracking().ToListAsync();
        }
    }
}
