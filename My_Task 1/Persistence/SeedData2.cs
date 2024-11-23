using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class SeedData2
    {
        public static async Task seed(DataContext context)
        {
             if (context.Tbl_Orders.Any()) return;

             var activities = new List<Tbl_Order>
             {
                new Tbl_Order
                {
                    OrderId  = 1,
                    ProductId = 1,
                    CustomerName = "Joe Doe",
                    Quantity = 20,
                    OrderDate = DateTime.UtcNow.AddMonths(8)
                },
                new Tbl_Order
                {
                    OrderId  = 2,
                    ProductId = 2,
                    CustomerName = "Jane Smith",
                    Quantity = 10,
                    OrderDate = DateTime.UtcNow.AddMonths(8)
                },
                new Tbl_Order
                {
                    OrderId  = 3,
                    ProductId = 1,
                    CustomerName = "Sam Wilson",
                    Quantity = 15,
                    OrderDate = DateTime.UtcNow.AddMonths(8)
                },
             };
             await context.Tbl_Orders.AddRangeAsync(activities);
            await context.SaveChangesAsync();
            
        }
    }
}