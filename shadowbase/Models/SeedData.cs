﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using shadowbase.Data;
using System;

namespace shadowbase.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Data.shadowbaseContext(
                  serviceProvider.GetRequiredService<
                      DbContextOptions<Data.shadowbaseContext>>()))

            {
                if (context == null)
                {
                    throw new ArgumentNullException("Null shadowbaseContext");
                }
                // Ensure the database is created
                context.Database.EnsureCreated();

                // Seed data for ClientData table
                SeedClientData(context);

                // Seed data for AuctionData table
                SeedAuctionData(context);

                context.SaveChanges();
            }
        }

        private static void SeedClientData(shadowbaseContext context)
        {
            if (context.ClientData.Any())
            {
                return;   // DB has been seeded
            }

            context.ClientData.AddRange(
                    new ClientData
                    {
                        FirstName = "Revina",
                        LastName = "Grewal",
                        Email = "R.Grewal@my.bcit.ca",
                        Phone = "1234564321"
                    },

                    new ClientData
                    {
                        FirstName = "Walter",
                        LastName = "Yeung",
                        Email = "W.Yeung@my.bcit.ca",
                        Phone = "1234561234"
                    },
                    new ClientData
                    {
                        FirstName = "Enouch",
                        LastName = "Yeung",
                        Email = "E.Yeung@my.bcit.ca",
                        Phone = "1234561230"
                    },
                    new ClientData
                    {
                        FirstName = "Thanya",
                        LastName = "Tang",
                        Email = "T.Thanya@my.bcit.ca",
                        Phone = "1234561235"
                    }
                );
       
        }
        private static void SeedAuctionData(shadowbaseContext context)
        {
            if (context.AuctionData.Any())
            {
                return;   // DB has been seeded
            }

            context.AuctionData.AddRange(
                    new AuctionData
                    {
                        UserID = 1,
                        ClientID =1,
                        Type = "Home",
                        StatusID = "Live",
                        CreationDate = DateTime.Today,
                        ExpiryDate = DateTime.Today.AddMonths(1),
                        HomeBudget = 30000000,
                        BidID = 1,
                        BidLimit = 10
                    },
                    new AuctionData
                    {
                        UserID = 2,
                        ClientID = 2,
                        Type = "Home",
                        StatusID = "Won",
                        CreationDate = DateTime.Today,
                        ExpiryDate = DateTime.Today.AddMonths(1),
                        HomeBudget = 5000000,
                        BidID = 2,
                        BidLimit = 10
                    },
                    new AuctionData
                    {
                        UserID = 1,
                        ClientID = 1,
                        Type = "Apt",
                        StatusID = "Closed",
                        CreationDate = DateTime.Today,
                        ExpiryDate = DateTime.Today.AddMonths(1),
                        HomeBudget = 3000000,
                        BidID = 3,
                        BidLimit = 5
                    }
                );

        }

    }

}
