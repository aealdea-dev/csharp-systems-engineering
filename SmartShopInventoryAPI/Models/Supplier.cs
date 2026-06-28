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
    public bool HasDelayedDeliveries { get; set; }
    
    //Relationship: A supplier provides many products
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();    
}
