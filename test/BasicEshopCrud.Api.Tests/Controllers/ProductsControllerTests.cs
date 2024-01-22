using System;
using System.Threading.Tasks;
using BasicEshopCrud.Api.Controllers;
using BasicEshopCrud.Api.Contracts.Requests;
using BasicEshopCrud.Domain;
using BasicEshopCrud.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace BasicEshopCrud.Api.Tests.Controllers;

public class ProductsControllerTests
{
    [Fact]
    public async Task Get_ProductExists_ReturnsOk()
    {
        // Arrange
        long ProductId = 1;
        var mockRepository = new Mock<IProductRepository>();
        mockRepository.Setup(repo => repo.GetProductAsync(ProductId)).ReturnsAsync(new Product());
        var controller = new ProductsController(mockRepository.Object);

        // Act
        var result = await controller.Get(ProductId);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task Get_ProductNotFound_ReturnsNotFound()
    {
        // Arrange
        long ProductId = 1;
        var mockRepository = new Mock<IProductRepository>();
        mockRepository.Setup(repo => repo.GetProductAsync(ProductId)).ReturnsAsync((Product)null);
        var controller = new ProductsController(mockRepository.Object);

        // Act
        var result = await controller.Get(ProductId);

        // Assert
        Assert.IsType<StatusCodeResult>(result);
        Assert.Equal(StatusCodes.Status404NotFound, ((StatusCodeResult)result).StatusCode);
    }

    [Fact]
    public async Task Post_ValidProduct_ReturnsCreated()
    {
        // Arrange
        var request = new ProductRequest("product 1", "description", "sku123");
        var mockRepository = new Mock<IProductRepository>();
        mockRepository.Setup(repo => repo.InsertProductAsync(request)).ReturnsAsync(1);
        var controller = new ProductsController(mockRepository.Object);

        // Act
        var result = await controller.Post(request);

        // Assert
        Assert.IsType<CreatedResult>(result);
    }

    [Fact]
    public async Task Post_InvalidProduct_ReturnsUnprocessableEntity()
    {
        // Arrange
        var request = new ProductRequest("product 1", "description", "sku123");
        var mockRepository = new Mock<IProductRepository>();
        mockRepository.Setup(repo => repo.InsertProductAsync(request)).Throws(new Exception("Validation failed"));
        var controller = new ProductsController(mockRepository.Object);

        // Act
        var result = await controller.Post(request);

        // Assert
        Assert.IsType<StatusCodeResult>(result);
        Assert.Equal(StatusCodes.Status422UnprocessableEntity, ((StatusCodeResult)result).StatusCode);
    }

    [Fact]
    public async Task Put_ValidProduct_ReturnsNoContent()
    {
        // Arrange
        long ProductId = 1;
        var request = new ProductRequest("product 1", "description", "sku123");
        var mockRepository = new Mock<IProductRepository>();
        mockRepository.Setup(repo => repo.UpdateProductAsync(ProductId, request));
        var controller = new ProductsController(mockRepository.Object);

        // Act
        var result = await controller.Put(ProductId, request);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task Put_InvalidProduct_ReturnsBadRequest()
    {
        // Arrange
        long ProductId = 1;
        var request = new ProductRequest("product 1", "description", "sku123");
        var mockRepository = new Mock<IProductRepository>();
        mockRepository.Setup(repo => repo.UpdateProductAsync(ProductId, request)).Throws(new Exception("Validation failed"));
        var controller = new ProductsController(mockRepository.Object);

        // Act
        var result = await controller.Put(ProductId, request);

        // Assert
        Assert.IsType<StatusCodeResult>(result);
        Assert.Equal(StatusCodes.Status400BadRequest, ((StatusCodeResult)result).StatusCode);
    }

    [Fact]
    public async Task Delete_ProductExists_ReturnsNoContent()
    {
        // Arrange
        long ProductId = 1;
        var mockRepository = new Mock<IProductRepository>();
        mockRepository.Setup(repo => repo.DeleteProductAsync(ProductId));
        var controller = new ProductsController(mockRepository.Object);

        // Act
        var result = await controller.Delete(ProductId);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task Delete_ProductNotFound_ReturnsNotFound()
    {
        // Arrange
        long ProductId = 1;
        var mockRepository = new Mock<IProductRepository>();
        mockRepository.Setup(repo => repo.DeleteProductAsync(ProductId)).Throws(new Exception("Product not found"));
        var controller = new ProductsController(mockRepository.Object);

        // Act
        var result = await controller.Delete(ProductId);

        // Assert
        Assert.IsType<StatusCodeResult>(result);
        Assert.Equal(StatusCodes.Status404NotFound, ((StatusCodeResult)result).StatusCode);
    }
}
