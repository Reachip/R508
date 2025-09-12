using App.Controllers;
using App.Models;
using App.Models.Repository;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests.Controllers;

[TestClass]
[TestSubject(typeof(ProductController))]
[TestCategory("mock")]
public class ProductControllerMockTest
{
    private readonly ProductController _productController;

    public ProductControllerMockTest()
    {
        var manager = new Mock<IDataRepository<Produit>>();
        _productController = new ProductController(manager.Object);
    }
}
