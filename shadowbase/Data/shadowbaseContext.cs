using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using shadowbase.Models;

// Creation of Auctions might be failing because of shadowbasecontext and applicationdbcontext 

namespace shadowbase.Data
{
    public class ShadowbaseContext : DbContext
    {
        public ShadowbaseContext (DbContextOptions<ShadowbaseContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<AuctionStatus> AuctionStatuses { get; set; }
        public DbSet<AuctionType> AuctionTypes { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
            // Above added Feb 28, if this breaks anything, remove it? - Walter
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Auction>().ToTable("Auction");
            modelBuilder.Entity<AuctionStatus>().ToTable("AuctionStatus");
            modelBuilder.Entity<AuctionType>().ToTable("AuctionType");
            modelBuilder.Entity<Bid>().ToTable("Bid");
            modelBuilder.Entity<UserType>().ToTable("UserType");
            
            //modelBuilder.Entity<User>().ToTable("User");
            
            // Test Apr 12
            modelBuilder.Entity<User>().ToTable(nameof(User))
                .HasMany(c => c.Auctions);


        }
    }
   
}
