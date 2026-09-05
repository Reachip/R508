using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("product_type")]
public class ProductType
{
    [Key] [Column("product_type_id")] public int Id { get; set; }

    [Required(ErrorMessage = "This property must be filled")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "The string length must be between 2 and 50 characters")]
    [Column("product_type_name")]
    public string Name { get; set; }

    [InverseProperty(nameof(Product.ProductType))]
    public ICollection<Product>? Products { get; set; } = new List<Product>();
}