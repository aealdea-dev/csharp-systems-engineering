using System.ComponentModel.DataAnnotations;

namespace SmartShopInventoryAPI.Models;

public class Sale
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime SaleDate { get; set; }

    [Required]
    public int UnitsSold { get; set; }

    // Relationships: A sale is linked to one product and one store
    public int ProductId { get; set; }
    public Product? Product { get; set; }

    public int StoreId { get; set; }
    public virtual Store? Store { get; set; }
}