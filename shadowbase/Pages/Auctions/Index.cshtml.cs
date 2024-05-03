using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using shadowbase.Data;
using shadowbase.Models;
using Microsoft.Extensions.Configuration;

namespace shadowbase.Pages.Auctions
{
    public class IndexModel : PageModel
    {
        private readonly shadowbase.Data.ShadowbaseContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(shadowbase.Data.ShadowbaseContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        // Feb 29 - Added Sort (Lab 7)
        public string AuctionSort { get; set; }
        public string StatusSort { get; set; }
        public string BudgetSort { get; set; }
        public string TypeSort { get; set; }
        public string ExpirySort { get; set; }
        public string CreationSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Auction> Auctions { get; set; }
        // Feb 29 - Added above

        //public IList<Auction> Auction { get; set; } = default!;

        //SearchString bind property
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        //AuctionType select from list
        public SelectList? Types { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? AuctionType { get; set; }

        //AuctionStatus select from list
        public SelectList? Statuses { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? AuctionStatus { get; set; }


        public async Task OnGetAsync(string sortOrder,
        string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            AuctionSort = String.IsNullOrEmpty(sortOrder) ? "auction_desc" : "";
            StatusSort = sortOrder == "Status" ? "status_desc" : "Status";
            BudgetSort = sortOrder == "Budget" ? "budget_desc" : "Budget";
            TypeSort = sortOrder == "Type" ? "type_desc" : "Type";
            ExpirySort = sortOrder == "Expiry" ? "expiry_desc" : "Expiry";
            CreationSort = sortOrder == "Creation" ? "creation_desc" : "Creation";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Auction> auctions = from a in _context.Auctions
                                           select a;

            IQueryable<string> auctionTypeQuery = from at in _context.AuctionTypes
                                                  orderby at.AuctionTypeDescription
                                                  select at.AuctionTypeDescription;

            // Query the database for all auction statuses
            IQueryable<string> auctionStatusQuery = from ast in _context.AuctionStatuses
                                                    orderby ast.AuctionStatusDescription
                                                    select ast.AuctionStatusDescription;

            // Removed Mar 6
            //var auctions = from a in _context.Auctions
            //              select a;

            // Filter by search string = auction ID
            if (!String.IsNullOrEmpty(searchString))
            {
                //int auctionID;
                //if (int.TryParse(SearchString, out auctionID))
                //{
                //    auctions = auctions.Where(a => a.AuctionID == auctionID);
                //}

                auctions = auctions.Where(a => a.AuctionID.ToString().Contains(searchString));

            }
            // Filter by auction type
            if (!string.IsNullOrEmpty(AuctionType))
            {
                auctions = auctions.Where(a => a.AuctionType.AuctionTypeDescription == AuctionType);
            }
            // Filter by auction status
            if (!string.IsNullOrEmpty(AuctionStatus))
            {
                auctions = auctions.Where(b => b.AuctionStatus.AuctionStatusDescription == AuctionStatus);
            }

            // Set the select list dropdowns for auction types and statuses
            Types = new SelectList(await auctionTypeQuery.Distinct().ToListAsync());
            Statuses = new SelectList(await auctionStatusQuery.Distinct().ToListAsync());

            // Feb 29 - Added Sort (Lab 7)
            switch (sortOrder)
            {
                case "auction_desc":
                    auctions = auctions.OrderByDescending(a => a.AuctionID);
                    break;
                case "status_desc":
                    auctions = auctions.OrderByDescending(a => a.AuctionStatus.AuctionStatusDescription);
                    break;
                case "budget_desc":
                    auctions = auctions.OrderByDescending(a => a.HomeBudget);
                    break;
                case "type_desc":
                    auctions = auctions.OrderByDescending(a => a.AuctionType.AuctionTypeDescription);
                    break;
                case "expiry_desc":
                    auctions = auctions.OrderBy(a => a.ExpiryDate);
                    break;
                case "creation_desc":
                    auctions = auctions.OrderByDescending(a => a.CreationDate);
                    break;
                default:
                    auctions = auctions.OrderBy(a => a.AuctionID);
                    break;
            }

            Console.WriteLine(auctions.ToQueryString());

            //Auction = await auctions
            //    .Include(a => a.AuctionStatus)
            //    .Include(a => a.AuctionType)
            //    .Include(a => a.Client)
            //    .Include(a => a.User)
            //    .AsNoTracking()
            //    .ToListAsync();

            var pageSize = Configuration.GetValue("PageSize", 4);
            Auctions = await PaginatedList<Auction>.CreateAsync(
            auctions.Include(a => a.AuctionStatus)
            .Include(a => a.AuctionType)
            //.Include(a => a.Client)
            .Include(a => a.User)
            .AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
