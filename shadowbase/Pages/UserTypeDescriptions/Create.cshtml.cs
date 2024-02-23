using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using shadowbase.Data;
using shadowbase.Models;

namespace shadowbase.Pages.UserTypeDescriptions
{
    public class CreateModel : PageModel
    {
        private readonly shadowbase.Data.shadowbaseContext _context;

        public CreateModel(shadowbase.Data.shadowbaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public UserTypes UserTypes { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyUserTypes = new UserTypes();

            if (await TryUpdateModelAsync<UserTypes>(
                emptyUserTypes,
                "user",   // Prefix for form value.
                s => s.TypeID, s => s.TypeDescription))
            {
                _context.UserTypes.Add(emptyUserTypes);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
