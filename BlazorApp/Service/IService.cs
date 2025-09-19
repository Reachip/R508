using BlazorApp.Models;

namespace BlazorApp.Service;

public interface IService<TEntity>
{
    Task<List<TEntity>?> GetAllAsync();
    Task<TEntity?> GetByIdAsync(int id);
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity updatedEntity);
    Task DeleteAsync(int id);
    Task<Produit?> GetByNameAsync(string name);
}
