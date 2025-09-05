using Microsoft.AspNetCore.Mvc;

namespace App.Models.Repository;

public class ProductManager : IDataRepository<Produit>
{
    public async Task<ActionResult<IEnumerable<Produit>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<ActionResult<Produit?>> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ActionResult<Produit?>> GetByStringAsync(string str)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Produit entity)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Produit entityToUpdate, Produit entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(Produit entity)
    {
        throw new NotImplementedException();
    }
}