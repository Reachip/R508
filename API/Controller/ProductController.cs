using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller;

[ApiController]
[Route("api/product")]
public class ProductController(AppDbContext context) : ControllerBase
{
    // GET api/product
    [HttpGet]
    public ActionResult<Product> GetProduct( int id)
    {
        var products = context.Products.ToList();
        return Ok(products);
    }

    // POST api/product
    [HttpPost]
    public ActionResult<Product> CreateProduct([FromBody] Product product)
    {
        context.Products.Add(product);
        context.SaveChanges();
        
        return Ok(product);
    }

    // PATCH api/product
    [HttpPatch]
    public IActionResult ModifyProduct([FromBody] Product product)
    {
        return Ok();
    }

    // PUT api/product
    [HttpPut]
    public IActionResult ModifyProductPartially([FromBody] Product product)
    {
        return Ok();
    }

    // DELETE api/product
    [HttpDelete]
    public IActionResult ModifyProductPartially(int id)
    {
        return NoContent();
    }
}