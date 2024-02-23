using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using shadowbase.Data;
using shadowbase.Models;

namespace shadowbase.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly shadowbase.Data.ShadowbaseContext _context;

        public CreateModel(shadowbase.Data.ShadowbaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["UserTypeIDFK"] = new SelectList(_context.UserTypes, "UserTypeID", "UserTypeDescription");
            return Page();
        }

        [BindProperty]
        public User User { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Users == null || User == null)
            {
                return Page();
            }

            _context.Users.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
