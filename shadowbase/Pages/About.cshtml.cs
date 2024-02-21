
using shadowbase.Models.SchoolViewModels;
using shadowbase.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shadowbase.Models;

namespace shadowbase.Pages
{
    public class AboutModel : PageModel
    {
        private readonly shadowbaseContext _context;

        public AboutModel(shadowbaseContext context)
        {
            _context = context;
        }

        public IList<EnrollmentDateGroup> AuctionBidData { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<EnrollmentDateGroup> data =
                from AuctionBidData in _context.AuctionBidData
                group AuctionBidData by AuctionBidData.BidDate into dateGroup
                select new EnrollmentDateGroup()
                {
                    BidDate = dateGroup.Key,
                    ClientCount = dateGroup.Count()
                };

            AuctionBidData = await data.AsNoTracking().ToListAsync();
        }
    }
}