using App.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace App.Models.Repository;

public class ProductManager(AppDbContext context) : IDataRepository<Produit>
{
    public async Task<ActionResult<IEnumerable<Produit>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<ActionResult<Produit?>> GetByIdAsync(int id)
    {
        return await context.Produits.FindAsync(id);
    }

    public async Task<ActionResult<Produit?>> GetByStringAsync(string str)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Produit entity)
    {
        await context.Produits.AddAsync(entity);
        await context.SaveChangesAsync();
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