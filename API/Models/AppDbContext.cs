using Microsoft.EntityFrameworkCore;

namespace API.Models;

public partial class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    private DbSet<Brand> Brands { get; set; }
    private DbSet<Product> Products { get; set; }
    private DbSet<ProductType> ProductTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(product => product.Id);

            entity.HasOne(product => product.Brand)
                .WithMany(brand => brand.Products)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Produits_Brand");

            entity.HasOne(product => product.ProductType)
                .WithMany(brand => brand.Products)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Produits_ProductType");
        });


        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(brand => brand.Id);

            entity.HasMany(brand => brand.Products)
                .WithOne(product => product.Brand)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_brand_Product");
        });


        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(productType => productType.Id);

            entity.HasMany(productType => productType.Products)
                .WithOne(product => product.ProductType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product_type_Product");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}