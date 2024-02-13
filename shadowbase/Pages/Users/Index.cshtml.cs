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
    public class IndexModel : PageModel
    {
        private readonly shadowbase.Data.shadowbaseContext _context;

        public IndexModel(shadowbase.Data.shadowbaseContext context)
        {
            _context = context;
        }

        public IList<UserData> UserData { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.UserData != null)
            {
                UserData = await _context.UserData.ToListAsync();
            }
        }
    }
}
