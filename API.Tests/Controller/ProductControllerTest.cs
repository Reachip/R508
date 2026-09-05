using API.Controller;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace API.Tests.Controller;

[TestClass]
[TestSubject(typeof(ProductController))]
public class ProductControllerTest
{
    private readonly ProductController _controller;

    [TestInitialize]
    public void Init()
    {
        
    }
    
    [TestMethod]
    public void ShouldCreateProduct()
    {
        // Given
        
        // When
        
        // Then
        Assert.AreEqual(1, 1);
    }
}