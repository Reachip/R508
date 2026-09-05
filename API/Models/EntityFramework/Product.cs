using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("product")]
public class Product
{
    [Key] [Column("product_id")] public int Id { get; set; }

    [Column("product_name")] public string ProductName { get; set; } = null!;

    [Column("description")] public string? Description { get; set; }

    [Column("photo_name")] public string? PhotoName { get; set; }

    [Column("photo_uri")] public string? PhotoUri { get; set; }

    [Column("product_type_id")] public int? ProductTypeId { get; set; }

    [Column("brand_id")] public int? BrandId { get; set; }

    [Column("actual_stock")] public int? ActualStock { get; set; }

    [Column("min_stock")] public int MinStock { get; set; }

    [Column("max_stock")] public int MaxStock { get; set; }

    [ForeignKey(nameof(BrandId))]
    [InverseProperty(nameof(Models.Brand.Products))]
    public virtual Brand? Brand { get; set; } = null!;

    [ForeignKey(nameof(ProductTypeId))]
    [InverseProperty(nameof(Models.ProductType.Products))]
    public virtual ProductType? ProductType { get; set; } = null!;
}