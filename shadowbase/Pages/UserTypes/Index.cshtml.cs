using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using shadowbase.Data;
using shadowbase.Models;

namespace shadowbase.Pages.UserTypes
{
    public class IndexModel : PageModel
    {
        private readonly shadowbase.Data.ShadowbaseContext _context;

        public IndexModel(shadowbase.Data.ShadowbaseContext context)
        {
            _context = context;
        }

        public IList<UserType> UserType { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.UserTypes != null)
            {
                UserType = await _context.UserTypes.ToListAsync();
            }
        }
    }
}
