using IMS_BE.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace IMS_BE.DataAccess
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}
