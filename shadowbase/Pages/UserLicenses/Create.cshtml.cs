using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using shadowbase.Data;
using shadowbase.Models;

namespace shadowbase.Pages.UserLicenses
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
        public LicenseData LicenseData { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyLicenseData = new LicenseData();

            if (await TryUpdateModelAsync<LicenseData>(
                emptyLicenseData,
                "license",   // Prefix for form value.
                s => s.UserID, s => s.reLicense, s => s.mbLicense, s => s.hiLicense))
            {
                _context.LicenseData.Add(emptyLicenseData);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
