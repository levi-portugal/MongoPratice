using Moq;
using NUnit.Framework;
using ExempleTestMongo.Services;
using ExempleTestMongo.Data.Repositories;
using ExempleTestMongo.Entities;
using ExempleTestMongo.DTOs;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace ExempleTestMongo.Tests;

[TestFixture] //serve pro NUnit identificar como uma classe de testes.
public class ProductServiceTests
{
    private Mock<IRepository<Product>> _repositoryMock;
    private ProductService _productService;

    [SetUp]
    public void Setup()
    {
        // Arrange Global: Criamos o mock do repositório
        _repositoryMock = new Mock<IRepository<Product>>();

        // Injetamos o mock no serviço real
        _productService = new ProductService(_repositoryMock.Object);
    }

    [Test]
    public void GetAll_WhenProductsExist_ShouldReturnListOfDtos()
    {
        // Arrange
        var fakeProducts = new List<Product>
            {
                new Product { Id = "1", Name = "Teclado", Price = 100, Stock = 10 },
                new Product { Id = "2", Name = "Mouse", Price = 50, Stock = 5 }
            };

        // Configuramos o Mock para retornar a lista fake quando o método for chamado
        _repositoryMock.Setup(r => r.GetAll()).Returns(fakeProducts);

        // Act
        var result = _productService.GetAll();

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual("Teclado", result[0].Name);
        _repositoryMock.Verify(r => r.GetAll(), Times.Once); // Garante que o repo foi chamado
    }
}
