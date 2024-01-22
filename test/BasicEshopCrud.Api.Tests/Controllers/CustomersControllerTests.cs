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

public class CustomersControllerTests
{
    [Fact]
    public async Task Get_CustomerExists_ReturnsOk()
    {
        // Arrange
        long customerId = 1;
        var mockRepository = new Mock<ICustomerRepository>();
        mockRepository.Setup(repo => repo.GetCustomerAsync(customerId)).ReturnsAsync(new Customer());
        var controller = new CustomersController(mockRepository.Object);

        // Act
        var result = await controller.Get(customerId);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task Get_CustomerNotFound_ReturnsNotFound()
    {
        // Arrange
        long customerId = 1;
        var mockRepository = new Mock<ICustomerRepository>();
        mockRepository.Setup(repo => repo.GetCustomerAsync(customerId)).ReturnsAsync((Customer)null);
        var controller = new CustomersController(mockRepository.Object);

        // Act
        var result = await controller.Get(customerId);

        // Assert
        Assert.IsType<StatusCodeResult>(result);
        Assert.Equal(StatusCodes.Status404NotFound, ((StatusCodeResult)result).StatusCode);
    }

    [Fact]
    public async Task Post_ValidCustomer_ReturnsCreated()
    {
        // Arrange
        var request = new CustomerRequest("John", "Doe","999999","john.doe");
        var mockRepository = new Mock<ICustomerRepository>();
        mockRepository.Setup(repo => repo.InsertCustomerAsync(request)).ReturnsAsync(1);
        var controller = new CustomersController(mockRepository.Object);

        // Act
        var result = await controller.Post(request);

        // Assert
        Assert.IsType<CreatedResult>(result);
    }

    [Fact]
    public async Task Post_InvalidCustomer_ReturnsUnprocessableEntity()
    {
        // Arrange
        var request = new CustomerRequest("John", "Doe", "999999", "john.doe");
        var mockRepository = new Mock<ICustomerRepository>();
        mockRepository.Setup(repo => repo.InsertCustomerAsync(request)).Throws(new Exception("Validation failed"));
        var controller = new CustomersController(mockRepository.Object);

        // Act
        var result = await controller.Post(request);

        // Assert
        Assert.IsType<StatusCodeResult>(result);
        Assert.Equal(StatusCodes.Status422UnprocessableEntity, ((StatusCodeResult)result).StatusCode);
    }

    [Fact]
    public async Task Put_ValidCustomer_ReturnsNoContent()
    {
        // Arrange
        long customerId = 1;
        var request = new CustomerRequest("John", "Doe", "999999", "john.doe");
        var mockRepository = new Mock<ICustomerRepository>();
        mockRepository.Setup(repo => repo.UpdateCustomerAsync(customerId, request));
        var controller = new CustomersController(mockRepository.Object);

        // Act
        var result = await controller.Put(customerId, request);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task Put_InvalidCustomer_ReturnsBadRequest()
    {
        // Arrange
        long customerId = 1;
        var request = new CustomerRequest("John", "Doe", "999999", "john.doe");
        var mockRepository = new Mock<ICustomerRepository>();
        mockRepository.Setup(repo => repo.UpdateCustomerAsync(customerId, request)).Throws(new Exception("Validation failed"));
        var controller = new CustomersController(mockRepository.Object);

        // Act
        var result = await controller.Put(customerId, request);

        // Assert
        Assert.IsType<StatusCodeResult>(result);
        Assert.Equal(StatusCodes.Status400BadRequest, ((StatusCodeResult)result).StatusCode);
    }

    [Fact]
    public async Task Delete_CustomerExists_ReturnsNoContent()
    {
        // Arrange
        long customerId = 1;
        var mockRepository = new Mock<ICustomerRepository>();
        mockRepository.Setup(repo => repo.DeleteCustomerAsync(customerId));
        var controller = new CustomersController(mockRepository.Object);

        // Act
        var result = await controller.Delete(customerId);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task Delete_CustomerNotFound_ReturnsNotFound()
    {
        // Arrange
        long customerId = 1;
        var mockRepository = new Mock<ICustomerRepository>();
        mockRepository.Setup(repo => repo.DeleteCustomerAsync(customerId)).Throws(new Exception("Customer not found"));
        var controller = new CustomersController(mockRepository.Object);

        // Act
        var result = await controller.Delete(customerId);

        // Assert
        Assert.IsType<StatusCodeResult>(result);
        Assert.Equal(StatusCodes.Status404NotFound, ((StatusCodeResult)result).StatusCode);
    }
}
