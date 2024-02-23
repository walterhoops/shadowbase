using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using shadowbase.Data;
using shadowbase.Models;

namespace shadowbase.Pages.Clients
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
        public ClientData ClientData { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyClientData = new ClientData();

            if (await TryUpdateModelAsync<ClientData>(
                emptyClientData,
                "client",   // Prefix for form value.
                s => s.FirstName, s => s.LastName, s => s.Email, s => s.Phone))
            {
                _context.ClientData.Add(emptyClientData);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
