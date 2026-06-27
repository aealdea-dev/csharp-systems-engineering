using Microsoft.EntityFrameworkCore;
using SmartShopInventoryAPI.Models;
namespace SmartShopInventoryAPI.Data;

public class SmartShopDbContext : DbContext
{
    public SmartShopDbContext(DbContextOptions<SmartShopDbContext> options) : base(options)
    {
    }
    // These properties represent the actual database tables

    public DbSet<Product> Products { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<Sale> Sales { get; set; }
    
    //To speedup database queries, we are adding indexes here
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Product>()
            .HasIndex(p => p.Category);

        modelBuilder.Entity<Product>()
            .HasIndex(p => p.Price);
    }
}