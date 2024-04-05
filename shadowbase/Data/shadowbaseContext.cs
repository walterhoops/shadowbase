using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Models;
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
        public DbSet<Department> Department { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<AdminAssignment> AdminAssignments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
                base.OnModelCreating(modelBuilder);
                // Above added Feb 28, if this breaks anything, remove it? - Walter
                modelBuilder.Entity<Client>().ToTable("Client");
                modelBuilder.Entity<Auction>().ToTable("Auction");
                modelBuilder.Entity<User>().ToTable("User");
                modelBuilder.Entity<AuctionStatus>().ToTable("AuctionStatus");
                modelBuilder.Entity<AuctionType>().ToTable("AuctionType");
                modelBuilder.Entity<Bid>().ToTable("Bid");
                modelBuilder.Entity<UserType>().ToTable("UserType");
                modelBuilder.Entity<Admin>().ToTable("Admin");
                modelBuilder.Entity<Department>().ToTable("Departments");
     
        }
    }
   
}
