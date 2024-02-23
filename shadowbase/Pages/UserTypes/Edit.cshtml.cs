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

namespace shadowbase.Pages.UserTypes
{
    public class EditModel : PageModel
    {
        private readonly shadowbase.Data.ShadowbaseContext _context;

        public EditModel(shadowbase.Data.ShadowbaseContext context)
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

            var usertype =  await _context.UserTypes.FirstOrDefaultAsync(m => m.UserTypeID == id);
            if (usertype == null)
            {
                return NotFound();
            }
            UserType = usertype;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(UserType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTypeExists(UserType.UserTypeID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UserTypeExists(int id)
        {
          return (_context.UserTypes?.Any(e => e.UserTypeID == id)).GetValueOrDefault();
        }
    }
}
