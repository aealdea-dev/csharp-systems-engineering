using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartShopInventoryAPI.Data;
using SmartShopInventoryAPI.Models;

namespace SmartShopInventoryAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private readonly SmartShopDbContext _context;
    
    // A simple example of a Dependency Injection
    public InventoryController(SmartShopDbContext context)
    {
        _context = context;
    }
    // Retrival & Filtering items
    [HttpGet("products")]
    public async Task<ActionResult<IEnumerable<Product>>> GetProduct(string? category, bool lowStock = false)
    {
        var query = _context.Products.AsQueryable();

        if (!string.IsNullOrEmpty(category))
        {
            query = query.Where(p => p.Category == category);
            
        }

        // Low stock filter
        if (lowStock)
        {
            query = query.Where(p => p.StockLevel < 10);
        }
        
        // Filter by price
        var product = await query.OrderBy(p => p.Price).ToListAsync();

        return Ok(product);
    }
    [HttpPost("add-product")]
    public async Task<IActionResult> AddProduct(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return Ok(product);
    }
    // ==========================================
    // UTILITY: Seed Database with Test Data
    // ==========================================
    [HttpPost("seed")]
    public async Task<IActionResult> SeedDatabase()
    {
        // Prevent double-seeding
        if (_context.Products.Any()) return BadRequest("Database already has data.");

        // Create dummy data
        var supplier = new Supplier { SupplierName = "Acme Corp", HasDelayedDeliveries = true };
        var store = new Store { StoreLocation = "Seattle HQ" };
        var product = new Product { ProductName = "Industrial Server", Category = "Hardware", Price = 1200.50m, StockLevel = 4, Supplier = supplier };
        var sale = new Sale { SaleDate = DateTime.UtcNow, UnitsSold = 3, Product = product, Store = store };

        // Add to database memory
        _context.Suppliers.Add(supplier);
        _context.Stores.Add(store);
        _context.Products.Add(product);
        _context.Sales.Add(sale);

        // Commit permanently to the SQLite file
        await _context.SaveChangesAsync();

        return Ok("Warehouse successfully stocked with test data!");

       
    }

    // ==========================================
    // CAPSTONE ACTIVITY 2: Multi-Table JOIN & Aggregation
    // ==========================================
    [HttpGet("sales-report")]
    public async Task<IActionResult> GetSalesReport()
    {
        // This is Entity Framework's version of a SQL JOIN.
        // It connects Sales to Products, and Sales to Stores.
        var report = await _context.Sales
            .Include(s => s.Product)
            .Include(s => s.Store)
            .Select(s => new
            {
                ProductName = s.Product!.ProductName,
                SaleDate = s.SaleDate,
                StoreLocation = s.Store!.StoreLocation,
                UnitsSold = s.UnitsSold,
                TotalRevenue = s.UnitsSold * s.Product.Price // Aggregation Calculation
            })
            .ToListAsync();

        return Ok(report);
        
        
    }

}


