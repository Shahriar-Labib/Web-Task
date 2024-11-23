using Domain;

namespace Persistence
{
    public class SeedData
    {
        public static async Task seed(DataContext context)
        {
             if (context.Tbl_Products.Any()) return;

             var activities = new List<Tbl_product>
             {
                new Tbl_product
                {
                    ProductId = 1,
                    ProductName = "Widget A",
                    UnitPrice = 50,
                    Stock = 300
                },
                new Tbl_product
                {
                    ProductId = 2,
                    ProductName = "Gadget B",
                    UnitPrice = 75,
                    Stock = 150
                },
                new Tbl_product
                {
                    ProductId = 3,
                    ProductName = "Tool C",
                    UnitPrice = 50,
                    Stock = 300
                },
             };
             await context.Tbl_Products.AddRangeAsync(activities);
            await context.SaveChangesAsync();
            
        }
    }
}