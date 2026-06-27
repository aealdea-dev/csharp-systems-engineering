using System.ComponentModel.DataAnnotations;
    
    
namespace SmartShopInventoryAPI.Models;

public class Supplier
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public required string SupplierName { get; set; }
    
    [Required]
    public bool HasDelayedDelivers { get; set; }
    
    //Relationship: A supplier provides many products
    public ICollection<Product> Products { get; set; } = new List<Product>();    
}
