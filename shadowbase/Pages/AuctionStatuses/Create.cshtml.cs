using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using shadowbase.Data;
using shadowbase.Models;

namespace shadowbase.Pages.AuctionStatuses
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
        public StatusIDs StatusIDs { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyStatusIDs = new StatusIDs();

            if (await TryUpdateModelAsync<StatusIDs>(
                emptyStatusIDs,
                "status",   // Prefix for form value.
                s => s.StatusID, s => s.StatusDescription))
            {
                _context.StatusIDs.Add(emptyStatusIDs);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
