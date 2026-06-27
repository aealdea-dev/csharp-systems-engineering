using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace SmartShopInventoryAPI.Models;

public class Product
{


    [Key] public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public required string ProductName { get; set; }

    [Required] 
    [StringLength(50)] 
    public required string Category { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    
    [Required]
    public int StockLevel { get; set; }

    [Required] 
    // Relationship: A product comes from one supplier
    public int SupplierId { get; set; }
    public Supplier? Supplier { get; set; }





}