using System.Collections.Generic;
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
    public void ShouldDeleteProduct()
    {
        // Given : Un produit enregistré
        Produit produitInDb = new Produit()
        {
            NomProduit = "Chaise",
            Description = "Une superbe chaise",
            NomPhoto = "Une superbe chaise bleu",
            UriPhoto = "https://ikea.fr/chaise.jpg"
        };

        _context.Produits.Add(produitInDb);
        _context.SaveChanges();
        
        // When : Je souhaite supprimé un produit depuis l'API
        IActionResult action = _productController.Delete(produitInDb.IdProduit).GetAwaiter().GetResult();
        
        // Then : Le produit a bien été supprimé et le code HTTP est NO_CONTENT (204)
        Assert.IsNotNull(action);
        Assert.IsInstanceOfType(action, typeof(NoContentResult));
        Assert.IsNull(_context.Produits.Find(produitInDb.IdProduit));
    }
    
    [TestMethod]
    public void ShouldNotDeleteProductBecauseProductDoesNotExist()
    {
        // Given : Un produit enregistré
        Produit produitInDb = new Produit()
        {
            NomProduit = "Chaise",
            Description = "Une superbe chaise",
            NomPhoto = "Une superbe chaise bleu",
            UriPhoto = "https://ikea.fr/chaise.jpg"
        };
        
        // When : Je souhaite supprimé un produit depuis l'API
        IActionResult action = _productController.Delete(produitInDb.IdProduit).GetAwaiter().GetResult();
        
        // Then : Le produit a bien été supprimé et le code HTTP est NO_CONTENT (204)
        Assert.IsNotNull(action);
        Assert.IsInstanceOfType(action, typeof(NotFoundResult));
    }

    [TestMethod]
    public void ShouldGetAllProducts()
    {
        // Given : Des produits enregistrées
        IEnumerable<Produit> productInDb = [
            new()
            {
                NomProduit = "Chaise",
                Description = "Une superbe chaise",
                NomPhoto = "Une superbe chaise bleu",
                UriPhoto = "https://ikea.fr/chaise.jpg"
            },
            new()
            {
                NomProduit = "Armoir",
                Description = "Une superbe armoire",
                NomPhoto = "Une superbe armoire jaune",
                UriPhoto = "https://ikea.fr/armoire-jaune.jpg"
            }
        ];
        
        _context.Produits.AddRange(productInDb);
        _context.SaveChanges();
        
        // When : On souhaite récupérer tous les produits
        var products = _productController.GetAll().GetAwaiter().GetResult();

        // Then : Tous les produits sont récupérés
        Assert.IsNotNull(products);
        Assert.IsInstanceOfType(products.Value, typeof(IEnumerable<Produit>));
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

    [TestMethod]
    public void ShouldCreateProduct()
    {
        // Given
        Produit productToInsert = new Produit()
        {
            NomProduit = "Chaise",
            Description = "Une superbe chaise",
            NomPhoto = "Une superbe chaise bleu",
            UriPhoto = "https://ikea.fr/chaise.jpg"
        };
        
        // When
        ActionResult<Produit> action = _productController.Create(productToInsert).GetAwaiter().GetResult();
        
        // Then
        Produit productInDb = _context.Produits.Find(productToInsert.IdProduit);
        
        Assert.IsNotNull(productInDb);
        Assert.IsNotNull(action);
        Assert.IsInstanceOfType(action.Result, typeof(CreatedAtActionResult));
    }

    [TestCleanup]
    public void Cleanup()
    {
        _context.Produits.RemoveRange(_context.Produits);
        _context.SaveChanges();
    }
}