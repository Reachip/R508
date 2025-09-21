using App.DTO;
using App.Models;

namespace App.Mapper;

public class ProduitMapper : IMapper<Produit, ProduitDto>, IMapper<Produit, ProduitDetailDto>
{
    Produit IMapper<Produit, ProduitDto>.ToEntity(ProduitDto dto)
    {
        return new Produit()
        {
            IdProduit = dto.Id,
            NomProduit = dto.Nom,
            TypeProduitNavigation = new TypeProduit() {NomTypeProduit = dto.Type},
            MarqueNavigation = new Marque() {NomMarque = dto.Marque}
        };
    }

    Produit IMapper<Produit, ProduitDetailDto>.ToEntity(ProduitDetailDto dto)
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

    ProduitDetailDto IMapper<Produit, ProduitDetailDto>.ToDTO(Produit entity)
    {
        return new ProduitDetailDto()
        {
            Id = entity.IdProduit,
            Nom = entity.NomProduit,
            Type =  entity.TypeProduitNavigation?.NomTypeProduit,
            Marque = entity.MarqueNavigation?.NomMarque,
            Description = entity.Description,
            Nomphoto = entity.NomPhoto,
            Uriphoto = entity.UriPhoto,
            Stock = entity.StockReel,
            EnReappro = entity.StockReel > 0
        };
    }

    ProduitDto IMapper<Produit, ProduitDto>.ToDTO(Produit entity)
    {
        return new ProduitDto()
        {
            Id = entity.IdProduit,
            Nom = entity.NomProduit,
            Marque = entity.MarqueNavigation?.NomMarque,
            Type = entity.TypeProduitNavigation?.NomTypeProduit
        };
    }
}