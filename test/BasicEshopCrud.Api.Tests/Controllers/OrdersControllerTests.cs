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

public class OrdersControllerTests
{
    [Fact]
    public async Task Get_OrderExists_ReturnsOk()
    {
        // Arrange
        long OrderId = 1;
        var mockRepository = new Mock<IOrderRepository>();
        mockRepository.Setup(repo => repo.GetOrderAsync(OrderId)).ReturnsAsync(new Order());
        var controller = new OrdersController(mockRepository.Object);

        // Act
        var result = await controller.Get(OrderId);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task Get_OrderNotFound_ReturnsNotFound()
    {
        // Arrange
        long OrderId = 1;
        var mockRepository = new Mock<IOrderRepository>();
        mockRepository.Setup(repo => repo.GetOrderAsync(OrderId)).ReturnsAsync((Order)null);
        var controller = new OrdersController(mockRepository.Object);

        // Act
        var result = await controller.Get(OrderId);

        // Assert
        Assert.IsType<StatusCodeResult>(result);
        Assert.Equal(StatusCodes.Status404NotFound, ((StatusCodeResult)result).StatusCode);
    }

    [Fact]
    public async Task Post_ValidOrder_ReturnsCreated()
    {
        // Arrange
        var request = new OrderRequest(1,1,"completed");
        var mockRepository = new Mock<IOrderRepository>();
        mockRepository.Setup(repo => repo.InsertOrderAsync(request)).ReturnsAsync(1);
        var controller = new OrdersController(mockRepository.Object);

        // Act
        var result = await controller.Post(request);

        // Assert
        Assert.IsType<CreatedResult>(result);
    }

    [Fact]
    public async Task Post_InvalidOrder_ReturnsUnprocessableEntity()
    {
        // Arrange
        var request = new OrderRequest(1, 1, "completed");
        var mockRepository = new Mock<IOrderRepository>();
        mockRepository.Setup(repo => repo.InsertOrderAsync(request)).Throws(new Exception("Validation failed"));
        var controller = new OrdersController(mockRepository.Object);

        // Act
        var result = await controller.Post(request);

        // Assert
        Assert.IsType<StatusCodeResult>(result);
        Assert.Equal(StatusCodes.Status422UnprocessableEntity, ((StatusCodeResult)result).StatusCode);
    }

    [Fact]
    public async Task Put_ValidOrder_ReturnsNoContent()
    {
        // Arrange
        long OrderId = 1;
        var request = new OrderRequest(1, 1, "completed");
        var mockRepository = new Mock<IOrderRepository>();
        mockRepository.Setup(repo => repo.UpdateOrderAsync(OrderId, request));
        var controller = new OrdersController(mockRepository.Object);

        // Act
        var result = await controller.Put(OrderId, request);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task Put_InvalidOrder_ReturnsBadRequest()
    {
        // Arrange
        long OrderId = 1;
        var request = new OrderRequest(1, 1, "completed");
        var mockRepository = new Mock<IOrderRepository>();
        mockRepository.Setup(repo => repo.UpdateOrderAsync(OrderId, request)).Throws(new Exception("Validation failed"));
        var controller = new OrdersController(mockRepository.Object);

        // Act
        var result = await controller.Put(OrderId, request);

        // Assert
        Assert.IsType<StatusCodeResult>(result);
        Assert.Equal(StatusCodes.Status400BadRequest, ((StatusCodeResult)result).StatusCode);
    }

    [Fact]
    public async Task Delete_OrderExists_ReturnsNoContent()
    {
        // Arrange
        long OrderId = 1;
        var mockRepository = new Mock<IOrderRepository>();
        mockRepository.Setup(repo => repo.DeleteOrderAsync(OrderId));
        var controller = new OrdersController(mockRepository.Object);

        // Act
        var result = await controller.Delete(OrderId);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task Delete_OrderNotFound_ReturnsNotFound()
    {
        // Arrange
        long OrderId = 1;
        var mockRepository = new Mock<IOrderRepository>();
        mockRepository.Setup(repo => repo.DeleteOrderAsync(OrderId)).Throws(new Exception("Order not found"));
        var controller = new OrdersController(mockRepository.Object);

        // Act
        var result = await controller.Delete(OrderId);

        // Assert
        Assert.IsType<StatusCodeResult>(result);
        Assert.Equal(StatusCodes.Status404NotFound, ((StatusCodeResult)result).StatusCode);
    }
}
