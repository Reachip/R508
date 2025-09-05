using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

public class TypeProduit
{
    [Key]
    [Column("id_type_produit")]
    public int IdTypeProduit { get; set; }

    [Column("nom_type_produit")]
    public string NomTypeProduit { get; set; } = null!;
    
    [InverseProperty(nameof(Produit.TypeProduitNavigation))]
    public virtual ICollection<Produit> Produits { get; set; } = null!;
}