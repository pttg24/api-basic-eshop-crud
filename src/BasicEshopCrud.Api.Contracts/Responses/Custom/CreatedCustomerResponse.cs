namespace BasicEshopCrud.Api.Contracts.Responses.Custom;

public class CreatedCustomerResponse
{
    public long CustomerId { get; }

    public CreatedCustomerResponse(long customerId)
    {
        CustomerId = customerId;
    }
}
