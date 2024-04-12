using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using shadowbase.Models;
using System;
using System.Linq;
using System.Reflection.Metadata;

namespace shadowbase.Data
{
    public static class SeedData
    {
        public static void Initialize(ShadowbaseContext context)
        {
            if (context == null)
            {
                Console.WriteLine("Database context is null. Seed data initialization aborted.");
                return;
            }

            // Ensure the database is created
            context.Database.EnsureCreated();

            // Seed data for UserType table
            SeedUserType(context);

            // Seed data for AuctionType table
            SeedAuctionType(context);

            // Seed data for AuctionStatus table
            SeedAuctionStatus(context);

            // Seed data for Client table
            SeedClientData(context);

            // Seed data for User table
            SeedUserData(context);

            // Seed data for Auction table
            SeedAuctionData(context);

            // Seed data for Bid table
            SeedBidData(context);
            

            // Save changes to the database
            context.SaveChanges();

        }

        private static void SeedUserType(ShadowbaseContext context)
        {
            if (context.UserTypes.Any())
            {
                return;   // DB has been seeded
            }

            context.UserTypes.AddRange(
                    new UserType
                    {
                        UserTypeID = 0,
                        UserTypeDescription = "Real Estate"
                    },
                    new UserType
                    {
                        UserTypeID = 1,
                        UserTypeDescription = "Mortgage"
                    },
                    new UserType
                    {
                        UserTypeID = 2,
                        UserTypeDescription = "Home Insurance"
                    }
                );

            // Save changes to the database
            context.SaveChanges();
        }

        private static void SeedAuctionType(ShadowbaseContext context)
        {
            if (context.AuctionTypes.Any())
            {
                return;   // DB has been seeded
            }

            context.AuctionTypes.AddRange(
                new AuctionType
                {
                    AuctionTypeID = 0,
                    AuctionTypeDescription = "Real Estate"
                },
                new AuctionType
                {
                    AuctionTypeID = 1,
                    AuctionTypeDescription = "Mortgage"
                },
                new AuctionType
                {
                    AuctionTypeID = 2,
                    AuctionTypeDescription = "Home Insurance"
                }
            );

            // Save changes to the database
            context.SaveChanges();
        }

        private static void SeedAuctionStatus(ShadowbaseContext context)
        {
            if (context.AuctionStatuses.Any())
            {
                return;   // DB has been seeded
            }

            context.AuctionStatuses.AddRange(
                new AuctionStatus
                {
                    AuctionStatusID = 0,
                    AuctionStatusDescription = "Closed"
                },
                new AuctionStatus
                {
                    AuctionStatusID = 1,
                    AuctionStatusDescription = "Open"
                },
                new AuctionStatus
                {
                    AuctionStatusID = 2,
                    AuctionStatusDescription = "Pending"
                }
            );

            // Save changes to the database
            context.SaveChanges();
        }

        public static void SeedClientData(ShadowbaseContext context)
        {
            if (context.Clients.Any())
            {
                return;   // DB has been seeded
            }

            context.Clients.AddRange(
                new Client
                {
                    FirstName = "Revina",
                    LastName = "Grewal",
                    Email = "R.Grewal@my.bcit.ca",
                    Phone = "1234560000"
                },
                new Client
                {
                    FirstName = "Walter",
                    LastName = "Yeung",
                    Email = "W.Yeung@my.bcit.ca",
                    Phone = "1234560001"
                },
                new Client
                {
                    FirstName = "Enoch",
                    LastName = "Yeung",
                    Email = "E.Yeung@my.bcit.ca",
                    Phone = "1234560002"
                },
                new Client
                {
                    FirstName = "Thanya",
                    LastName = "Tang",
                    Email = "T.Thanya@my.bcit.ca",
                    Phone = "1234560003"
                },
                new Client
                {
                    FirstName = "Jacky",
                    LastName = "Tang",
                    Email = "j.Thanya@my.bcit.ca",
                    Phone = "1234560004"
                },
                new Client
                {
                    FirstName = "Benny",
                    LastName = "Tang",
                    Email = "B.Thanya@my.bcit.ca",
                    Phone = "1234560005"
                }
            );

            // Save changes to the database
            context.SaveChanges();
        }

        public static void SeedUserData(ShadowbaseContext context)
        {
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            context.Users.AddRange(
                new User
                {
                    UserTypeIDFK = 1, // Mortgage
                    Username = "JohnMortgage",
                    FirstName = "John",
                    LastName = "Mortgage",
                    Email = "john.mortgage@mortgage.ca",
                    Password = "password",
                    DOB = DateTime.Parse("1998-03-18"),
                    Phone = "1234567890",
                    Address = "1234 Main St",
                    City = "Vancouver",
                    PostalCode = "V5I 1P9",
                    Country = "Canada",
                    Company = "Awesome Mortgage Co.",
                    PayPalEmail = "john.mortgage@mortgage.ca",
                    LicenseID = "123456",
                },
                new User
                {
                    UserTypeIDFK = 0, // Realtor
                    Username = "TomRealtor",
                    FirstName = "Tom",
                    LastName = "Realtor",
                    Email = "tom.realtor@realtor.ca",
                    Password = "password",
                    DOB = DateTime.Parse("1990-05-08"),
                    Phone = "1038402482",
                    Address = "2718 Granville St",
                    City = "Vancouver",
                    PostalCode = "V8K 2G5",
                    Country = "Canada",
                    Company = "Great Real Estate Co.",
                    PayPalEmail = "tom.realtor@realtor.ca",
                    LicenseID = "234567",
                },
                new User
                {
                    UserTypeIDFK = 2, // Home Insurance
                    Username = "SallyInsurance",
                    FirstName = "Sally",
                    LastName = "Insurance",
                    Email = "sally.insurance@insurance.ca",
                    Password = "password",
                    DOB = DateTime.Parse("1995-12-21"),
                    Phone = "3845038284",
                    Address = "3945 Oak St",
                    City = "Vancouver",
                    PostalCode = "V2T 8G2",
                    Country = "Canada",
                    Company = "Excellent Insurance Co.",
                    PayPalEmail = "sally.insurance@insurance.ca",
                    LicenseID = "345678",
                },
                new User
                {
                    UserTypeIDFK = 0, //realtor
                    Username = "BOBsmith",
                    FirstName = "Bob",
                    LastName = "Smith",
                    Email = "bob.realtor@ayd.ca",
                    Password = "password",
                    DOB = DateTime.Parse("1995-12-21"),
                    Phone = "3895023284",
                    Address = "4028 Oak Ave",
                    City = "Vancouver",
                    PostalCode = "V2T 8G2",
                    Country = "Canada",
                    Company = "Excellent Realtor Co.",
                    PayPalEmail = "bob.realtor@ayd.ca",
                    LicenseID = "341868",
                },
                new User
                {
                    UserTypeIDFK = 1, //mortgage
                    Username = "kimtam",
                    FirstName = "Kim",
                    LastName = "Abercrombie",
                    Email = "kim.abercrombie@insurance.ca",
                    Password = "password",
                    DOB = DateTime.Parse("1995-12-21"),
                    Phone = "3895038284",
                    Address = "4028 Oak St",
                    City = "Vancouver",
                    PostalCode = "V2T 8G2",
                    Country = "Canada",
                    Company = "Excellent Insurance Co.",
                    PayPalEmail = "kim.abercrombie@insurance.ca",
                    LicenseID = "341358",
                },
                new User
                {
                    UserTypeIDFK = 1, //mortgage
                    Username = "Timtam",
                    FirstName = "Tim",
                    LastName = "Tam",
                    Email = "kim.tam@mortgage.ca",
                    Password = "password",
                    DOB = DateTime.Parse("1995-12-21"),
                    Phone = "3895038284",
                    Address = "4028 Knight St",
                    City = "Vancouver",
                    PostalCode = "V2T 8G2",
                    Country = "Canada",
                    Company = "Excellent Mortgage Co.",
                    PayPalEmail = "kim.tam@mortgage.ca",
                    LicenseID = "305358",
                }

            );

            // Save changes to the database
            context.SaveChanges();
        }

        private static void SeedAuctionData(ShadowbaseContext context)
        {
            if (context.Auctions.Any())
            {
                return;   // DB has been seeded
            }

            context.Auctions.AddRange(
                new Auction
                {
                    UserIDFK = 1, // JohnMortgage
                    ClientIDFK = 1, // Revina
                    AuctionStatusIDFK = 0, // Closed
                    AuctionTypeIDFK = 0, // Real Estate
                    CreationDate = DateTime.Parse("2023-12-01"),
                    ExpiryDate = DateTime.Parse("2023-12-01").AddMonths(1),
                    //HighestBidIDFK = 0,
                    HomeBudget = 750000,
                    BidLimit = 0.10m // Adjusted to decimal type
                },
                new Auction
                {
                    UserIDFK = 1, // JohnMortgage
                    ClientIDFK = 2, // Walter
                    AuctionTypeIDFK = 0, // Real Estate
                    AuctionStatusIDFK = 1, // Open
                    CreationDate = DateTime.Today,
                    ExpiryDate = DateTime.Today.AddMonths(1),
                    //HighestBidIDFK = 1,
                    HomeBudget = 900000,
                    BidLimit = 0.10m // Adjusted to decimal type
                },
                new Auction
                {
                    UserIDFK = 2, // TomRealtor
                    ClientIDFK = 3, // Enoch
                    AuctionTypeIDFK = 2, // Home Insurance
                    AuctionStatusIDFK = 2, // Pending
                    CreationDate = DateTime.Today.AddMonths(-1),
                    ExpiryDate = DateTime.Today,
                    //HighestBidIDFK = 2,
                    HomeBudget = 1000000,
                    BidLimit = 0.70m // Adjusted to decimal type
                }
            );

            // Save changes to the database
            context.SaveChanges();
        }

        private static void SeedBidData(ShadowbaseContext context)
        {
            if (context.Bids.Any())
            {
                return;   // DB has been seeded
            }

            context.Bids.AddRange(
                new Bid
                {
                    UserIDFK = 2, // TomRealtor
                    AuctionIDFK = 1,
                    BidAmount = 0.10m,
                    BidDate = DateTime.Parse("2023-12-15")
                },
                new Bid
                {
                    UserIDFK = 2, // TomRealtor
                    AuctionIDFK = 2,
                    BidAmount = 0.08m,
                    BidDate = DateTime.Today
                },
                new Bid
                {
                    UserIDFK = 3, // SallyInsurance
                    AuctionIDFK = 3,
                    BidAmount = 0.09m,
                    BidDate = DateTime.Today
                }
            );

            // Save changes to the database
            context.SaveChanges();
        }
        
        
    }
}


