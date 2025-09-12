using App.Models;
using App.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[Route("api/produits")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ProductManager _productManager;
    
    public ProductController(ProductManager manager)
    {
        _productManager = manager;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Produit>> Get(int id)
    {
        var result = await _productManager.GetByIdAsync(id);
        
        if(result.Value == null)
        {
            return NotFound();
        }
        
        return result;
    }


    [HttpGet]
    public async Task<ActionResult<List<Produit>>> GetAll()
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<ActionResult<Produit>> Create(Produit produit)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _productManager.AddAsync(produit);
        return CreatedAtAction("Get", new { id = produit.IdProduit }, produit);
    }
}