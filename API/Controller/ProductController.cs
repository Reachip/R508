using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller;

[ApiController]
[Route("api/product")]
public class ProductController : ControllerBase
{
    // GET api/product
    [HttpGet]
    public ActionResult<Product> GetProduct(int id)
    {
        return Ok();
    }

    // POST api/product
    [HttpPost]
    public ActionResult<Product> CreateProduct([FromBody] Product product)
    {
        return Ok();
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