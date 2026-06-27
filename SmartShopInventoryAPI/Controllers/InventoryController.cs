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

}


