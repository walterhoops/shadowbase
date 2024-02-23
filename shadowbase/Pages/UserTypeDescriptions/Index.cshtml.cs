using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using shadowbase.Data;
using shadowbase.Models;

namespace shadowbase.Pages.UserTypeDescriptions
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

        public IList<UserTypes> StudAuctionDataents { get; set; }
        public List<UserTypes> UserTypes { get; private set; }

        public async Task OnGetAsync(string sortOrder)
        {
            // using System;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            IQueryable<UserTypes> Type = from s in _context.UserTypes
                                           select s;

            switch (sortOrder)
            {
                case "type":
                    Type = Type.OrderByDescending(s => s.TypeID);
                    break;
                case "typeDescription":
                    Type = Type.OrderBy(s => s.TypeDescription);
                    break;
                case "typeDescription_desc":
                    Type = Type.OrderByDescending(s => s.TypeDescription);
                    break;
                default:
                    Type = Type.OrderBy(s => s.TypeID);
                    break;
            }

            UserTypes = await Type.AsNoTracking().ToListAsync();
        }
    }
}
