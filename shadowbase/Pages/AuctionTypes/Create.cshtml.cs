using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using shadowbase.Data;
using shadowbase.Models;

namespace shadowbase.Pages.AuctionTypes
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
            return Page();
        }

        [BindProperty]
        public AuctionType AuctionType { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.AuctionTypes == null || AuctionType == null)
            {
                return Page();
            }

            _context.AuctionTypes.Add(AuctionType);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
