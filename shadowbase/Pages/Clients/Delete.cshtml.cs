using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using shadowbase.Data;
using shadowbase.Models;

namespace shadowbase.Pages.Clients
{
    public class DeleteModel : PageModel
    {
        private readonly shadowbase.Data.shadowbaseContext _context;

        public DeleteModel(shadowbase.Data.shadowbaseContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ClientData ClientData { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ClientData == null)
            {
                return NotFound();
            }

            var clientdata = await _context.ClientData.FirstOrDefaultAsync(m => m.Id == id);

            if (clientdata == null)
            {
                return NotFound();
            }
            else 
            {
                ClientData = clientdata;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ClientData == null)
            {
                return NotFound();
            }
            var clientdata = await _context.ClientData.FindAsync(id);

            if (clientdata != null)
            {
                ClientData = clientdata;
                _context.ClientData.Remove(ClientData);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
