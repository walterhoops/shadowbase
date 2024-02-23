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

namespace shadowbase.Pages.Clients
{
    public class EditModel : PageModel
    {
        private readonly shadowbase.Data.shadowbaseContext _context;

        public EditModel(shadowbase.Data.shadowbaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ClientData ClientData { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClientData = await _context.ClientData.FindAsync(id);

            if (ClientData == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var ClientDataToUpdate = await _context.ClientData.FindAsync(id);

            if (ClientDataToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<ClientData>(
                ClientDataToUpdate,
                "client",
                s => s.FirstName, s => s.LastName, s => s.Email, s => s.Phone))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool ClientDataExists(int id)
        {
          return (_context.ClientData?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
