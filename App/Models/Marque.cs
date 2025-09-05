using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

public class Marque
{
    [Key]
    [Column("id_marque")]
    public int IdMarque { get; set; }

    [Column("nom_marque")] public string NomMarque { get; set; } = null!;

    [InverseProperty(nameof(Produit.MarqueNavigation))]
    public virtual ICollection<Produit> Produits { get; set; } = null!;
}