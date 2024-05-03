using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using shadowbase.Data;
using shadowbase.Models;
using shadowbase.Models.SchoolViewModels;

namespace shadowbase.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly shadowbase.Data.ShadowbaseContext _context;

        public IndexModel(shadowbase.Data.ShadowbaseContext context)
        {
            _context = context;
        }

        public UserIndexData UserData { get; set; }
        public int UserID { get; set; }
        public int BidID { get; set; }


       // public IList<User> User { get;set; } = default!;

        public async Task OnGetAsync(int? id)
        {//, int? bidID
            UserData = new UserIndexData();
            UserData.Users = await _context.Users.Include(i => i.Bids).ToListAsync();

            
           if (id != null)
            {
                UserID = id.Value;
                User user = UserData.Users
                    .Where(i => i.UserID == id.Value).Single();
                UserData.Bids = user.Bids;
            }
            
        }
    }
}
