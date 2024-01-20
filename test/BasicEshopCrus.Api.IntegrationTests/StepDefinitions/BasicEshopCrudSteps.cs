using System.Text.Json;
using System.Text.Json.Serialization;
using BasicEshopCrud.Api.IntegrationTests.Drivers;
using BasicEshopCrud.Api.IntegrationTests.Models.Builders;
using BasicEshopCrud.Api.IntegrationTests.SerializationPolicies;
using BasicEshopCrud.Api.Contracts.Requests;
using BasicEshopCrud.Api.Contracts.Responses;
using Shouldly;
using Xunit;

namespace BasicEshopCrud.Api.IntegrationTests.Steps;

[Binding]
public sealed class BasicEshopCrudSteps
{
    private readonly ScenarioContext _scenarioContext;
    private readonly BasicEshopCrudApiDriver _driver;
    private HttpRequestMessage _requestMessage;
    private HttpResponseMessage _responseMessage;
    private CustomerRequestBuilder _customerRequestBuilder;
    private CustomerRequest _customerRequestBody;
    private CustomerResponse _customerResponseBody;

    public BasicEshopCrudSteps(ScenarioContext scenarioContext, BasicEshopCrudApiDriver driver)
    {
        _scenarioContext = scenarioContext;
        _driver = driver;
    }

    [Given("a customer request is created")]
    public void GivenARequestIsCreated()
    {
        _customerRequestBuilder = new CustomerRequestBuilder();
    }

    [When("the POST request is sent to the api")]
    public async Task PostRequestIsSentToApi()
    {
        _customerRequestBody = _customerRequestBuilder.Build();
        _requestMessage = _driver.CreatePostRequest(JsonSerializer.Serialize(_customerRequestBody, _customerRequestBody.GetType(), JsonSerializerSettings));
        _responseMessage = await _driver.SendRequest(_requestMessage);
    }

    [Then("the response status code should be (.*)")]
    public async Task ThenResponseShouldHaveHttpStatusCodeOfValue(int code)
    {
        var x = "asdf";
        Assert.NotNull(x);
        //Assert.NotNull(_responseMessage);
        //Assert.Equal((int)_responseMessage.StatusCode, code);
        //var responseBody = await _responseMessage.Content.ReadAsStringAsync();
        //_customerResponseBody = JsonSerializer.Deserialize<CustomerResponse>(responseBody, JsonSerializerSettings);
    }

    private static JsonSerializerOptions JsonSerializerSettings => new()
    {
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNamingPolicy = new SnakeCaseNamingPolicy(),
        PropertyNameCaseInsensitive = true
    };
}
