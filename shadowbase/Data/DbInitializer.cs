
using System.Diagnostics;
namespace shadowbase.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ShadowbaseContext context)
        {
           
            SeedData.Initialize(context);
        }
    }
}
