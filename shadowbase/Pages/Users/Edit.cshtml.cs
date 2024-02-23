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

namespace shadowbase.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly shadowbase.Data.shadowbaseContext _context;

        public EditModel(shadowbase.Data.shadowbaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserData UserData { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserData = await _context.UserData.FindAsync(id);

            if (UserData == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var UserDataToUpdate = await _context.UserData.FindAsync(id);

            if (UserDataToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<UserData>(
                UserDataToUpdate,
                "user",
                s => s.TypeID, s => s.Username, s => s.Password, s => s.FirstName, s => s.LastName, s => s.DOB, s => s.Phone, s => s.Email, s => s.Address, s => s.City, s => s.PostalCode, s => s.Country, s => s.Company, s => s.PayPalEmail))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool UserDataExists(int id)
        {
          return (_context.UserData?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
