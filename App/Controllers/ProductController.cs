using App.Models;
using App.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[Route("api/produits")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IDataRepository<Produit> _productManager;
    
    public ProductController(IDataRepository<Produit> manager)
    {
        _productManager = manager;
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Produit?>> Get(int id)
    {
        var result = await _productManager.GetByIdAsync(id);
        
        if(result.Value == null)
        {
            return NotFound();
        }
        
        return result;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        ActionResult<Produit?> produit = await _productManager.GetByIdAsync(id);
        
        if (produit.Value == null)
            return NotFound();
        
        await _productManager.DeleteAsync(produit.Value);
        return NoContent();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<IEnumerable<Produit>>> GetAll()
    {
        return await _productManager.GetAllAsync();
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
        await _productManager.AddAsync(produit);
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
        
        ActionResult<Produit?> prodToUpdate = await _productManager.GetByIdAsync(id);
        
        if (prodToUpdate.Value == null)
        {
            return NotFound();
        }
        
        await _productManager.UpdateAsync(prodToUpdate.Value, produit);
        return NoContent();
    }
}