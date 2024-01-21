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

[Route("v{version:apiVersion}/customers")]
[ApiController]
[ApiVersion("1")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;

    public CustomersController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
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
            var getCustomerResponse = _customerRepository.GetCustomerAsync(id).Result;
            var apiResponse = new CustomerResponse(
                getCustomerResponse.Id,
                getCustomerResponse.FirstName,
                getCustomerResponse.LastName,
                getCustomerResponse.Email,
                getCustomerResponse.Phone
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
    public async Task<IActionResult?> Post(CustomerRequest request)
    {
        //TO-DO
        //add validators
        //add mappers
        //use service
        try
        {
            var insertCustomerResponse = _customerRepository.InsertCustomerAsync(request);
            var apiResponse = new CreatedCustomerResponse(insertCustomerResponse.Result);
            return Created("/customers", apiResponse);
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
    public async Task<IActionResult?> Put(long id, CustomerRequest request)
    {
        //TO-DO
        //add validators
        //add mappers
        //use service
        try
        {
            var updateCustomerResponse = _customerRepository.UpdateCustomerAsync(id, request);
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
            var deleteCustomerResponse = _customerRepository.DeleteCustomerAsync(id);
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
