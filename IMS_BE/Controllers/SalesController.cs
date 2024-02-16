using Microsoft.AspNetCore.Mvc;
using IMS_BE.Models;
using IMS_BE.DataAccess;

namespace IMS_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly InventoryDbContext _context;

        public SalesController(InventoryDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Sale>> RecordSale(Sale sale)
        {
            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSale), new { id = sale.Id }, sale);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> GetSale(int id)
        {
            var sale = await _context.Sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }
            return sale;
        }

        // Other methods like GetSaleById, UpdateSale, DeleteSale, etc.
    }
}
