using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using shadowbase.Models.SchoolViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shadowbase.Models;

namespace shadowbase.Pages
{
    public class AboutModel : PageModel
    {
        private readonly shadowbase.Data.ShadowbaseContext _context;
        
        public AboutModel(shadowbase.Data.ShadowbaseContext context)
        {
            _context = context;
        }

        public IList<EnrollmentDateGroup> Auction { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<EnrollmentDateGroup> data =
                from auction in _context.Auctions
                group auction by auction.CreationDate into dateGroup
                select new EnrollmentDateGroup()
                {
                    CreationDate = dateGroup.Key,
                    AuctionCount = dateGroup.Count()
                };
            Auction = await data.AsNoTracking().ToListAsync();
        }
    }
}
