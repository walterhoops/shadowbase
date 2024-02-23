﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using shadowbase.Data;
using shadowbase.Models;

namespace shadowbase.Pages.UserTypeDescriptions
{
    public class DetailsModel : PageModel
    {
        private readonly shadowbase.Data.shadowbaseContext _context;

        public DetailsModel(shadowbase.Data.shadowbaseContext context)
        {
            _context = context;
        }

      public UserTypes UserTypes { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UserTypes == null)
            {
                return NotFound();
            }

            UserTypes = await _context.UserTypes
        .Include(u => u.UserData)
        
        .AsNoTracking()
        .FirstOrDefaultAsync(m => m.Id == id);
            if (UserTypes == null)
            {
                return NotFound();
            }
            
            return Page();
        }
    }
}
