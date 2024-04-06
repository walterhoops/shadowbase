
using ContosoUniversity.Models;
using shadowbase.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace shadowbase.Data
{
    public static class DbInitializer
    {
        
        public static void Initialize(ShadowbaseContext context) {

            SeedData.Initialize(context);   
        }



    }
}