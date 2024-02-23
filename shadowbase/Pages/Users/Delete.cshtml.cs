using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using shadowbase.Data;
using shadowbase.Models;

namespace shadowbase.Pages.Users
{
    public class DeleteModel : PageModel
    {
        private readonly shadowbaseContext _context;
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(shadowbaseContext context,
                           ILogger<DeleteModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public UserData UserData { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserData = await _context.UserData
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (UserData == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = String.Format("Delete {ID} failed. Try again", id);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var UserData = await _context.UserData.FindAsync(id);

            if (UserData == null)
            {
                return NotFound();
            }

            try
            {
                _context.UserData.Remove(UserData);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, ErrorMessage);

                return RedirectToAction("./Delete",
                                     new { id, saveChangesError = true });
            }
        }
    }
}