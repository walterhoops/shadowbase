
using ContosoUniversity.Models;
using shadowbase.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace shadowbase.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ShadowbaseContext context)
        {
            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var alexander = new Client
            {
                FirstName = "Carson",
                LastName = "Alexander",
            };

            var alonso = new Client
            {
                FirstName = "Meredith",
                LastName = "Alonso",
            };

            var anand = new Client
            {
                FirstName = "Arturo",
                LastName = "Anand",
            };

            var barzdukas = new Client
            {
                FirstName = "Gytis",
                LastName = "Barzdukas",
            };

            var li = new Client
            {
                FirstName = "Yan",
                LastName = "Li",
            };

            var justice = new Client
            {
                FirstName = "Peggy",
                LastName = "Justice",
            };

            var norman = new Client
            {
                FirstName = "Laura",
                LastName = "Norman",
            };

            var olivetto = new Client
            {
                FirstName = "Nino",
                LastName = "Olivetto",
            };

            var clients = new Client[]
            {
                alexander,
                alonso,
                anand,
                barzdukas,
                li,
                justice,
                norman,
                olivetto
            };
            context.SaveChanges();
            context.AddRange(clients);

            var abercrombie = new Admin
            {
                FirstMidName = "Kim",
                LastName = "Abercrombie",
            };

            var fakhouri = new Admin
            {
                FirstMidName = "Fadi",
                LastName = "Fakhouri",
                HireDate = DateTime.Parse("2002-07-06")
            };

            var harui = new Admin
            {
                FirstMidName = "Roger",
                LastName = "Harui",
                HireDate = DateTime.Parse("1998-07-01")
            };

            var kapoor = new Admin
            {
                FirstMidName = "Candace",
                LastName = "Kapoor",
                HireDate = DateTime.Parse("2001-01-15")
            };

            var zheng = new Admin
            {
                FirstMidName = "Roger",
                LastName = "Zheng",
                HireDate = DateTime.Parse("2004-02-12")
            };

            var admins = new Admin[]
            {
                abercrombie,
                fakhouri,
                harui,
                kapoor,
                zheng
            };
            context.SaveChanges();
            context.AddRange(admins);

            var adminAssignments = new AdminAssignment[]
            {
                new AdminAssignment {
                    Admin = fakhouri,
                    Location = "Smith 17" },
                new AdminAssignment {
                    Admin = harui,
                    Location = "Gowan 27" },
                new AdminAssignment {
                    Admin = kapoor,
                    Location = "Thompson 304" }
            };
            context.SaveChanges();
            context.AddRange(adminAssignments);

            var tech = new Department
            {
                Name = "Tech",
                Budget = 350000,
                StartDate = DateTime.Parse("2007-09-01"),
                Administrator = abercrombie
            };

            var humanresource = new Department
            {
                Name = "Human Resource",
                Budget = 100000,
                StartDate = DateTime.Parse("2007-09-01"),
                Administrator = fakhouri
            };


            var departments = new Department[]
            {
                tech,
                humanresource
            };
            context.SaveChanges();
            context.AddRange(departments);

        }
    }
}