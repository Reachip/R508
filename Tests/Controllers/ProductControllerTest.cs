using App.Controllers;
using App.Models;
using App.Models.EntityFramework;
using App.Models.Repository;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Controllers;

[TestClass]
[TestSubject(typeof(ProductController))]
public class ProductControllerTest
{
    private readonly AppDbContext  _context;
    private readonly ProductController _productController;

    public ProductControllerTest()
    {
        _context = new AppDbContext();
        
        var manager = new ProductManager(_context);
        _productController = new ProductController(manager);
    }

    [TestMethod]
    public void ShouldGetProduct()
    {
        // Given : un produit en base de donnée
        Produit produitInDb = new Produit()
        {
            NomProduit = "Chaise",
            Description = "Une superbe chaise",
            NomPhoto = "Une superbe chaise bleu",
            UriPhoto = "https://ikea.fr/chaise.jpg"
        };

        _context.Produits.Add(produitInDb);
        _context.SaveChanges();
        
        // When : J'appelle la méthode get de mon api pour récupérer le produit
        ActionResult<Produit> action = _productController.Get(produitInDb.IdProduit).GetAwaiter().GetResult();
        
        // Then : On récupère le produit et le code de retour est 200
        Assert.IsNotNull(action);
        Assert.IsInstanceOfType(action.Value, typeof(Produit));
        
        Produit returnProduct = action.Value;
        Assert.AreEqual(produitInDb.NomProduit, returnProduct.NomProduit);
        
        // Assert.IsInstanceOfType(action.Result, typeof(OkObjectResult));
    }

    [TestMethod]
    public void GetProductShouldReturnNotFound()
    {
        // When : J'appelle la méthode get de mon api pour récupérer le produit
        ActionResult<Produit> action = _productController.Get(0).GetAwaiter().GetResult();
        
        // Then : On ne renvoie rien et on renvoie 404
        Assert.IsInstanceOfType(action.Result, typeof(NotFoundResult), "Ne renvoie pas 404");
        Assert.IsNull(action.Value, "Le produit n'est pas null");
    }
}