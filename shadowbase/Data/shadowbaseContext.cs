using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using shadowbase.Models;

namespace shadowbase.Data
{
    public class shadowbaseContext : DbContext
    {
        public shadowbaseContext (DbContextOptions<shadowbaseContext> options)
            : base(options)
        {
        }

        public DbSet<shadowbase.Models.ClientData> ClientData { get; set; } = default!;

        public DbSet<shadowbase.Models.AuctionData> AuctionData { get; set; } = default!;
    }
}
