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
    public class DeleteModel : PageModel
    {
        private readonly shadowbase.Data.ShadowbaseContext _context;

        public DeleteModel(shadowbase.Data.ShadowbaseContext context)
        {
            _context = context;
        }

        [BindProperty]
      public UserType UserType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UserTypes == null)
            {
                return NotFound();
            }

            var usertype = await _context.UserTypes.FirstOrDefaultAsync(m => m.UserTypeID == id);

            if (usertype == null)
            {
                return NotFound();
            }
            else 
            {
                UserType = usertype;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.UserTypes == null)
            {
                return NotFound();
            }
            var usertype = await _context.UserTypes.FindAsync(id);

            if (usertype != null)
            {
                UserType = usertype;
                _context.UserTypes.Remove(UserType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
