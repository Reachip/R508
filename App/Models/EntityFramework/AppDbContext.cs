using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace App.Models.EntityFramework;

public partial class AppDbContext : DbContext
{
    public DbSet<Produit> Produits { get; set; }
    
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;port=5432;Database=postgres; uid=postgres; password=postgres;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Produit>(e =>
        {
            e.HasKey(p => p.IdProduit);
            
            e.HasOne(p => p.MarqueNavigation)
                .WithMany(m => m.Produits)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_produits_marque");
            
            e.HasOne(p => p.TypeProduitNavigation)
                .WithMany(m => m.Produits)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_produits_type_produit");
        });
        modelBuilder.Entity<TypeProduit>(e =>
        {
            e.HasKey(p => p.IdTypeProduit);

            e.HasMany(p => p.Produits)
                .WithOne(m => m.TypeProduitNavigation)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });
        
        modelBuilder.Entity<Marque>(e =>
        {
            e.HasKey(p => p.IdMarque);

            e.HasMany(p => p.Produits)
                .WithOne(m => m.MarqueNavigation)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });
        
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
