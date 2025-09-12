using App.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Models.Repository;

public class ProductManager(AppDbContext context) : IDataRepository<Produit>
{
    public async Task<ActionResult<IEnumerable<Produit>>> GetAllAsync()
    {
        return await context.Produits.ToListAsync();
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
        context.Produits.Attach(entityToUpdate);
        context.Entry(entityToUpdate).CurrentValues.SetValues(entity);
        
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Produit entity)
    {
        context.Produits.Remove(entity);
        await context.SaveChangesAsync();
    }
}