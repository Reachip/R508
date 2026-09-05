using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("brand")]
public class Brand
{
    [Key] [Column("brand_id")] public int Id { get; set; }

    [Column("brand_name")] public string BrandName { get; set; }

    [InverseProperty(nameof(Product.Brand))]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}