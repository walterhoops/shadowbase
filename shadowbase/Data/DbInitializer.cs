
using System.Diagnostics;
using shadowbase.Models;
namespace shadowbase.Data
{
    public static class DbInitializer
    {
        public static void Initialize(shadowbaseContext context)
        {
            // Look for any students.
            if (context.AuctionBidData.Any())
            {
                return;   // DB has been seeded
            }

            var auctionsbid = new AuctionBidData[]
            {
                new AuctionBidData{UserID=123452,BidAmount=13245678,BidDate=DateTime.Parse("2019-09-01")},
                
            };

            context.AuctionBidData.AddRange(auctionsbid);
            context.SaveChanges();

            var auctions = new AuctionData[]
            {
                new AuctionData{UserID=1050,ClientID=3,Type="A",HomeBudget=3,BidID=3,BidLimit=3},
                
            };

            context.AuctionData.AddRange(auctions);
            context.SaveChanges();

            var clients = new ClientData[]
            {
                new ClientData{FirstName="John",LastName="Ben",Email="ben10@gmail.com",Phone="7886809456"},
                
            };

            context.ClientData.AddRange(clients);
            context.SaveChanges();

            var licenses = new LicenseData[]
            {
                new LicenseData{UserID=3456,reLicense="No",mbLicense="Yes",hiLicense="No"},

            };

            context.LicenseData.AddRange(licenses);
            context.SaveChanges();

            var status = new StatusIDs[]
            {
                new StatusIDs{StatusID=3456,StatusDescription="Good"},

            };

            context.StatusIDs.AddRange(status);
            context.SaveChanges();

            var user = new UserData[]
            {
                new UserData{TypeID="A",Username="ben10",Password="Nice",FirstName="John",LastName="Ben",DOB=DateTime.Parse("2000-09-01"),Phone="7886809456",Email="ben10@gmail.com",Address="1234 Johnson Ave",City="Downtown",PostalCode="G5I 1P9",Country="Canada",Company="The good company",PayPalEmail="ben10@gmail.com"},

            };

            context.UserData.AddRange(user);
            context.SaveChanges();

        }
    }
}
