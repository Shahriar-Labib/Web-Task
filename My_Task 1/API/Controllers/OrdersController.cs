using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly DataContext _context;
        public OrdersController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("create")]

        public async Task<IActionResult> AddOrders([FromBody] Tbl_Order tbl_Orders)
        {
            if(tbl_Orders == null || tbl_Orders.Quantity <= 0)
            {
                return BadRequest("Invalid Input");
            }

            var products = await _context.Tbl_Products.FindAsync(tbl_Orders.ProductId);

            if(products == null)
            {
                return NotFound("Product Not found");
            }
            if(products.Stock < tbl_Orders.Quantity)
            {
                return BadRequest("Insufficient stock available");
            }
            var order = new Tbl_Order{
                ProductId = tbl_Orders.ProductId,
                CustomerName = tbl_Orders.CustomerName,
                Quantity = tbl_Orders.Quantity,
                OrderDate = DateTime.UtcNow
            };

            _context.Tbl_Orders.Add(order);
            products.Stock -= tbl_Orders.Quantity;

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(AddOrders), new {id = order.OrderId},order);
            
        }
    }
}