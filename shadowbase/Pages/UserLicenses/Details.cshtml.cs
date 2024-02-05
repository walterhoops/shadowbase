using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using shadowbase.Data;
using shadowbase.Models;

namespace shadowbase.Pages.UserLicenses
{
    public class DetailsModel : PageModel
    {
        private readonly shadowbase.Data.shadowbaseContext _context;

        public DetailsModel(shadowbase.Data.shadowbaseContext context)
        {
            _context = context;
        }

      public LicenseData LicenseData { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.LicenseData == null)
            {
                return NotFound();
            }

            var licensedata = await _context.LicenseData.FirstOrDefaultAsync(m => m.Id == id);
            if (licensedata == null)
            {
                return NotFound();
            }
            else 
            {
                LicenseData = licensedata;
            }
            return Page();
        }
    }
}
