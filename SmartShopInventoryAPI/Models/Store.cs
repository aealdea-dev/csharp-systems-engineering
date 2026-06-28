using System.ComponentModel.DataAnnotations;

namespace SmartShopInventoryAPI.Models;

public class Store
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public required string StoreLocation { get; set; }
    
    // Relationship: A store has many sales
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
    


}