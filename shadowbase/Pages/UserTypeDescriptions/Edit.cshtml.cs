using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using shadowbase.Data;
using shadowbase.Models;

namespace shadowbase.Pages.UserTypeDescriptions
{
    public class EditModel : PageModel
    {
        private readonly shadowbase.Data.shadowbaseContext _context;

        public EditModel(shadowbase.Data.shadowbaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserTypes UserTypes { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserTypes = await _context.UserTypes.FindAsync(id);

            if (UserTypes == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var UserTypesToUpdate = await _context.UserTypes.FindAsync(id);

            if (UserTypesToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<UserTypes>(
                UserTypesToUpdate,
                "userType",
                s => s.TypeID, s => s.TypeDescription))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool UserTypesExists(int id)
        {
          return (_context.UserTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
