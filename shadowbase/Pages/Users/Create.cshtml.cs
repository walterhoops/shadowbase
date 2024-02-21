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
        public UserData UserData { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyUserData = new UserData();

            if (await TryUpdateModelAsync<UserData>(
                emptyUserData,
                "user",   // Prefix for form value.
                s => s.TypeID, s => s.Username, s => s.Password, s => s.FirstName, s => s.LastName, s => s.DOB, s => s.Phone, s => s.Email, s => s.Address, s => s.City, s => s.PostalCode, s => s.Country, s => s.Company, s => s.PayPalEmail))
            {
                _context.UserData.Add(emptyUserData);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
