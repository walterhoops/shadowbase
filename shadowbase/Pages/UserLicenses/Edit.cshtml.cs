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

namespace shadowbase.Pages.UserLicenses
{
    public class EditModel : PageModel
    {
        private readonly shadowbase.Data.shadowbaseContext _context;

        public EditModel(shadowbase.Data.shadowbaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LicenseData LicenseData { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LicenseData = await _context.LicenseData.FindAsync(id);

            if (LicenseData == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var LicenseDataToUpdate = await _context.LicenseData.FindAsync(id);

            if (LicenseDataToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<LicenseData>(
                LicenseDataToUpdate,
                "student",
                s => s.UserID, s => s.reLicense, s => s.mbLicense, s => s.hiLicense))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool LicenseDataExists(int id)
        {
          return (_context.LicenseData?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
