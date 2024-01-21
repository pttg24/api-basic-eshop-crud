using System.Net;
using System.Net.Mime;
using BasicEshopCrud.Api.Contracts.Requests;
using BasicEshopCrud.Api.Contracts.Responses;
using BasicEshopCrud.Api.Contracts.Responses.Custom;
using BasicEshopCrud.Domain;
using BasicEshopCrud.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicEshopCrud.Api.Controllers;

[Route("v{version:apiVersion}/orders")]
[ApiController]
[ApiVersion("1")]
public class OrdersController : ControllerBase
{
    private readonly IOrderRepository _orderRepository;

    public OrdersController(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    [HttpGet]
    [Route("{id}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult?> Get(long id)
    {
        //TO-DO
        //add validators
        //add mappers
        //use service
        try
        {
            var getOrderResponse = _orderRepository.GetOrderAsync(id).Result;
            var apiResponse = new OrderResponse(
                getOrderResponse.Id,
                getOrderResponse.CustomerId,
                getOrderResponse.ProductId,
                getOrderResponse.Status
                );
            return Ok(apiResponse);
        }
        catch (Exception ex)
        {
            //TO-DO
            //log exception
            return new StatusCodeResult((int)HttpStatusCode.NotFound);
        }
    }

    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult?> Post(OrderRequest request)
    {
        //TO-DO
        //add validators
        //add mappers
        //use service
        try
        {
            var insertOrderResponse = _orderRepository.InsertOrderAsync(request);
            var apiResponse = new CreatedOrderResponse(insertOrderResponse.Result);
            return Created("/orders", apiResponse);
        }
        catch (Exception ex)
        {
            //TO-DO
            //log exception
            return new StatusCodeResult((int)HttpStatusCode.UnprocessableEntity);
        }
    }

    [HttpPut]
    [Route("{id}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult?> Put(long id, OrderRequest request)
    {
        //TO-DO
        //add validators
        //add mappers
        //use service
        try
        {
            var updateOrderResponse = _orderRepository.UpdateOrderAsync(id, request);
            return NoContent();
        }
        catch (Exception ex)
        {
            //TO-DO
            //log exception
            return new StatusCodeResult((int)HttpStatusCode.BadRequest);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult?> Delete(long id)
    {
        //TO-DO
        //add validators
        //add mappers
        //use service
        try
        {
            var deleteOrderResponse = _orderRepository.DeleteOrderAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            //TO-DO
            //log exception
            return new StatusCodeResult((int)HttpStatusCode.NotFound);
        }
    }
}
