﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly shadowbase.Data.ShadowbaseContext _context;

        public DetailsModel(shadowbase.Data.ShadowbaseContext context)
        {
            _context = context;
        }

        // Below underline may be influencing Details.cshtml ability to retrieve
        // and display the [Display(Name = "Account Type")] attribute in the
        // details page.
      public User User { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            //var user = await _context.Users.FirstOrDefaultAsync(m => m.UserID == id);
            
            User = await _context.Users
                .Include(u => u.UserType)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.UserID == id);

            if (User == null)
            {
                return NotFound();
            }

            //else 
            //{
            //    User = user;
            //}

            return Page();
        }
    }
}
