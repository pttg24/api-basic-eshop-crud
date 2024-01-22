using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BasicEshopCrud.Api.Contracts.Requests;
using BasicEshopCrud.Api.Contracts.Responses;
using BasicEshopCrud.Api.IntegrationTests.Drivers;
using BasicEshopCrud.Api.IntegrationTests.Models.Builders;
using BasicEshopCrud.Api.IntegrationTests.SerializationPolicies;
using BasicEshopCrud.Domain;
using BasicEshopCrud.Infrastructure.DataModels;
using FluentAssertions;
using TechTalk.SpecFlow;
using Xunit;

namespace BasicEshopCrud.Api.IntegrationTests.Steps;

[Binding]
public class BasicEshopManagementSteps
{
    private readonly ScenarioContext _scenarioContext;
    private readonly BasicEshopCrudApiDriver _driver;
    private HttpRequestMessage _requestMessage;
    private HttpResponseMessage _responseMessage;
    private CustomerRequestBuilder _requestBodyBuilder;
    private CustomerRequest _requestBody;
    private CustomerResponse _responseBody;

    public BasicEshopManagementSteps(ScenarioContext scenarioContext, BasicEshopCrudApiDriver driver)
    {
        _scenarioContext = scenarioContext;
        _driver = driver;
    }

    [Given("a customer request is created")]
    public void GivenACustomerRequestIsCreated()
    {
        _requestBodyBuilder = new CustomerRequestBuilder();
    }

    [When("the POST request is sent to the api")]
    public async Task WhenThePOSTRequestIsSentToTheApi()
    {
        _requestBody = _requestBodyBuilder.Build();
        _requestMessage = _driver.CreateCustomerPostRequest(JsonSerializer.Serialize(_requestBody, _requestBody.GetType(), JsonSerializerSettings));
        _responseMessage = await _driver.SendRequest(_requestMessage);
    }

    [Then("the response status code should be (.*)")]
    public void ThenTheResponseStatusCodeShouldBe(int expectedStatusCode)
    {
        _responseMessage.StatusCode.Should().Be((HttpStatusCode)expectedStatusCode);
    }

    [When("the GET request is sent to the api with the created customer details")]
    public async Task WhenTheGETRequestIsSentToTheApiWithTheCreatedCustomerDetails()
    {
        var responseBody = await _responseMessage.Content.ReadAsStringAsync();
        _responseBody = JsonSerializer.Deserialize<CustomerResponse>(responseBody, JsonSerializerSettings);
        _responseBody.Should().NotBeNull();
        _responseMessage = await _driver.GetCustomerRequest(_responseBody.CustomerId);
        var getResponseBody = await _responseMessage.Content.ReadAsStringAsync();
        _responseBody = JsonSerializer.Deserialize<CustomerResponse>(getResponseBody, JsonSerializerSettings);
    }

    [Then("the GET response should contain a created customer fully populated")]
    public async Task AndTheResponseShouldContainACreatedCustomerFullyPopulated()
    {
        _responseBody.Should().NotBeNull();
        _responseBody.FirstName.Should().Be(_requestBody.FirstName);
        _responseBody.LastName.Should().Be(_requestBody.LastName);
    }

    private static JsonSerializerOptions JsonSerializerSettings => new()
    {
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNamingPolicy = new SnakeCaseNamingPolicy(),
        PropertyNameCaseInsensitive = true
    };
}
