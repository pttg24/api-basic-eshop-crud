using BasicEshopCrud.Api.Contracts.Requests;

namespace BasicEshopCrud.Api.IntegrationTests.Models.Builders;

public class CustomerRequestBuilder
{
    private string _firstName;
    private string _lastName;
    private string _email;
    private string _phone;

    public CustomerRequestBuilder()
    {
        _firstName = "John";
        _lastName = "Doe";
        _email = "john.doe@basiceshopcrudapi.com";
        _phone = "999999999";   
    }

    public CustomerRequestBuilder WithFirstName(string firstName)
    {
        _firstName = firstName;
        return this;
    }

    public CustomerRequestBuilder WithLastName(string lastName)
    {
        _lastName = lastName;
        return this;
    }

    public CustomerRequestBuilder WithEmail(string email)
    {
        _email = email;
        return this;
    }

    public CustomerRequestBuilder WithPhone(string phone)
    {
        _phone = phone;
        return this;
    }

    public CustomerRequest Build()
    {
        return new CustomerRequest(
            _firstName,
            _lastName,
            _email,
            _phone);
    }
}
