using System.Collections.Generic;
using System.Linq;
using App.Controllers;
using App.DTO;
using App.Mapper;
using App.Models;
using App.Models.EntityFramework;
using App.Models.Repository;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Controllers;

[TestClass]
[TestSubject(typeof(ProductController))]
[TestCategory("integration")]
public class ProductControllerTest
{
    private readonly AppDbContext  _context;
    private readonly ProductController _productController;
    private readonly ProduitMapper _produitMapper;

    public ProductControllerTest()
    {
        _context = new AppDbContext();
        
        ProductManager manager = new(_context);
        
        _produitMapper = new ProduitMapper();
        _productController = new ProductController(_produitMapper, _produitMapper, manager);
    }
    
    [TestCleanup]
    public void Cleanup()
    {
        _context.Produits.RemoveRange(_context.Produits);
        _context.SaveChanges();
    }

    [TestMethod]
    public void ShouldGetProduct()
    {
        // Given : Un produit en enregistré
        Produit produitInDb = new()
        {
            NomProduit = "Chaise",
            Description = "Une superbe chaise",
            NomPhoto = "Une superbe chaise bleu",
            UriPhoto = "https://ikea.fr/chaise.jpg"
        };

        _context.Produits.Add(produitInDb);
        _context.SaveChanges();
        
        // When : On appelle la méthode GET de l'API pour récupérer le produit
        ActionResult<ProduitDetailDto> action = _productController.Get(produitInDb.IdProduit).GetAwaiter().GetResult();
        
        // Then : On récupère le produit et le code de retour est 200
        Assert.IsNotNull(action);
        Assert.IsInstanceOfType(action.Value, typeof(ProduitDetailDto));
        
        ProduitDetailDto returnProduct = action.Value;
        Assert.AreEqual(((IMapper<Produit, ProduitDetailDto>)_produitMapper).ToDTO(produitInDb), returnProduct);
    }

    [TestMethod]
    public void ShouldDeleteProduct()
    {
        // Given : Un produit enregistré
        Produit produitInDb = new()
        {
            NomProduit = "Chaise",
            Description = "Une superbe chaise",
            NomPhoto = "Une superbe chaise bleu",
            UriPhoto = "https://ikea.fr/chaise.jpg"
        };

        _context.Produits.Add(produitInDb);
        _context.SaveChanges();
        
        // When : On souhaite supprimer un produit depuis l'API
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
        Produit produitInDb = new()
        {
            NomProduit = "Chaise",
            Description = "Une superbe chaise",
            NomPhoto = "Une superbe chaise bleu",
            UriPhoto = "https://ikea.fr/chaise.jpg"
        };
        
        // When : On souhaite supprimer un produit depuis l'API
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
        Assert.IsInstanceOfType(products.Value, typeof(IEnumerable<ProduitDto>));
        Assert.IsTrue(((IMapper<Produit, ProduitDto>)_produitMapper).ToDTOs(productInDb).SequenceEqual(products.Value));
    }
    
    [TestMethod]
    public void GetProductShouldReturnNotFound()
    {
        // When : On appelle la méthode get de mon api pour récupérer le produit
        ActionResult<ProduitDetailDto> action = _productController.Get(0).GetAwaiter().GetResult();
        
        // Then : On ne renvoie rien et on renvoie NOT_FOUND (404)
        Assert.IsInstanceOfType(action.Result, typeof(NotFoundResult), "Ne renvoie pas 404");
        Assert.IsNull(action.Value, "Le produit n'est pas null");
    }
    
    [TestMethod]
    public void ShouldCreateProduct()
    {
        // Given : Un produit a enregistré
        Produit productToInsert = new()
        {
            NomProduit = "Chaise",
            Description = "Une superbe chaise",
            NomPhoto = "Une superbe chaise bleu",
            UriPhoto = "https://ikea.fr/chaise.jpg"
        };
        
        // When : On appel la méthode POST de l'API pour enregistrer le produit
        ActionResult<Produit> action = _productController.Create(productToInsert).GetAwaiter().GetResult();
        
        // Then : Le produit est bien enregistré et le code renvoyé et CREATED (201)
        Produit productInDb = _context.Produits.Find(productToInsert.IdProduit);
        
        Assert.IsNotNull(productInDb);
        Assert.IsNotNull(action);
        Assert.IsInstanceOfType(action.Result, typeof(CreatedAtActionResult));
    }

    [TestMethod]
    public void ShouldUpdateProduct()
    {
        // Given : Un produit à mettre à jour
        Produit produitToEdit = new()
        {
            NomProduit = "Bureau",
            Description = "Un super bureau",
            NomPhoto = "Un super bureau bleu",
            UriPhoto = "https://ikea.fr/bureau.jpg"
        };
        
        _context.Produits.Add(produitToEdit);
        _context.SaveChanges();
        
        // Une fois enregistré, on modifie certaines propriétés 
        produitToEdit.NomProduit = "Lit";
        produitToEdit.Description = "Un super lit";

        // When : On appelle la méthode PUT du controller pour mettre à jour le produit
        IActionResult action = _productController.Update(produitToEdit.IdProduit, produitToEdit).GetAwaiter().GetResult();
        
        // Then : On vérifie que le produit a bien été modifié et que le code renvoyé et NO_CONTENT (204)
        Assert.IsNotNull(action);
        Assert.IsInstanceOfType(action, typeof(NoContentResult));
        
        Produit editedProductInDb = _context.Produits.Find(produitToEdit.IdProduit);
        
        Assert.IsNotNull(editedProductInDb);
        Assert.AreEqual(produitToEdit, editedProductInDb);
    }
    
    [TestMethod]
    public void ShouldNotUpdateProductBecauseIdInUrlIsDifferent()
    {
        // Given : Un produit à mettre à jour
        Produit produitToEdit = new()
        {
            NomProduit = "Bureau",
            Description = "Un super bureau",
            NomPhoto = "Un super bureau bleu",
            UriPhoto = "https://ikea.fr/bureau.jpg"
        };
        
        _context.Produits.Add(produitToEdit);
        _context.SaveChanges();
        
        produitToEdit.NomProduit = "Lit";
        produitToEdit.Description = "Un super lit";

        // When : On appelle la méthode PUT du controller pour mettre à jour le produit,
        // mais en précisant un ID différent de celui du produit enregistré
        IActionResult action = _productController.Update(0, produitToEdit).GetAwaiter().GetResult();
        
        // Then : On vérifie que l'API renvoie un code BAD_REQUEST (400)
        Assert.IsNotNull(action);
        Assert.IsInstanceOfType(action, typeof(BadRequestResult));
    }
    
    [TestMethod]
    public void ShouldNotUpdateProductBecauseProductDoesNotExist()
    {
        // Given : Un produit à mettre à jour qui n'est pas enregistré
        Produit produitToEdit = new()
        {
            IdProduit = 20,
            NomProduit = "Bureau",
            Description = "Un super bureau",
            NomPhoto = "Un super bureau bleu",
            UriPhoto = "https://ikea.fr/bureau.jpg"
        };
        
        // When : On appelle la méthode PUT du controller pour mettre à jour un produit qui n'est pas enregistré
        IActionResult action = _productController.Update(produitToEdit.IdProduit, produitToEdit).GetAwaiter().GetResult();
        
        // Then : On vérifie que l'API renvoie un code NOT_FOUND (404)
        Assert.IsNotNull(action);
        Assert.IsInstanceOfType(action, typeof(NotFoundResult));
    }
}
