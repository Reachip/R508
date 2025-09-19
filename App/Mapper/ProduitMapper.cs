using App.DTO;
using App.Models;

namespace App.Mapper;

public class ProduitMapper : IMapper<Produit, ProduitDto>, IMapper<Produit, ProduitDetailDto>
{
    public Produit? FromDTO(ProduitDto dto)
    {
        return new Produit()
        {
            IdProduit = dto.Id,
            NomProduit = dto.Nom,
            TypeProduitNavigation = new TypeProduit() {NomTypeProduit = dto.Type},
            MarqueNavigation = new Marque() {NomMarque = dto.Marque}
        };
    }

    public Produit? FromDTO(ProduitDetailDto dto)
    {
        return new Produit()
        {
            IdProduit = dto.Id,
            NomProduit = dto.Nom,
            TypeProduitNavigation = new TypeProduit() {NomTypeProduit = dto.Type},
            MarqueNavigation = new Marque() {NomMarque = dto.Marque},
            Description = dto.Description,
            NomPhoto = dto.Nomphoto,
            UriPhoto = dto.Uriphoto,
            StockReel  = dto.Stock
        };
    }

    ProduitDetailDto? IMapper<Produit, ProduitDetailDto>.FromEntity(Produit entity)
    {
        return new ProduitDetailDto()
        {
            Id = entity.IdProduit,
            Nom = entity.NomProduit,
            Type =  entity.TypeProduitNavigation != null ? entity.TypeProduitNavigation.NomTypeProduit : null,
            Marque = entity.MarqueNavigation != null ? entity.MarqueNavigation.NomMarque : null,
            Description = entity.Description,
            Nomphoto = entity.NomPhoto,
            Uriphoto = entity.UriPhoto,
            Stock = entity.StockReel,
            EnReappro = entity.StockReel > 0
        };
    }

    public ProduitDto? FromEntity(Produit entity)
    {
        return new ProduitDto()
        {
            Id = entity.IdProduit,
            Nom = entity.NomProduit,
            Marque = entity.MarqueNavigation != null ? entity.MarqueNavigation.NomMarque : null,
            Type = entity.TypeProduitNavigation != null ? entity.TypeProduitNavigation.NomTypeProduit : null
        };
    }
}