namespace BlazorApp.Models;

public class Produit
{
    public int IdProduit { get; set; }
    public string NomProduit { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string NomPhoto { get; set; } = null!;
    public string UriPhoto { get; set; } = null!;
}
