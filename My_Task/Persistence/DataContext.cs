using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
         public DbSet<Tbl_product> Tbl_Products { get; set; }
         public DbSet<Tbl_Order> Tbl_Orders { get; set; }
    }

   

}