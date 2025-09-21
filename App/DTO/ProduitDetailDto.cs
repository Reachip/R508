namespace App.DTO;

public class ProduitDetailDto
{
    public int Id { get; set; }
    public string? Nom { get; set; }
    public string? Type { get; set; }
    public string? Marque { get; set; }
    public string? Description { get; set; }
    public string? Nomphoto { get; set; }
    public string? Uriphoto { get; set; }
    public int? Stock { get; set; }
    public bool EnReappro { get; set; }

    protected bool Equals(ProduitDetailDto other)
    {
        return Nom == other.Nom && Type == other.Type && Marque == other.Marque && Description == other.Description && Nomphoto == other.Nomphoto && Uriphoto == other.Uriphoto && Stock == other.Stock && EnReappro == other.EnReappro;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((ProduitDetailDto)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Nom, Type, Marque, Description, Nomphoto, Uriphoto, Stock, EnReappro);
    }
}
