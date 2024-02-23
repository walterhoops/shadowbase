using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using shadowbase.Data;
using shadowbase.Models;

namespace shadowbase.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly shadowbase.Data.shadowbaseContext _context;

        public DetailsModel(shadowbase.Data.shadowbaseContext context)
        {
            _context = context;
        }

      public UserData UserData { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UserData == null)
            {
                return NotFound();
            }

            UserData = await _context.UserData
        .Include(s => s.AuctionData)
        .ThenInclude(a => a.AuctionBidData)
        .Include(u => u.UserTypes)
        .Include(u => u.LicenseData)
        .AsNoTracking()
        .FirstOrDefaultAsync(m => m.Id == id);
            if (UserData == null)
            {
                return NotFound();
            }
            
            return Page();
        }
    }
}
