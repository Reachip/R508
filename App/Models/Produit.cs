using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

[Table(("produit"))]
public class Produit
{
    [Key]
    [Column("id_produit")]
    public int IdProduit { get; set; }

    [Column("nom_produit")] 
    public string NomProduit { get; set; } = null!;

    [Column("description")] public string Description { get; set; } = null!;

    [Column("nom_photo")] public string NomPhoto { get; set; } = null!;

    [Column("uri_photo")] public string UriPhoto { get; set; } = null!;

    [Column("id_type_produit")]
    public int? IdTypeProduit { get; set; }

    [Column("id_marque")]
    public int? IdMarque { get; set; }

    [Column("stock_reel")]
    public int StockReel { get; set; }
    
    [Column("stock_min")]
    public int StockMin { get; set; }
    
    [Column("stock_max")]
    public int StockMax { get; set; }

    [ForeignKey(nameof(IdMarque))]
    [InverseProperty(nameof(Marque.Produits))]
    public virtual Marque? MarqueNavigation { get; set; } = null!;
    
    [ForeignKey(nameof(IdTypeProduit))]
    [InverseProperty(nameof(TypeProduit.Produits))]
    public virtual TypeProduit? TypeProduitNavigation { get; set; } = null!;

    protected bool Equals(Produit other)
    {
        return NomProduit == other.NomProduit;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Produit)obj);
    }
}