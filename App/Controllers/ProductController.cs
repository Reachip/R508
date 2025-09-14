using App.Models;
using App.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[Route("api/produits")]
[ApiController]
public class ProductController(IDataRepository<Produit> manager) : ControllerBase
{
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Produit?>> Get(int id)
    {
        var result = await manager.GetByIdAsync(id);
        return result.Value == null ? NotFound() : result;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        ActionResult<Produit?> produit = await manager.GetByIdAsync(id);
        
        if (produit.Value == null)
            return NotFound();
        
        await manager.DeleteAsync(produit.Value);
        return NoContent();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<IEnumerable<Produit>>> GetAll()
    {
        return await manager.GetAllAsync();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Produit>> Create([FromBody] Produit produit)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await manager.AddAsync(produit);
        return CreatedAtAction("Get", new { id = produit.IdProduit }, produit);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromBody] Produit produit)
    {
        if (id != produit.IdProduit)
        {
            return BadRequest();
        }
        
        ActionResult<Produit?> prodToUpdate = await manager.GetByIdAsync(id);
        
        if (prodToUpdate.Value == null)
        {
            return NotFound();
        }
        
        await manager.UpdateAsync(prodToUpdate.Value, produit);
        return NoContent();
    }
}