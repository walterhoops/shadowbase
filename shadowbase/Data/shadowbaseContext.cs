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


        public DbSet<shadowbase.Models.ClientData> ClientData { get; set; }
        public DbSet<shadowbase.Models.AuctionData> AuctionData { get; set; }
        public DbSet<shadowbase.Models.UserData> UserData { get; set; }
        public DbSet<shadowbase.Models.LicenseData> LicenseData { get; set; }
        public DbSet<shadowbase.Models.AuctionBidData> AuctionBidData { get; set; }
        public DbSet<shadowbase.Models.StatusIDs> StatusIDs { get; set; }
        public DbSet<shadowbase.Models.UserTypes> UserTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientData>().ToTable("ClientData");
            modelBuilder.Entity<AuctionData>().ToTable("AuctionData");
            modelBuilder.Entity<UserData>().ToTable("UserData");
            modelBuilder.Entity<LicenseData>().ToTable("LicenseData");
            modelBuilder.Entity<AuctionBidData>().ToTable("AuctionBidData");
            modelBuilder.Entity<StatusIDs>().ToTable("StatusIDs");
            modelBuilder.Entity<UserTypes>().ToTable("UserTypes");
            
        }
    }
   
}
