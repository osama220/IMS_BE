using Microsoft.AspNetCore.Mvc;
using IMS_BE.Models;
using IMS_BE.DataAccess;

namespace IMS_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchasesController : ControllerBase
    {
        private readonly InventoryDbContext _context;

        public PurchasesController(InventoryDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Purchase>> TrackPurchase(Purchase purchase)
        {
            _context.Purchases.Add(purchase);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPurchase), new { id = purchase.Id }, purchase);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Purchase>> GetPurchase(int id)
        {
            var purchase = await _context.Purchases.FindAsync(id);
            if (purchase == null)
            {
                return NotFound();
            }
            return purchase;
        }

    }
}
